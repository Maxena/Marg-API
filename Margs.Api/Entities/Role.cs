namespace Margs.Api.Entities;

public class Role : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
}