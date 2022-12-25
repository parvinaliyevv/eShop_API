﻿namespace eShop.Application.Services;

public interface IUserManager
{
    bool CreateUser(User user, string password);
    Task<bool> CreateUserAsync(User user, string password);

    User? FindUserByEmail(string email);
    Task<User?> FindUserByEmailAsync(string email);

    bool CheckPassword(User user, string password);
    Task<bool> CheckPasswordAsync(User user, string password);

    bool Exists(string email);
    Task<bool> ExistsAsync(string email);
}
