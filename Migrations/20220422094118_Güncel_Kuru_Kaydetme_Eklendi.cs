using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Güncel_Kuru_Kaydetme_Eklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "O_Günki_Kur",
                table: "Toplam_Maliyet_Saveds",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Parça_Toplam_Maliyeti_Güncel_Kur",
                table: "Toplam_Maliyet_Saveds",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "O_Günki_Kur",
                table: "Toplam_Maliyet_Saveds");

            migrationBuilder.DropColumn(
                name: "Parça_Toplam_Maliyeti_Güncel_Kur",
                table: "Toplam_Maliyet_Saveds");
        }
    }
}
