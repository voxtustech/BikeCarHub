using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddIsTW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TWLatestNews_TWBrands_TwoWBrandId",
                table: "TWLatestNews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TWLatestNews",
                table: "TWLatestNews");

            migrationBuilder.RenameTable(
                name: "TWLatestNews",
                newName: "LatestNews");

            migrationBuilder.RenameIndex(
                name: "IX_TWLatestNews_TwoWBrandId",
                table: "LatestNews",
                newName: "IX_LatestNews_TwoWBrandId");

            migrationBuilder.AddColumn<bool>(
                name: "IsTwoWheeler",
                table: "LatestNews",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LatestNews",
                table: "LatestNews",
                column: "TWLatestNewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LatestNews_TWBrands_TwoWBrandId",
                table: "LatestNews",
                column: "TwoWBrandId",
                principalTable: "TWBrands",
                principalColumn: "TWBrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LatestNews_TWBrands_TwoWBrandId",
                table: "LatestNews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LatestNews",
                table: "LatestNews");

            migrationBuilder.DropColumn(
                name: "IsTwoWheeler",
                table: "LatestNews");

            migrationBuilder.RenameTable(
                name: "LatestNews",
                newName: "TWLatestNews");

            migrationBuilder.RenameIndex(
                name: "IX_LatestNews_TwoWBrandId",
                table: "TWLatestNews",
                newName: "IX_TWLatestNews_TwoWBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TWLatestNews",
                table: "TWLatestNews",
                column: "TWLatestNewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TWLatestNews_TWBrands_TwoWBrandId",
                table: "TWLatestNews",
                column: "TwoWBrandId",
                principalTable: "TWBrands",
                principalColumn: "TWBrandId");
        }
    }
}
