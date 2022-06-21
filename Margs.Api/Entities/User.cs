using Margs.Api.Common;

namespace Margs.Api.Entities;

public class User : BaseEntity<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Mobile { get; set; } = null!;
    public string Profile { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Gender Gender { get; set; }
    public int CityId { get; set; }
    public string Password { get; set; } = null!;
    public DateTime LastLoginDateTime { get; set; }
    public bool IsActive { get; set; }
    public virtual ICollection<Address> Addresses { get; set; } = null!;
    public virtual ICollection<UserRole> UserRoles { get; set; } = null!;
    public virtual City City { get; set; } = null!;
}