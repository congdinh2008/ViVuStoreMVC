using Microsoft.EntityFrameworkCore.Migrations;

namespace ViVuStoreMVC.Migrations
{
    public partial class UpdateBookOfTheWeekandInStockForBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Books",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBookOfTheWeek",
                table: "Books",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsBookOfTheWeek",
                table: "Books");
        }
    }
}
