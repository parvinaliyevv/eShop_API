namespace eShop.Application.Services;

public interface IPasswordEncryptorService
{
    string Encrypt(string password);

    Task<string> EncryptAsync(string password);
}
