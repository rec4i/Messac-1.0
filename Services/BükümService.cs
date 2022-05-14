using System.Collections.Generic;
using System.Linq;
using KaynakKod.Entities.UretimMaliyeti.İşlemler;
using Microsoft.Extensions.Options;
using qrmenu.Entities;
using WebApi.Authorization;
using WebApi.Helpers;


namespace qrmenu.Services
{
    //     public DbSet<Kilo_Başına_Büküm> kilo_Başına_Büküms { get; set; }
    public interface IBükümService
    {
        Kalınlık Kalınlık_Add(Kalınlık x);

        Kalınlık Kalınlık_Delete(Kalınlık x);

        Kalınlık Kalınlık_Edit(Kalınlık x);

        List<Kalınlık_Return_Value> Kalınlık_Get_All();

        Kalınlık_Return_Value Kalınlık_Get_By_Id(Kalınlık x);


        Uzunluk_Fiyat Uzunluk_Fiyat_Add(Uzunluk_Fiyat x);

        Uzunluk_Fiyat Uzunluk_Fiyat_Delete(Uzunluk_Fiyat x);

        Uzunluk_Fiyat Uzunluk_Fiyat_Edit(Uzunluk_Fiyat x);

        List<Uzunluk_Fiyat_Return_Value> Uzunluk_Fiyat_Get_All();

        Uzunluk_Fiyat_Return_Value Uzunluk_Fiyat_Get_By_Id(Uzunluk_Fiyat x);

        List<Uzunluk_Fiyat_Return_Value> Uzunluk_Fiyat_Get_Kalınlık_Id(Uzunluk_Fiyat x);


        Adet_Başına_Fiyat Adet_Başına_Fiyat_Add(Adet_Başına_Fiyat x);

        Adet_Başına_Fiyat Adet_Başına_Fiyat_Delete(Adet_Başına_Fiyat x);

        Adet_Başına_Fiyat Adet_Başına_Fiyat_Edit(Adet_Başına_Fiyat x);

        List<Adet_Başına_Fiyat_Retun_Value> Adet_Başına_Fiyat_Get_All();

        Adet_Başına_Fiyat_Retun_Value Adet_Başına_Fiyat_Get_By_Id(Adet_Başına_Fiyat x);


        Kilo_Başına_Büküm Kilo_Başına_Büküm_Add(Kilo_Başına_Büküm x);

        Kilo_Başına_Büküm Kilo_Başına_Büküm_Delet(Kilo_Başına_Büküm x);

        Kilo_Başına_Büküm Kilo_Başına_Büküm_Edit(Kilo_Başına_Büküm x);

        List<Kilo_Başına_Büküm_Return_Value> Kilo_Başına_Büküm_Get_All();

        Kilo_Başına_Büküm_Return_Value Kilo_Başına_Büküm_Get_By_Id(Kilo_Başına_Büküm x);

        List<Kilo_Başına_Büküm_Return_Value> Kilo_Başına_Büküm_Get_By_Malzeme_Id(Kilo_Başına_Büküm x);



        

        List<Uzunluk_Fiyat_Return_Value> Uygun_Adet_İle_Büküm_Getir(Uzunluk_Fiyat_Return_Value x);

