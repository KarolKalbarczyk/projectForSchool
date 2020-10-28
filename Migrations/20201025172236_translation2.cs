using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_pl.Migrations
{
    public partial class translation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductHasPrices_PriceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PriceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "LangaugeId",
                table: "Translations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductHasPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductHasPrices_ProductId",
                table: "ProductHasPrices",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductHasPrices_Products_ProductId",
                table: "ProductHasPrices",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductHasPrices_Products_ProductId",
                table: "ProductHasPrices");

            migrationBuilder.DropIndex(
                name: "IX_ProductHasPrices_ProductId",
                table: "ProductHasPrices");

            migrationBuilder.DropColumn(
                name: "LangaugeId",
                table: "Translations");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductHasPrices");

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PriceId",
                table: "Products",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductHasPrices_PriceId",
                table: "Products",
                column: "PriceId",
                principalTable: "ProductHasPrices",
                principalColumn: "ProductHasPriceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
