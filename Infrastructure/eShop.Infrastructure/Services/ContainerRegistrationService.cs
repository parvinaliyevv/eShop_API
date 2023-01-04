namespace eShop.Infrastructure.Services;

public static class ContainerRegistrationService
{
    public static void InfrastructureRegister(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BlobStorageOptions>(configuration.GetSection("BlobStorage"));
        services.Configure<JsonWebTokenOptions>(configuration.GetSection("JsonWebToken"));

        services.AddScoped<IStorageManager, BlobStorageManager>();

        services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
        services.AddSingleton<IPasswordEncryptorService, Sha256PasswordEncryptorService>();
    }
}
