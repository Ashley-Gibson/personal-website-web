using Ash.Portfolio.Web.Framework.Database.Constants;
using Ash.Portfolio.Web.Infrastructure.Data.Education;
using Ash.Portfolio.Web.Infrastructure.Data.Portfolio;
using Ash.Portfolio.Web.Infrastructure.Repositories;
using Ash.Portfolio.Web.Tests.Base;
using Dapper;

namespace Ash.Portfolio.Web.Tests.Infrastructure.Repositories;

public class PortfolioRepository_Tests : BaseTest
{
    private readonly PortfolioRepository _sut;

    public PortfolioRepository_Tests()
    {
        _sut = new PortfolioRepository(DatabaseFactory);
    }

    [Fact]
    public async Task GetProjectsAsync_ReturnsProjects()
    {
        // Arrange
        MainDatabase
            .QueryAsync<Project>(SQLConstants.PortfolioGetProjects, Arg.Any<DynamicParameters>())
            .Returns(
                [
                    new() { Technologies = "C#", Name = "Project1", RepositoryLink = "RepositoryLink1", ImageLink = "ImageLink1", Status = "InProgress" },
                    new() { Technologies = "SQL", Name = "Project2", RepositoryLink = "RepositoryLink2", ImageLink = "ImageLink2", Status = "Complete" },
                ]);

        // Act
        var projects = await _sut.GetProjectsAsync();

        // Assert
        Received.InOrder(() =>
        {
            MainDatabase.Received(1).QueryAsync<Project>(SQLConstants.PortfolioGetProjects, Arg.Any<DynamicParameters>());
        });

        var projectList = projects.ToList();
        var project1 = projectList[0];
        var project2 = projectList[1];

        Assert.Equal(2, projects.Count());
        Assert.Equal("Project1", project1.Name);
        Assert.Equal("Project2", project2.Name);
    }

    [Fact]
    public async Task GetProjectsAsync_ReturnsNoProjects()
    {
        // Arrange
        MainDatabase
            .QueryAsync<Project>(SQLConstants.PortfolioGetProjects, Arg.Any<DynamicParameters>())
            .Returns([]);

        // Act
        var projects = await _sut.GetProjectsAsync();

        // Assert
        Received.InOrder(() =>
        {
            MainDatabase.Received(1).QueryAsync<Project>(SQLConstants.PortfolioGetProjects, Arg.Any<DynamicParameters>());
        });

        Assert.Empty(projects);
    }
}
