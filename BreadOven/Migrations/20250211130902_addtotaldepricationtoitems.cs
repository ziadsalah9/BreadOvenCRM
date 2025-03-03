using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreadOven.Migrations
{
    /// <inheritdoc />
    public partial class addtotaldepricationtoitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Totalvalueofhoursdeprication",
                table: "items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Totalvalueofhoursdeprication",
                table: "items");
        }
    }
}
