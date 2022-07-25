using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Authentication;

public class AppRole : IdentityRole
{
    public AppRole()  : base() { }

    public AppRole(string name) : base(name) { }
    
}