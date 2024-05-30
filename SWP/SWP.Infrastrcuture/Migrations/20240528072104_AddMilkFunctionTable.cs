using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMilkFunctionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MilkFunctions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilkFunctionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilkFunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilkBrandFunctions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilkBrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilkFunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilkBrandFunctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilkBrandFunctions_MilkBrands_MilkBrandId",
                        column: x => x.MilkBrandId,
                        principalTable: "MilkBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MilkBrandFunctions_MilkFunctions_MilkFunctionId",
                        column: x => x.MilkFunctionId,
                        principalTable: "MilkFunctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MilkBrandFunctions_MilkBrandId",
                table: "MilkBrandFunctions",
                column: "MilkBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_MilkBrandFunctions_MilkFunctionId",
                table: "MilkBrandFunctions",
                column: "MilkFunctionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MilkBrandFunctions");

            migrationBuilder.DropTable(
                name: "MilkFunctions");
        }
    }
}
