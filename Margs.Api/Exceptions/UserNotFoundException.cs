namespace Margs.Api.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base($"user not found")
    {
    }
}