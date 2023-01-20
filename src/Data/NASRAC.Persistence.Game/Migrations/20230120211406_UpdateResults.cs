using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NASRAC.Persistence.Game.Migrations
{
    /// <inheritdoc />
    public partial class UpdateResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stage",
                table: "RaceResults",
                newName: "Stage2Position");

            migrationBuilder.RenameColumn(
                name: "AveragePosition",
                table: "RaceResults",
                newName: "Stage1Position");

            migrationBuilder.AddColumn<int>(
                name: "AverageRacePosition",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AverageRunningPosition",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CautionLapCount",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CautionLapPercentage",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CautionsCaused",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DNFPosition",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRacePosition",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "AverageRunningPosition",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "CautionLapCount",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "CautionLapPercentage",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "CautionsCaused",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "DNFPosition",
                table: "RaceResults");

            migrationBuilder.RenameColumn(
                name: "Stage2Position",
                table: "RaceResults",
                newName: "Stage");

            migrationBuilder.RenameColumn(
                name: "Stage1Position",
                table: "RaceResults",
                newName: "AveragePosition");
        }
    }
}
