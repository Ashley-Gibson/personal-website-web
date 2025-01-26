namespace Ash.Portfolio.Web.Infrastructure.Data.Experience;

public class Role
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string EmployerName { get; set; } = string.Empty;

    public string EmployerLink { get; set; } = string.Empty;

    public string ImageLink { get; set; } = string.Empty;

    public List<RoleDescription> DescriptionRows { get; set; } = [];
}
