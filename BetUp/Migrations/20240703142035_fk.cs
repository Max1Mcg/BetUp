using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetUp.Migrations
{
    /// <inheritdoc />
    public partial class fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_LocalTeam1Id",
                table: "Matches");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_LocalTeam1Id",
                table: "Matches",
                column: "LocalTeam1Id",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_LocalTeam1Id",
                table: "Matches");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_LocalTeam1Id",
                table: "Matches",
                column: "LocalTeam1Id",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
