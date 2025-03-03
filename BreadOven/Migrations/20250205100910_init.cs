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
                name: "ProductionLineDepreciations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionAgeYear = table.Column<int>(type: "int", nullable: false),
                    OriginalValue = table.Column<int>(type: "int", nullable: false),
                    ValuePercentage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valueYear = table.Column<int>(type: "int", nullable: false),
                    valueMonth = table.Column<int>(type: "int", nullable: false),
                    valueDay = table.Column<int>(type: "int", nullable: false),
                    valueHour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionLineDepreciations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionLineDepreciations");
        }
    }
}
