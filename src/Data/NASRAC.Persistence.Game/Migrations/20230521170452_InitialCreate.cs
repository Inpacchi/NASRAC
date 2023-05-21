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
                    { 1, 45, 0.002, 55.274999999999999, 6, "Valentina Bednar", 51.319000000000003, 39, 31, 0.0, 90.111999999999995, 0.068000000000000005, 0.021000000000000001, 0.001, 50.0, 50.0, 50.0, null },
                    { 2, 28, 0.002, 56.171999999999997, 6, "Rosalind Connelly", 52.719999999999999, 37, 34, 0.0, 54.795999999999999, 0.021000000000000001, 0.0050000000000000001, 0.0, 50.539000000000001, 50.0, 54.167999999999999, null },
                    { 3, 42, 0.0040000000000000001, 78.025000000000006, 4, "Keira Kihn", 81.189999999999998, 28, 27, 0.0, 92.335999999999999, 0.049000000000000002, 0.032000000000000001, 0.0, 67.936000000000007, 97.111999999999995, 81.686000000000007, null },
                    { 4, 39, 0.001, 64.933000000000007, 9, "Sterling Olson", 75.736000000000004, 38, 34, 0.0, 91.158000000000001, 0.039, 0.014, 0.0040000000000000001, 74.113, 64.372, 99.527000000000001, null },
                    { 5, 34, 0.002, 95.536000000000001, 2, "Addie Ward", 70.513999999999996, 39, 35, 0.0, 100.0, 0.049000000000000002, 0.012999999999999999, 0.001, 50.0, 56.456000000000003, 80.063000000000002, null },
                    { 6, 24, 0.001, 70.043000000000006, 9, "Lavada Weimann", 71.619, 39, 30, 0.0, 86.230999999999995, 0.078, 0.014999999999999999, 0.0, 66.311000000000007, 66.123000000000005, 83.997, null },
                    { 7, 29, 0.0040000000000000001, 56.802, 1, "Hilton Robel", 63.481999999999999, 31, 30, 0.0, 100.0, 0.069000000000000006, 0.050999999999999997, 0.001, 56.054000000000002, 72.623000000000005, 68.447000000000003, null },
                    { 8, 27, 0.0030000000000000001, 100.0, 1, "Loma Bahringer", 93.391999999999996, 36, 35, 0.0, 100.0, 0.0060000000000000001, 0.002, 0.0030000000000000001, 97.932000000000002, 80.194000000000003, 95.441999999999993, null },
                    { 9, 33, 0.0050000000000000001, 65.033000000000001, 7, "Joshua Renner", 65.114000000000004, 36, 27, 0.0, 88.891000000000005, 0.042000000000000003, 0.029000000000000001, 0.0, 65.731999999999999, 68.296000000000006, 61.395000000000003, null },
                    { 10, 22, 0.001, 67.638000000000005, 2, "Ulises Wolff", 63.026000000000003, 36, 27, 0.0, 100.0, 0.074999999999999997, 0.012999999999999999, 0.0040000000000000001, 50.0, 72.896000000000001, 61.570999999999998, null },
                    { 11, 34, 0.0050000000000000001, 91.233999999999995, 9, "Samir Miller", 83.478999999999999, 40, 37, 0.0, 100.0, 0.078, 0.0070000000000000001, 0.002, 97.492999999999995, 66.713999999999999, 78.475999999999999, null },
                    { 12, 24, 0.001, 81.802000000000007, 10, "Greg Zboncak", 81.030000000000001, 37, 35, 0.0, 100.0, 0.012999999999999999, 0.002, 0.0050000000000000001, 73.835999999999999, 93.688000000000002, 74.793000000000006, null },
                    { 13, 29, 0.0, 83.881, 2, "Valentina Hoeger", 85.677999999999997, 27, 27, 0.0, 91.200999999999993, 0.066000000000000003, 0.051999999999999998, 0.0050000000000000001, 97.046000000000006, 81.590999999999994, 80.192999999999998, null },
                    { 14, 21, 0.0050000000000000001, 50.0, 8, "Jamel Powlowski", 50.0, 32, 31, 0.0, 66.174000000000007, 0.050000000000000003, 0.042999999999999997, 0.002, 50.0, 50.0, 50.0, null },
                    { 15, 26, 0.0, 50.0, 1, "Kamille Schmitt", 50.311, 36, 35, 0.0, 55.055999999999997, 0.089999999999999997, 0.032000000000000001, 0.0, 50.0, 50.0, 51.243000000000002, null },
                    { 16, 34, 0.002, 85.406000000000006, 9, "Destini Crona", 86.691000000000003, 39, 34, 0.0, 96.609999999999999, 0.051999999999999998, 0.044999999999999998, 0.002, 82.915999999999997, 87.403000000000006, 91.039000000000001, null },
                    { 17, 32, 0.0030000000000000001, 93.197000000000003, 1, "Janessa Mitchell", 95.280000000000001, 39, 32, 0.0, 94.716999999999999, 0.080000000000000002, 0.016, 0.002, 99.204999999999998, 100.0, 88.718999999999994, null },
                    { 18, 45, 0.0030000000000000001, 100.0, 10, "Gage Pollich", 93.956999999999994, 37, 31, 0.0, 100.0, 0.035000000000000003, 0.001, 0.002, 86.671000000000006, 100.0, 89.156999999999996, null },
                    { 19, 31, 0.002, 72.078999999999994, 2, "Amalia Swaniawski", 64.135999999999996, 32, 32, 0.0, 79.793000000000006, 0.094, 0.010999999999999999, 0.0040000000000000001, 60.771000000000001, 73.694000000000003, 50.0, null },
                    { 20, 25, 0.0050000000000000001, 78.394000000000005, 4, "Scotty O'Connell", 88.989000000000004, 39, 28, 0.0, 100.0, 0.042999999999999997, 0.014, 0.001, 93.022000000000006, 92.540000000000006, 91.998999999999995, null },
                    { 21, 28, 0.0040000000000000001, 50.0, 7, "Cleta Muller", 50.0, 38, 32, 0.0, 34.079000000000001, 0.082000000000000003, 0.069000000000000006, 0.002, 50.0, 50.0, 50.0, null },
                    { 22, 26, 0.001, 87.316000000000003, 2, "Norwood Thompson", 77.152000000000001, 32, 32, 0.0, 100.0, 0.085999999999999993, 0.0030000000000000001, 0.0, 73.965999999999994, 77.507999999999996, 69.817999999999998, null },
                    { 23, 28, 0.0050000000000000001, 50.0, 6, "Olin McDermott", 50.0, 40, 36, 0.0, 54.091999999999999, 0.012, 0.0, 0.001, 50.0, 50.0, 50.0, null },
                    { 24, 30, 0.001, 50.0, 5, "Madelyn Metz", 50.0, 31, 31, 0.0, 42.067999999999998, 0.084000000000000005, 0.017999999999999999, 0.0040000000000000001, 50.0, 50.0, 50.0, null },
                    { 25, 27, 0.002, 63.798999999999999, 8, "Andrew Treutel", 57.414000000000001, 38, 33, 0.0, 72.352000000000004, 0.042000000000000003, 0.019, 0.0, 50.0, 65.858000000000004, 50.0, null },
                    { 26, 34, 0.0040000000000000001, 61.941000000000003, 6, "Sven Spinka", 63.566000000000003, 39, 35, 0.0, 65.325000000000003, 0.012999999999999999, 0.01, 0.002, 64.182000000000002, 62.997, 65.141999999999996, null },
                    { 27, 34, 0.0040000000000000001, 70.349000000000004, 9, "Verna Auer", 64.540999999999997, 38, 34, 0.0, 80.903000000000006, 0.002, 0.001, 0.0040000000000000001, 61.923000000000002, 60.822000000000003, 65.070999999999998, null },
                    { 28, 37, 0.002, 89.816000000000003, 9, "Maiya Grimes", 88.340999999999994, 32, 31, 0.0, 84.936999999999998, 0.014, 0.001, 0.001, 96.781999999999996, 81.361999999999995, 85.405000000000001, null },
                    { 29, 32, 0.001, 66.609999999999999, 6, "Harrison Sporer", 70.319999999999993, 38, 31, 0.0, 91.611000000000004, 0.089999999999999997, 0.048000000000000001, 0.0030000000000000001, 71.215999999999994, 78.682000000000002, 64.769999999999996, null },
                    { 30, 21, 0.0050000000000000001, 82.721000000000004, 9, "Suzanne Stroman", 77.950999999999993, 30, 29, 0.0, 81.197999999999993, 0.099000000000000005, 0.012999999999999999, 0.0040000000000000001, 79.048000000000002, 72.778999999999996, 77.254999999999995, null },
                    { 31, 24, 0.001, 55.700000000000003, 10, "Dayne Wisozk", 53.305, 36, 33, 0.0, 80.010999999999996, 0.012999999999999999, 0.0070000000000000001, 0.002, 50.0, 55.341000000000001, 52.18, null },
                    { 32, 33, 0.0030000000000000001, 50.0, 10, "Sterling Pouros", 50.073999999999998, 37, 33, 0.0, 76.519000000000005, 0.012999999999999999, 0.01, 0.001, 50.0, 50.296999999999997, 50.0, null },
                    { 33, 19, 0.002, 90.5, 5, "Chanelle Schneider", 64.432000000000002, 33, 27, 0.0, 86.766999999999996, 0.014999999999999999, 0.002, 0.0, 50.0, 67.227000000000004, 50.0, null },
                    { 34, 30, 0.0030000000000000001, 88.555999999999997, 3, "Shemar Schultz", 87.769999999999996, 35, 27, 0.0, 99.457999999999998, 0.056000000000000001, 0.025999999999999999, 0.0, 98.378, 80.771000000000001, 83.376999999999995, null },
                    { 35, 18, 0.002, 89.451999999999998, 2, "Kareem Zieme", 82.817999999999998, 34, 31, 0.0, 94.203999999999994, 0.055, 0.032000000000000001, 0.0, 74.468999999999994, 91.471999999999994, 75.881, null },
                    { 36, 27, 0.0030000000000000001, 52.073, 1, "Candace Kautzer", 55.302999999999997, 33, 33, 0.0, 58.097999999999999, 0.0089999999999999993, 0.0050000000000000001, 0.002, 56.802999999999997, 55.615000000000002, 56.719999999999999, null },
                    { 37, 29, 0.0050000000000000001, 91.106999999999999, 6, "Whitney Keeling", 85.649000000000001, 40, 37, 0.0, 93.228999999999999, 0.069000000000000006, 0.0030000000000000001, 0.0030000000000000001, 77.111000000000004, 83.825999999999993, 90.554000000000002, null },
                    { 38, 20, 0.002, 50.0, 4, "Gideon Armstrong", 50.0, 33, 29, 0.0, 46.110999999999997, 0.094, 0.070999999999999994, 0.0050000000000000001, 50.0, 50.0, 50.0, null },
                    { 39, 38, 0.0, 75.340000000000003, 4, "Tavares O'Connell", 70.561000000000007, 35, 27, 0.0, 100.0, 0.027, 0.014999999999999999, 0.0050000000000000001, 73.272000000000006, 64.924999999999997, 68.706000000000003, null },
                    { 40, 25, 0.0050000000000000001, 61.113, 2, "Claudia Runte", 62.179000000000002, 40, 33, 0.0, 83.641999999999996, 0.059999999999999998, 0.050000000000000003, 0.0030000000000000001, 62.597000000000001, 53.975999999999999, 71.031000000000006, null }
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
