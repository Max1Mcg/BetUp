using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetUp.Migrations
{
    /// <inheritdoc />
    public partial class DeleteLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BKMatches_Matches_LocalMatchId",
                table: "BKMatches");

            migrationBuilder.DropIndex(
                name: "IX_BKMatches_LocalMatchId",
                table: "BKMatches");

            migrationBuilder.DropColumn(
                name: "LocalMatchId",
                table: "BKMatches");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocalMatchId",
                table: "BKMatches",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BKMatches_LocalMatchId",
                table: "BKMatches",
                column: "LocalMatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_BKMatches_Matches_LocalMatchId",
                table: "BKMatches",
                column: "LocalMatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
