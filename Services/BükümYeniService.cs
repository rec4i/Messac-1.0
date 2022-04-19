

using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using qrmenu.Entities;
using WebApi.Authorization;
using WebApi.Helpers;

namespace KaynakKod.Services
{

    public interface IBükümYeniService
    {
        Büküm_KiloHesabı Büküm_KiloHesabı_Add(Büküm_KiloHesabı x);

        Büküm_KiloHesabı Büküm_KiloHesabı_Delete(Büküm_KiloHesabı x);

        Büküm_KiloHesabı Büküm_KiloHesabı_Edit(Büküm_KiloHesabı x);

        List<Büküm_KiloHesabı> Büküm_KiloHesabı_Get_All();

        Büküm_KiloHesabı Büküm_KiloHesabı_Get_By_Id(Büküm_KiloHesabı x);




        Büküm_AdetHesabı Büküm_AdetHesabı_Add(Büküm_AdetHesabı x);

        Büküm_AdetHesabı Büküm_AdetHesabı_Delete(Büküm_AdetHesabı x);

        Büküm_AdetHesabı Büküm_AdetHesabı_Edit(Büküm_AdetHesabı x);

        List<Büküm_AdetHesabı> Büküm_AdetHesabı_Get_All();

        Büküm_AdetHesabı Büküm_AdetHesabı_Get_By_Id(Büküm_AdetHesabı x);



        Büküm_Uzunluk_Hesabı Büküm_Uzunluk_Hesabı_Add(Büküm_Uzunluk_Hesabı x);

        Büküm_Uzunluk_Hesabı Büküm_Uzunluk_Hesabı_Delete(Büküm_Uzunluk_Hesabı x);

        Büküm_Uzunluk_Hesabı Büküm_Uzunluk_Hesabı_Edit(Büküm_Uzunluk_Hesabı x);

        List<Büküm_Uzunluk_Hesabı> Büküm_Uzunluk_Hesabı_Get_All();

        Büküm_Uzunluk_Hesabı Büküm_Uzunluk_Hesabı_Get_By_Id(Büküm_Uzunluk_Hesabı x);





        Büküm_Uzunluk_Hesabı_Zorluk Büküm_Uzunluk_Hesabı_Zorluk_Add(Büküm_Uzunluk_Hesabı_Zorluk x);

        Büküm_Uzunluk_Hesabı_Zorluk Büküm_Uzunluk_Hesabı_Zorluk_Delete(Büküm_Uzunluk_Hesabı_Zorluk x);


        Büküm_Uzunluk_Hesabı_Zorluk Büküm_Uzunluk_Hesabı_Zorluk_Edit(Büküm_Uzunluk_Hesabı_Zorluk x);


        List<Büküm_Uzunluk_Hesabı_Zorluk_Return_Value> Büküm_Uzunluk_Hesabı_Zorluk_Get_All();


        Büküm_Uzunluk_Hesabı_Zorluk_Return_Value Büküm_Uzunluk_Hesabı_Zorluk_Get_By_Id(Büküm_Uzunluk_Hesabı_Zorluk x);
        List<Büküm_Uzunluk_Hesabı_Zorluk_Return_Value> Büküm_Uzunluk_Hesabı_Zorluk_Get_Genel_Id(Büküm_Uzunluk_Hesabı x);


        Büküm_KiloHesabı Uygun_Büküm_Kilo_Getir(Büküm_KiloHesabı x);
        List<Büküm_Uzunluk_Hesabı_Zorluk_Return_Value> Büküm_Uzunluk_Hesabı_Zorluk_Get_By_Uzunluk_Hesabı_Id(Büküm_Uzunluk_Hesabı y);




