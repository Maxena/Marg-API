namespace Margs.Api.Exceptions;

public class LoginFailedException : Exception
{
    public LoginFailedException(string userName, string password) : base(
        $"login failed with username : {userName} and password : {password}!!")
    {
    }
}