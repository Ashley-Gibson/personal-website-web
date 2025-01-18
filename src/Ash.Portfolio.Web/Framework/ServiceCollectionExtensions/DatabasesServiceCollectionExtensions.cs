using Microsoft.Extensions.Options;
using Ash.Portfolio.Web.Framework.Database.Configuration;
using Ash.Portfolio.Web.Framework.Database.Options;
using Ash.Portfolio.Web.Framework.Database.Constants;
using Ash.Portfolio.Web.Framework.Database.Connection;
using Ash.Portfolio.Web.Framework.Database.Credentials;
using Ash.Portfolio.Web.Framework.Database.Factory;

namespace Ash.Portfolio.Web.Framework.ServiceCollectionExtensions;

public static class DatabasesServiceCollectionExtensions
{
    public static IServiceCollection AddDatabases(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseName.Ash_Portfolio_Database));
        var databaseOptions = GetDatabaseOptions(services);
        var databaseConfiguration = new OptionsDatabaseConfiguration(databaseOptions);

        SetupDatabase(databaseOptions.Value.AuthenticationMode, databaseOptions, services, databaseConfiguration);
        AddDatabaseFactory(services);

        return services;
    }

    private static IOptions<DatabaseOptions> GetDatabaseOptions(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider.GetService<IOptions<DatabaseOptions>>()!;
    }

    private static IServiceCollection SetupDatabase(
        AuthenticationMode authenticationMode,
        IOptions<DatabaseOptions> databaseOptions,
        IServiceCollection services,
        Database.Configuration.IConfiguration configuration) =>
    authenticationMode switch
    {
        AuthenticationMode.SqlUser => AddSqlUserDatabase(services, databaseOptions, configuration),
        _ => throw new ArgumentException("Invalid Authentication Mode.", nameof(authenticationMode))
    };

    private static IServiceCollection AddSqlUserDatabase(this IServiceCollection services, IOptions<DatabaseOptions> databaseOptions, Database.Configuration.IConfiguration configuration)
    {
        var sqlUserCredentials = new OptionsSqlUserCredentials(databaseOptions);
        services.AddScoped<ISqlUserCredentials>(s => sqlUserCredentials);

        var sqlUserConnectionStringBuilder = new SqlUserConnectionStringBuilder(int.Parse(databaseOptions.Value.ConnectionTimeout));
        services.AddScoped<ISqlUserConnectionStringBuilder>(x => sqlUserConnectionStringBuilder);

        services.AddScoped<IConnection>(s => new SqlUserConnection(configuration, sqlUserCredentials, sqlUserConnectionStringBuilder));
        return services;
    }

    private static void AddDatabaseFactory(IServiceCollection services)
    {
        var databaseConnections = new List<IConnection>();
        var serviceProvider = services.BuildServiceProvider();
        databaseConnections.AddRange(serviceProvider.GetServices<IConnection>());

        services.AddScoped<IDatabaseFactory>(_ => new DatabaseFactory(databaseConnections));
    }
}
