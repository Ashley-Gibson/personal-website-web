using Ash.Portfolio.Web.Framework.Database.Constants;
using Ash.Portfolio.Web.Infrastructure.Data.Education;
using Ash.Portfolio.Web.Infrastructure.Data.Experience;
using Ash.Portfolio.Web.Infrastructure.Repositories;
using Ash.Portfolio.Web.Tests.Base;
using Dapper;

namespace Ash.Portfolio.Web.Tests.Infrastructure.Repositories;

public class ExperienceRepository_Tests : BaseTest
{
    private readonly ExperienceRepository _sut;

    public ExperienceRepository_Tests()
    {
        _sut = new ExperienceRepository(DatabaseFactory);
    }

    [Fact]
    public async Task GetRolesWithDescriptionsAsync_ReturnsRolesWithDescriptions()
    {
        // Arrange
        MainDatabase
            .QueryAsync<Role>(SQLConstants.ExperienceGetRoles, Arg.Any<DynamicParameters>())
            .Returns(
                [
                    new() { Id = 1, EmployerName = "EmployerName1", DescriptionRows = [new() { ParentId = 1, Text = "Text1" }], EmployerLink = "EmployerLink1", ImageLink = "ImageLink1", Title = "Title1" },
                    new() { Id = 2, EmployerName = "EmployerName2", DescriptionRows = [new() { ParentId = 2, Text = "Text2" }], EmployerLink = "EmployerLink2", ImageLink = "ImageLink2", Title = "Title2" }
                ]);

        MainDatabase
            .QueryAsync<RoleDescription>(SQLConstants.ExperienceGetRoleDescriptions, Arg.Any<DynamicParameters>())
            .Returns(
                [
                    new() { ParentId = 1, Text = "Text1" },
                    new() { ParentId = 2, Text = "Text2" }
                ]);

        // Act
        var roles = await _sut.GetRolesWithDescriptionsAsync();

        // Assert
        Received.InOrder(() =>
        {
            MainDatabase.Received(1).QueryAsync<Role>(SQLConstants.ExperienceGetRoles, Arg.Any<DynamicParameters>());
            MainDatabase.Received(1).QueryAsync<RoleDescription>(SQLConstants.ExperienceGetRoleDescriptions, Arg.Any<DynamicParameters>());
        });

        var roleList = roles.ToList();
        var role1 = roleList[0];
        var role2 = roleList[1];

        Assert.Equal(2, roles.Count());
        Assert.Equal("EmployerName1", role1.EmployerName);
        Assert.Equal("EmployerName2", role2.EmployerName);
    }

    [Fact]
    public async Task GetInstitutesAsync_ReturnsNoInstitutes()
    {
        // Arrange
        MainDatabase
            .QueryAsync<Role>(SQLConstants.ExperienceGetRoles, Arg.Any<DynamicParameters>())
            .Returns([]);

        // Act
        var roles = await _sut.GetRolesWithDescriptionsAsync();

        // Assert
        Received.InOrder(() =>
        {
            MainDatabase.Received(1).QueryAsync<Role>(SQLConstants.ExperienceGetRoles, Arg.Any<DynamicParameters>());
        });

        Assert.Empty(roles);
    }
}
