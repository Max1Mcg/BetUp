using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetUp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BKTeams_Teams_LocalTeamId",
                table: "BKTeams");

            migrationBuilder.DropIndex(
                name: "IX_BKTeams_LocalTeamId",
                table: "BKTeams");

            migrationBuilder.DropColumn(
                name: "LocalTeamId",
                table: "BKTeams");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.AddColumn<Guid>(
                name: "LocalTeamId",
                table: "BKTeams",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BKTeams_LocalTeamId",
                table: "BKTeams",
                column: "LocalTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_BKTeams_Teams_LocalTeamId",
                table: "BKTeams",
                column: "LocalTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
