using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreadOven.Migrations
{
    /// <inheritdoc />
    public partial class updateUnitProduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_unitProductions_items_ItemId",
                table: "unitProductions");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "unitProductions",
                newName: "costsAndDistributionId");

            migrationBuilder.RenameIndex(
                name: "IX_unitProductions_ItemId",
                table: "unitProductions",
                newName: "IX_unitProductions_costsAndDistributionId");

            migrationBuilder.AddForeignKey(
                name: "FK_unitProductions_CostsAndDistrubutionfromitems_costsAndDistributionId",
                table: "unitProductions",
                column: "costsAndDistributionId",
                principalTable: "CostsAndDistrubutionfromitems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_unitProductions_CostsAndDistrubutionfromitems_costsAndDistributionId",
                table: "unitProductions");

            migrationBuilder.RenameColumn(
                name: "costsAndDistributionId",
                table: "unitProductions",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_unitProductions_costsAndDistributionId",
                table: "unitProductions",
                newName: "IX_unitProductions_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_unitProductions_items_ItemId",
                table: "unitProductions",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
