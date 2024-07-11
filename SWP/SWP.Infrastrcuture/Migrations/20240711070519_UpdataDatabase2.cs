using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdataDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "ProductNutrients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "ProductItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Nutrients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "MilkFunctions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "MilkBrands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "MilkBrands",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "ImageFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilkBrands_ImageId",
                table: "MilkBrands",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ImageId",
                table: "Companies",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_ImageFiles_ImageId",
                table: "Companies",
                column: "ImageId",
                principalTable: "ImageFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MilkBrands_ImageFiles_ImageId",
                table: "MilkBrands",
                column: "ImageId",
                principalTable: "ImageFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ImageFiles_ImageId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_MilkBrands_ImageFiles_ImageId",
                table: "MilkBrands");

            migrationBuilder.DropIndex(
                name: "IX_MilkBrands_ImageId",
                table: "MilkBrands");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ImageId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "ProductNutrients");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Nutrients");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "MilkFunctions");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "MilkBrands");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "MilkBrands");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "ImageFiles");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Companies");
        }
    }
}
