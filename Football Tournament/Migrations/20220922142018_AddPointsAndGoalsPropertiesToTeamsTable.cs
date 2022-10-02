using Microsoft.EntityFrameworkCore.Migrations;

namespace Football_Tournament.Migrations
{
    public partial class AddPointsAndGoalsPropertiesToTeamsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fwr",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsAg",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsFwd",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Penalities",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fwr",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GoalsAg",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GoalsFwd",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Penalities",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Teams");
        }
    }
}
