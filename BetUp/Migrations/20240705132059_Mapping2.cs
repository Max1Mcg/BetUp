using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetUp.Migrations
{
    /// <inheritdoc />
    public partial class Mapping2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeamMapping_BKTeamId",
                table: "TeamMapping");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMapping_BKTeamId_TeamId",
                table: "TeamMapping",
                columns: new[] { "BKTeamId", "TeamId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeamMapping_BKTeamId_TeamId",
                table: "TeamMapping");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMapping_BKTeamId",
                table: "TeamMapping",
                column: "BKTeamId");
        }
    }
}
