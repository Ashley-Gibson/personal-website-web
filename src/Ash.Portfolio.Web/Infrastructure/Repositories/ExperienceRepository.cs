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

    private async Task<IEnumerable<Role>> GetRolesAsync()
    {
        var p = new DynamicParameters();

        return await _database.QueryAsync<Role>("[Experience].[uspGetRoles]", p);
    }

    private async Task<IEnumerable<RoleDescription>> GetRoleDescriptionsAsync()
    {
        var p = new DynamicParameters();

        return await _database.QueryAsync<RoleDescription>("[Experience].[uspGetRoleDescriptions]", p);
    }

    public async Task<IEnumerable<Role>> GetRolesWithDescriptionsAsync()
    {
        var roles = await GetRolesAsync();
        var roleDescriptions = await GetRoleDescriptionsAsync();

        roles
            .ToList()
            .ForEach(d =>
            {
                d.DescriptionRows = roleDescriptions.Where(r => r.ParentId == d.Id).ToList();
            });

        return roles;
    }
}
