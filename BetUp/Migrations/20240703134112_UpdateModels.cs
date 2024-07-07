using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetUp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Player1Name",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Player2Name",
                table: "Matches");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Teams",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "Player1Name",
                table: "Matches",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Player2Name",
                table: "Matches",
                type: "text",
                nullable: true);
        }
    }
}
