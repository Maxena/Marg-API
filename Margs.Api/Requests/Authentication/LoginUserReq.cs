namespace Margs.Api.Requests.Authentication;

public class LoginUserReq
{
    public string UserName { get; set; } = "Admin";

    public string Password { get; set; } = "1234";
}