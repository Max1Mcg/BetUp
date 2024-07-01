using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetUp.Migrations
{
    /// <inheritdoc />
    public partial class deleteFKBKTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BKTeams_Teams_FKTeam",
                table: "BKTeams");

            migrationBuilder.RenameColumn(
                name: "FKTeam",
                table: "BKTeams",
                newName: "LocalTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_BKTeams_FKTeam",
                table: "BKTeams",
                newName: "IX_BKTeams_LocalTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_BKTeams_Teams_LocalTeamId",
                table: "BKTeams",
                column: "LocalTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BKTeams_Teams_LocalTeamId",
                table: "BKTeams");

            migrationBuilder.RenameColumn(
                name: "LocalTeamId",
                table: "BKTeams",
                newName: "FKTeam");

            migrationBuilder.RenameIndex(
                name: "IX_BKTeams_LocalTeamId",
                table: "BKTeams",
                newName: "IX_BKTeams_FKTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_BKTeams_Teams_FKTeam",
                table: "BKTeams",
                column: "FKTeam",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
