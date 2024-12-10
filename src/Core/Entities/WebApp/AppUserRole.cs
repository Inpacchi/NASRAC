using Microsoft.AspNetCore.Identity;

namespace NASRAC.Core.Entities.WebApp;

public class AppUserRole : IdentityUserRole<int>
{
    public AppUser User { get; set; } = null!;
    public AppRole Role { get; set; } = null!;
}