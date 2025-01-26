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

    private IEnumerable<Role> GetRoles()
    {
        var p = new DynamicParameters();

        return _database.Query<Role>("[Experience].[uspGetRoles]", p);
    }

    private IEnumerable<RoleDescription> GetRoleDescriptions()
    {
        var p = new DynamicParameters();

        return _database.Query<RoleDescription>("[Experience].[uspGetRoleDescriptions]", p);
    }

    public IEnumerable<Role> GetRolesWithDescriptions()
    {
        var roles = GetRoles();
        var roleDescriptions = GetRoleDescriptions();

        roles
            .ToList()
            .ForEach(d =>
            {
                d.DescriptionRows = roleDescriptions.Where(r => r.ParentId == d.Id).ToList();
            });

        return roles;
    }
}
