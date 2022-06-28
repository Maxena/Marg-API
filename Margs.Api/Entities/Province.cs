namespace Margs.Api.Entities;

public class Province : BaseEntity<Guid>
{
    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;
    public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
}