using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class ParcalarRevizeYapışldı : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Parça_Id",
                table: "Malzeme_Maliyeti_Saveds",
                newName: "Revize_Id");

            migrationBuilder.RenameColumn(
                name: "Parça_Id",
                table: "Kesim_Maliyeti_Saveds",
                newName: "Revize_Id");

            migrationBuilder.RenameColumn(
                name: "Parça_Id",
                table: "Kaynak_Maliyeti_Saveds",
                newName: "Revize_Id");

            migrationBuilder.RenameColumn(
                name: "Parça_Id",
                table: "Dıs_Operasyon_Maliyeti_Saveds",
                newName: "Revize_Id");

            migrationBuilder.RenameColumn(
                name: "Parça_Id",
                table: "Büküm_Maliyeti_Saved_Uzunluks",
                newName: "Revize_Id");

            migrationBuilder.RenameColumn(
                name: "Parça_Id",
                table: "Büküm_Maliyeti_Saved_Ağırlıks",
                newName: "Revize_Id");

            migrationBuilder.RenameColumn(
                name: "Parça_Id",
                table: "Büküm_Maliyeti_Saved_Adets",
                newName: "Revize_Id");

            migrationBuilder.RenameColumn(
                name: "Parça_Id",
                table: "Bağlantı_Elemanı_Saveds",
                newName: "Revize_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Revize_Id",
                table: "Malzeme_Maliyeti_Saveds",
                newName: "Parça_Id");

            migrationBuilder.RenameColumn(
                name: "Revize_Id",
                table: "Kesim_Maliyeti_Saveds",
                newName: "Parça_Id");

            migrationBuilder.RenameColumn(
                name: "Revize_Id",
                table: "Kaynak_Maliyeti_Saveds",
                newName: "Parça_Id");

            migrationBuilder.RenameColumn(
                name: "Revize_Id",
                table: "Dıs_Operasyon_Maliyeti_Saveds",
                newName: "Parça_Id");

            migrationBuilder.RenameColumn(
                name: "Revize_Id",
                table: "Büküm_Maliyeti_Saved_Uzunluks",
                newName: "Parça_Id");

            migrationBuilder.RenameColumn(
                name: "Revize_Id",
                table: "Büküm_Maliyeti_Saved_Ağırlıks",
                newName: "Parça_Id");

            migrationBuilder.RenameColumn(
                name: "Revize_Id",
                table: "Büküm_Maliyeti_Saved_Adets",
                newName: "Parça_Id");

            migrationBuilder.RenameColumn(
                name: "Revize_Id",
                table: "Bağlantı_Elemanı_Saveds",
                newName: "Parça_Id");
        }
    }
}
