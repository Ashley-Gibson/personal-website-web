using Ash.Portfolio.Web.Framework.Database.Constants;
using Ash.Portfolio.Web.Infrastructure.Data.Education;
using Ash.Portfolio.Web.Infrastructure.Repositories;
using Ash.Portfolio.Web.Tests.Base;
using Dapper;

namespace Ash.Portfolio.Web.Tests.Infrastructure.Repositories;

public class EducationRepository_Tests : BaseTest
{
    private readonly EducationRepository _sut;

    public EducationRepository_Tests()
    {
        _sut = new EducationRepository(DatabaseFactory);
    }

    [Fact]
    public async Task GetInstitutesAsync_ReturnsInstitutes()
    {
        // Arrange
        MainDatabase
            .QueryAsync<Institute>(SQLConstants.EducationGetInstitutes, Arg.Any<DynamicParameters>())
            .Returns(
                [
                    new() { Id = 1, Name = "Institute1", DescriptionRows = [new() { ParentId = 1, Text = "Text1" }], ImageLink = "ImageLink1", Link = "Link1", Title = "Title1" },
                    new() { Id = 2, Name = "Institute2", DescriptionRows = [new() { ParentId = 2, Text = "Text2" }], ImageLink = "ImageLink2", Link = "Link2", Title = "Title2" }
                ]);

        // Act
        var institutes = await _sut.GetInstitutesAsync();

        // Assert
        Received.InOrder(() =>
        {
            MainDatabase.Received(1).QueryAsync<Institute>(SQLConstants.EducationGetInstitutes, Arg.Any<DynamicParameters>());
        });

        var instituteList = institutes.ToList();
        var institute1 = instituteList[0];
        var institute2 = instituteList[1];

        Assert.Equal(2, institutes.Count());
        Assert.Equal("Institute1", institute1.Name);
        Assert.Equal("Institute2", institute2.Name);
    }

    [Fact]
    public async Task GetInstitutesAsync_ReturnsNoInstitutes()
    {
        // Arrange
        MainDatabase
            .QueryAsync<Institute>(SQLConstants.EducationGetInstitutes, Arg.Any<DynamicParameters>())
            .Returns([]);

        // Act
        var institutes = await _sut.GetInstitutesAsync();

        // Assert
        Received.InOrder(() =>
        {
            MainDatabase.Received(1).QueryAsync<Institute>(SQLConstants.EducationGetInstitutes, Arg.Any<DynamicParameters>());
        });

        Assert.Empty(institutes);
    }
}
