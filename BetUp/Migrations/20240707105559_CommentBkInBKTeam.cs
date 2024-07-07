using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetUp.Migrations
{
    /// <inheritdoc />
    public partial class CommentBkInBKTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BKTeams_BKs_BkId",
                table: "BKTeams");

            migrationBuilder.DropIndex(
                name: "IX_BKTeams_BkId",
                table: "BKTeams");

            migrationBuilder.DropColumn(
                name: "BkId",
                table: "BKTeams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BkId",
                table: "BKTeams",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BKTeams_BkId",
                table: "BKTeams",
                column: "BkId");

            migrationBuilder.AddForeignKey(
                name: "FK_BKTeams_BKs_BkId",
                table: "BKTeams",
                column: "BkId",
                principalTable: "BKs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
