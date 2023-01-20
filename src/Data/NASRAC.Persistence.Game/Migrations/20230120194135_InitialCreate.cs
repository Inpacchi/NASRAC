using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Tier = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Budget = table.Column<double>(type: "REAL", nullable: false),
                    PrestigeLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Length = table.Column<double>(type: "REAL", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    EquipmentRating = table.Column<double>(type: "REAL", nullable: false),
                    PersonnelRating = table.Column<double>(type: "REAL", nullable: false),
                    PerformanceRating = table.Column<double>(type: "REAL", nullable: false),
                    OverallRating = table.Column<double>(type: "REAL", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Laps = table.Column<int>(type: "INTEGER", nullable: false),
                    Stages = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    OverallRating = table.Column<double>(type: "REAL", nullable: false),
                    PerformanceRating = table.Column<double>(type: "REAL", nullable: false),
                    ShortTrackRating = table.Column<double>(type: "REAL", nullable: false),
                    IntermediateTrackRating = table.Column<double>(type: "REAL", nullable: false),
                    SuperspeedwayTrackRating = table.Column<double>(type: "REAL", nullable: false),
                    RoadTrackRating = table.Column<double>(type: "REAL", nullable: false),
                    PotentialRating = table.Column<double>(type: "REAL", nullable: false),
                    ProgressionRate = table.Column<double>(type: "REAL", nullable: false),
                    RegressionRate = table.Column<double>(type: "REAL", nullable: false),
                    PeakAgeStart = table.Column<int>(type: "INTEGER", nullable: false),
                    PeakAgeEnd = table.Column<int>(type: "INTEGER", nullable: false),
                    RetirementFactor = table.Column<double>(type: "REAL", nullable: false),
                    DNFOdds = table.Column<double>(type: "REAL", nullable: false),
                    Marketability = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Driver_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalAmountLoaned = table.Column<double>(type: "REAL", nullable: false),
                    TotalAmountPaid = table.Column<double>(type: "REAL", nullable: false),
                    MaturityDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InterestRate = table.Column<double>(type: "REAL", nullable: false),
                    LenderId = table.Column<int>(type: "INTEGER", nullable: false),
                    BorrowerId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    Balance = table.Column<double>(type: "REAL", nullable: false),
                    StatementDate = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RaceNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    RaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeasonId = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "QualifyingResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    RaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    DriverId = table.Column<int>(type: "INTEGER", nullable: false),
                    FastestTime = table.Column<double>(type: "REAL", nullable: false),
                    TopSpeed = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualifyingResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualifyingResults_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QualifyingResults_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stage = table.Column<int>(type: "INTEGER", nullable: false),
                    StartPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    FinishPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    LowestPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    HighestPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    AveragePosition = table.Column<int>(type: "INTEGER", nullable: false),
                    Top15LapCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Top15LapPercentage = table.Column<int>(type: "INTEGER", nullable: false),
                    LapLedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LapLedPercentage = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalLapCount = table.Column<int>(type: "INTEGER", nullable: false),
                    RaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    DriverId = table.Column<int>(type: "INTEGER", nullable: false),
                    FastestTime = table.Column<double>(type: "REAL", nullable: false),
                    TopSpeed = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceResults_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceResults_Race_RaceId",
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
                    { 1, 94.0, "Endless Galaxy Motorsports", 83.0, null, 85.0, 70.0 },
                    { 2, 69.0, "Ortega Racing", 78.0, null, 81.0, 83.0 },
                    { 3, 87.0, "AJ Cruz Motorsports", 78.0, null, 81.0, 65.0 }
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
                    { 1, 26, 0.025000000000000001, 73.0, 6, "Yovarni Yearwood", 80.0, 33, 28, 86.0, 85.0, 0.0, 2.0, 0.0050000000000000001, 85.0, 75.0, 80.0, 1 },
                    { 2, 26, 0.025000000000000001, 83.0, 7, "Angel Ortega", 83.0, 45, 26, 89.0, 92.0, 4.0, 2.0, 0.0050000000000000001, 86.0, 78.0, 77.0, 2 },
                    { 3, 26, 0.025000000000000001, 73.0, 5, "Agustin Cruz, Jr.", 70.0, 32, 28, 69.0, 72.0, 5.0, 1.0, 0.0050000000000000001, 65.0, 69.0, 76.0, 3 }
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
                table: "TeamManufacturers",
                columns: new[] { "Id", "ManufacturerId", "TeamId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 4, 1 },
                    { 3, 1, 2 },
                    { 4, 2, 2 },
                    { 5, 5, 3 },
                    { 6, 6, 3 }
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
                name: "IX_QualifyingResults_DriverId",
                table: "QualifyingResults",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_QualifyingResults_RaceId",
                table: "QualifyingResults",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Race_TrackId",
                table: "Race",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_DriverId",
                table: "RaceResults",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_RaceId",
                table: "RaceResults",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_RaceId",
                table: "Schedule",
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
                name: "QualifyingResults");

            migrationBuilder.DropTable(
                name: "RaceResults");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Series");

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
