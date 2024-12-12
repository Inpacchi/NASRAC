using Microsoft.AspNetCore.Identity;

namespace NASRAC.Core.Entities.WebApp;

public class AppUser : IdentityUser<int>
{
    public virtual List<AppUserRole>? UserRoles { get; set; } = [];
}