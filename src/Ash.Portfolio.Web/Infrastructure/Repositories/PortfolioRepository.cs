using Ash.Portfolio.Web.Framework.Database;
using Ash.Portfolio.Web.Framework.Database.Constants;
using Ash.Portfolio.Web.Framework.Database.Factory;
using Ash.Portfolio.Web.Infrastructure.Data.Portfolio;
using Dapper;

namespace Ash.Portfolio.Web.Infrastructure.Repositories;

public class PortfolioRepository : IPortfolioRepository
{
    private readonly IDatabase _database;

    public PortfolioRepository(IDatabaseFactory databaseFactory)
    {
        _database = databaseFactory.GetDatabase(DatabaseName.Ash_Portfolio_Database);
    }

    public IEnumerable<Project> GetRolesWithDescription()
    {
        var p = new DynamicParameters();

        return _database.Query<Project>("[Portfolio].[uspGetProjects]", p);
    }
}
