using Ash.Portfolio.Web.Infrastructure.Data.Portfolio;

namespace Ash.Portfolio.Web.Infrastructure.Repositories;

public interface IPortfolioRepository
{
    IEnumerable<Project> GetProjects();
}
