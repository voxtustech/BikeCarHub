using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnInTWImageColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BottomColorCode",
                table: "TWImageColorPrices",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageAltTag",
                table: "TWImageColorPrices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopColorCode",
                table: "TWImageColorPrices",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFWBrand",
                table: "TWBrands",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTWBrand",
                table: "TWBrands",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NewsSummary",
                table: "LatestNews",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NewsHeading",
                table: "LatestNews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BottomColorCode",
                table: "TWImageColorPrices");

            migrationBuilder.DropColumn(
                name: "ImageAltTag",
                table: "TWImageColorPrices");

            migrationBuilder.DropColumn(
                name: "TopColorCode",
                table: "TWImageColorPrices");

            migrationBuilder.DropColumn(
                name: "IsFWBrand",
                table: "TWBrands");

            migrationBuilder.DropColumn(
                name: "IsTWBrand",
                table: "TWBrands");

            migrationBuilder.AlterColumn<string>(
                name: "NewsSummary",
                table: "LatestNews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NewsHeading",
                table: "LatestNews",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
