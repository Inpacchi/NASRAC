using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NASRAC.Core.Entities.WebApp;
using NASRAC.Core.Models.Game.DriverEntities;
using NASRAC.Core.Models.Game.Entities;
using NASRAC.Core.Models.Game.RaceEntities;
using NASRAC.Core.Models.Game.Stats;
using NASRAC.Core.Models.Game.TeamEntities;

namespace NASRAC.Data.DAL;

public class DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
    : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>(options)
{
    private readonly IConfiguration _configuration = configuration;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<AppUser>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

        builder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseNpgsql(_configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging()
        .UseSeeding((context, b) =>
        {
            InitializeSeedData(context);
        })
        .UseAsyncSeeding(async (context, b, arg3) =>
        {
            await InitializeSeedDataAsync(context);
        });

    private void InitializeSeedData(DbContext dbContext)
    {
        var seed = new Seed(dbContext, _configuration);
        seed.Initialize();
    }
    
    private async Task InitializeSeedDataAsync(DbContext dbContext)
    {
        var seed = new Seed(dbContext, _configuration);
        await seed.InitializeAsync();
    }

    #region Database Structure
    
    public virtual DbSet<Car> Car { get; set; }
    public virtual DbSet<Driver> Driver { get; set; }
    public virtual DbSet<Loan> Loan { get; set; }
    public virtual DbSet<Manufacturer> Manufacturer { get; set; }
    public virtual DbSet<Race> Race { get; set; }
    public virtual DbSet<Schedule> Schedule { get; set; }
    public virtual DbSet<Series> Series { get; set; }
    public virtual DbSet<Sponsor> Sponsor { get; set; }
    public virtual DbSet<Team> Team { get; set; }
    public virtual DbSet<TeamFinancials> TeamFinancials { get; set; }
    public virtual DbSet<Track> Track { get; set; }
    public virtual DbSet<QualifyingStats> QualifyingStats { get; set; }
    public virtual DbSet<RaceLog> RaceLog { get; set; }
    public virtual DbSet<SessionResults> SessionResults { get; set; }
    
    #endregion

    #region Helper Methods
    
    public void Clone<T>(T entity, T clone) where T : class
    {
        var values = Entry(entity).CurrentValues.Clone();
        Entry(clone).CurrentValues.SetValues(values);
        typeof(T).GetProperty("Id")?.SetValue(clone, 0);
        Add(clone);
        SaveChanges();
    }

    #endregion
}