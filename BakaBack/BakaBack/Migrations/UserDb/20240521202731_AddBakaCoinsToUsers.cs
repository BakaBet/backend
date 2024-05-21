using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakaBack.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class AddBakaCoinsToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BakaCoins",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BakaCoins",
                table: "AspNetUsers");
        }
    }
}
