using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NASRAC.Persistence.Game.Migrations
{
    /// <inheritdoc />
    public partial class FixRaceLogTableAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Id",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "QualifyingResults",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "RaceLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    RaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    DriverId = table.Column<int>(type: "INTEGER", nullable: false),
                    FastestTime = table.Column<double>(type: "REAL", nullable: false),
                    TopSpeed = table.Column<double>(type: "REAL", nullable: false),
                    StartPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    FinishPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    LowestPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    HighestPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageRacePosition = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageRunningPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    Stage1Position = table.Column<int>(type: "INTEGER", nullable: false),
                    Stage2Position = table.Column<int>(type: "INTEGER", nullable: false),
                    DNFPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    Top15LapCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Top15LapPercentage = table.Column<int>(type: "INTEGER", nullable: false),
                    LapLedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LapLedPercentage = table.Column<int>(type: "INTEGER", nullable: true),
                    CautionLapCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CautionLapPercentage = table.Column<int>(type: "INTEGER", nullable: false),
                    CautionsCaused = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalLapCount = table.Column<int>(type: "INTEGER", nullable: false),
                    DriverRating = table.Column<double>(type: "REAL", nullable: false),
                    DNFOdds = table.Column<double>(type: "REAL", nullable: false),
                    IsRunning = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentPosition = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_RaceLog_DriverId",
                table: "RaceLog",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceLog_RaceId",
                table: "RaceLog",
                column: "RaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceLog");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "QualifyingResults",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