        Büküm_Uzunluk_Hesabı Malzeme_Uzunuğuna_Göre_Katsayı_Getir(Büküm_Uzunluk_Hesabı y);




    }
    public class BükümYeniService : IBükümYeniService
    {

        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public BükümYeniService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Büküm_KiloHesabı Büküm_KiloHesabı_Add(Büküm_KiloHesabı x)
        {

            _context.Büküm_KiloHesabı.Add(x);
            _context.SaveChanges();
            return x;

        }

        public Büküm_KiloHesabı Büküm_KiloHesabı_Delete(Büküm_KiloHesabı x)
        {
            var temp = _context.Büküm_KiloHesabı;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted=1;
            //_context.Büküm_KiloHesabı.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Büküm_KiloHesabı Büküm_KiloHesabı_Edit(Büküm_KiloHesabı x)
        {
            var temp = _context.Büküm_KiloHesabı;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id&&x.Is_Deleted==0);
            Değer.Kilo_Bas = x.Kilo_Bas;
            Değer.Kilo_Son = x.Kilo_Son;
            Değer.KatSayı = x.KatSayı;
            _context.SaveChanges();

            return Değer;
        }

        public List<Büküm_KiloHesabı> Büküm_KiloHesabı_Get_All()
        {
            var temp = (from x in _context.Büküm_KiloHesabı
                        where x.Is_Deleted==0
                        select x
            ).ToList();

            return temp;
        }

        public Büküm_KiloHesabı Büküm_KiloHesabı_Get_By_Id(Büküm_KiloHesabı y)
        {
            var temp = (from x in _context.Büküm_KiloHesabı
                        
                        where x.Id==y.Id && x.Is_Deleted==0
                        select x

            ).FirstOrDefault();

            return temp;
        }

