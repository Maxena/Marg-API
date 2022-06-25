using Margs.Api.Common;

namespace Margs.Api.Response.Authentication;

public class UsersRes
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Profile { get; set; }
    public bool IsActive { get; set; }
    public int CityId { get; set; }
    public Gender Gender { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastLoginDateTime { get; set; }
}