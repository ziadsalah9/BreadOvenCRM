using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreadOven.Repository.Migrations
{
    /// <inheritdoc />
    public partial class cleancodeinit : Migration
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
                    OriginalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValuePercentage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valueYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valueMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valueDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valueHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionLineDepreciations", x => x.Id);
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
                name: "CostsAndDistrubutionfromitems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DistCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostsAndDistrubutionfromitems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostsAndDistrubutionfromitems_items_ItemId",
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
                    OperatingHoursQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    costsAndDistributionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unitProductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_unitProductions_CostsAndDistrubutionfromitems_costsAndDistributionId",
                        column: x => x.costsAndDistributionId,
                        principalTable: "CostsAndDistrubutionfromitems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostsAndDistrubutionfromitems_ItemId",
                table: "CostsAndDistrubutionfromitems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_items_factoryLinesId",
                table: "items",
                column: "factoryLinesId");

            migrationBuilder.CreateIndex(
                name: "IX_unitProductions_costsAndDistributionId",
                table: "unitProductions",
                column: "costsAndDistributionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionLineDepreciations");

            migrationBuilder.DropTable(
                name: "unitProductions");

            migrationBuilder.DropTable(
                name: "CostsAndDistrubutionfromitems");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "FactoryLines");
        }
    }
}
