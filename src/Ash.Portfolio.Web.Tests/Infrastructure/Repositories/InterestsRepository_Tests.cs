using Ash.Portfolio.Web.Framework.Database.Constants;
using Ash.Portfolio.Web.Infrastructure.Data.Education;
using Ash.Portfolio.Web.Infrastructure.Data.Portfolio;
using Ash.Portfolio.Web.Infrastructure.Repositories;
using Ash.Portfolio.Web.Tests.Base;
using Dapper;

namespace Ash.Portfolio.Web.Tests.Infrastructure.Repositories;

public class InterestsRepository_Tests : BaseTest
{
    private readonly InterestsRepository _sut;

    public InterestsRepository_Tests()
    {
        _sut = new InterestsRepository(DatabaseFactory);
    }

    [Fact]
    public async Task GetPhotoGalleryImageLinksAsync_ReturnsImageLinks()
    {
        // Arrange
        MainDatabase
            .QueryAsync<string>(SQLConstants.InterestsGetPhotoGalleryImageLinks, Arg.Any<DynamicParameters>())
            .Returns(
                [
                    "ImageLink1",
                    "ImageLink2"
                ]);

        // Act
        var imageLinks = await _sut.GetPhotoGalleryImageLinksAsync();

        // Assert
        Received.InOrder(() =>
        {
            MainDatabase.Received(1).QueryAsync<string>(SQLConstants.InterestsGetPhotoGalleryImageLinks, Arg.Any<DynamicParameters>());
        });

        var imageLinksList = imageLinks.ToList();
        var imageLink1 = imageLinksList[0];
        var imageLink2 = imageLinksList[1];

        Assert.Equal(2, imageLinksList.Count());
        Assert.Equal("ImageLink1", imageLink1);
        Assert.Equal("ImageLink2", imageLink2);
    }

    [Fact]
    public async Task GetPhotoGalleryImageLinksAsync_ReturnsNoImageLinks()
    {
        // Arrange
        MainDatabase
            .QueryAsync<string>(SQLConstants.InterestsGetPhotoGalleryImageLinks, Arg.Any<DynamicParameters>())
                .Returns([]);

        // Act
        var imageLinks = await _sut.GetPhotoGalleryImageLinksAsync();

        // Assert
        Received.InOrder(() =>
        {
            MainDatabase.Received(1).QueryAsync<string>(SQLConstants.InterestsGetPhotoGalleryImageLinks, Arg.Any<DynamicParameters>());
        });

        Assert.Empty(imageLinks);
    }
}
