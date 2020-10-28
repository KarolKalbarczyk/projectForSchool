using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_pl.Migrations
{
    public partial class translation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductHasPrice_PriceId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductHasPrice",
                table: "ProductHasPrice");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductHasPrice",
                newName: "ProductHasPrices");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DescriptionTranslationId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductHasPrices",
                table: "ProductHasPrices",
                column: "ProductHasPriceId");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    TranslationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalId = table.Column<int>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.TranslationId);
                    table.ForeignKey(
                        name: "FK_Translations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Translations_Translations_OriginalId",
                        column: x => x.OriginalId,
                        principalTable: "Translations",
                        principalColumn: "TranslationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DescriptionTranslationId",
                table: "Products",
                column: "DescriptionTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_LanguageId",
                table: "Translations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_OriginalId",
                table: "Translations",
                column: "OriginalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Translations_DescriptionTranslationId",
                table: "Products",
                column: "DescriptionTranslationId",
                principalTable: "Translations",
                principalColumn: "TranslationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductHasPrices_PriceId",
                table: "Products",
                column: "PriceId",
                principalTable: "ProductHasPrices",
                principalColumn: "ProductHasPriceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Translations_DescriptionTranslationId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductHasPrices_PriceId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Products_DescriptionTranslationId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductHasPrices",
                table: "ProductHasPrices");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DescriptionTranslationId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductHasPrices",
                newName: "ProductHasPrice");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductHasPrice",
                table: "ProductHasPrice",
                column: "ProductHasPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductHasPrice_PriceId",
                table: "Products",
                column: "PriceId",
                principalTable: "ProductHasPrice",
                principalColumn: "ProductHasPriceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
