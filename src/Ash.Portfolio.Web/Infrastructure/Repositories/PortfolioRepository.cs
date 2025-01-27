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

    public async Task<IEnumerable<Project>> GetProjectsAsync()
    {
        var p = new DynamicParameters();

        return await _database.QueryAsync<Project>("[Portfolio].[uspGetProjects]", p);
    }
}
