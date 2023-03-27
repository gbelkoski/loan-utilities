using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceUtilities.Data.Migrations
{
    public partial class GlobalSettingsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "GlobalSettings",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                MaxAllowedInterestPercentage = table.Column<decimal>(nullable: false)
            },
            schema: "dbo",
            constraints: table =>
            {
                table.PrimaryKey("PK_GlobalSettings", x => x.Id);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("GlobalSettings");
        }
    }
}
