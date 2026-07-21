using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TWChassisAndSuspensions",
                columns: table => new
                {
                    TWChassisAndSuspensionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyGraphics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWChassisAndSuspensions", x => x.TWChassisAndSuspensionId);
                    table.ForeignKey(
                        name: "FK_TWChassisAndSuspensions_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWChassisAndSuspensions_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TWChassisAndSuspensions_TwoWheelerId",
                table: "TWChassisAndSuspensions",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWChassisAndSuspensions_TWVarientId",
                table: "TWChassisAndSuspensions",
                column: "TWVarientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TWChassisAndSuspensions");
        }
    }
}
