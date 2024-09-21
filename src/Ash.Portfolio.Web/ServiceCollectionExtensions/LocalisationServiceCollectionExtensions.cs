using Ash.Portfolio.Web.Resources;
using Microsoft.AspNetCore.Localization;

namespace Ash.Portfolio.Web.ServiceCollectionExtensions;

public static class LocalisationServiceCollectionExtensions
{
    public static IServiceCollection AddLocalisation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IResourceSourceService, SharedResourcesSourceService>();

        var sectionKey = "Localisation";
        var localisationOptions = configuration.GetSection(sectionKey).Get<LocalisationOptions>();

        if (localisationOptions != null)
        {
            services.AddRequestLocalization(requestLocalizationOptions =>
            {
                if (!string.IsNullOrWhiteSpace(localisationOptions.DefaultCulture))
                    requestLocalizationOptions.DefaultRequestCulture = new RequestCulture(localisationOptions.DefaultCulture);

                var supportedCultures = localisationOptions.SupportedCultures;

                if (supportedCultures is not null)
                {
                    requestLocalizationOptions.AddSupportedCultures(supportedCultures);
                    requestLocalizationOptions.AddSupportedUICultures(supportedCultures);
                }
            });

            services.AddLocalization(s => s.ResourcesPath = "Resources");
        }

        services.AddScoped<ILocalisationService, LocalisationService>();
        return services;
    }
}

public class LocalisationOptions
{
    public string? DefaultCulture { get; set; }
    public string[]? SupportedCultures { get; set; }
}
