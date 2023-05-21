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
                table: "Driver",
                columns: new[] { "Id", "Age", "DNFOdds", "IntermediateTrackRating", "Marketability", "Name", "OverallRating", "PeakAgeEnd", "PeakAgeStart", "PerformanceRating", "PotentialRating", "ProgressionRate", "RegressionRate", "RetirementFactor", "RoadTrackRating", "ShortTrackRating", "SuperspeedwayTrackRating", "TeamId" },
                values: new object[,]
                {
                    { 1, 38, 0.0021375708368050902, 100.0, 1, "Rosa Bernier", 81.522721524512903, 36, 32, 0.0, 105.27078748198981, 0.098219326429966877, 0.085440725363896755, 0.0, 60.479410573317232, 83.718533026103188, 81.892942498631157, null },
                    { 2, 24, 4.1112229608485927E-05, 50.0, 5, "Merlin Hilll", 51.536513819980705, 35, 33, 0.0, 67.408905094326002, 0.095784242144265105, 0.0066820667651790854, 0.0, 50.0, 56.146055279922813, 50.0, null },
                    { 3, 34, 0.00464593169584928, 66.438509285058188, 8, "Lynn Okuneva", 71.990375694432259, 30, 29, 0.0, 77.15425182852232, 0.086646888207234318, 0.07619027074442801, 0.0, 77.423532554990786, 73.607288376080277, 70.492172561599801, null },
                    { 4, 37, 0.0025836305585242385, 50.0, 7, "Garry Torp", 50.0, 39, 28, 0.0, 45.194740922468654, 0.0038794135179762382, 0.0017752164172156184, 0.0, 50.0, 50.0, 50.0, null },
                    { 5, 27, 0.0037757457310612697, 87.757524806583845, 3, "Theo King", 88.14030959045229, 34, 28, 0.0, 85.422032695024868, 0.092846779794437465, 0.051840200238852018, 0.0, 84.401884788692001, 91.400175729487856, 89.001653037045443, null },
                    { 6, 18, 0.0031852665473018306, 100.0, 7, "Immanuel Sawayn", 84.502288833431891, 37, 37, 0.0, 98.849003051626681, 0.023049347069496275, 0.0022359012850124362, 0.0, 100.0, 77.927884503004435, 60.081270830723156, null },
                    { 7, 39, 0.00066681490616605555, 50.0, 3, "Isaac Quitzon", 57.046451244386667, 40, 37, 0.0, 79.870931181267196, 0.0017535185514637064, 8.7932048415689261E-05, 0.0, 64.426047486833795, 63.759757490712865, 50.0, null },
                    { 8, 39, 0.00015478303803538208, 95.096471548895522, 6, "Juwan Feest", 77.107420767491632, 30, 27, 0.0, 115.90524960388429, 0.09661657644711398, 0.04635308107326018, 0.0, 80.509090225611942, 82.824121295459079, 50.0, null },
                    { 9, 24, 0.00060948632469653768, 84.43961049368805, 9, "Maritza Hintz", 76.631911657905377, 38, 35, 0.0, 88.103753867744658, 0.081659229743110351, 0.063041211065696823, 0.0, 82.470242375334408, 64.800996544509616, 74.816797218089462, null },
                    { 10, 41, 0.0036606723020208942, 74.413112318431999, 3, "Monroe White", 73.436126106381664, 34, 29, 0.0, 72.472513825311154, 0.092848992615626569, 0.041790005177844695, 0.0, 74.736857459150215, 64.875867272004285, 79.718667375940157, null },
                    { 11, 20, 0.0041024509019933608, 67.687516874108084, 7, "Edmond Ratke", 66.184068664163192, 31, 30, 0.0, 76.377343830321138, 0.048930476354700027, 0.004609994369049606, 0.0, 64.065511478780508, 78.658435592288455, 54.324810711475685, null },
                    { 12, 36, 0.0023030123319793074, 50.0, 6, "Zachary Yost", 51.012911292612131, 31, 27, 0.0, 48.213764131425521, 0.059784635963350569, 0.032387275469560474, 0.0, 54.051645170448516, 50.0, 50.0, null },
                    { 13, 26, 0.0038069173232697911, 67.181358611577195, 5, "Erich Connelly", 72.739027095532066, 40, 29, 0.0, 88.076652977010795, 0.0035774421323934271, 0.0028020761276427251, 0.0, 66.370959503452355, 90.276148171710645, 67.127642095388083, null },
                    { 14, 28, 0.0044295343536042697, 83.536259929154241, 7, "Camylle Flatley", 82.197717622937262, 33, 32, 0.0, 93.912800064938168, 0.037488777316389311, 0.0095138378266399534, 0.0, 77.648402549181696, 79.207841837635314, 88.398366175777809, null },
                    { 15, 36, 0.0020195770589466555, 50.0, 1, "Evans Schamberger", 53.04656083662735, 38, 28, 0.0, 64.125894696939952, 0.068189354775058525, 0.0092174744772506572, 0.0, 60.236116144849753, 51.95012720165964, 50.0, null },
                    { 16, 16, 0.00088697667150995532, 85.126286759978314, 5, "Marguerite Larkin", 73.546231914171273, 37, 36, 0.0, 95.375300520241851, 0.06008480440345864, 0.04493081791185264, 0.0, 74.503964894122745, 74.768633803276714, 59.786042199307332, null },
                    { 17, 22, 0.0040348060552188834, 77.480132533948606, 6, "Stewart Crona", 75.978842668837117, 36, 30, 0.0, 83.544479947125069, 0.073307297281569248, 0.053501619651038695, 0.0, 75.815670013664217, 72.557659612734867, 78.061908515000795, null },
                    { 18, 22, 0.0017665498556693837, 78.3110222255861, 9, "Cale Denesik", 69.090375039810397, 40, 33, 0.0, 78.052273552723136, 0.094592737081215919, 0.039669342914262197, 0.0, 56.892525775645815, 72.190818671497937, 68.967133486511713, null },
                    { 19, 35, 0.0025020280166663587, 81.400923095807912, 1, "Joanne Barton", 82.611742442544028, 38, 36, 0.0, 118.60827328678297, 0.033084264958323152, 0.0091809826293302033, 0.0, 81.017363030772131, 85.974860798377705, 82.053822845218392, null },
                    { 20, 51, 0.0042805433024749326, 55.77575570189768, 3, "Raina Rice", 64.894324004685117, 34, 32, 0.0, 77.138882577601819, 0.051631816784863165, 0.049965801612856263, 0.0, 86.980503215157924, 63.730651557653985, 53.09038554403088, null },
                    { 21, 29, 0.00057320527817943166, 50.0, 8, "Emelie Williamson", 50.0, 36, 36, 0.0, 54.178081582482172, 0.037322313834455369, 0.023533189793067608, 0.0, 50.0, 50.0, 50.0, null },
                    { 22, 33, 0.0036305543057162681, 100.0, 8, "Austyn Rohan", 95.176148097408685, 36, 35, 0.0, 133.37663632351419, 0.099635523012821928, 0.091846224711152905, 0.0, 91.289447192547811, 89.415145197086929, 100.0, null },
                    { 23, 35, 0.0037143704655824526, 71.097547449544123, 2, "Johnathan Reichel", 69.229514243081383, 38, 32, 0.0, 83.167642165511637, 0.039174354616459607, 0.036151835427865278, 0.0, 61.986237657084629, 74.705557661352444, 69.128714204344291, null },
                    { 24, 32, 0.0029075963662006359, 99.182785827318028, 1, "Maxine Russel", 92.67001280406582, 36, 34, 0.0, 89.24977935350141, 0.041879131922960749, 0.0068375029515128499, 0.0, 100.0, 81.429120562614699, 90.068144826330553, null },
                    { 25, 32, 0.0027254160828173836, 61.082894819596419, 9, "Giovani Harber", 75.87477826121453, 31, 29, 0.0, 93.343016832483215, 0.042552293595282842, 0.017717361670307068, 0.0, 99.804195668096455, 61.046856303095318, 81.56516625406995, null },
                    { 26, 31, 0.0036584176937288983, 70.435429110879298, 4, "Curt Nolan", 63.279281720071552, 34, 28, 0.0, 104.22189092742552, 0.056153241963391803, 0.033445827414052512, 0.0, 66.970263516860413, 60.468346510639655, 55.243087741906848, null },
                    { 27, 29, 0.0037143966013184894, 50.0, 5, "Eryn Collins", 50.0, 34, 29, 0.0, 48.337170685234511, 0.029004594152449849, 0.0041674172557067159, 0.0, 50.0, 50.0, 50.0, null },
                    { 28, 33, 0.0012736883334101918, 50.0, 3, "Tre Wyman", 57.589005578303251, 30, 29, 0.0, 78.997661084487021, 0.015678584665560213, 0.009509234567276514, 0.0, 54.262919568232228, 59.518310025461155, 66.574792719519621, null },
                    { 29, 23, 0.00012060958326038096, 50.0, 9, "Shana Huels", 51.305771150226136, 31, 31, 0.0, 72.873646476658237, 0.074455629605573684, 0.0099690083356574807, 0.0, 55.223084600904528, 50.0, 50.0, null },
                    { 30, 43, 2.9276335348972782E-05, 50.0, 2, "Danny Hagenes", 50.0, 35, 34, 0.0, 45.6074690634874, 0.042307907236801459, 0.0099974839373217963, 0.0, 50.0, 50.0, 50.0, null },
                    { 31, 26, 0.0025126195970349811, 65.541052152303891, 9, "Deshawn Bednar", 77.830231468090091, 37, 32, 0.0, 87.049979228935712, 0.069780043217992124, 0.046231300367540168, 0.0, 86.801166106296549, 78.579416273183924, 80.399291340576028, null },
                    { 32, 29, 0.0039270301797049417, 92.936345360066994, 7, "Cyril DuBuque", 92.372273533968155, 29, 28, 0.0, 101.43103513299828, 0.044241323444948112, 0.0039056864100985851, 0.0, 93.460126079635771, 83.631802073362124, 99.460820622807745, null },
                    { 33, 32, 0.0024463202468081513, 63.75558641066236, 3, "Ressie Jerde", 60.784399960653246, 40, 37, 0.0, 84.313220214723856, 0.010832243315021407, 0.0058642204003081892, 0.0, 50.0, 54.577440782927823, 74.804572649022802, null },
                    { 34, 20, 0.0033519387031568032, 100.0, 1, "Sarah Sauer", 99.222500285044575, 39, 37, 0.0, 121.19741610469053, 0.04329238269314481, 0.04279924755683414, 0.0, 99.179192435001482, 99.855590548155334, 97.855218157021469, null },
                    { 35, 42, 0.00045412752902480478, 50.0, 3, "Ezra Thompson", 50.0, 39, 30, 0.0, 62.616580417626025, 0.089894917379781739, 0.073266127691377386, 0.0, 50.0, 50.0, 50.0, null },
                    { 36, 26, 0.0018446342871982601, 91.391835448867795, 8, "Georgiana Cummerata", 79.451911243065183, 34, 33, 0.0, 109.46713282224347, 0.043719199261940171, 0.017189917064086298, 0.0, 97.004624202975492, 60.519303242789725, 68.891882077627741, null },
                    { 37, 40, 0.0032449041493221517, 97.861196145053995, 4, "Adrien Green", 86.276219926897795, 37, 37, 0.0, 94.725158938981679, 0.054568777948032492, 0.032568383852611085, 0.0, 100.0, 89.08003019827585, 58.163653364261307, null },
                    { 38, 38, 0.0039644031568764658, 56.579985048072416, 9, "Stan Hessel", 53.88712221160975, 40, 36, 0.0, 66.597901469175213, 0.014538216294916584, 0.0022534398717661826, 0.0, 56.792147266199137, 52.176356532167453, 50.0, null },
                    { 39, 22, 0.001536526825639703, 50.0, 4, "Meaghan Bruen", 58.688529521476354, 30, 30, 0.0, 79.323664555574112, 0.077018953452276689, 0.02890023063695973, 0.0, 75.508170593555349, 59.245947492350069, 50.0, null },
                    { 40, 43, 0.0020364794885854875, 90.120798372133194, 2, "Abner Turcotte", 91.594190549003997, 38, 36, 0.0, 103.30690675232884, 0.094990632611582179, 0.052730259276443023, 0.0, 100.0, 87.79639613183754, 88.459567692045283, null }
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
                table: "Track",
                columns: new[] { "Id", "Length", "Location", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 0.25, "Los Angeles, CA", "Los Angeles Memorial Coliseum", 0 },
                    { 2, 2.5, "Daytona Beach, FL", "Daytona International Speedway", 2 },
                    { 3, 2.0, "Fontana, CA", "Auto Club Speedway", 2 }
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
