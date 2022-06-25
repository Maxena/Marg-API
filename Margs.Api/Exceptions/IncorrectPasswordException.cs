namespace Margs.Api.Exceptions;

public class IncorrectPasswordException : BadHttpRequestException
{
    public IncorrectPasswordException() : base("password is incorrect login failed")
    {
    }

    public IncorrectPasswordException(string message, int statusCode) : base(message, statusCode)
    {
    }

    public IncorrectPasswordException(string message) : base(message)
    {
    }

    public IncorrectPasswordException(string message, int statusCode, Exception innerException) : base(message,
        statusCode, innerException)
    {
    }

    public IncorrectPasswordException(string message, Exception innerException) : base(message, innerException)
    {
    }
}