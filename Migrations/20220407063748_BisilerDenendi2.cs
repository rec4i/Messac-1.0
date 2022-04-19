using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class BisilerDenendi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Plaka_Maliyeti",
                table: "Malzeme_Maliyeti_Saveds",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Parça_Firesiz_Ağırlığı",
                table: "Malzeme_Maliyeti_Saveds",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "Büküm_Adeti",
                table: "Büküm_Maliyeti_Saved_Uzunluks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Malzeme_Boyu",
                table: "Büküm_Maliyeti_Saved_Uzunluks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Büküm_Adeti",
                table: "Büküm_Maliyeti_Saved_Adets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Büküm_Adeti",
                table: "Büküm_Maliyeti_Saved_Uzunluks");

            migrationBuilder.DropColumn(
                name: "Malzeme_Boyu",
                table: "Büküm_Maliyeti_Saved_Uzunluks");

            migrationBuilder.DropColumn(
                name: "Büküm_Adeti",
                table: "Büküm_Maliyeti_Saved_Adets");

            migrationBuilder.AlterColumn<decimal>(
                name: "Plaka_Maliyeti",
                table: "Malzeme_Maliyeti_Saveds",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Parça_Firesiz_Ağırlığı",
                table: "Malzeme_Maliyeti_Saveds",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }
    }
}
