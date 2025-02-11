using Ash.Portfolio.Web.Domain.Portfolio;
using Ash.Portfolio.Web.Infrastructure.Data.Portfolio;
using Ash.Portfolio.Web.Tests.Base;

namespace Ash.Portfolio.Web.Tests.Domain;

public class PortfolioService_Tests : BaseTest
{
    private readonly IPortfolioService _sut;

    public PortfolioService_Tests()
    {
        _sut = new PortfolioService();
    }

    [Fact]
    public void FilterProjectsByType_ValidProjects_ReturnsFilteredProjects()
    {
        // Arrange
        var projectType = ProjectType.InProgress;

        var projects = new List<Project>
        {
            new() { Name = "Project1", Status = ProjectType.Complete.ToString() },
            new() { Name = "Project2", Status = projectType.ToString() },
            new() { Name = "Project3", Status = projectType.ToString() }
        };

        // Act
        var filteredProjects = _sut.FilterProjectsByType(projects, projectType);

        // Assert
        var filteredProject1 = filteredProjects.ToList()[0];
        var filteredProject2 = filteredProjects.ToList()[1];

        Assert.Equal(2, filteredProjects.Count());
        Assert.Equal("Project2", filteredProject1.Name);
        Assert.Equal("Project3", filteredProject2.Name);
    }

    [Fact]
    public void FilterProjectsByType_EmptyProjects_ReturnsNoProjects()
    {
        // Arrange
        var projectType = ProjectType.InProgress;

        var projects = new List<Project>();

        // Act
        var filteredProjects = _sut.FilterProjectsByType(projects, projectType);

        // Assert
        Assert.Empty(filteredProjects);
    }

    [Fact]
    public void FilterProjectsByType_FilterProjectsWithDifferentProjectType_ReturnsNoProjects()
    {
        // Arrange
        var projectType = ProjectType.InProgress;

        var projects = new List<Project>
        {
            new() { Name = "Project1", Status = ProjectType.Complete.ToString() },
            new() { Name = "Project2", Status = ProjectType.Complete.ToString() },
            new() { Name = "Project3", Status = ProjectType.Complete.ToString() }
        };


        // Act
        var filteredProjects = _sut.FilterProjectsByType(projects, projectType);

        // Assert
        Assert.Empty(filteredProjects);
    }
}
