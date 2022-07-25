using Domain.Entities.Shared;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Authentication;

public class AppUser : IdentityUser
{
    // Additional Properties in User
    public string FullName { get; set; }
    public UserType UserType { get; set; }
    public string ActiveDeactive { get; set; }
    public DateTime? ValidTime { get; set; }
    public string ValidateCode { get; set; }
    
    

}