using Ash.Portfolio.Web.Framework.Database.Connection;
using Microsoft.Data.SqlClient;

namespace Ash.Portfolio.Web.Framework.Database.Factory;

public class DatabaseFactory : IDatabaseFactory
{
    private readonly List<SqlConnection> _sqlConnections;

    public DatabaseFactory(List<IConnection> connections)
    {
        _sqlConnections = new List<SqlConnection>();
        connections.ForEach(c =>
        {
            _sqlConnections.Add(c.CreateConnection());
        });
    }

    public DatabaseFactory(IConnection connection)
    {
        _sqlConnections = new List<SqlConnection> { connection.CreateConnection() };
    }

    public IDatabase GetDatabase(string database)
    {
        var dbConnection = _sqlConnections.SingleOrDefault(s => s.Database == database);

        if (dbConnection == null)
        {
            throw new Exception($"{database} not found");
        }

        var db = new Database(dbConnection);
        return db;

    }
}
