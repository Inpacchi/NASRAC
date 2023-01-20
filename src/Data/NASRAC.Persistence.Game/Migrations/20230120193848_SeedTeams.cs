using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NASRAC.Persistence.Game.Migrations
{
    /// <inheritdoc />
    public partial class SeedTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Team_TeamId",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Season_SeasonId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Manufacturer_ManufacturerId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropIndex(
                name: "IX_Team_ManufacturerId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_SeasonId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Team");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Driver",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
                table: "Team",
                columns: new[] { "Id", "EquipmentRating", "Name", "OverallRating", "OwnerId", "PerformanceRating", "PersonnelRating" },
                values: new object[,]
                {
                    { 1, 94.0, "Endless Galaxy Motorsports", 83.0, null, 85.0, 70.0 },
                    { 2, 69.0, "Ortega Racing", 78.0, null, 81.0, 83.0 },
                    { 3, 87.0, "AJ Cruz Motorsports", 78.0, null, 81.0, 65.0 }
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

            migrationBuilder.CreateIndex(
                name: "IX_TeamManufacturers_ManufacturerId",
                table: "TeamManufacturers",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamManufacturers_TeamId",
                table: "TeamManufacturers",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Team_TeamId",
                table: "Driver",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Team_TeamId",
                table: "Driver");

            migrationBuilder.DropTable(
                name: "TeamManufacturers");

            migrationBuilder.DeleteData(
                table: "Driver",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Driver",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Driver",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Team",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Driver",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SeriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Season_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Season",
                columns: new[] { "Id", "EndDate", "Name", "SeriesId", "StartDate" },
                values: new object[] { 1, new DateOnly(2022, 11, 6), "2022", 1, new DateOnly(2022, 2, 20) });

            migrationBuilder.CreateIndex(
                name: "IX_Team_ManufacturerId",
                table: "Team",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_SeasonId",
                table: "Schedule",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Season_SeriesId",
                table: "Season",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Team_TeamId",
                table: "Driver",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Season_SeasonId",
                table: "Schedule",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Manufacturer_ManufacturerId",
                table: "Team",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
