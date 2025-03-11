namespace Ash.Portfolio.Web.Framework.Database.Constants;

public static class SQLConstants
{
    private const string ExperienceSchema = "[Experience]";
    private const string PortfolioSchema = "[Portfolio]";
    private const string EducationSchema = "[Education]";
    private const string InterestsSchema = "[Interests]";

    public readonly static string ExperienceGetRoles = $"{ExperienceSchema}.[uspGetRoles]";
    public readonly static string ExperienceGetRoleDescriptions = $"{ExperienceSchema}.[uspGetRoleDescriptions]";

    public readonly static string PortfolioGetProjects = $"{PortfolioSchema}.[uspGetProjects]";

    public readonly static string EducationGetInstitutes = $"{EducationSchema}.[uspGetInstitutes]";
    public readonly static string EducationGetInstituteDescriptions = $"{EducationSchema}.[uspGetInstituteDescriptions]";

    public readonly static string InterestsGetPhotoGalleryImageLinks = $"{InterestsSchema}.[uspGetPhotoGalleryImageLinks]";
}
