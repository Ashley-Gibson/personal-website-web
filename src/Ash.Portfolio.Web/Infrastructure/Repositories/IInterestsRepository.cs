namespace Ash.Portfolio.Web.Infrastructure.Repositories;

public interface IInterestsRepository
{
    Task<IEnumerable<string>> GetPhotoGalleryImageLinksAsync();
}
