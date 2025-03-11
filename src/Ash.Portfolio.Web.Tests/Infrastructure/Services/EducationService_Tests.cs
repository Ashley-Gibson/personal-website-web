using Ash.Portfolio.Web.Infrastructure.Services;
using Ash.Portfolio.Web.Tests.Base;

namespace Ash.Portfolio.Web.Tests.Infrastructure.Services;

public class EducationService_Tests : BaseTest
{
    private readonly IEducationService _sut;

    public EducationService_Tests()
    {
        _sut = new EducationService(EducationRepository);
    }

    [Fact]
    public async Task GetInstitutesWithDescriptionAsync_ReturnsInstitutes()
    {
        // Arrange
        EducationRepository
            .GetInstitutesAsync()
            .Returns(
                [
                    new() { Id = 1, Name = "Institute1", DescriptionRows = [new() { ParentId = 1, Text = "Text1" }], ImageLink = "ImageLink1", Link = "Link1", Title = "Title1" },
                    new() { Id = 2, Name = "Institute2", DescriptionRows = [new() { ParentId = 2, Text = "Text2" }], ImageLink = "ImageLink2", Link = "Link2", Title = "Title2" }
                ]);

        // Act
        var institutes = await _sut.GetInstitutesWithDescriptionAsync();

        // Assert
        Received.InOrder(() =>
        {
            EducationRepository.Received(1).GetInstitutesAsync();
        });

        var institute1 = institutes.ToList()[0];
        var institute2 = institutes.ToList()[1];

        Assert.Equal(2, institutes.Count());
        Assert.Equal("Institute1", institute1.Name);
        Assert.Equal("Institute2", institute2.Name);
    }

    [Fact]
    public async Task GetInstitutesWithDescriptionAsync_ReturnsNoInstitutes()
    {
        // Arrange
        EducationRepository
            .GetInstitutesAsync()
            .Returns([]);

        // Act
        var institutes = await _sut.GetInstitutesWithDescriptionAsync();

        // Assert
        Received.InOrder(() =>
        {
            EducationRepository.Received(1).GetInstitutesAsync();
        });

        Assert.Empty(institutes);
    }
}
