using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNutrientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "In100g",
                table: "Nutrients");

            migrationBuilder.DropColumn(
                name: "InCup",
                table: "Nutrients");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Nutrients");

            migrationBuilder.AddColumn<double>(
                name: "In100g",
                table: "ProductNutrients",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "InCup",
                table: "ProductNutrients",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "ProductNutrients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "In100g",
                table: "ProductNutrients");

            migrationBuilder.DropColumn(
                name: "InCup",
                table: "ProductNutrients");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "ProductNutrients");

            migrationBuilder.AddColumn<int>(
                name: "In100g",
                table: "Nutrients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InCup",
                table: "Nutrients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Nutrients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
