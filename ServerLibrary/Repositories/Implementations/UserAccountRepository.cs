using BaseLibrary.DTOs;
using BaseLibrary.Models;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServerLibrary.Data;
using ServerLibrary.Helpers;
using ServerLibrary.Repositories.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ServerLibrary.Repositories.Implementations
{
    public class UserAccountRepository(IOptions<JwtSection> config, ApplicationDbContext applicationDbContext) : IUserAccount
    {
        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            if (user is null) return new GeneralResponse(false, "Response is empty");

            var checkUser = await FindUserByEmail(user.Email!);
            if (checkUser != null) return new GeneralResponse(true, "User registered already");

            // Save User
            var applicationUser = await AddToDatabase(new ApplicationUser()
            {
                Fullname = user.Fullname,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            });

            // check, create and assign role
            var checkAdminRole = await applicationDbContext.SystemRoles.FirstOrDefaultAsync(_ => _.Name!.Equals(Constants.Admin));
            if (checkAdminRole is null)
            {
                var createAdminRole = await AddToDatabase(new SystemRole() { Name = Constants.Admin });
                await AddToDatabase(new UserRole() { RoleId = createAdminRole.Id, UserId = applicationUser.Id });
                return new GeneralResponse(true, "Account Created!");
            }

            // check, create and assign user
            var checkUserRole = await applicationDbContext.SystemRoles.FirstOrDefaultAsync(_ => _.Name!.Equals(Constants.User));
            SystemRole response = new();
            if (checkUserRole is null)
            {
                response = await AddToDatabase(new SystemRole() { Name = Constants.User });
                await AddToDatabase(new UserRole() { RoleId = response.Id, UserId = applicationUser.Id });
            }
            else
            {
                await AddToDatabase(new UserRole() { RoleId = checkUserRole.Id, UserId = applicationUser.Id });
            }

            return new GeneralResponse(true, "Account Created!");
        }

        public async Task<LoginResponse> SignInAsync(Login user)
        {
            if (user is null) return new LoginResponse(false, "Model is empty");

            var applicationUser = await FindUserByEmail(user.Email!);
            if (applicationUser is null) return new LoginResponse(false, "User not found");

            // Verify Password
            if (!BCrypt.Net.BCrypt.Verify(user.Password, applicationUser.Password))
                return new LoginResponse(false, "Invalid Email/Password");

            var getUserRole = await FindUserRole(applicationUser.Id);
            if (getUserRole is null) return new LoginResponse(false, "User Role not found");

            var getRoleName = await FindRoleName(getUserRole.RoleId);
            if (getRoleName is null) return new LoginResponse(false, "Role not found");

            string jwtToken = GenerateToken(applicationUser, getRoleName!.Name!);
            string refreshToken = GenerateRefreshToken();

            // save the refresh token to the database
            var findUser = await applicationDbContext.RefreshTokenInfos.FirstOrDefaultAsync(_ => _.UserId == applicationUser.Id);
            if (findUser is not null)
            {
                findUser!.Token = refreshToken;
                await applicationDbContext.SaveChangesAsync();
            }
            else
            {
                await AddToDatabase(new RefreshTokenInfo() { Token = refreshToken, UserId = applicationUser.Id });
            }

            return new LoginResponse(true, "Login successfully", jwtToken, refreshToken);
        }

        private string GenerateToken(ApplicationUser user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Value.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Fullname!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: config.Value.Issuer,
                audience: config.Value.Audience,
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<UserRole> FindUserRole(int userId) =>
            await applicationDbContext.UserRoles.FirstOrDefaultAsync(_ => _.UserId == userId);

        private async Task<SystemRole> FindRoleName(int roleId) =>
            await applicationDbContext.SystemRoles.FirstOrDefaultAsync(_ => _.Id == roleId);

        public static string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        private async Task<ApplicationUser> FindUserByEmail(string email) =>
            await applicationDbContext.ApplicationUsers.FirstOrDefaultAsync(_ => _.Email!.ToLower()!.Equals(email!.ToLower()));

        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = applicationDbContext.Add(model!);
            await applicationDbContext.SaveChangesAsync();
            return (T)result.Entity;
        }

        public async Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
        {
            if (token is null) return new LoginResponse(false, "Token is empty");

            var findToken = await applicationDbContext.RefreshTokenInfos.FirstOrDefaultAsync(_ => _.Token!.Equals(token.Token));
            if (findToken is null) return new LoginResponse(false, "Refresh token is required");

            // get user details
            var user = await applicationDbContext.ApplicationUsers.FirstOrDefaultAsync(_ => _.Id == findToken.UserId);
            if (user is null) return new LoginResponse(false, "Refresh token could not be generated because user was not found.");

            // if none of the above was null continue and get the info for the refresh token
            var userRole = await FindUserRole(user.Id);
            var roleName = await FindRoleName(userRole.RoleId);
            string jwtToken = GenerateToken(user, roleName.Name!);
            string refreshToken = GenerateRefreshToken();

            var updateRefreshToken = await applicationDbContext.RefreshTokenInfos.FirstOrDefaultAsync(_ => _.UserId == user.Id);
            if (updateRefreshToken is null) return new LoginResponse(false, "Refresh token could not be generated because user has not signed in");

            updateRefreshToken.Token = refreshToken;
            await applicationDbContext.SaveChangesAsync();
            return new LoginResponse(true, "Token refreshed Successfully.", jwtToken, refreshToken);
        }

        public async Task<List<ManageUser>> GetUsers()
        {
            var allUsers = await GetApplicationUsers();
            var allUserRoles = await UserRoles();
            var allRoles = await SystemRoles();

            if (allUsers.Count == 0 || allRoles.Count == 0) return null!;

            var users = new List<ManageUser>();
            foreach (var user in allUsers)
            {
                var userRole = allUserRoles.FirstOrDefault(u => u.UserId == user.Id);
                var roleName = allRoles.FirstOrDefault(r => r.Id == userRole!.RoleId);
                users.Add(new ManageUser() { UserId = user.Id, Name = user.Fullname!, Email = user.Email, Role = roleName!.Name! });
            }
            return users;
        }

        public async Task<GeneralResponse> UpdateUser(ManageUser user)
        {
            var getRole = (await SystemRoles()).FirstOrDefault(r => r.Name!.Equals(user.Role));
            var userRole = await applicationDbContext.UserRoles.FirstOrDefaultAsync(u => u.UserId == user.UserId);
            userRole!.RoleId = getRole!.Id;
            await applicationDbContext.SaveChangesAsync();
            return new GeneralResponse(true, "User Role Updated Successfully");
        }

        public async Task<List<SystemRole>> GetRoles() => await SystemRoles();

        public async Task<GeneralResponse> DeleteUser(int id)
        {
            var user = await applicationDbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == id);
            applicationDbContext.ApplicationUsers.Remove(user!);
            await applicationDbContext.SaveChangesAsync();
            return new GeneralResponse(true, "User Deleted Successfully");
        }

        private async Task<List<SystemRole>> SystemRoles() => await applicationDbContext.SystemRoles.AsNoTracking().ToListAsync();

        private async Task<List<UserRole>> UserRoles() => await applicationDbContext.UserRoles.AsNoTracking().ToListAsync();

        private async Task<List<ApplicationUser>> GetApplicationUsers() => await applicationDbContext.ApplicationUsers.AsNoTracking().ToListAsync();
    }
}