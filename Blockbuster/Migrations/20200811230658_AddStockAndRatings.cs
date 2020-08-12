using Microsoft.EntityFrameworkCore.Migrations;

namespace Blockbuster.Migrations
{
    public partial class AddStockAndRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ratings",
                table: "Videos",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Videos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Videos",
                newName: "Ratings");
        }
    }
}
