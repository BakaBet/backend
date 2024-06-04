using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakaBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class lb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LifeBets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeBets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Stake = table.Column<decimal>(type: "TEXT", nullable: false),
                    Odds = table.Column<decimal>(type: "TEXT", nullable: false),
                    LifeBetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participations_LifeBets_LifeBetId",
                        column: x => x.LifeBetId,
                        principalTable: "LifeBets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participations_LifeBetId",
                table: "Participations",
                column: "LifeBetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "LifeBets");
        }
    }
}
