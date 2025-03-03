using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreadOven.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDistrbutionfromItemsTOCostsAndDistribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distrubutionfromitems_items_ItemId",
                table: "Distrubutionfromitems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Distrubutionfromitems",
                table: "Distrubutionfromitems");

            migrationBuilder.RenameTable(
                name: "Distrubutionfromitems",
                newName: "CostsAndDistrubutionfromitems");

            migrationBuilder.RenameIndex(
                name: "IX_Distrubutionfromitems_ItemId",
                table: "CostsAndDistrubutionfromitems",
                newName: "IX_CostsAndDistrubutionfromitems_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostsAndDistrubutionfromitems",
                table: "CostsAndDistrubutionfromitems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CostsAndDistrubutionfromitems_items_ItemId",
                table: "CostsAndDistrubutionfromitems",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostsAndDistrubutionfromitems_items_ItemId",
                table: "CostsAndDistrubutionfromitems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CostsAndDistrubutionfromitems",
                table: "CostsAndDistrubutionfromitems");

            migrationBuilder.RenameTable(
                name: "CostsAndDistrubutionfromitems",
                newName: "Distrubutionfromitems");

            migrationBuilder.RenameIndex(
                name: "IX_CostsAndDistrubutionfromitems_ItemId",
                table: "Distrubutionfromitems",
                newName: "IX_Distrubutionfromitems_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Distrubutionfromitems",
                table: "Distrubutionfromitems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Distrubutionfromitems_items_ItemId",
                table: "Distrubutionfromitems",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
