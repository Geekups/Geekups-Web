using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayanaWeb.Shared.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class migmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                schema: "dbo",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                schema: "dbo",
                table: "Post");
        }
    }
}
