using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetUp.Migrations
{
    /// <inheritdoc />
    public partial class replaceAllCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BKMatches_Matches_LocalMatchId",
                table: "BKMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_BKTeams_BKs_BkId",
                table: "BKTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_BKTeams_Teams_LocalTeamId",
                table: "BKTeams");

            migrationBuilder.AddForeignKey(
                name: "FK_BKMatches_Matches_LocalMatchId",
                table: "BKMatches",
                column: "LocalMatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BKTeams_BKs_BkId",
                table: "BKTeams",
                column: "BkId",
                principalTable: "BKs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BKTeams_Teams_LocalTeamId",
                table: "BKTeams",
                column: "LocalTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BKMatches_Matches_LocalMatchId",
                table: "BKMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_BKTeams_BKs_BkId",
                table: "BKTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_BKTeams_Teams_LocalTeamId",
                table: "BKTeams");

            migrationBuilder.AddForeignKey(
                name: "FK_BKMatches_Matches_LocalMatchId",
                table: "BKMatches",
                column: "LocalMatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BKTeams_BKs_BkId",
                table: "BKTeams",
                column: "BkId",
                principalTable: "BKs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BKTeams_Teams_LocalTeamId",
                table: "BKTeams",
                column: "LocalTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
