using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NASRAC.Persistence.Game.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VehicleType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Tier = table.Column<int>(type: "integer", nullable: false),
                    VehicleType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Budget = table.Column<double>(type: "double precision", nullable: false),
                    PrestigeLevel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EquipmentRating = table.Column<double>(type: "double precision", nullable: false),
                    PersonnelRating = table.Column<double>(type: "double precision", nullable: false),
                    PerformanceRating = table.Column<double>(type: "double precision", nullable: false),
                    OverallRating = table.Column<double>(type: "double precision", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Laps = table.Column<int>(type: "integer", nullable: false),
                    Stages = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    TrackId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Race_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    ManufacturerId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    OverallRating = table.Column<double>(type: "double precision", nullable: false),
                    PerformanceRating = table.Column<double>(type: "double precision", nullable: false),
                    ShortTrackRating = table.Column<double>(type: "double precision", nullable: false),
                    IntermediateTrackRating = table.Column<double>(type: "double precision", nullable: false),
                    SuperspeedwayTrackRating = table.Column<double>(type: "double precision", nullable: false),
                    RoadTrackRating = table.Column<double>(type: "double precision", nullable: false),
                    PotentialRating = table.Column<double>(type: "double precision", nullable: false),
                    ProgressionRate = table.Column<double>(type: "double precision", nullable: false),
                    RegressionRate = table.Column<double>(type: "double precision", nullable: false),
                    PeakAgeStart = table.Column<int>(type: "integer", nullable: false),
                    PeakAgeEnd = table.Column<int>(type: "integer", nullable: false),
                    RetirementFactor = table.Column<double>(type: "double precision", nullable: false),
                    DNFOdds = table.Column<double>(type: "double precision", nullable: false),
                    Marketability = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Driver_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalAmountLoaned = table.Column<double>(type: "double precision", nullable: false),
                    TotalAmountPaid = table.Column<double>(type: "double precision", nullable: false),
                    MaturityDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InterestRate = table.Column<double>(type: "double precision", nullable: false),
                    LenderId = table.Column<int>(type: "integer", nullable: false),
                    BorrowerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loan_Team_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loan_Team_LenderId",
                        column: x => x.LenderId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamFinancials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    Balance = table.Column<double>(type: "double precision", nullable: false),
                    StatementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamFinancials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamFinancials_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ManufacturerId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamManufacturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamManufacturers_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamManufacturers_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RaceNumber = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    SeasonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QualifyingStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    FastestTime = table.Column<double>(type: "double precision", nullable: false),
                    TopSpeed = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualifyingStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualifyingStats_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QualifyingStats_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DriverRating = table.Column<double>(type: "double precision", nullable: false),
                    DNFOdds = table.Column<double>(type: "double precision", nullable: false),
                    IsRunning = table.Column<bool>(type: "boolean", nullable: false),
                    CurrentPosition = table.Column<int>(type: "integer", nullable: false),
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    FastestTime = table.Column<double>(type: "double precision", nullable: false),
                    TopSpeed = table.Column<double>(type: "double precision", nullable: false),
                    AveragePosition = table.Column<double>(type: "double precision", nullable: false),
                    AverageRunningPosition = table.Column<double>(type: "double precision", nullable: false),
                    Top15LapCount = table.Column<int>(type: "integer", nullable: false),
                    Top15LapPercentage = table.Column<double>(type: "double precision", nullable: false),
                    LapLedCount = table.Column<int>(type: "integer", nullable: false),
                    LapLedPercentage = table.Column<double>(type: "double precision", nullable: false),
                    CautionLapCount = table.Column<int>(type: "integer", nullable: false),
                    CautionLapPercentage = table.Column<double>(type: "double precision", nullable: false),
                    CautionsCaused = table.Column<int>(type: "integer", nullable: false),
                    TotalLapCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceLog_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceLog_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartPosition = table.Column<int>(type: "integer", nullable: false),
                    FinishPosition = table.Column<int>(type: "integer", nullable: false),
                    LowestPosition = table.Column<int>(type: "integer", nullable: false),
                    HighestPosition = table.Column<int>(type: "integer", nullable: false),
                    DNFPosition = table.Column<int>(type: "integer", nullable: false),
                    SessionType = table.Column<int>(type: "integer", nullable: false),
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    FastestTime = table.Column<double>(type: "double precision", nullable: false),
                    TopSpeed = table.Column<double>(type: "double precision", nullable: false),
                    AveragePosition = table.Column<double>(type: "double precision", nullable: false),
                    AverageRunningPosition = table.Column<double>(type: "double precision", nullable: false),
                    Top15LapCount = table.Column<int>(type: "integer", nullable: false),
                    Top15LapPercentage = table.Column<double>(type: "double precision", nullable: false),
                    LapLedCount = table.Column<int>(type: "integer", nullable: false),
                    LapLedPercentage = table.Column<double>(type: "double precision", nullable: false),
                    CautionLapCount = table.Column<int>(type: "integer", nullable: false),
                    CautionLapPercentage = table.Column<double>(type: "double precision", nullable: false),
                    CautionsCaused = table.Column<int>(type: "integer", nullable: false),
                    TotalLapCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionResults_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionResults_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Name", "VehicleType" },
                values: new object[,]
                {
                    { 1, "Chevy", 0 },
                    { 2, "Chevy", 1 },
                    { 3, "Ford", 0 },
                    { 4, "Ford", 1 },
                    { 5, "Toyota", 0 },
                    { 6, "Toyota", 1 }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Name", "Tier", "VehicleType" },
                values: new object[,]
                {
                    { 1, "NASRAC Cup Series", 1, 0 },
                    { 2, "NASRAC Bowl Series", 2, 0 },
                    { 3, "NASRAC Truck Series", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "EquipmentRating", "Name", "OverallRating", "OwnerId", "PerformanceRating", "PersonnelRating" },
                values: new object[,]
                {
                    { 1, 84.697000000000003, "Purple Finish Line Motorsports", 86.238, null, 0.0, 87.780000000000001 },
                    { 2, 85.504000000000005, "Cosmos Racing Group LLC", 84.715000000000003, null, 0.0, 83.926000000000002 },
                    { 3, 90.649000000000001, "Black Mountain Racing Limited", 95.323999999999998, null, 0.0, 100.0 },
                    { 4, 93.561999999999998, "Nitro Racing Team Incorporated", 88.227000000000004, null, 0.0, 82.891999999999996 },
                    { 5, 90.043999999999997, "Burnout Racing Team Ltd.", 94.989000000000004, null, 0.0, 99.933999999999997 },
                    { 6, 100.0, "Valley Racing Group Inc.", 100.0, null, 0.0, 100.0 },
                    { 7, 80.948999999999998, "Safari Racing Limited", 79.384, null, 0.0, 77.817999999999998 },
                    { 8, 100.0, "White Sun Racing Group LLC", 92.085999999999999, null, 0.0, 84.173000000000002 },
                    { 9, 84.114000000000004, "Comet Racing Group Limited", 84.840999999999994, null, 0.0, 85.567999999999998 },
                    { 10, 80.605999999999995, "Crest Racing Group Incorporated", 84.256, null, 0.0, 87.905000000000001 },
                    { 11, 67.019000000000005, "Valley Racing Group Ltd.", 79.896000000000001, null, 0.0, 92.772000000000006 },
                    { 12, 93.924000000000007, "Asteroid Racing Group Limited", 91.468999999999994, null, 0.0, 89.013999999999996 },
                    { 13, 85.638999999999996, "Cosmos Racing Group Incorporated", 88.989000000000004, null, 0.0, 92.338999999999999 },
                    { 14, 76.866, "Yellow Canyon Racing Ltd.", 83.939999999999998, null, 0.0, 91.013999999999996 },
                    { 15, 55.991999999999997, "Galaxy Racing Group Inc.", 52.996000000000002, null, 0.0, 50.0 },
                    { 16, 82.164000000000001, "Red Peak Racing Group Limited", 91.081999999999994, null, 0.0, 100.0 },
                    { 17, 90.244, "Yellow Sun Racing Incorporated", 89.813999999999993, null, 0.0, 89.382999999999996 },
                    { 18, 81.619, "Vertex Racing Team LLC", 79.281000000000006, null, 0.0, 76.942999999999998 },
                    { 19, 57.731999999999999, "Crown Racing Group Limited", 66.007000000000005, null, 0.0, 74.281999999999996 },
                    { 20, 84.073999999999998, "Mountain Racing Team Incorporated", 91.573999999999998, null, 0.0, 99.075000000000003 },
                    { 21, 89.856999999999999, "Finish Line Racing Team Limited", 94.927999999999997, null, 0.0, 100.0 },
                    { 22, 79.843999999999994, "Green Ridge Racing Group Limited", 76.597999999999999, null, 0.0, 73.352000000000004 },
                    { 23, 95.097999999999999, "Crest Racing Ltd.", 89.847999999999999, null, 0.0, 84.599000000000004 },
                    { 24, 59.725999999999999, "Moon Racing Team LLC", 59.476999999999997, null, 0.0, 59.228000000000002 },
                    { 25, 66.671000000000006, "Vertex Racing Incorporated", 67.686000000000007, null, 0.0, 68.700999999999993 },
                    { 26, 94.129999999999995, "Galaxy Racing Group", 94.781999999999996, null, 0.0, 95.433000000000007 },
                    { 27, 83.311999999999998, "Adrenaline Motorsports", 91.656000000000006, null, 0.0, 100.0 },
                    { 28, 100.0, "Green Meteor Racing", 93.262, null, 0.0, 86.522999999999996 },
                    { 29, 50.0, "White Spire Racing Team Ltd.", 74.902000000000001, null, 0.0, 99.802999999999997 },
                    { 30, 74.614000000000004, "Apex Racing Group LLC", 74.548000000000002, null, 0.0, 74.483000000000004 }
                });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "Id", "Length", "Location", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 0.25, "Los Angeles, CA", "Los Angeles Memorial Coliseum", 0 },
                    { 2, 2.5, "Daytona Beach, FL", "Daytona International Speedway", 2 },
                    { 3, 2.0, "Fontana, CA", "Auto Club Speedway", 2 }
                });

            migrationBuilder.InsertData(
                table: "Driver",
                columns: new[] { "Id", "Age", "DNFOdds", "IntermediateTrackRating", "Marketability", "Name", "OverallRating", "PeakAgeEnd", "PeakAgeStart", "PerformanceRating", "PotentialRating", "ProgressionRate", "RegressionRate", "RetirementFactor", "RoadTrackRating", "ShortTrackRating", "SuperspeedwayTrackRating", "TeamId" },
                values: new object[,]
                {
                    { 1, 29, 0.002, 64.650999999999996, 1, "Judge Quigley", 65.733000000000004, 40, 30, 0.0, 69.831999999999994, 0.045999999999999999, 0.043999999999999997, 0.0040000000000000001, 61.171999999999997, 68.626999999999995, 68.480999999999995, 30 },
                    { 2, 27, 0.0, 73.230999999999995, 9, "Alfonzo Feil", 68.295000000000002, 36, 34, 0.0, 70.057000000000002, 0.084000000000000005, 0.0060000000000000001, 0.001, 72.840999999999994, 57.140000000000001, 69.968000000000004, 15 },
                    { 3, 31, 0.0040000000000000001, 52.159999999999997, 9, "Mckenna Lehner", 57.631, 35, 34, 0.0, 64.994, 0.066000000000000003, 0.028000000000000001, 0.002, 66.141000000000005, 62.223999999999997, 50.0, 16 },
                    { 4, 28, 0.0040000000000000001, 61.616, 5, "Emerson Goldner", 59.731999999999999, 38, 29, 0.0, 66.924000000000007, 0.057000000000000002, 0.0030000000000000001, 0.002, 58.811999999999998, 50.0, 68.501000000000005, 29 },
                    { 5, 49, 0.002, 87.905000000000001, 1, "Claude Koepp", 95.003, 36, 29, 0.0, 100.0, 0.070000000000000007, 0.067000000000000004, 0.0030000000000000001, 92.108999999999995, 100.0, 100.0, 20 },
                    { 6, 30, 0.0040000000000000001, 52.914999999999999, 10, "Maximus Ferry", 50.728999999999999, 38, 35, 0.0, 66.388000000000005, 0.072999999999999995, 0.041000000000000002, 0.0030000000000000001, 50.0, 50.0, 50.0, 1 },
                    { 7, 45, 0.0040000000000000001, 65.462000000000003, 1, "Landen Goyette", 66.881, 32, 29, 0.0, 93.799999999999997, 0.083000000000000004, 0.002, 0.0040000000000000001, 72.498000000000005, 65.984999999999999, 63.578000000000003, 22 },
                    { 8, 35, 0.0050000000000000001, 69.277000000000001, 4, "Frederique Schamberger", 78.475999999999999, 36, 28, 0.0, 85.271000000000001, 0.094, 0.0040000000000000001, 0.001, 88.533000000000001, 71.406999999999996, 84.685000000000002, 28 },
                    { 9, 27, 0.0040000000000000001, 65.792000000000002, 6, "Eddie Koss", 68.661000000000001, 34, 29, 0.0, 88.748999999999995, 0.031, 0.021000000000000001, 0.0050000000000000001, 67.507000000000005, 72.379000000000005, 68.965000000000003, 28 },
                    { 10, 28, 0.0040000000000000001, 75.457999999999998, 8, "Lou Schoen", 78.415000000000006, 38, 28, 0.0, 80.427999999999997, 0.075999999999999998, 0.047, 0.0, 79.554000000000002, 89.698999999999998, 68.950000000000003, 4 },
                    { 11, 27, 0.0040000000000000001, 69.513000000000005, 10, "Emanuel Lakin", 69.494, 37, 29, 0.0, 79.105000000000004, 0.017000000000000001, 0.016, 0.001, 65.269999999999996, 74.677000000000007, 68.515000000000001, 21 },
                    { 12, 41, 0.001, 50.0, 10, "Pedro Harvey", 50.0, 38, 37, 0.0, 53.161000000000001, 0.001, 0.001, 0.002, 50.0, 50.0, 50.0, 4 },
                    { 13, 27, 0.001, 50.0, 2, "Jefferey Shields", 50.0, 38, 37, 0.0, 44.603999999999999, 0.042999999999999997, 0.012, 0.0030000000000000001, 50.0, 50.0, 50.0, 7 },
                    { 14, 23, 0.0040000000000000001, 73.950000000000003, 7, "Delpha Donnelly", 58.421999999999997, 38, 36, 0.0, 82.516999999999996, 0.043999999999999997, 0.039, 0.0, 50.0, 59.740000000000002, 50.0, 29 },
                    { 15, 25, 0.0040000000000000001, 73.533000000000001, 8, "Brenda Lind", 72.787999999999997, 30, 28, 0.0, 88.097999999999999, 0.01, 0.001, 0.0030000000000000001, 80.738, 67.578999999999994, 69.302000000000007, 30 },
                    { 16, 20, 0.001, 61.343000000000004, 8, "Judy Ryan", 80.647999999999996, 28, 27, 0.0, 100.0, 0.063, 0.035000000000000003, 0.0040000000000000001, 97.400999999999996, 80.683000000000007, 83.165999999999997, 26 },
                    { 17, 29, 0.0030000000000000001, 57.866999999999997, 5, "Ramona Homenick", 67.329999999999998, 40, 33, 0.0, 79.165999999999997, 0.058000000000000003, 0.037999999999999999, 0.0040000000000000001, 80.881, 69.528999999999996, 61.042000000000002, 29 },
                    { 18, 33, 0.0030000000000000001, 92.150999999999996, 7, "Kathryne Dach", 82.927000000000007, 30, 29, 0.0, 100.0, 0.080000000000000002, 0.069000000000000006, 0.001, 81.009, 71.819000000000003, 86.730000000000004, 2 },
                    { 19, 29, 0.0030000000000000001, 67.822999999999993, 9, "Velva Hackett", 70.978999999999999, 35, 27, 0.0, 97.941000000000003, 0.068000000000000005, 0.050999999999999997, 0.0050000000000000001, 72.573999999999998, 85.415999999999997, 58.103999999999999, 29 },
                    { 20, 32, 0.0, 56.606999999999999, 3, "Harvey O'Hara", 58.231000000000002, 39, 29, 0.0, 73.822999999999993, 0.067000000000000004, 0.019, 0.0030000000000000001, 55.543999999999997, 64.409999999999997, 56.362000000000002, 11 },
                    { 21, 28, 0.0050000000000000001, 50.073999999999998, 10, "Adele Smitham", 54.637999999999998, 37, 32, 0.0, 75.888999999999996, 0.076999999999999999, 0.014999999999999999, 0.0030000000000000001, 50.0, 68.478999999999999, 50.0, 23 },
                    { 22, 36, 0.0040000000000000001, 50.0, 6, "Wilson Dickinson", 50.0, 34, 33, 0.0, 46.164999999999999, 0.051999999999999998, 0.017000000000000001, 0.0030000000000000001, 50.0, 50.0, 50.0, 12 },
                    { 23, 45, 0.002, 100.0, 6, "Dion Russel", 68.225999999999999, 39, 28, 0.0, 100.0, 0.0060000000000000001, 0.002, 0.0040000000000000001, 50.0, 72.905000000000001, 50.0, 10 },
                    { 24, 32, 0.001, 91.251000000000005, 6, "Susan Rempel", 76.122, 37, 37, 0.0, 89.798000000000002, 0.042999999999999997, 0.0060000000000000001, 0.001, 69.966999999999999, 73.206999999999994, 70.063999999999993, 11 },
                    { 25, 18, 0.002, 60.616, 5, "Elsie Bogan", 68.597999999999999, 40, 37, 0.0, 95.858999999999995, 0.049000000000000002, 0.0089999999999999993, 0.001, 71.293000000000006, 88.247, 54.237000000000002, 10 },
                    { 26, 22, 0.0030000000000000001, 72.600999999999999, 6, "Marian Kassulke", 61.659999999999997, 37, 30, 0.0, 95.456999999999994, 0.047, 0.034000000000000002, 0.0040000000000000001, 55.927, 56.862000000000002, 61.249000000000002, 14 },
                    { 27, 35, 0.0030000000000000001, 50.0, 5, "Eugenia Blick", 50.067999999999998, 37, 35, 0.0, 59.268000000000001, 0.012, 0.01, 0.0030000000000000001, 50.271000000000001, 50.0, 50.0, 4 },
                    { 28, 28, 0.0040000000000000001, 61.93, 2, "Cleo Crona", 78.600999999999999, 40, 30, 0.0, 95.311000000000007, 0.042999999999999997, 0.016, 0.002, 74.789000000000001, 100.0, 77.686000000000007, 13 },
                    { 29, 14, 0.001, 50.0, 2, "Fanny Grant", 50.316000000000003, 33, 29, 0.0, 70.948999999999998, 0.067000000000000004, 0.053999999999999999, 0.0, 50.0, 51.264000000000003, 50.0, 8 },
                    { 30, 29, 0.002, 59.606000000000002, 6, "Misty Schoen", 69.260000000000005, 33, 29, 0.0, 81.046999999999997, 0.065000000000000002, 0.048000000000000001, 0.0040000000000000001, 90.171999999999997, 54.755000000000003, 72.507000000000005, 16 },
                    { 31, 25, 0.0, 69.852999999999994, 5, "Lonnie Nicolas", 59.792000000000002, 30, 28, 0.0, 90.969999999999999, 0.051999999999999998, 0.041000000000000002, 0.0040000000000000001, 69.313999999999993, 50.0, 50.0, 12 },
                    { 32, 23, 0.0030000000000000001, 53.579000000000001, 9, "Elenor Schimmel", 50.895000000000003, 37, 35, 0.0, 71.513000000000005, 0.074999999999999997, 0.029000000000000001, 0.0040000000000000001, 50.0, 50.0, 50.0, 24 },
                    { 33, 24, 0.0050000000000000001, 72.013999999999996, 3, "Torrance Schaefer", 57.509, 40, 35, 0.0, 65.281000000000006, 0.058999999999999997, 0.002, 0.002, 51.034999999999997, 50.0, 56.985999999999997, 14 },
                    { 34, 33, 0.002, 87.658000000000001, 6, "Delilah Zieme", 93.953999999999994, 38, 30, 0.0, 100.0, 0.081000000000000003, 0.028000000000000001, 0.0040000000000000001, 88.158000000000001, 100.0, 100.0, 15 },
                    { 35, 26, 0.0, 57.387, 8, "Brannon Cruickshank", 54.457999999999998, 38, 31, 0.0, 77.637, 0.070999999999999994, 0.044999999999999998, 0.0030000000000000001, 54.344999999999999, 56.098999999999997, 50.0, 9 },
                    { 36, 22, 0.002, 66.040999999999997, 2, "David Gerlach", 70.105000000000004, 33, 27, 0.0, 91.616, 0.024, 0.021000000000000001, 0.0040000000000000001, 84.376999999999995, 71.861999999999995, 58.139000000000003, 17 },
                    { 37, 43, 0.002, 53.280000000000001, 5, "Delbert Nicolas", 51.320999999999998, 38, 34, 0.0, 51.950000000000003, 0.074999999999999997, 0.031, 0.0030000000000000001, 50.0, 50.0, 52.003999999999998, 29 },
                    { 38, 32, 0.0, 50.0, 9, "Devan Beatty", 50.137999999999998, 40, 29, 0.0, 58.893999999999998, 0.0, 0.0, 0.001, 50.551000000000002, 50.0, 50.0, 24 },
                    { 39, 26, 0.0040000000000000001, 50.0, 5, "Deven Rohan", 50.0, 40, 35, 0.0, 36.389000000000003, 0.086999999999999994, 0.027, 0.0030000000000000001, 50.0, 50.0, 50.0, 6 },
                    { 40, 30, 0.0, 82.329999999999998, 10, "Merle Nikolaus", 83.884, 36, 35, 0.0, 100.0, 0.096000000000000002, 0.095000000000000001, 0.0, 87.704999999999998, 85.218999999999994, 80.281999999999996, 26 }
                });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "Id", "Laps", "Name", "Stages", "TrackId", "Type" },
                values: new object[,]
                {
                    { 1, 150, "Busch Light Clash at The Coliseum", 0, 1, 0 },
                    { 2, 60, "Bluegreen Vacations Duel 1 at DAYTONA", 2, 2, 1 },
                    { 3, 60, "Bluegreen Vacations Duel 2 at DAYTONA", 2, 2, 1 },
                    { 4, 500, "Daytona 500", 3, 2, 2 },
                    { 5, 200, "Pale Casino 400", 3, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "Date", "RaceId", "RaceNumber", "SeasonId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 2, 6), 1, 1, 1 },
                    { 2, new DateOnly(2022, 2, 17), 2, 2, 1 },
                    { 3, new DateOnly(2022, 2, 17), 3, 3, 1 },
                    { 4, new DateOnly(2022, 2, 20), 4, 4, 1 },
                    { 5, new DateOnly(2022, 2, 27), 5, 5, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_ManufacturerId",
                table: "Car",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TeamId",
                table: "Car",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_TeamId",
                table: "Driver",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_BorrowerId",
                table: "Loan",
                column: "BorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_LenderId",
                table: "Loan",
                column: "LenderId");

            migrationBuilder.CreateIndex(
                name: "IX_QualifyingStats_DriverId",
                table: "QualifyingStats",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_QualifyingStats_RaceId",
                table: "QualifyingStats",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Race_TrackId",
                table: "Race",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceLog_DriverId",
                table: "RaceLog",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceLog_RaceId",
                table: "RaceLog",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_RaceId",
                table: "Schedule",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionResults_DriverId",
                table: "SessionResults",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionResults_RaceId",
                table: "SessionResults",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_OwnerId",
                table: "Team",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamFinancials_TeamId",
                table: "TeamFinancials",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamManufacturers_ManufacturerId",
                table: "TeamManufacturers",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamManufacturers_TeamId",
                table: "TeamManufacturers",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "QualifyingStats");

            migrationBuilder.DropTable(
                name: "RaceLog");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "SessionResults");

            migrationBuilder.DropTable(
                name: "Sponsor");

            migrationBuilder.DropTable(
                name: "TeamFinancials");

            migrationBuilder.DropTable(
                name: "TeamManufacturers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
