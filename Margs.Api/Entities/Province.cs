namespace Margs.Api.Entities;

public class Province : BaseEntity<Guid>
{
    public string Name { get; set; } = null!;
    public virtual ICollection<City> Cities { get; set; }
}