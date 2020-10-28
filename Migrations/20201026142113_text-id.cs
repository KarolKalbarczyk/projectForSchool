using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_pl.Migrations
{
    public partial class textid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TextId",
                table: "Translations",
                nullable: false,
                computedColumnSql: "COALESCE([OriginalId], [TranslationId])");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextId",
                table: "Translations");
        }
    }
}
