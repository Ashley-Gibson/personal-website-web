using Ash.Portfolio.Web.Infrastructure.Data.Portfolio;
namespace Ash.Portfolio.Web.Domain.Portfolio;

public class PortfolioService : IPortfolioService
{
    public IEnumerable<Project> FilterProjectsByType(IEnumerable<Project> projects, ProjectType projectType)
    {
        if (projects is null)
            return [];

        return projects.Where(p => p.Status == projectType.ToString());
    }
}
