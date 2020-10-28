using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_pl.Migrations
{
    public partial class spellingerror : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Languages_LanguageId",
                table: "Translations");

            migrationBuilder.DropColumn(
                name: "LangaugeId",
                table: "Translations");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Translations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Languages_LanguageId",
                table: "Translations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Languages_LanguageId",
                table: "Translations");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Translations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "LangaugeId",
                table: "Translations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TextId",
                table: "Translations",
                type: "int",
                nullable: false,
                computedColumnSql: "NVL([OriginalId], [TranslationId])",
                oldClrType: typeof(int),
                oldComputedColumnSql: "COALESCE([OriginalId], [TranslationId])");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Languages_LanguageId",
                table: "Translations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
