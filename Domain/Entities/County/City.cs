using Domain.Entities.Shared;

namespace Domain.Entities.County;

public class City : BaseEntity
{
    public string Name { get; set; }
    public Guid ProvinceId { get; set; }
    public virtual Province Province { get; set; }
}