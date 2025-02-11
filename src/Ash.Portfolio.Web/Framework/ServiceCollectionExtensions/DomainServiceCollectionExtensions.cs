using Ash.Portfolio.Web.Domain.Portfolio;

namespace Ash.Portfolio.Web.Framework.ServiceCollectionExtensions;

public static class DomainServiceCollectionExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddTransient<IPortfolioService, PortfolioService>();

        return services;
    }
}
