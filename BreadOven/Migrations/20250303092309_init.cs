using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreadOven.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FactoryLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionLineDepreciations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionAgeYear = table.Column<int>(type: "int", nullable: false),
                    OriginalValue = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    ValuePercentage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valueYear = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    valueMonth = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    valueDay = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    valueHour = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionLineDepreciations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "typeOfCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeOfCosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnergyReq = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OperatingHours = table.Column<int>(type: "int", nullable: false),
                    Totalvalueofhoursdeprication = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HourlyOperatingRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    factoryLinesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_items_FactoryLines_factoryLinesId",
                        column: x => x.factoryLinesId,
                        principalTable: "FactoryLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distrubutionfromitems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    DistCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalOperatingSalary = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrubutionfromitems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distrubutionfromitems_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unitProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatingHoursQuantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    unitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitNumber = table.Column<int>(type: "int", nullable: false),
                    UnitValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                name: "IX_Distrubutionfromitems_ItemId",
                table: "Distrubutionfromitems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_items_factoryLinesId",
                table: "items",
                column: "factoryLinesId");

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
                name: "Distrubutionfromitems");

            migrationBuilder.DropTable(
                name: "ProductionLineDepreciations");

            migrationBuilder.DropTable(
                name: "unitProductions");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "typeOfCosts");

            migrationBuilder.DropTable(
                name: "FactoryLines");
        }
    }
}
