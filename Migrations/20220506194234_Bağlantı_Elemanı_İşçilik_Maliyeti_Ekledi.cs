using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Bağlantı_Elemanı_İşçilik_Maliyeti_Ekledi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "İşçilik_Maliyeti",
                table: "baglantıElemanlarıs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "İşçilik_Maliyeti",
                table: "baglantıElemanlarıs");
        }
    }
}
