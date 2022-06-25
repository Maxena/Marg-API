using Margs.Api.Common;

namespace Margs.Api.Requests.Authentication;

public class RegisterUserReq
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mobile { get; set; }
    public string? Profile { get; set; }
    public Gender Gender { get; set; }
    public int CityId { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}