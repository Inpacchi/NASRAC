using Microsoft.AspNetCore.Identity;

namespace NASRAC.Core.Entities.WebApp;

public class AppUserRole : IdentityUserRole<int>
{
    public virtual AppUser? User { get; set; }
    public virtual AppRole? Role { get; set; }
}