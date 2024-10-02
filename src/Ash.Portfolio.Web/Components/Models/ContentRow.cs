namespace Ash.Portfolio.Web.Components.Models;

public class ContentRow
{
    public string LocalisedPrimaryTitle { get; set; } = string.Empty;

    public string LocalisedSecondaryTitle { get; set; } = string.Empty;

    public List<string> HtmlDescriptionList { get; set; } = [];

    public string LogoPath { get; set; } = string.Empty;

    public string LogoUrl { get; set; } = string.Empty;
}
