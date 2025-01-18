using Ash.Portfolio.Web.Framework.Database;
using Ash.Portfolio.Web.Framework.Database.Constants;
using Ash.Portfolio.Web.Framework.Database.Factory;
using Ash.Portfolio.Web.Infrastructure.Data.Experience;
using Dapper;

namespace Ash.Portfolio.Web.Infrastructure.Repositories;

public class ExperienceRepository : IExperienceRepository
{
    private readonly IDatabase _database;

    public ExperienceRepository(IDatabaseFactory databaseFactory)
    {
        _database = databaseFactory.GetDatabase(DatabaseName.Ash_Portfolio_Database);
    }

    public IEnumerable<Role> GetRolesWithDescription()
    {
        var p = new DynamicParameters();

        return _database.Query<Role>("[Experience].[uspGetRolesWithDescription]", p);
    }
}
