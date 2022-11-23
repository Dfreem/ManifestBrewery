
namespace ManifestBreweryClasses;

public static class ConfigDB
{
    public static string GetMySqlConnectionString()
    {
        string folder = System.AppContext.BaseDirectory;
        var builder = new ConfigurationBuilder()
                .SetBasePath(folder)
                .AddJsonFile("mySqlSettings.json", optional: true, reloadOnChange: true);

        string connectionString = builder.Build().GetConnectionString("mySql");
        Console.WriteLine(connectionString);
        return connectionString;
    }
}