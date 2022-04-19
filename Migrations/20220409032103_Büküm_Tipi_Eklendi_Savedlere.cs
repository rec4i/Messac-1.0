using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Büküm_Tipi_Eklendi_Savedlere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Büküm_Tipi",
                table: "Büküm_Maliyeti_Saved_Uzunluks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Büküm_Tipi",
                table: "Büküm_Maliyeti_Saved_Ağırlıks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Büküm_Tipi",
                table: "Büküm_Maliyeti_Saved_Adets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Büküm_Tipi",
                table: "Büküm_Maliyeti_Saved_Uzunluks");

            migrationBuilder.DropColumn(
                name: "Büküm_Tipi",
                table: "Büküm_Maliyeti_Saved_Ağırlıks");

            migrationBuilder.DropColumn(
                name: "Büküm_Tipi",
                table: "Büküm_Maliyeti_Saved_Adets");
        }
    }
}
