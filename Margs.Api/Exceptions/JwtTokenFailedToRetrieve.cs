namespace Margs.Api.Exceptions;

public class JwtTokenFailedToRetrieve : Exception
{
    public JwtTokenFailedToRetrieve() : base("Failed To Retrieve Jwt Token")
    {
    }
}