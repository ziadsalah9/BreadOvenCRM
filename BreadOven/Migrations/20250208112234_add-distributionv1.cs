using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreadOven.Migrations
{
    /// <inheritdoc />
    public partial class adddistributionv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distrubutionfromitems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixedSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VariableSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalOperatingSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Distrubutionfromitems_ItemId",
                table: "Distrubutionfromitems",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distrubutionfromitems");
        }
    }
}
