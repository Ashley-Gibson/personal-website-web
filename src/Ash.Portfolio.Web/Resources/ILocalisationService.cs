using Microsoft.Extensions.Localization;

namespace Ash.Portfolio.Web.Resources;

public interface ILocalisationService
{
    LocalizedString GetString(string key);

    LocalizedString GetLocalizedHtmlString(string key);
}
