using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class kesimtas2b2l22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adet_Başına_Fiyats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Büküm_Adeti = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Malzeme_Genel_Adı_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adet_Başına_Fiyats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Birimlers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birim_Txt_ = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birimlers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Büküms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Büküm_Cinsi_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aralıkmı = table.Column<int>(type: "int", nullable: false),
                    Aralık_Bas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Aralık_Son = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sabit_Değer = table.Column<int>(type: "int", nullable: true),
                    Birim_Id = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Büküms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "kalınlıks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kalınlık_Bas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kalınlık_Son = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Malzeme_Genel_Adı_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kalınlıks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kaynaks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kaynak_Türü = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim_Id = table.Column<int>(type: "int", nullable: false),
                    Maliyet = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kaynaks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kesim_Türüs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kesim_Türü_Txt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kesim_Türüs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kesims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kesim_Türü_Id = table.Column<int>(type: "int", nullable: false),
                    Kesim_mm_Bas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kesim_mm_Son = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Saat_Bası_Ucret = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kesims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kilo_Başına_Büküms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kilo_Bas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kilo_Son = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Malzeme_Genel_Id = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kilo_Başına_Büküms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Malzeme_Genel_Adıs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Malzeme_Genel_Adı_Txt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malzeme_Genel_Adıs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "malzemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Malzeme_Cinsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Özgül_Ağırlık = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kesim_TürüId = table.Column<int>(type: "int", nullable: false),
                    Büküm_Kriteri = table.Column<int>(type: "int", nullable: false),
                    Malzeme_Genel_AdıId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_malzemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    TownID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    TownName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.TownID);
                });

            migrationBuilder.CreateTable(
                name: "uretimMaliyetis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İşin_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oluşturlma_Tar = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Son_Düzenleme_Tar = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Olusturan_kullanıcı = table.Column<int>(type: "int", nullable: false),
                    Musteri_Id = table.Column<int>(type: "int", nullable: false),
                    Teslim_Tarihi_Beklentisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ödeme_Şekli_Beklentisi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uretimMaliyetis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gorev_Yeri_İl = table.Column<int>(type: "int", nullable: false),
                    Gorev_Yeri_İlçe = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "uzunluk_Fiyats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kalınlık_Id = table.Column<int>(type: "int", nullable: false),
                    Uzunluk_Bas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uzunluk_Son = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uzunluk_Fiyats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adet_Başına_Fiyats");

            migrationBuilder.DropTable(
                name: "Birimlers");

            migrationBuilder.DropTable(
                name: "Büküms");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "kalınlıks");

            migrationBuilder.DropTable(
                name: "Kaynaks");

            migrationBuilder.DropTable(
                name: "kesim_Türüs");

            migrationBuilder.DropTable(
                name: "Kesims");

            migrationBuilder.DropTable(
                name: "kilo_Başına_Büküms");

            migrationBuilder.DropTable(
                name: "Malzeme_Genel_Adıs");

            migrationBuilder.DropTable(
                name: "malzemes");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "uretimMaliyetis");

            migrationBuilder.DropTable(
                name: "uzunluk_Fiyats");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
