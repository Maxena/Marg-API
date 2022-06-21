namespace Margs.Api.Services.Authentication;

public class JwtSetting
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
    public int ExpireInMinute { get; set; }
}