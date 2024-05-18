using BaseLibrary.DTOs;
using BaseLibrary.Models;
using BaseLibrary.Responses;

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

        Task<List<ManageUser>> GetUsers();
        Task<GeneralResponse> UpdateUser(ManageUser user);
        Task<List<SystemRole>> GetRoles();
        Task<GeneralResponse> DeleteUser(int id);
    }
}