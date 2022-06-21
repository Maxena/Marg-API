namespace Margs.Api.Exceptions;

public class RegisterFailedException : Exception
{
    public int ErrorCode { get; set; }

    public RegisterFailedException(string message) : base(message)
    {
    }

    public RegisterFailedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public RegisterFailedException(string message, int errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }

    public RegisterFailedException() : base("Register Failed : Somthing went wrong")
    {
    }
}