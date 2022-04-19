using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class BisilerDenendi22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bağlantı_Elemanı_Adı",
                table: "Bağlantı_Elemanı_Saved_Rows",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bağlantı_Elemanı_Adı",
                table: "Bağlantı_Elemanı_Saved_Rows");
        }
    }
}
