using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetUp.Migrations
{
    /// <inheritdoc />
    public partial class AddMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BKMatchId = table.Column<Guid>(type: "uuid", nullable: false),
                    MatchId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchMapping_BKMatches_BKMatchId",
                        column: x => x.BKMatchId,
                        principalTable: "BKMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchMapping_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BKTeamId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMapping_BKTeams_BKTeamId",
                        column: x => x.BKTeamId,
                        principalTable: "BKTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMapping_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchMapping_BKMatchId",
                table: "MatchMapping",
                column: "BKMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchMapping_MatchId",
                table: "MatchMapping",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMapping_BKTeamId",
                table: "TeamMapping",
                column: "BKTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMapping_TeamId",
                table: "TeamMapping",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchMapping");

            migrationBuilder.DropTable(
                name: "TeamMapping");
        }
    }
}
