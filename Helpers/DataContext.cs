using KaynakKod.Entities;
using KaynakKod.Entities.UretimMaliyeti.İşlemler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using qrmenu.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

namespace WebApi.Helpers
{

    public class DataContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<UretimMaliyeti> uretimMaliyetis { get; set; }
        public DbSet<Malzeme> malzemes { get; set; }
        public DbSet<Büküm> Büküms { get; set; }
        public DbSet<Malzeme_Genel_Adı> Malzeme_Genel_Adıs { get; set; }
        public DbSet<Kesim_Türü> kesim_Türüs { get; set; }

        public DbSet<Kesim> Kesims { get; set; }
        public DbSet<Birimler> Birimlers { get; set; }
        public DbSet<Kaynak> Kaynaks { get; set; }

        public DbSet<Parça> Parças { get; set; }
        public DbSet<Revize> Revizes { get; set; }


        public DbSet<Kalınlık> kalınlıks { get; set; }
        public DbSet<Uzunluk_Fiyat> uzunluk_Fiyats { get; set; }
        public DbSet<Adet_Başına_Fiyat> adet_Başına_Fiyats { get; set; }
        public DbSet<Kilo_Başına_Büküm> kilo_Başına_Büküms { get; set; }

        public DbSet<Bağlantı_Elemanları_Türü> bağlantı_Elemanları_Türüs { get; set; }


        public DbSet<BaglantıElemanları> baglantıElemanlarıs { get; set; }

        public DbSet<Kaplama> kaplamas { get; set; }

        public DbSet<DısOperasyon> DısOperasyons { get; set; }



        public DbSet<Büküm_KiloHesabı> Büküm_KiloHesabı { get; set; }
        public DbSet<Büküm_AdetHesabı> Büküm_AdetHesabı { get; set; }


        public DbSet<Büküm_Uzunluk_Hesabı> Büküm_Uzunluk_Hesabı { get; set; }

        public DbSet<Büküm_Uzunluk_Hesabı_Zorluk> Büküm_Uzunluk_Hesabı_Zorluk { get; set; }

        public DbSet<İş> İşs { get; set; }

        public DbSet<Takım> Takıms { get; set; }


        public DbSet<Bağlantı_Elemanı_Saved> Bağlantı_Elemanı_Saveds { get; set; }
        public DbSet<Bağlantı_Elemanı_Saved_row> Bağlantı_Elemanı_Saved_Rows { get; set; }
        public DbSet<Büküm_Maliyeti_Saved_Ağırlık> Büküm_Maliyeti_Saved_Ağırlıks { get; set; }
        public DbSet<Büküm_Maliyeti_Saved_Adet> Büküm_Maliyeti_Saved_Adets { get; set; }
        public DbSet<Büküm_Maliyeti_Saved_Uzunluk> Büküm_Maliyeti_Saved_Uzunluks { get; set; }


        public DbSet<Dıs_Operasyon_Maliyeti_Saved> Dıs_Operasyon_Maliyeti_Saveds { get; set; }

        public DbSet<Dıs_Operasyon_Maliyeti_Saved_Row> Dıs_Operasyon_Maliyeti_Saved_Rows { get; set; }


        public DbSet<Kaplama_Maliyeti_Saved> Kaplama_Maliyeti_Saveds { get; set; }
        public DbSet<Kaplama_Maliyeti_Saved_Row> Kaplama_Maliyeti_Saved_Rows { get; set; }




        public DbSet<Kaynak_Maliyeti_Saved> Kaynak_Maliyeti_Saveds { get; set; }
        public DbSet<Kaynak_Maliyeti_Saved_Row> Kaynak_Maliyeti_Saved_Rows { get; set; }

        public DbSet<Kesim_Maliyeti_Saved> Kesim_Maliyeti_Saveds { get; set; }




        public DbSet<Malzeme_Maliyeti_Saved> Malzeme_Maliyeti_Saveds { get; set; }


        public DbSet<Toplam_Maliyet_Saved> Toplam_Maliyet_Saveds { get; set; }

        public DbSet<İşçilik_Maliyeti_Selected> İşçilik_Maliyeti_Selecteds { get; set; }
        public DbSet<Malzeme_Maliyeti_Selected> Malzeme_Maliyeti_Selecteds { get; set; }



        public DbSet<Tesfiye> Tesfiyes { get; set; }
        public DbSet<Tesfiye_Maliyeti_Saved> Tesfiye_Maliyeti_Saveds { get; set; }

        public DbSet<Tesfiye_Maliyeti_Saved_Row> Tesfiye_Maliyeti_Saved_Rows { get; set; }

        public DbSet<Boya> Boyas { get; set; }

        public DbSet<Boya_Türü> Boya_Türüs { get; set; }
        public DbSet<Paketleme> Paketlemes { get; set; }


        public DbSet<Paketleme_Maliyeti_Saved> Paketleme_Maliyeti_Saveds { get; set; }
        public DbSet<Paketleme_Maliyeti_Saved_Row> Paketleme_Maliyeti_Saved_Rows { get; set; }


        public DbSet<Boya_Maliyeti_Saved> Boya_Maliyeti_Saveds { get; set; }

        public DbSet<Boya_Maliyeti_Saved_Row> Boya_Maliyeti_Saved_Rows { get; set; }






        //İşçilik_Maliyeti_Selected



        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Malzeme_Genel_Adı>().HasMany<Malzeme>(o => o.Malzemes).WithOne(o => o.Malzeme_Genel_Adı).HasForeignKey(o => o.Malzeme_Genel_AdıId);



        }
        public void Context(DbContext context_)
        {
            context_.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("ConnString"));


            // in memory database used for simplicity, change to a real db for production applications
            // options.UseInMemoryDatabase("TestDb");

        }

    }
}