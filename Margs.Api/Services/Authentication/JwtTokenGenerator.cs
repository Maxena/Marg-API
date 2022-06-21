using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Margs.Api.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Margs.Api.Services.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSetting _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSetting> jwtSettings,
        IDateTimeProvider dateTimeProvider,
        IConfiguration configuration)
    {
        _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings));
        _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public string GenerateToken(Guid userId, string userName, IEnumerable<string> userRoles)
    {
        var str = _jwtSettings.SecretKey;

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimsIdentity.DefaultIssuer, userId.ToString()),
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, string.Join(",", userRoles)),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: _dateTimeProvider.UtcNow.AddDays(_jwtSettings.ExpireInMinute),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}