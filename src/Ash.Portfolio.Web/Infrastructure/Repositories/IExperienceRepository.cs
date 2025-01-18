using Ash.Portfolio.Web.Infrastructure.Data.Experience;

namespace Ash.Portfolio.Web.Infrastructure.Repositories;

public interface IExperienceRepository
{
    IEnumerable<Role> GetRolesWithDescription();
}
