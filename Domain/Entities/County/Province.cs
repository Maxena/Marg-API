using Domain.Entities.Shared;

namespace Domain.Entities.County;

public class Province : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
}