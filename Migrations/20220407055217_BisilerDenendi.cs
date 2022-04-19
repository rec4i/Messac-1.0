using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class BisilerDenendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Parça_Id",
                table: "Kaplama_Maliyeti_Saveds",
                newName: "Revize_Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "Plaka_Maliyeti",
                table: "Malzeme_Maliyeti_Saveds",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Revize_Id",
                table: "Kaplama_Maliyeti_Saveds",
                newName: "Parça_Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "Plaka_Maliyeti",
                table: "Malzeme_Maliyeti_Saveds",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }
    }
}
