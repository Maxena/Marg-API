namespace Margs.Api.Response;

public class RegisterUserRes
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
}