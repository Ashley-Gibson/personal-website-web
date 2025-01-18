namespace Ash.Portfolio.Web.Framework.Database.Configuration;

public class DatabaseEnvironmentVariablesConfiguration : IConfiguration
{
    private readonly string _serverEnvironmentVariable;
    private readonly string _databaseEnvironmentVariable;

    public DatabaseEnvironmentVariablesConfiguration(string serverEnvironmentVariable, string databaseEnvironmentVariable)
    {
        _serverEnvironmentVariable = serverEnvironmentVariable;
        _databaseEnvironmentVariable = databaseEnvironmentVariable;
    }

    public Configuration GetConfiguration()
    {
        var serverEnvironmentVariable = Environment.GetEnvironmentVariable(_serverEnvironmentVariable);

        if (string.IsNullOrEmpty(serverEnvironmentVariable))
            throw new Exception(_serverEnvironmentVariable);

        var databaseEnvironmentVariable = Environment.GetEnvironmentVariable(_databaseEnvironmentVariable);

        if (string.IsNullOrEmpty(databaseEnvironmentVariable))
            throw new Exception(_databaseEnvironmentVariable);

        return new Configuration(serverEnvironmentVariable, databaseEnvironmentVariable);
    }
}
