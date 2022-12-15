namespace eShop.Persistence.Services;

internal static class ConfigurationService
{
    public static string? GetConnectionString(string key)
    {
        var configurationManager = new ConfigurationManager();

        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/eShop.API"));
        configurationManager.AddJsonFile("appsettings.json");

        return configurationManager.GetConnectionString(key);
    }
}
