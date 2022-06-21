namespace Margs.Api.Entities;

public class Address : BaseEntity<Guid>
{
    public string Main { get; set; }
    public string Detail { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}