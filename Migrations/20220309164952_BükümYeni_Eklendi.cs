using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class BükümYeni_Eklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Büküm_AdetHesabı",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zorluk_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zorluk_Katsayısı = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Büküm_AdetHesabı", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Büküm_KiloHesabı",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kilo_Bas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kilo_Son = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KatSayı = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Büküm_KiloHesabı", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Büküm_Uzunluk_Hesabı",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uzunluk_Bas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uzunluk_Son = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Büküm_Uzunluk_Hesabı", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Büküm_Uzunluk_Hesabı_Zorluk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zorluk_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zorluk_Katsayısı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Büküm_Uzunluk_Hesabı_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Büküm_Uzunluk_Hesabı_Zorluk", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Büküm_AdetHesabı");

            migrationBuilder.DropTable(
                name: "Büküm_KiloHesabı");

            migrationBuilder.DropTable(
                name: "Büküm_Uzunluk_Hesabı");

            migrationBuilder.DropTable(
                name: "Büküm_Uzunluk_Hesabı_Zorluk");
        }
    }
}
