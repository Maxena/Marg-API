namespace Margs.Api.Response.Authentication;

public class RoleRes
{
    public Guid RoleId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
}