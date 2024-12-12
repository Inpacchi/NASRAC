using Microsoft.AspNetCore.Identity;

namespace NASRAC.Core.Entities.WebApp;

public class AppRole : IdentityRole<int>
{
    public virtual List<AppUserRole>? UserRoles { get; set; }
}