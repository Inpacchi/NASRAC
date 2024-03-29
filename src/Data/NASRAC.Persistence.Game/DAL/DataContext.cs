using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Models.Game.RaceEntities;
using NASRAC.Models.Game.Stats;
using NASRAC.Models.Game.TeamEntities;
using NASRAC.Models.WebApp.Entities;

namespace NASRAC.Persistence.Game.DAL;

public class DataContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    private readonly string _seedPath;
    
    public DataContext(DbContextOptions options) : base(options)
    {
        _seedPath = Path.Combine("..", "..", "Data", "NASRAC.Persistence.Game", "Seed Data");
    }
    
    public DataContext(DbContextOptions options, string seedPath) : base(options)
    {
        _seedPath = seedPath;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Seed Data
        
        var seed = new Seed(builder, _seedPath);
        seed.Initialize();
        
        #endregion
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