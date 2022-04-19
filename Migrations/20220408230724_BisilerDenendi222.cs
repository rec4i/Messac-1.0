using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class BisilerDenendi222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Kaynak_birimi",
                table: "Kaplama_Maliyeti_Saved_Rows",
                newName: "Kaplama_Birimi");

            migrationBuilder.RenameColumn(
                name: "Kaynak_Maliyeti_Saved_Id",
                table: "Kaplama_Maliyeti_Saved_Rows",
                newName: "Kaplama_Maliyeti_Saved_Id");

            migrationBuilder.RenameColumn(
                name: "Kaynak_Adı",
                table: "Kaplama_Maliyeti_Saved_Rows",
                newName: "Kaplama_Adı");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Kaplama_Maliyeti_Saved_Id",
                table: "Kaplama_Maliyeti_Saved_Rows",
                newName: "Kaynak_Maliyeti_Saved_Id");

            migrationBuilder.RenameColumn(
                name: "Kaplama_Birimi",
                table: "Kaplama_Maliyeti_Saved_Rows",
                newName: "Kaynak_birimi");

            migrationBuilder.RenameColumn(
                name: "Kaplama_Adı",
                table: "Kaplama_Maliyeti_Saved_Rows",
                newName: "Kaynak_Adı");
        }
    }
}
