using Microsoft.AspNetCore.Identity;

namespace NASRAC.Core.Entities.WebApp;

public class AppRole : IdentityRole<int>
{
    public List<AppUserRole> UserRoles { get; set; } = [];
}