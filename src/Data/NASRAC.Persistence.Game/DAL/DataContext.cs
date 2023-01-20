using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
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

    public virtual DbSet<Car> Car { get; set; }
    public virtual DbSet<Driver> Driver { get; set; }
    public virtual DbSet<Loan> Loan { get; set; }
    public virtual DbSet<Manufacturer> Manufacturer { get; set; }
    public virtual DbSet<QualifyingResults> QualifyingResults { get; set; }
    public virtual DbSet<Race> Race { get; set; }
    public virtual DbSet<RaceResults> RaceResults { get; set; }
    public virtual DbSet<Schedule> Schedule { get; set; }
    public virtual DbSet<Series> Series { get; set; }
    public virtual DbSet<Sponsor> Sponsor { get; set; }
    public virtual DbSet<Team> Team { get; set; }
    public virtual DbSet<TeamFinancials> TeamFinancials { get; set; }
    public virtual DbSet<Track> Track { get; set; }
}