﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220327212539_BükümIsDeletedEklendi")]
    partial class BükümIsDeletedEklendi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KaynakKod.Entities.DısOperasyon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Birim_Id")
                        .HasColumnType("int");

                    b.Property<string>("Operasyon_Adı")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Operasyon_Maliyeti")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DısOperasyons");
                });

            modelBuilder.Entity("KaynakKod.Entities.UretimMaliyeti.İşlemler.BaglantıElemanları", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Bağlantı_Elemanları_Türü_Id")
                        .HasColumnType("int");

                    b.Property<string>("Bağlantı_Elemanı_Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Birim_Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("baglantıElemanlarıs");
                });

            modelBuilder.Entity("KaynakKod.Entities.UretimMaliyeti.İşlemler.Bağlantı_Elemanları_Türü", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bağlantı_Elemanları_Türü_Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("bağlantı_Elemanları_Türüs");
                });

            modelBuilder.Entity("KaynakKod.Entities.UretimMaliyeti.İşlemler.Kaplama", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Birim_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Birim_Maliyet")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Kapmala_Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("kaplamas");
                });

            modelBuilder.Entity("KaynakKod.Entities.UretimMaliyeti.İşlemler.Kaynak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Birim_Id")
                        .HasColumnType("int");

                    b.Property<string>("Kaynak_Türü")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Maliyet")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Kaynaks");
                });

            modelBuilder.Entity("WebApi.Entities.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("PhoneCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("WebApi.Entities.Town", b =>
                {
                    b.Property<int>("TownID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("TownName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TownID");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("WebApi.Entities.UretimMaliyeti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Musteri_Id")
                        .HasColumnType("int");

                    b.Property<int>("Olusturan_kullanıcı")
                        .HasColumnType("int");

                    b.Property<DateTime>("Oluşturlma_Tar")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Son_Düzenleme_Tar")
                        .HasColumnType("datetime2");

                    b.Property<string>("Teslim_Tarihi_Beklentisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ödeme_Şekli_Beklentisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("İşin_Adı")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("uretimMaliyetis");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gorev_Yeri_İl")
                        .HasColumnType("int");

                    b.Property<int>("Gorev_Yeri_İlçe")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("qrmenu.Entities.Adet_Başına_Fiyat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Büküm_Adeti")
                        .HasColumnType("int");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Malzeme_Genel_Adı_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("adet_Başına_Fiyats");
                });

            modelBuilder.Entity("qrmenu.Entities.Birimler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Birim_Kısa_ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Birim_Uzun_Ad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Birimlers");
                });

            modelBuilder.Entity("qrmenu.Entities.Büküm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Aralık_Bas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Aralık_Son")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Aralıkmı")
                        .HasColumnType("int");

                    b.Property<int>("Birim_Id")
                        .HasColumnType("int");

                    b.Property<string>("Büküm_Cinsi_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fiyat")
                        .HasColumnType("int");

                    b.Property<int?>("Sabit_Değer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Büküms");
                });

            modelBuilder.Entity("qrmenu.Entities.Büküm_AdetHesabı", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Is_Deleted")
                        .HasColumnType("int");

                    b.Property<string>("Zorluk_Adı")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Zorluk_Katsayısı")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Büküm_AdetHesabı");
                });

            modelBuilder.Entity("qrmenu.Entities.Büküm_KiloHesabı", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Is_Deleted")
                        .HasColumnType("int");

                    b.Property<decimal>("KatSayı")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Kilo_Bas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Kilo_Son")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Büküm_KiloHesabı");
                });

            modelBuilder.Entity("qrmenu.Entities.Büküm_Uzunluk_Hesabı", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Is_Deleted")
                        .HasColumnType("int");

                    b.Property<decimal>("Uzunluk_Bas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Uzunluk_Son")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Zorluk_Katsayısı")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Büküm_Uzunluk_Hesabı");
                });

            modelBuilder.Entity("qrmenu.Entities.Büküm_Uzunluk_Hesabı_Zorluk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Büküm_Uzunluk_Hesabı_Id")
                        .HasColumnType("int");

                    b.Property<int>("Is_Deleted")
                        .HasColumnType("int");

                    b.Property<string>("Zorluk_Adı")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Zorluk_Katsayısı")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Büküm_Uzunluk_Hesabı_Zorluk");
                });

            modelBuilder.Entity("qrmenu.Entities.Kalınlık", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Kalınlık_Bas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Kalınlık_Son")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Malzeme_Genel_Adı_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("kalınlıks");
                });

            modelBuilder.Entity("qrmenu.Entities.Kesim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Is_Deleted")
                        .HasColumnType("int");

                    b.Property<int>("Kesim_Türü_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Kesim_mm_Bas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Kesim_mm_Son")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Saat_Bası_Ucret")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Kesims");
                });

            modelBuilder.Entity("qrmenu.Entities.Kesim_Türü", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Is_Deleted")
                        .HasColumnType("int");

                    b.Property<string>("Kesim_Türü_Txt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("kesim_Türüs");
                });

            modelBuilder.Entity("qrmenu.Entities.Kilo_Başına_Büküm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Kilo_Bas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Kilo_Son")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Malzeme_Genel_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("kilo_Başına_Büküms");
                });

            modelBuilder.Entity("qrmenu.Entities.Malzeme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Büküm_Kriteri")
                        .HasColumnType("int");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Is_Deleted")
                        .HasColumnType("int");

                    b.Property<int>("Kesim_TürüId")
                        .HasColumnType("int");

                    b.Property<string>("Malzeme_Cinsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Malzeme_Genel_AdıId")
                        .HasColumnType("int");

                    b.Property<decimal>("Özgül_Ağırlık")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("malzemes");
                });

            modelBuilder.Entity("qrmenu.Entities.Malzeme_Genel_Adı", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Is_Deleted")
                        .HasColumnType("int");

                    b.Property<string>("Malzeme_Genel_Adı_Txt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Malzeme_Genel_Adıs");
                });

            modelBuilder.Entity("qrmenu.Entities.Uzunluk_Fiyat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Kalınlık_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Uzunluk_Bas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Uzunluk_Son")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("uzunluk_Fiyats");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.OwnsMany("WebApi.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ReasonRevoked")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Token")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
