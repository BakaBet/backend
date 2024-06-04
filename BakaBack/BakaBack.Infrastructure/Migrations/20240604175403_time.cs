using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakaBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "SportEvents",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Bets",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Gains",
                table: "Bets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnded",
                table: "Bets",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Gains",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "IsEnded",
                table: "Bets");
        }
    }
}
