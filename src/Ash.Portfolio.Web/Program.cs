using Ash.Portfolio.Web.Components;
using Ash.Portfolio.Web.Framework.ServiceCollectionExtensions;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Ash.Portfolio.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true);

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddLocalisation(builder.Configuration);

        builder.Services.AddMvc()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();

        builder.Services.AddDatabases(builder.Configuration);

        builder.Services.AddInfrastructure();
        builder.Services.AddDomainServices();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
        }

        app.UseHsts();

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();
        app.UseRequestLocalization();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
