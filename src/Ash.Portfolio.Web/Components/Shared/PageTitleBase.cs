using Microsoft.AspNetCore.Components;

namespace Ash.Portfolio.Web.Components.Pages;

public class PageTitleBase : PageBase
{
    [Parameter]
    public string LocalisedString { get; set; } = string.Empty;
}
