using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NASRAC.Persistence.Game.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScheduleDate",
                table: "Schedule",
                newName: "Date");

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
                table: "Season",
                columns: new[] { "Id", "EndDate", "Name", "SeriesId", "StartDate" },
                values: new object[] { 1, new DateOnly(2022, 11, 6), "2022", 1, new DateOnly(2022, 2, 20) });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Season",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Schedule",
                newName: "ScheduleDate");
        }
    }
}
