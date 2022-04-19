using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Bağlantı_Elemanları_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "baglantıElemanlarıs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bağlantı_Elemanı_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim_Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bağlantı_Elemanları_Türü_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baglantıElemanlarıs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bağlantı_Elemanları_Türüs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bağlantı_Elemanları_Türü_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bağlantı_Elemanları_Türüs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "baglantıElemanlarıs");

            migrationBuilder.DropTable(
                name: "bağlantı_Elemanları_Türüs");
        }
    }
}
