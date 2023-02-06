using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetNewsAgregator.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AddRssUrlToSource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RssUrl",
                table: "Sources",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RssUrl",
                table: "Sources");
        }
    }
}
