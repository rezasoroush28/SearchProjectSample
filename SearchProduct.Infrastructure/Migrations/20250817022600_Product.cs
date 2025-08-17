using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchProduct.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ProductVariant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_ProductId1",
                table: "ProductVariant",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariant_Product_ProductId1",
                table: "ProductVariant",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariant_Product_ProductId1",
                table: "ProductVariant");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariant_ProductId1",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductVariant");
        }
    }
}
