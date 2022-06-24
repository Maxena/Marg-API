namespace Margs.Api.Entities;

public class City : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public int ProvinceId { get; set; }
    public virtual Province Province { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = null!;
}