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

    public static void LoggerRegister(this ILoggingBuilder logging, IConfiguration configuration)
    {
        logging.ClearProviders();

        var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

        logging.AddSerilog(logger);
    }
}
