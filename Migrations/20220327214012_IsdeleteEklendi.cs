using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class IsdeleteEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Is_Deleted",
                table: "Kaynaks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Is_Deleted",
                table: "kaplamas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Is_Deleted",
                table: "Birimlers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Is_Deleted",
                table: "bağlantı_Elemanları_Türüs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Is_Deleted",
                table: "baglantıElemanlarıs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Is_Deleted",
                table: "Kaynaks");

            migrationBuilder.DropColumn(
                name: "Is_Deleted",
                table: "kaplamas");

            migrationBuilder.DropColumn(
                name: "Is_Deleted",
                table: "Birimlers");

            migrationBuilder.DropColumn(
                name: "Is_Deleted",
                table: "bağlantı_Elemanları_Türüs");

            migrationBuilder.DropColumn(
                name: "Is_Deleted",
                table: "baglantıElemanlarıs");
        }
    }
}
