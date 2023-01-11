using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NASRAC.Models.WebApp.Entities;

namespace NASRAC.Persistence.Game.DAL;

public class DataContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
}