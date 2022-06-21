namespace Margs.Api.Exceptions;

public class UserAlreadyExistException : Exception
{
    public UserAlreadyExistException(string message) : base(message)
    {
    }

    public UserAlreadyExistException() : base("user already exits")
    {
    }
}