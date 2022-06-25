namespace Margs.Api.Requests.Authentication;

public class LoginUserRes
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Profile { get; set; }
    public string Email { get; set; }
    public int CityId { get; set; }
    public bool IsActive { get; set; }
    public string Token { get; set; }
}