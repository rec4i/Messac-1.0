using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class TakımIşEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "İşs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İşin_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İşs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Takıms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Takım_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İş_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takıms", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "İşs");

            migrationBuilder.DropTable(
                name: "Takıms");
        }
    }
}
