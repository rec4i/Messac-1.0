using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class ParçaEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bağlantı_Elemanı_Saved_Rows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bağlantı_Elemanı_Saved_Id = table.Column<int>(type: "int", nullable: false),
                    Bağlantı_Elemanı_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim_Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Toplam_Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bağlantı_Elemanı_Saved_Rows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bağlantı_Elemanı_Saveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parça_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bağlantı_Elemanı_Saveds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Büküm_Maliyeti_Saved_Adets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parça_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Büküm_Zorluğu_Id = table.Column<int>(type: "int", nullable: false),
                    Kat_Sayı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Büküm_Maliyeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Büküm_Maliyeti_Saved_Adets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Büküm_Maliyeti_Saved_Ağırlıks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parça_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Malzeme_Ağırlığı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kat_Sayı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Büküm_Maliyeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Büküm_Maliyeti_Saved_Ağırlıks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Büküm_Maliyeti_Saved_Uzunluks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parça_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hesap_Çeşiti_Id = table.Column<int>(type: "int", nullable: false),
                    Malzeme_Eni = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Malzeme_Boyu_Katsayı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Büküm_Zorluğu_Id = table.Column<int>(type: "int", nullable: false),
                    Büküm_Zorluğu_Katsayı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Büküm_Maliyeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Büküm_Maliyeti_Saved_Uzunluks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dıs_Operasyon_Maliyeti_Saved_Rows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dıs_Operasyon_Maliyeti_Saved_Id = table.Column<int>(type: "int", nullable: false),
                    Dıs_Operasyon_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dıs_Operasyon_Birim_Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dıs_Operasyon_Adet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Toplam_Maliyet = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dıs_Operasyon_Maliyeti_Saved_Rows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dıs_Operasyon_Maliyeti_Saveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parça_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dıs_Operasyon_Maliyeti_Saveds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kaplama_Maliyeti_Saved_Rows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kaynak_Maliyeti_Saved_Id = table.Column<int>(type: "int", nullable: false),
                    Kaynak_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kaynak_birimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim_Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Toplam_Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kaplama_Maliyeti_Saved_Rows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kaplama_Maliyeti_Saveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parça_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kaplama_Maliyeti_Saveds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kaynak_Maliyeti_Saved_Rows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kaynak_Maliyeti_Saved_Id = table.Column<int>(type: "int", nullable: false),
                    Kaynak_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kaynak_birimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim_Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Toplam_Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kaynak_Maliyeti_Saved_Rows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kaynak_Maliyeti_Saveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parça_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kaynak_Maliyeti_Saveds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kesim_Maliyeti_Saveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parça_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Malzeme_Kesim_Türü_Id = table.Column<int>(type: "int", nullable: false),
                    Parça_Adeti = table.Column<int>(type: "int", nullable: false),
                    Kesim_Verimliliği = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kesim_Süresi_Saat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kesim_Süresi_Saniye = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kesim_Fiyatı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kesim_Maliyeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kesim_Maliyeti_Saveds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Malzeme_Maliyeti_Saveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parça_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Malzeme_Id = table.Column<int>(type: "int", nullable: false),
                    Malzeme_Birim_Fiyatı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Malzeme_Kesim_Türü_Id = table.Column<int>(type: "int", nullable: false),
                    Plaka_Eni = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Plaka_Boyu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Plaka_Kalınlığı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Parça_Adeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Parça_Firesiz_Ağırlığı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Plaka_Maliyeti = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malzeme_Maliyeti_Saveds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parças",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parça_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Takım_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false),
                    Olusturlma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parças", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bağlantı_Elemanı_Saved_Rows");

            migrationBuilder.DropTable(
                name: "Bağlantı_Elemanı_Saveds");

            migrationBuilder.DropTable(
                name: "Büküm_Maliyeti_Saved_Adets");

            migrationBuilder.DropTable(
                name: "Büküm_Maliyeti_Saved_Ağırlıks");

            migrationBuilder.DropTable(
                name: "Büküm_Maliyeti_Saved_Uzunluks");

            migrationBuilder.DropTable(
                name: "Dıs_Operasyon_Maliyeti_Saved_Rows");

            migrationBuilder.DropTable(
                name: "Dıs_Operasyon_Maliyeti_Saveds");

            migrationBuilder.DropTable(
                name: "Kaplama_Maliyeti_Saved_Rows");

            migrationBuilder.DropTable(
                name: "Kaplama_Maliyeti_Saveds");

            migrationBuilder.DropTable(
                name: "Kaynak_Maliyeti_Saved_Rows");

            migrationBuilder.DropTable(
                name: "Kaynak_Maliyeti_Saveds");

            migrationBuilder.DropTable(
                name: "Kesim_Maliyeti_Saveds");

            migrationBuilder.DropTable(
                name: "Malzeme_Maliyeti_Saveds");

            migrationBuilder.DropTable(
                name: "Parças");
        }
    }
}
