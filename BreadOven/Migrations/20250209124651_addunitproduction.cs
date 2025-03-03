using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreadOven.Migrations
{
    /// <inheritdoc />
    public partial class addunitproduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "unitProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatingHoursQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitNumber = table.Column<int>(type: "int", nullable: false),
                    UnitValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    costsId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unitProductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_unitProductions_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_unitProductions_typeOfCosts_costsId",
                        column: x => x.costsId,
                        principalTable: "typeOfCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_unitProductions_costsId",
                table: "unitProductions",
                column: "costsId");

            migrationBuilder.CreateIndex(
                name: "IX_unitProductions_ItemId",
                table: "unitProductions",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "unitProductions");
        }
    }
}
