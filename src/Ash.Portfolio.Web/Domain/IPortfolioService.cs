using Ash.Portfolio.Web.Infrastructure.Data.Portfolio;

namespace Ash.Portfolio.Web.Domain;

public interface IPortfolioService
{
    IEnumerable<Project> FilterProjectsByType(IEnumerable<Project> projects, ProjectType projectType);
}
