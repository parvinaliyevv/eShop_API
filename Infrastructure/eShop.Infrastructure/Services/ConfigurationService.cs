namespace eShop.Infrastructure.Services;

internal static class ConfigurationService
{
    private static readonly ConfigurationManager _configurationManager;


    static ConfigurationService()
    {
        _configurationManager = new ConfigurationManager();

        Init();
    }


    private static void Init()
    {
        _configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/eShop.API"));
        _configurationManager.AddJsonFile("appsettings.json");
    }

    public static string GetValue(string path) => _configurationManager[path];
}
