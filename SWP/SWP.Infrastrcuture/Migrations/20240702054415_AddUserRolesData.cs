using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRolesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var id = new Guid();
            string sqlQuery = String.Format(@"INSERT INTO [dbo].[AspNetRoles]([Id],[Name]) VALUES ('{0}', 'Admin')", id.ToString());
            migrationBuilder.Sql(sqlQuery);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
