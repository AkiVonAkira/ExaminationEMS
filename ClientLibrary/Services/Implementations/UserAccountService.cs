using BaseLibrary.DTOs;
using BaseLibrary.Responses;
using ClientLibrary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Services.Implementations
{
    public class UserAccountService : IUserAccountService   
    {
        public Task<GeneralResponse> CreateAsync(Register user)
        {
            // för att skapa en ny användare 
            throw new NotImplementedException();
        }

        public Task<LoginResponse> SignInAsync(Login user)
        {
            //för att logga in en användare 
            throw new NotImplementedException();
        }

        public Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
        {
            //för att uppdatera autentiserings-token
            throw new NotImplementedException();
        }

        public Task<WeatherForecast[]> GetWeatherForecast()
        {
            // för att hämta väderprognoser (testing purposes)
            throw new NotImplementedException();
        }

    }
}
