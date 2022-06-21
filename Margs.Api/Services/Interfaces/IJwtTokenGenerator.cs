namespace Margs.Api.Services.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string userName, IEnumerable<string> userRoles);
}