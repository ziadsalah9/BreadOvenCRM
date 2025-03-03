using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreadOven.Migrations
{
    /// <inheritdoc />
    public partial class updateitemwithhourlyoperatingrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "HourlyOperatingRate",
                table: "items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourlyOperatingRate",
                table: "items");
        }
    }
}
