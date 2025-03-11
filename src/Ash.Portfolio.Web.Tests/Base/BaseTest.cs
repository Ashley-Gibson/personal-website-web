global using Xunit;
global using NSubstitute;
using Ash.Portfolio.Web.Infrastructure.Repositories;
using Ash.Portfolio.Web.Framework.Database.Factory;
using Ash.Portfolio.Web.Framework.Database;
using Ash.Portfolio.Web.Framework.Database.Constants;

namespace Ash.Portfolio.Web.Tests.Base;

public class BaseTest
{
    protected readonly IDatabase MainDatabase;
    protected readonly IDatabaseFactory DatabaseFactory;

    protected readonly IEducationRepository EducationRepository;

    public BaseTest()
    {
        MainDatabase = Substitute.For<IDatabase>();
        DatabaseFactory = Substitute.For<IDatabaseFactory>();
        DatabaseFactory.GetDatabase(DatabaseName.Ash_Portfolio_Database)
            .Returns(MainDatabase);

        EducationRepository = Substitute.For<IEducationRepository>();
    }
}