        List<Kilo_Başına_Büküm_Return_Value> Uygun_Kilo_İle_Büküm_Getir(Kilo_Başına_Büküm_Return_Value x);


    }
    public class BükümService : IBükümService
    {

        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public BükümService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Kalınlık Kalınlık_Add(Kalınlık x)
        {
            _context.kalınlıks.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Kalınlık Kalınlık_Delete(Kalınlık x)
        {
            var temp = _context.kalınlıks;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.kalınlıks.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Kalınlık Kalınlık_Edit(Kalınlık x)
        {
            var temp = _context.kalınlıks;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Kalınlık_Bas = x.Kalınlık_Bas;
            Değer.Kalınlık_Son = x.Kalınlık_Son;
            Değer.Malzeme_Genel_Adı_ID = x.Malzeme_Genel_Adı_ID;
            _context.SaveChanges();

            return Değer;
        }

        public List<Kalınlık_Return_Value> Kalınlık_Get_All()
        {
            var temp = _context.kalınlıks;

            var Değer = (from x in temp
                         join Malzeme_Adı in _context.Malzeme_Genel_Adıs
                         on x.Malzeme_Genel_Adı_ID equals Malzeme_Adı.Id
                         select new
                         {
                             x.Id,
                             x.Kalınlık_Bas,
                             x.Kalınlık_Son,
                             x.Malzeme_Genel_Adı_ID,
                             Malzeme_Adı
                         }
            );

            IEnumerable<Kalınlık_Return_Value> Retunr_Değr = Değer.Select(o => new Kalınlık_Return_Value
            {
                Id = o.Id,
                Kalınlık_Bas = o.Kalınlık_Bas,
                Kalınlık_Son = o.Kalınlık_Son,
                Malzeme_Genel_Adı = o.Malzeme_Adı
            });

            return Retunr_Değr.ToList();

        }

        public Kalınlık_Return_Value Kalınlık_Get_By_Id(Kalınlık x)
        {
            var temp = _context.kalınlıks;
            var Değer = (from y in temp
                         join Malzeme_Adı in _context.Malzeme_Genel_Adıs
                         on y.Malzeme_Genel_Adı_ID equals Malzeme_Adı.Id
                         select new
                         {
                             y.Id,
                             y.Kalınlık_Bas,
                             y.Kalınlık_Son,
                             y.Malzeme_Genel_Adı_ID,
                             Malzeme_Adı
                         }
            ).FirstOrDefault(o => o.Id == x.Id);
            Kalınlık_Return_Value Rd = new Kalınlık_Return_Value
            {
                Id = Değer.Id,
                Kalınlık_Bas = Değer.Kalınlık_Bas,
                Kalınlık_Son = Değer.Kalınlık_Son,
                Malzeme_Genel_Adı_ID = Değer.Malzeme_Genel_Adı_ID,
                Malzeme_Genel_Adı = Değer.Malzeme_Adı
            };
            return Rd;
        }

        public Uzunluk_Fiyat Uzunluk_Fiyat_Add(Uzunluk_Fiyat x)
        {
            _context.uzunluk_Fiyats.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Uzunluk_Fiyat Uzunluk_Fiyat_Delete(Uzunluk_Fiyat x)
        {
            var temp = _context.uzunluk_Fiyats;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.uzunluk_Fiyats.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Uzunluk_Fiyat Uzunluk_Fiyat_Edit(Uzunluk_Fiyat x)
        {
            var temp = _context.uzunluk_Fiyats;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Fiyat = x.Fiyat;
            Değer.Kalınlık_Id = x.Kalınlık_Id;
            Değer.Uzunluk_Bas = x.Uzunluk_Son;
            Değer.Uzunluk_Bas = x.Uzunluk_Son;
            _context.SaveChanges();

            return Değer;
        }

        public List<Uzunluk_Fiyat_Return_Value> Uzunluk_Fiyat_Get_All()
        {
            var temp = _context.uzunluk_Fiyats;
            var Değer = (from x in temp
                         join Kalınlık_ in _context.kalınlıks
                         on x.Kalınlık_Id equals Kalınlık_.Id

                         select new
                         {
                             x.Fiyat,
                             x.Id,
                             x.Kalınlık_Id,
                             x.Uzunluk_Bas,
                             x.Uzunluk_Son,
                             Kalınlık_

                         }
            );

            IEnumerable<Uzunluk_Fiyat_Return_Value> R_D = Değer.Select(o => new Uzunluk_Fiyat_Return_Value
            {
                Fiyat = o.Fiyat,
                Id = o.Id,
                Kalınlık_Id = o.Kalınlık_Id,
                Uzunluk_Bas = o.Uzunluk_Bas,
                Uzunluk_Son = o.Uzunluk_Son,
                Kalınlık = o.Kalınlık_
            });
            return R_D.ToList();
        }

        public Uzunluk_Fiyat_Return_Value Uzunluk_Fiyat_Get_By_Id(Uzunluk_Fiyat x)
        {
            var temp = _context.uzunluk_Fiyats;
            var Değer = (from y in temp
                         join Kalınlık_ in _context.kalınlıks
                         on y.Kalınlık_Id equals Kalınlık_.Id

                         select new
                         {
                             y.Fiyat,
                             y.Id,
                             y.Kalınlık_Id,
                             y.Uzunluk_Bas,
                             y.Uzunluk_Son,
                             Kalınlık_
                         }
            ).FirstOrDefault(o => o.Id == x.Id);
            Uzunluk_Fiyat_Return_Value RD = new Uzunluk_Fiyat_Return_Value
            {
                Fiyat = Değer.Fiyat,
                Id = Değer.Id,
                Kalınlık_Id = Değer.Kalınlık_Id,
                Uzunluk_Bas = Değer.Uzunluk_Bas,
                Uzunluk_Son = Değer.Uzunluk_Son,
                Kalınlık = Değer.Kalınlık_

            };
            return RD;
        }

        public Adet_Başına_Fiyat Adet_Başına_Fiyat_Add(Adet_Başına_Fiyat x)
        {
            _context.adet_Başına_Fiyats.Add(x);
            _context.SaveChanges();

            return x;
        }

        public Adet_Başına_Fiyat Adet_Başına_Fiyat_Delete(Adet_Başına_Fiyat x)
        {
            var temp = _context.adet_Başına_Fiyats;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.adet_Başına_Fiyats.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Adet_Başına_Fiyat Adet_Başına_Fiyat_Edit(Adet_Başına_Fiyat x)
        {
            var temp = _context.adet_Başına_Fiyats;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Büküm_Adeti = x.Büküm_Adeti;
            Değer.Fiyat = x.Fiyat;
            Değer.Malzeme_Genel_Adı_Id = x.Malzeme_Genel_Adı_Id;
            _context.SaveChanges();

            return Değer;
        }

        public List<Adet_Başına_Fiyat_Retun_Value> Adet_Başına_Fiyat_Get_All()
        {
            var temp = _context.adet_Başına_Fiyats;
            var Değer = (from x in temp
                         join Malzeme_Adı in _context.Malzeme_Genel_Adıs
                         on x.Malzeme_Genel_Adı_Id equals Malzeme_Adı.Id
                         select new
                         {
                             x.Büküm_Adeti,
                             x.Fiyat,
                             x.Id,
                             x.Malzeme_Genel_Adı_Id,
                             Malzeme_Adı
                         }
            );
            IEnumerable<Adet_Başına_Fiyat_Retun_Value> rd = Değer.Select(o => new Adet_Başına_Fiyat_Retun_Value
            {
                Büküm_Adeti = o.Büküm_Adeti,
                Fiyat = o.Fiyat,
                Id = o.Id,
                Malzeme_Genel_Adı_Id = o.Malzeme_Genel_Adı_Id,
                Malzeme_Genel_Adı = o.Malzeme_Adı
            });
            return rd.ToList();
        }

        public Adet_Başına_Fiyat_Retun_Value Adet_Başına_Fiyat_Get_By_Id(Adet_Başına_Fiyat x)
        {
            var temp = _context.adet_Başına_Fiyats;

            var Değer = (from y in temp
                         join Malzeme_Adı in _context.Malzeme_Genel_Adıs
                         on y.Malzeme_Genel_Adı_Id equals Malzeme_Adı.Id

                         select new
                         {
                             y.Büküm_Adeti,
                             y.Fiyat,
                             y.Id,
                             y.Malzeme_Genel_Adı_Id,
                             Malzeme_Adı
                         }
            ).FirstOrDefault(o => o.Id == x.Id);

            Adet_Başına_Fiyat_Retun_Value rd = new Adet_Başına_Fiyat_Retun_Value
            {
                Büküm_Adeti = Değer.Büküm_Adeti,
                Fiyat = Değer.Fiyat,
                Id = Değer.Id,
                Malzeme_Genel_Adı_Id = Değer.Malzeme_Genel_Adı_Id,
                Malzeme_Genel_Adı = Değer.Malzeme_Adı

            };

            return rd;

        }

        public Kilo_Başına_Büküm Kilo_Başına_Büküm_Add(Kilo_Başına_Büküm x)
        {
            _context.kilo_Başına_Büküms.Add(x);
            _context.SaveChanges();
            return x;

        }

        public Kilo_Başına_Büküm Kilo_Başına_Büküm_Delet(Kilo_Başına_Büküm x)
        {
            var temp = _context.kilo_Başına_Büküms;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.kilo_Başına_Büküms.Remove(Değer);
            _context.SaveChanges();

            return Değer;

        }

        public Kilo_Başına_Büküm Kilo_Başına_Büküm_Edit(Kilo_Başına_Büküm x)
        {
            var temp = _context.kilo_Başına_Büküms;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Fiyat = x.Fiyat;
            Değer.Kilo_Bas = x.Kilo_Bas;
            Değer.Kilo_Son = x.Kilo_Son;
            Değer.Malzeme_Genel_Id = x.Malzeme_Genel_Id;

            _context.SaveChanges();

            return Değer;
        }

        public List<Kilo_Başına_Büküm_Return_Value> Kilo_Başına_Büküm_Get_All()
        {
            var temp = _context.kilo_Başına_Büküms;
            var Değer = (from x in temp
                         join Malzeme_Adı in _context.Malzeme_Genel_Adıs
                         on x.Malzeme_Genel_Id equals Malzeme_Adı.Id
                         select new
                         {
                             x.Fiyat,
                             x.Id,
                             x.Kilo_Bas,
                             x.Kilo_Son,
                             x.Malzeme_Genel_Id,
                             Malzeme_Adı
                         }
            );
            IEnumerable<Kilo_Başına_Büküm_Return_Value> rd = Değer.Select(o => new Kilo_Başına_Büküm_Return_Value
            {
                Fiyat = o.Fiyat,
                Id = o.Id,
                Kilo_Bas = o.Kilo_Bas,
                Kilo_Son = o.Kilo_Son,
                Malzeme_Genel_Id = o.Malzeme_Genel_Id,
                Malzeme_Genel_Adı = o.Malzeme_Adı

            });
            return rd.ToList();

        }

        public Kilo_Başına_Büküm_Return_Value Kilo_Başına_Büküm_Get_By_Id(Kilo_Başına_Büküm x)
        {
            var temp = _context.kilo_Başına_Büküms;

            var Değer = (from y in temp
                         join Malzeme_Adı in _context.Malzeme_Genel_Adıs
                         on y.Malzeme_Genel_Id equals Malzeme_Adı.Id

                         select new
                         {
                             y.Fiyat,
                             y.Id,
                             y.Kilo_Bas,
                             y.Kilo_Son,
                             y.Malzeme_Genel_Id,
                             Malzeme_Adı

                         }
            ).FirstOrDefault(o => o.Id == x.Id);

            Kilo_Başına_Büküm_Return_Value rd = new Kilo_Başına_Büküm_Return_Value
            {
                Fiyat = Değer.Fiyat,
                Id = Değer.Id,
                Kilo_Bas = Değer.Kilo_Bas,
                Kilo_Son = Değer.Kilo_Son,
                Malzeme_Genel_Id = Değer.Malzeme_Genel_Id,
                Malzeme_Genel_Adı = Değer.Malzeme_Adı
            };
            return rd;

        }

        public List<Kilo_Başına_Büküm_Return_Value> Kilo_Başına_Büküm_Get_By_Malzeme_Id(Kilo_Başına_Büküm x)
        {
            var temp = _context.kilo_Başına_Büküms;

            var Değer = (from y in temp
                         join Malzeme_Adı in _context.Malzeme_Genel_Adıs
                         on y.Malzeme_Genel_Id equals Malzeme_Adı.Id
                         where y.Malzeme_Genel_Id == x.Malzeme_Genel_Id
                         select new
                         {
                             y.Fiyat,
                             y.Id,
                             y.Kilo_Bas,
                             y.Kilo_Son,
                             y.Malzeme_Genel_Id,
                             Malzeme_Adı

                         }
            );

            IEnumerable<Kilo_Başına_Büküm_Return_Value> rd = Değer.Select(o => new Kilo_Başına_Büküm_Return_Value
            {
                Id = o.Id,
                Fiyat = o.Fiyat,
                Kilo_Bas = o.Kilo_Bas,
                Kilo_Son = o.Kilo_Son,
                Malzeme_Genel_Id = o.Malzeme_Genel_Id,
                Malzeme_Genel_Adı = o.Malzeme_Adı
            });
            return rd.ToList();

        }

        public List<Uzunluk_Fiyat_Return_Value> Uzunluk_Fiyat_Get_Kalınlık_Id(Uzunluk_Fiyat x)
        {
            var temp = _context.uzunluk_Fiyats;
            var Değer = (from y in temp
                         join Kalınlık_ in _context.kalınlıks
                         on y.Kalınlık_Id equals Kalınlık_.Id
                         where y.Kalınlık_Id == x.Kalınlık_Id
                         select new
                         {
                             y.Fiyat,
                             y.Id,
                             y.Kalınlık_Id,
                             y.Uzunluk_Bas,
                             y.Uzunluk_Son,
                             Kalınlık_
                         }
            );
            IEnumerable<Uzunluk_Fiyat_Return_Value> RD = Değer.Select(o => new Uzunluk_Fiyat_Return_Value
            {
                Fiyat = o.Fiyat,
                Id = o.Id,
                Kalınlık_Id = o.Kalınlık_Id,
                Uzunluk_Bas = o.Uzunluk_Bas,
                Uzunluk_Son = o.Uzunluk_Son,
                Kalınlık = o.Kalınlık_
            });



            return RD.ToList();
        }

        public List<Uzunluk_Fiyat_Return_Value> Uygun_Adet_İle_Büküm_Getir(Uzunluk_Fiyat_Return_Value z)
        {
            var temp = _context.uzunluk_Fiyats;
            var Değer = (from x in temp
                         join Kalınlık_ in _context.kalınlıks
                         on x.Kalınlık_Id equals Kalınlık_.Id

                         where z.Uzunluk_Bas >= x.Uzunluk_Bas && z.Uzunluk_Bas <= x.Uzunluk_Son
                             && z.Kalınlık.Kalınlık_Bas >= Kalınlık_.Kalınlık_Bas && z.Kalınlık.Kalınlık_Bas <= Kalınlık_.Kalınlık_Son


                         select new
                         {
                             x.Fiyat,
                             x.Id,
                             x.Kalınlık_Id,
                             x.Uzunluk_Bas,
                             x.Uzunluk_Son,
                             Kalınlık_

                         }
            ).OrderByDescending(o => o.Fiyat);

            IEnumerable<Uzunluk_Fiyat_Return_Value> R_D = Değer.Select(o => new Uzunluk_Fiyat_Return_Value
            {
                Fiyat = o.Fiyat,
                Id = o.Id,
                Kalınlık_Id = o.Kalınlık_Id,
                Uzunluk_Bas = o.Uzunluk_Bas,
                Uzunluk_Son = o.Uzunluk_Son,
                Kalınlık = o.Kalınlık_
            });


            return R_D.ToList();


        }

        public List<Kilo_Başına_Büküm_Return_Value> Uygun_Kilo_İle_Büküm_Getir(Kilo_Başına_Büküm_Return_Value y)
        {

            var temp = _context.kilo_Başına_Büküms;
            var Değer = (from x in temp
                         join Malzeme_Adı in _context.Malzeme_Genel_Adıs
                         on x.Malzeme_Genel_Id equals Malzeme_Adı.Id

                         where y.Kilo_Bas >= x.Kilo_Bas && y.Kilo_Bas <= x.Kilo_Son &&
                                y.Malzeme_Genel_Id== Malzeme_Adı.Id

                         select new
                         {
                             x.Fiyat,
                             x.Id,
                             x.Kilo_Bas,
                             x.Kilo_Son,
                             x.Malzeme_Genel_Id,
                             Malzeme_Adı
                         }
            ).OrderByDescending(o => o.Fiyat);;
            IEnumerable<Kilo_Başına_Büküm_Return_Value> rd = Değer.Select(o => new Kilo_Başına_Büküm_Return_Value
            {
                Fiyat = o.Fiyat,
                Id = o.Id,
                Kilo_Bas = o.Kilo_Bas,
                Kilo_Son = o.Kilo_Son,
                Malzeme_Genel_Id = o.Malzeme_Genel_Id,
                Malzeme_Genel_Adı = o.Malzeme_Adı

            });
            return rd.ToList();
        }
    }
}
