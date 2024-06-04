using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakaBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class lc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Participations",
                table: "Participations");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Participations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "ProposalEventId",
                table: "LifeBets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProposalUserId",
                table: "LifeBets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participations",
                table: "Participations",
                columns: new[] { "UserId", "Stake" });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    EventId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => new { x.UserId, x.EventId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_LifeBets_ProposalUserId_ProposalEventId",
                table: "LifeBets",
                columns: new[] { "ProposalUserId", "ProposalEventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_LifeBets_Proposals_ProposalUserId_ProposalEventId",
                table: "LifeBets",
                columns: new[] { "ProposalUserId", "ProposalEventId" },
                principalTable: "Proposals",
                principalColumns: new[] { "UserId", "EventId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LifeBets_Proposals_ProposalUserId_ProposalEventId",
                table: "LifeBets");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participations",
                table: "Participations");

            migrationBuilder.DropIndex(
                name: "IX_LifeBets_ProposalUserId_ProposalEventId",
                table: "LifeBets");

            migrationBuilder.DropColumn(
                name: "ProposalEventId",
                table: "LifeBets");

            migrationBuilder.DropColumn(
                name: "ProposalUserId",
                table: "LifeBets");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Participations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participations",
                table: "Participations",
                column: "Id");
        }
    }
}
