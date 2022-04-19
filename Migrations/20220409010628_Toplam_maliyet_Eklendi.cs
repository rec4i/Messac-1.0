using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Toplam_maliyet_Eklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "İşçilik_Maliyeti_Selecteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Toplam_Maliyet_Saved_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Maliyet_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İşlem_Maliyeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İşçilik_Maliyeti_Selecteds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Malzeme_Maliyeti_Selecteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Toplam_Maliyet_Saved_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Maliyet_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İşlem_Maliyeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malzeme_Maliyeti_Selecteds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toplam_Maliyet_Saveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Revize_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    İşçilik_Maliyeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    İşçilik_Kar_Oranı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    İşçilik_Karlı_Toplam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Malzeme_Maliyeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Malzeme_Kar_Oranı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Malzeme_Karlı_Toplam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Malzeme_Birim_Fiyatı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hurda_Birim_Satış_Oranı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Malzeme_Hurda_Fiyatı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Malzeme_Fire_Oranı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fire_Maliyeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Parça_Genel_Kar_Oranı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Parça_Toplam_Maliyeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toplam_Maliyet_Saveds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "İşçilik_Maliyeti_Selecteds");

            migrationBuilder.DropTable(
                name: "Malzeme_Maliyeti_Selecteds");

            migrationBuilder.DropTable(
                name: "Toplam_Maliyet_Saveds");
        }
    }
}
