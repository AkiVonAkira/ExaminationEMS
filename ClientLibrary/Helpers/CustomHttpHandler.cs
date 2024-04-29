

namespace ClientLibrary.Helpers
{
    public class CustomHttpHandler(GetHttpClient getHttpClient, LocalStorageService localStorageService,IUserAccountService accountService) : DelegatingHandler 
    {
        protected async override Task<HttpResponseMessage>SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool loginUrl = request.RequestUri!.AbsoluteUri.Contains("login");
            bool registerUrl = request.RequestUri!.AbsoluteUri.Contains("register");
            bool refreshTokenUrl = request.RequestUri!.AbsoluteUri.Contains("refresh-token");

            if(loginUrl|| registerUrl || refreshTokenUrl)
                return await base.SendAsync(request, cancellationToken);

            var result = await base.SendAsync(request, cancellationToken);
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                //Get token from localStorage
                var stringToken = await localStorageService.GetToken();
                if (stringToken != null) return result;
                 
                //Check if the header contains token
                string token = string .Empty;
                try { token = request.Headers.Authorization!.Parameter!; }
                catch { }

                var deserializedToken = Serializations.DeserializeJsonString<UserSession>(stringToken);
                if (deserializedToken is null) return result;
                if(string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthorizationHeaderValue("Bearer", deserializedToken.Token);
                    return await base.SendAsync(request, cancellationToken);
                }
                // call for refresh token
                var newJwtToken = await GetReshToken(deserializedToken.RefreshToken!);
                if(string.IsNullOrEmpty(newJwtToken)) return result;

                request.Headers.Authorization = new System.Net.Http.Headers.AuthorizationHeaderValue("Bearer", newJwtToken.Token);
                return await base.SendAsync(request, cancellationToken);
            }
            return result;

        }
        private async Task<string> GetRefreshToken(string refreshToken)
        {
            var result = await accountService.GetRefreshTokenAsync(new RefreshToken() { Token = refreshToken});
            string serializedToken = Serializations.SerializeObj(new UserSession() { Token = result.Token, refreshToken = result.RefreshToken });
            await localStorageService.SetToken(serializedToken);
            return result.Token;

        }
    }
}