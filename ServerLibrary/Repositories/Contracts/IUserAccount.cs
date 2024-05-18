﻿using BaseLibrary.DTOs;
using BaseLibrary.Models;
using BaseLibrary.Responses;

namespace ServerLibrary.Repositories.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAsync(Register user);

        Task<LoginResponse> SignInAsync(Login user);

        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);

        Task<List<ManageUser>> GetUsers();

        Task<List<SystemRole>> GetRoles();

        Task<GeneralResponse> UpdateUser(ManageUser user);

        Task<GeneralResponse> DeleteUser(int id);
    }
}