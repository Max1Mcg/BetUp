using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetUp.Migrations
{
    /// <inheritdoc />
    public partial class AddFKTeamBkMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Matches",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Team1Id",
                table: "BKMatches",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Team2Id",
                table: "BKMatches",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BKMatches_Team1Id",
                table: "BKMatches",
                column: "Team1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BKMatches_Team2Id",
                table: "BKMatches",
                column: "Team2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BKMatches_BKTeams_Team1Id",
                table: "BKMatches",
                column: "Team1Id",
                principalTable: "BKTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BKMatches_BKTeams_Team2Id",
                table: "BKMatches",
                column: "Team2Id",
                principalTable: "BKTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BKMatches_BKTeams_Team1Id",
                table: "BKMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_BKMatches_BKTeams_Team2Id",
                table: "BKMatches");

            migrationBuilder.DropIndex(
                name: "IX_BKMatches_Team1Id",
                table: "BKMatches");

            migrationBuilder.DropIndex(
                name: "IX_BKMatches_Team2Id",
                table: "BKMatches");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Team1Id",
                table: "BKMatches");

            migrationBuilder.DropColumn(
                name: "Team2Id",
                table: "BKMatches");
        }
    }
}
