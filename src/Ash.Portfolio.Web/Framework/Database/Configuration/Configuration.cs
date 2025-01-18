namespace Ash.Portfolio.Web.Framework.Database.Configuration;

public class Configuration
{
    public Configuration(string server, string database)
    {
        Server = server;
        Database = database;
    }

    public string Server { get; }

    public string Database { get; }
}
