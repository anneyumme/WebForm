using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeyPRoduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "brandId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_brandId",
                table: "Products",
                column: "brandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_brandId",
                table: "Products",
                column: "brandId",
                principalTable: "Brands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_brandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_brandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "brandId",
                table: "Products");
        }
    }
}
