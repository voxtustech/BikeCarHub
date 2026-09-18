using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddHeroSlides : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroSlides",
                columns: table => new
                {
                    HeroSlideId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(200)", nullable: false),
                    Subtitle = table.Column<string>(type: "varchar(500)", nullable: false),
                    ImageURL = table.Column<string>(type: "varchar(500)", nullable: false),
                    Badge = table.Column<string>(type: "varchar(100)", nullable: true),
                    Featured = table.Column<string>(type: "varchar(200)", nullable: true),
                    Price = table.Column<string>(type: "varchar(100)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSlides", x => x.HeroSlideId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroSlides");
        }
    }
}
