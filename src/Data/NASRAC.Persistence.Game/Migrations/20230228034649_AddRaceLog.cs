using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NASRAC.Persistence.Game.Migrations
{
    /// <inheritdoc />
    public partial class AddRaceLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LapLedPercentage",
                table: "RaceResults",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "CurrentPosition",
                table: "RaceResults",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DNFOdds",
                table: "RaceResults",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RaceResults",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "DriverRating",
                table: "RaceResults",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRunning",
                table: "RaceResults",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPosition",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "DNFOdds",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "DriverRating",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "IsRunning",
                table: "RaceResults");

            migrationBuilder.AlterColumn<int>(
                name: "LapLedPercentage",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
