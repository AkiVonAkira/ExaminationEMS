using BaseLibrary.DTOs;
using BaseLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Services.Contracts
{
    public interface IUserAccountService
    {
        // Metod för att skapa en ny användare
        Task<GeneralResponse> CreateAsync(Register user);

        // Metod för att logga in en användare
        Task<LoginResponse> SignInAsync(Login user);

        // Metod för att uppdatera användarens åtkomsttoken
        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);

        // Metod för att hämta väderprognos (testing purposes)
        Task<WeatherForecast[]> GetWeatherForecast();
    }

}
