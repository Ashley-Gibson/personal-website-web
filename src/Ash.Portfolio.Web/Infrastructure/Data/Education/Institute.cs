namespace Ash.Portfolio.Web.Infrastructure.Data.Education;

public class Institute
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Link { get; set; } = string.Empty;

    public string ImageLink { get; set; } = string.Empty;

    public List<InstituteDescription> DescriptionRows { get; set; } = [];
}
