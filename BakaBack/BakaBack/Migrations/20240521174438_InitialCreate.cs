using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakaBack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SportKey = table.Column<string>(type: "TEXT", nullable: false),
                    CommenceTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HomeTeam = table.Column<string>(type: "TEXT", nullable: false),
                    AwayTeam = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookmakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    MatchId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookmakers_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    BookmakerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Markets_Bookmakers_BookmakerId",
                        column: x => x.BookmakerId,
                        principalTable: "Bookmakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outcomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    MarketId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outcomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outcomes_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookmakers_MatchId",
                table: "Bookmakers",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_BookmakerId",
                table: "Markets",
                column: "BookmakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_MarketId",
                table: "Outcomes",
                column: "MarketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Outcomes");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Bookmakers");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
