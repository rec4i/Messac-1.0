using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class BükümIsDeletedEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Is_Deleted",
                table: "Büküm_Uzunluk_Hesabı_Zorluk",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Is_Deleted",
                table: "Büküm_Uzunluk_Hesabı",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Is_Deleted",
                table: "Büküm_KiloHesabı",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Is_Deleted",
                table: "Büküm_AdetHesabı",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Is_Deleted",
                table: "Büküm_Uzunluk_Hesabı_Zorluk");

            migrationBuilder.DropColumn(
                name: "Is_Deleted",
                table: "Büküm_Uzunluk_Hesabı");

            migrationBuilder.DropColumn(
                name: "Is_Deleted",
                table: "Büküm_KiloHesabı");

            migrationBuilder.DropColumn(
                name: "Is_Deleted",
                table: "Büküm_AdetHesabı");
        }
    }
}