        public Büküm_AdetHesabı Büküm_AdetHesabı_Add(Büküm_AdetHesabı x)
        {

            _context.Büküm_AdetHesabı.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Büküm_AdetHesabı Büküm_AdetHesabı_Delete(Büküm_AdetHesabı x)
        {
            var temp = _context.Büküm_AdetHesabı;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted=1;
           // _context.Büküm_AdetHesabı.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Büküm_AdetHesabı Büküm_AdetHesabı_Edit(Büküm_AdetHesabı x)
        {
            var temp = _context.Büküm_AdetHesabı;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Zorluk_Adı = x.Zorluk_Adı;
            Değer.Zorluk_Katsayısı = x.Zorluk_Katsayısı;
            _context.SaveChanges();

            return Değer;
        }

        public List<Büküm_AdetHesabı> Büküm_AdetHesabı_Get_All()
        {
            var temp = (from x in _context.Büküm_AdetHesabı
                        where x.Is_Deleted==0
                        select x
            );

            return temp.ToList();
        }

        public Büküm_AdetHesabı Büküm_AdetHesabı_Get_By_Id(Büküm_AdetHesabı y)
        {
            var temp = (from x in _context.Büküm_AdetHesabı
                        where x.Is_Deleted==0
                        select x
            ).ToList().FirstOrDefault(o => o.Id == y.Id);

            return temp;
        }

        public Büküm_Uzunluk_Hesabı Büküm_Uzunluk_Hesabı_Add(Büküm_Uzunluk_Hesabı x)
        {
            _context.Büküm_Uzunluk_Hesabı.Add(x);
            _context.SaveChanges();

            return x;

        }

        public Büküm_Uzunluk_Hesabı Büküm_Uzunluk_Hesabı_Delete(Büküm_Uzunluk_Hesabı x)
        {
            var temp = _context.Büküm_Uzunluk_Hesabı;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted=1;

           
           // _context.Büküm_Uzunluk_Hesabı.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Büküm_Uzunluk_Hesabı Büküm_Uzunluk_Hesabı_Edit(Büküm_Uzunluk_Hesabı x)
        {
            var temp = _context.Büküm_Uzunluk_Hesabı;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Uzunluk_Bas = x.Uzunluk_Bas;
            Değer.Uzunluk_Son = x.Uzunluk_Son;
            Değer.Zorluk_Katsayısı = x.Zorluk_Katsayısı;
            _context.SaveChanges();

            return Değer;
        }

        public List<Büküm_Uzunluk_Hesabı> Büküm_Uzunluk_Hesabı_Get_All()
        {
            var temp = (from x in _context.Büküm_Uzunluk_Hesabı
                        where x.Is_Deleted==0
                        select x
            );

            return temp.ToList();
        }



        public Büküm_Uzunluk_Hesabı Büküm_Uzunluk_Hesabı_Get_By_Id(Büküm_Uzunluk_Hesabı y)
        {
            var temp = (from x in _context.Büküm_Uzunluk_Hesabı
                        where x.Is_Deleted==0

                        select x
              ).ToList().FirstOrDefault(o => o.Id == y.Id);

            return temp;
        }

        public Büküm_Uzunluk_Hesabı_Zorluk Büküm_Uzunluk_Hesabı_Zorluk_Add(Büküm_Uzunluk_Hesabı_Zorluk x)
        {
            _context.Büküm_Uzunluk_Hesabı_Zorluk.Add(x);
            _context.SaveChanges();
            return x;

        }

        public Büküm_Uzunluk_Hesabı_Zorluk Büküm_Uzunluk_Hesabı_Zorluk_Delete(Büküm_Uzunluk_Hesabı_Zorluk x)
        {
            var temp = _context.Büküm_Uzunluk_Hesabı_Zorluk;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted=1;
            //_context.Büküm_Uzunluk_Hesabı_Zorluk.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Büküm_Uzunluk_Hesabı_Zorluk Büküm_Uzunluk_Hesabı_Zorluk_Edit(Büküm_Uzunluk_Hesabı_Zorluk x)
        {
            var temp = _context.Büküm_Uzunluk_Hesabı_Zorluk;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Zorluk_Adı = x.Zorluk_Adı;
            Değer.Zorluk_Katsayısı = x.Zorluk_Katsayısı;
            Değer.Büküm_Uzunluk_Hesabı_Id = x.Büküm_Uzunluk_Hesabı_Id;
            _context.SaveChanges();

            return Değer;
        }

        public List<Büküm_Uzunluk_Hesabı_Zorluk_Return_Value> Büküm_Uzunluk_Hesabı_Zorluk_Get_All()
        {
            var temp = (from y in _context.Büküm_Uzunluk_Hesabı_Zorluk
                        where y.Is_Deleted==0

                        select y
            ).ToList();

            IEnumerable<Büküm_Uzunluk_Hesabı_Zorluk_Return_Value> rd = temp.Select(o => new Büküm_Uzunluk_Hesabı_Zorluk_Return_Value
            {
                Id = o.Id,
                Zorluk_Adı = o.Zorluk_Adı,
                Zorluk_Katsayısı = o.Zorluk_Katsayısı,
                Büküm_Uzunluk_Hesabı_Id = o.Büküm_Uzunluk_Hesabı_Id,
                Büküm_Uzunluk_Hesabı = (from z in _context.Büküm_Uzunluk_Hesabı
                                        select z
                ).FirstOrDefault(z => z.Id == o.Büküm_Uzunluk_Hesabı_Id)

            });
            return rd.ToList();
        }

        public Büküm_Uzunluk_Hesabı_Zorluk_Return_Value Büküm_Uzunluk_Hesabı_Zorluk_Get_By_Id(Büküm_Uzunluk_Hesabı_Zorluk x)
        {
            var temp = (from y in _context.Büküm_Uzunluk_Hesabı_Zorluk
                        where x.Is_Deleted==0

                        select y
            ).ToList();

            IEnumerable<Büküm_Uzunluk_Hesabı_Zorluk_Return_Value> rd = temp.Select(o => new Büküm_Uzunluk_Hesabı_Zorluk_Return_Value
            {
                Id = o.Id,
                Zorluk_Adı = o.Zorluk_Adı,
                Zorluk_Katsayısı = o.Zorluk_Katsayısı,
                Büküm_Uzunluk_Hesabı_Id = o.Büküm_Uzunluk_Hesabı_Id,
                Büküm_Uzunluk_Hesabı = (from z in _context.Büküm_Uzunluk_Hesabı
                                        select z
                ).FirstOrDefault(z => z.Id == o.Büküm_Uzunluk_Hesabı_Id)

            });

            return rd.FirstOrDefault(o => o.Id == x.Id);

        }
        public List<Büküm_Uzunluk_Hesabı_Zorluk_Return_Value> Büküm_Uzunluk_Hesabı_Zorluk_Get_Genel_Id(Büküm_Uzunluk_Hesabı x)
        {
            var temp = (from y in _context.Büküm_Uzunluk_Hesabı_Zorluk
                         
                        where y.Büküm_Uzunluk_Hesabı_Id == x.Id && x.Is_Deleted==0
                        select y
            ).ToList();

            IEnumerable<Büküm_Uzunluk_Hesabı_Zorluk_Return_Value> rd = temp.Select(o => new Büküm_Uzunluk_Hesabı_Zorluk_Return_Value
            {
                Id = o.Id,
                Zorluk_Adı = o.Zorluk_Adı,
                Zorluk_Katsayısı = o.Zorluk_Katsayısı,
                Büküm_Uzunluk_Hesabı_Id = o.Büküm_Uzunluk_Hesabı_Id,
                Büküm_Uzunluk_Hesabı = (from z in _context.Büküm_Uzunluk_Hesabı
                                        select z
                ).FirstOrDefault(z => z.Id == o.Büküm_Uzunluk_Hesabı_Id)

            });

            return rd.ToList();

        }

        public Büküm_KiloHesabı Uygun_Büküm_Kilo_Getir(Büküm_KiloHesabı y)
        {
            var temp = (from x in _context.Büküm_KiloHesabı
                        where y.Kilo_Bas >= x.Kilo_Bas && y.Kilo_Bas <= x.Kilo_Son && x.Is_Deleted==0
                        select x
           ).FirstOrDefault();

            return temp;
        }


        public Büküm_Uzunluk_Hesabı Malzeme_Uzunuğuna_Göre_Katsayı_Getir(Büküm_Uzunluk_Hesabı y)
        {
            var temp = (from x in _context.Büküm_Uzunluk_Hesabı
                        where y.Uzunluk_Bas >= x.Uzunluk_Bas && y.Uzunluk_Bas <= x.Uzunluk_Son && x.Is_Deleted==0
                        select x
            ).FirstOrDefault();

            return temp;

        }

        public List<Büküm_Uzunluk_Hesabı_Zorluk_Return_Value> Büküm_Uzunluk_Hesabı_Zorluk_Get_By_Uzunluk_Hesabı_Id(Büküm_Uzunluk_Hesabı y)
        {
            var temp = (from x in _context.Büküm_Uzunluk_Hesabı_Zorluk
                        where x.Büküm_Uzunluk_Hesabı_Id == y.Id && x.Is_Deleted==0
                        select x


            );

            IEnumerable<Büküm_Uzunluk_Hesabı_Zorluk_Return_Value> rv = temp.Select(o => new Büküm_Uzunluk_Hesabı_Zorluk_Return_Value
            {

                Id = o.Id,
                Büküm_Uzunluk_Hesabı_Id = o.Büküm_Uzunluk_Hesabı_Id,
                Zorluk_Adı = o.Zorluk_Adı,
                Zorluk_Katsayısı = o.Zorluk_Katsayısı,
                Büküm_Uzunluk_Hesabı = (from x in _context.Büküm_Uzunluk_Hesabı
                                        where x.Id == o.Büküm_Uzunluk_Hesabı_Id
                                        select x

                ).FirstOrDefault()
            });

            return rv.ToList();

        }
    }
}