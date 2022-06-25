namespace Margs.Api.Exceptions;

public class UserIsNotActiveException : BadHttpRequestException
{
    public UserIsNotActiveException() : base("user is not active login failed")
    {
    }

    public UserIsNotActiveException(string message, int statusCode) : base(message, statusCode)
    {
    }

    public UserIsNotActiveException(string message) : base(message)
    {
    }

    public UserIsNotActiveException(string message, int statusCode, Exception innerException) : base(message,
        statusCode, innerException)
    {
    }

    public UserIsNotActiveException(string message, Exception innerException) : base(message, innerException)
    {
    }
}