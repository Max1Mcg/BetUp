using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetUp.Migrations
{
    /// <inheritdoc />
    public partial class AddBksTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocalTeam1Id",
                table: "Matches",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LocalTeam2Id",
                table: "Matches",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BkId",
                table: "BKTeams",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BKMatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Player1Odds = table.Column<double>(type: "double precision", nullable: true),
                    Player2Odds = table.Column<double>(type: "double precision", nullable: true),
                    LocalMatchId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BKMatches_Matches_LocalMatchId",
                        column: x => x.LocalMatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BKs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LocalTeam1Id",
                table: "Matches",
                column: "LocalTeam1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LocalTeam2Id",
                table: "Matches",
                column: "LocalTeam2Id");

            migrationBuilder.CreateIndex(
                name: "IX_BKTeams_BkId",
                table: "BKTeams",
                column: "BkId");

            migrationBuilder.CreateIndex(
                name: "IX_BKMatches_LocalMatchId",
                table: "BKMatches",
                column: "LocalMatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_BKTeams_BKs_BkId",
                table: "BKTeams",
                column: "BkId",
                principalTable: "BKs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_LocalTeam1Id",
                table: "Matches",
                column: "LocalTeam1Id",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_LocalTeam2Id",
                table: "Matches",
                column: "LocalTeam2Id",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BKTeams_BKs_BkId",
                table: "BKTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_LocalTeam1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_LocalTeam2Id",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "BKMatches");

            migrationBuilder.DropTable(
                name: "BKs");

            migrationBuilder.DropIndex(
                name: "IX_Matches_LocalTeam1Id",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_LocalTeam2Id",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_BKTeams_BkId",
                table: "BKTeams");

            migrationBuilder.DropColumn(
                name: "LocalTeam1Id",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "LocalTeam2Id",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "BkId",
                table: "BKTeams");
        }
    }
}
