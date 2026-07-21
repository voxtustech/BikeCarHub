using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddImagesColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEV",
                table: "ValueForMoney");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "ValueForMoney",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "ValueForMoney");

            migrationBuilder.AddColumn<bool>(
                name: "IsEV",
                table: "ValueForMoney",
                type: "bit",
                nullable: true);
        }
    }
}
