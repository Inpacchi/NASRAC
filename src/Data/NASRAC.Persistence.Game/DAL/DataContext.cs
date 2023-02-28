using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Models.Game.RaceEntities;
using NASRAC.Models.Game.TeamEntities;
using NASRAC.Models.WebApp.Entities;

namespace NASRAC.Persistence.Game.DAL;

public class DataContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var seed = new Seed(builder);
        
        seed.Initialize();
    }

    protected virtual DbSet<Car> Car { get; set; }
    protected virtual DbSet<Driver> Driver { get; set; }
    protected virtual DbSet<Loan> Loan { get; set; }
    protected virtual DbSet<Manufacturer> Manufacturer { get; set; }
    protected virtual DbSet<QualifyingResults> QualifyingResults { get; set; }
    protected virtual DbSet<Race> Race { get; set; }
    protected virtual DbSet<RaceLog> RaceLogs { get; set; }
    protected virtual DbSet<RaceResults> RaceResults { get; set; }
    protected virtual DbSet<Schedule> Schedule { get; set; }
    protected virtual DbSet<Series> Series { get; set; }
    protected virtual DbSet<Sponsor> Sponsor { get; set; }
    protected virtual DbSet<Team> Team { get; set; }
    protected virtual DbSet<TeamFinancials> TeamFinancials { get; set; }
    protected virtual DbSet<Track> Track { get; set; }

    public ICollection<Driver> GetAllDrivers()
    {
        return Driver
            .Include(d => d.Team)
            .ToList();
    }

    public Race GetRaceById(int id)
    {
        return Race
            .Include(r => r.Track)
            .First(r => r.Id.Equals(id));
    }

    public Race GetRaceByName(string name)
    {
        return Race
            .Include(r => r.Track)
            .First(r => r.Name.Equals(name));
    }
}