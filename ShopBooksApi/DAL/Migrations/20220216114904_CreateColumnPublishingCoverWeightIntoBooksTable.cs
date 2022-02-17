using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBooksApi.Migrations
{
    public partial class CreateColumnPublishingCoverWeightIntoBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Books",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Publishing",
                table: "Books",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "Books",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Publishing",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Books");
        }
    }
}
