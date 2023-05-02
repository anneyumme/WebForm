using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class PriceDatable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "price100",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "price50",
                table: "Products",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price100",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "price50",
                table: "Products");
        }
    }
}
