using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAspNetCoreApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class TypoFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isPublish",
                table: "Products",
                newName: "IsPublish");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPublish",
                table: "Products",
                newName: "isPublish");
        }
    }
}
