namespace Margs.Api.Entities;

public class City : BaseEntity<Guid>
{
    public string Name { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public Guid ProvinceId { get; set; }
    public virtual Province Province { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = null!;
}