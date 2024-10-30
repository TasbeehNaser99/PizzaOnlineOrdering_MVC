using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza.PL.Data.Migrations
{
    /// <inheritdoc />
    public partial class addImgNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Pastas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Drinks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Chefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Burgers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Pastas");

            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Chefs");

            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Burgers");
        }
    }
}
