using Microsoft.Extensions.Localization;

namespace Ash.Portfolio.Web.Resources;

public class LocalisationService : ILocalisationService
{
    private readonly IStringLocalizer _localizer;

    public LocalisationService(
                            IStringLocalizerFactory factory,
                            IResourceSourceService resourceType)
    {
        _localizer = factory.Create(resourceType.ResourceSource);
    }

    public LocalizedString GetString(string key)
    {
        return GetLocalizedHtmlString(key);
    }

    public LocalizedString GetLocalizedHtmlString(string key)
    {
        var localizedString = _localizer[key];

        // If no resource found use the key as the value
        if (localizedString.ResourceNotFound)
            return new LocalizedString(key, key);

        return localizedString;
    }
}
