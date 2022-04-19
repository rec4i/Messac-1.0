using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class BOya_MaliyetiSaved_Eklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boya_Maliyeti_Saved_Rows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boya_Maliyeti_Saved_Id = table.Column<int>(type: "int", nullable: false),
                    Boya_Türü = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim_Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Toplam_Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boya_Maliyeti_Saved_Rows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boya_Maliyeti_Saveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Revize_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boya_Maliyeti_Saveds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boya_Maliyeti_Saved_Rows");

            migrationBuilder.DropTable(
                name: "Boya_Maliyeti_Saveds");
        }
    }
}
