using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class addSEOinTWVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SEO_Description",
                table: "TWVarients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEO_Keywords",
                table: "TWVarients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEO_Title",
                table: "TWVarients",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SEO_Description",
                table: "TWVarients");

            migrationBuilder.DropColumn(
                name: "SEO_Keywords",
                table: "TWVarients");

            migrationBuilder.DropColumn(
                name: "SEO_Title",
                table: "TWVarients");
        }
    }
}
