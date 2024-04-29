using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ClientLibrary.Helpers
{
    // Custom Authentication State Provider
    public class CustomAuthenticationStateProvider(LocalDataStrorage localDataStrorage) : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal anonymous = new(new ClaimsIdentity());

        // Get the authentication state asynchronously
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var stringToken = await localDataStrorage.GetToken();

            if (string.IsNullOrEmpty(stringToken))
                return await Task.FromResult(new AuthenticationState(anonymous));

            // Deserialize token
            var deserializeToken = Serializations.DeserializeJson<UserSession>(stringToken);
            if (deserializeToken is null)
                return await Task.FromResult(new AuthenticationState(anonymous));

            // Decrypt token
            var getUserClaims = DecryptToken(deserializeToken.Token!);
            if (getUserClaims is null)
                return await Task.FromResult(new AuthenticationState(anonymous));

            // Set claims principal
            var claimsPrincipal = SetClaimPrincipal(getUserClaims);
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        // Task to update the authentication state
        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            var claimsPrincipal = new ClaimsPrincipal();
            if (userSession.Token != null || userSession.RefreshToken != null)
            {
                var serializeSession = Serializations.SerializeObject(userSession);
                await localDataStrorage.SetToken(serializeSession);
                var getUserClaims = DecryptToken(userSession.Token!);
                claimsPrincipal = SetClaimPrincipal(getUserClaims);
            }
            else
            {
                await localDataStrorage.RemoveToken();
            }

            // Notify about authentication state change
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        // Set claims principal based on user claims
        public static ClaimsPrincipal SetClaimPrincipal(CustomUserClaims claims)
        {
            if (claims.Email is null)
                return new ClaimsPrincipal();

            // Create claims principal with user claims
            return new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, claims.Id!),
                new(ClaimTypes.Name, claims.Name!),
                new(ClaimTypes.Email, claims.Email!),
                new(ClaimTypes.Role, claims.Role!),
            }, "JwtAuth"));
        }

        // Decrypt JWT token and extract user claims
        private static CustomUserClaims DecryptToken(string jwtToken)
        {
            if (string.IsNullOrEmpty(jwtToken))
                return new CustomUserClaims();

            // Create JWT token handler
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            // Extract user claims from token
            var userId = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier);
            var name = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Name);
            var email = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Email);
            var role = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Role);

            // Create custom user claims object
            return new CustomUserClaims(userId!.Value, name!.Value, email!.Value, role!.Value);
        }
    }
}
