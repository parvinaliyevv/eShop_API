namespace eShop.Infrastructure.Services;

public static class ContainerRegistrationService
{
    public static void InfrastructureRegister(this IServiceCollection services)
    {
        services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
        services.AddSingleton<IPasswordEncryptorService, Sha256PasswordEncryptorService>();
    }
}
