using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Models.Game.RaceEntities;
using NASRAC.Models.Game.Stats;
using NASRAC.Models.Game.TeamEntities;
using NASRAC.Models.WebApp.Entities;

namespace Data.DAL;

public class DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
    : IdentityDbContext<AppUser, IdentityRole<int>, int>(options)
{
    private readonly IConfiguration _configuration = configuration;

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
    
    protected virtual DbSet<Car> Car { get; set; }
    protected virtual DbSet<Driver> Driver { get; set; }
    protected virtual DbSet<Loan> Loan { get; set; }
    protected virtual DbSet<Manufacturer> Manufacturer { get; set; }
    protected virtual DbSet<Race> Race { get; set; }
    protected virtual DbSet<Schedule> Schedule { get; set; }
    protected virtual DbSet<Series> Series { get; set; }
    protected virtual DbSet<Sponsor> Sponsor { get; set; }
    protected virtual DbSet<Team> Team { get; set; }
    protected virtual DbSet<TeamFinancials> TeamFinancials { get; set; }
    protected virtual DbSet<Track> Track { get; set; }
    protected virtual DbSet<QualifyingStats> QualifyingStats { get; set; }
    protected virtual DbSet<RaceLog> RaceLog { get; set; }
    protected virtual DbSet<SessionResults> SessionResults { get; set; }
    
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