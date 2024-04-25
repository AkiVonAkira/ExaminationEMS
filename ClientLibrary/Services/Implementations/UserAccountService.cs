using BaseLibrary.DTOs;
using BaseLibrary.Responses;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using System.Net.Http.Json;

namespace ClientLibrary.Services.Implementations
{
    public class UserAccountService(GetHttpClient getHttpClient) : IUserAccountService
    {
        public const string AuthUrl = "api/authentication";
        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            // för att skapa en ny användare
            var httpClient = getHttpClient.GetPublicHttpClient();
            var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/register", user);
            if (!result.IsSuccessStatusCode) return new GeneralResponse(false, " Error occured");

            return await result.Content.ReadFromJsonAsync<GeneralResponse>()!;
        }

        public Task<LoginResponse> SignInAsync(Login user)
        {
            //för att logga in en användare
            var httpClient = getHttpClient.GetPublicHttpClient();
            var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/login", user);
            if (!result.IsSuccessStatusCode) return new LoginResponse(false, " Error occured");

            return await result.Content.ReadFromJsonAsync<LoginResponse>()!;
        }

        public Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
        {
            //för att uppdatera autentiserings-token
            throw new NotImplementedException();
        }
    }
}