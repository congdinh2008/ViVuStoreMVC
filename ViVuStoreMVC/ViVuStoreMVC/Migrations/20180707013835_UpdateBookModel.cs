using Microsoft.EntityFrameworkCore.Migrations;

namespace ViVuStoreMVC.Migrations
{
    public partial class UpdateBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "TotalPages",
                table: "Books",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPages",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPages",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Books",
                newName: "TotalPages");

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Books",
                nullable: false,
                defaultValue: false);
        }
    }
}
