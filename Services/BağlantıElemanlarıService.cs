using System.Collections.Generic;
using System.Linq;
using KaynakKod.Entities.UretimMaliyeti.İşlemler;
using Microsoft.Extensions.Options;
using qrmenu.Entities;
using WebApi.Authorization;
using WebApi.Helpers;



namespace KaynakKod.Services
{
    public interface IBaglantıElemanlarıService
    {
        BaglantıElemanları BaglantıElemanları_Add(BaglantıElemanları x);

        BaglantıElemanları baglantıElemanları_Delete(BaglantıElemanları x);

        BaglantıElemanları baglantıElemanları_Edit(BaglantıElemanları x);

        List<BaglantıElemanları_Retun_Value> baglantıElemanları_Get_All();

        BaglantıElemanları_Retun_Value baglantıElemanları_Get_By_Id(BaglantıElemanları x);

        List<BaglantıElemanları_Retun_Value> baglantıElemanları_Get_By_Bağlantı_Türü_Id(Bağlantı_Elemanları_Türü x);





        Bağlantı_Elemanları_Türü bağlantı_Elemanları_Türü_Add(Bağlantı_Elemanları_Türü x);

        Bağlantı_Elemanları_Türü bağlantı_Elemanları_Türü_Delete(Bağlantı_Elemanları_Türü x);

        Bağlantı_Elemanları_Türü bağlantı_Elemanları_Türü_Edit(Bağlantı_Elemanları_Türü x);

        List<Bağlantı_Elemanları_Türü> bağlantı_Elemanları_Türü_Get_All();

        Bağlantı_Elemanları_Türü bağlantı_Elemanları_Türü_Get_By_Id(Bağlantı_Elemanları_Türü x);

        List<BaglantıElemanları_Retun_Value> baglantıElemanları_Get_By_Text(BaglantıElemanları x);
    }
    public class BağlantıElemanlarıService : IBaglantıElemanlarıService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public BağlantıElemanlarıService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public BaglantıElemanları BaglantıElemanları_Add(BaglantıElemanları x)
        {
            _context.baglantıElemanlarıs.Add(x);
            _context.SaveChanges();
            return x;

        }

        public BaglantıElemanları baglantıElemanları_Delete(BaglantıElemanları x)
        {

            var temp = _context.baglantıElemanlarıs;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;

        }

        public BaglantıElemanları baglantıElemanları_Edit(BaglantıElemanları x)
        {
            var temp = _context.baglantıElemanlarıs;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Bağlantı_Elemanları_Türü_Id = x.Bağlantı_Elemanları_Türü_Id;
            Değer.Bağlantı_Elemanı_Text = x.Bağlantı_Elemanı_Text;
            Değer.Birim_Fiyat = x.Birim_Fiyat;
            _context.SaveChanges();

            return Değer;
        }

        public List<BaglantıElemanları_Retun_Value> baglantıElemanları_Get_All()
        {
            var temp = (from x in _context.baglantıElemanlarıs
                        where x.Is_Deleted == 0
                        select new
                        {
                            x.Bağlantı_Elemanları_Türü_Id,
                            x.Bağlantı_Elemanı_Text,
                            x.Birim_Fiyat,
                            x.Id
                        }
            );

            IEnumerable<BaglantıElemanları_Retun_Value> rd = temp.Select(o => new BaglantıElemanları_Retun_Value
            {
                Id = o.Id,
                Bağlantı_Elemanları_Türü_Id = o.Bağlantı_Elemanları_Türü_Id,
                Bağlantı_Elemanı_Text = o.Bağlantı_Elemanı_Text,
                Birim_Fiyat = o.Birim_Fiyat,
                Bağlantı_Elemanları_Türü = (from x in _context.bağlantı_Elemanları_Türüs
                                            where x.Id == o.Id
                                            select x
                ).FirstOrDefault()

            });

            return rd.ToList();


        }

        public BaglantıElemanları_Retun_Value baglantıElemanları_Get_By_Id(BaglantıElemanları y)
        {
            var temp = (from x in _context.baglantıElemanlarıs
                        where x.Id == y.Id && x.Is_Deleted==0
                        select new
                        {
                            x.Bağlantı_Elemanları_Türü_Id,
                            x.Bağlantı_Elemanı_Text,
                            x.Birim_Fiyat,
                            x.Id
                        }
           ).FirstOrDefault();


            BaglantıElemanları_Retun_Value rd = new BaglantıElemanları_Retun_Value
            {
                Id = temp.Id,
                Bağlantı_Elemanı_Text = temp.Bağlantı_Elemanı_Text,
                Birim_Fiyat = temp.Birim_Fiyat,
                Bağlantı_Elemanları_Türü_Id = temp.Bağlantı_Elemanları_Türü_Id,
                Bağlantı_Elemanları_Türü = (from x in _context.bağlantı_Elemanları_Türüs
                                            where x.Id == temp.Bağlantı_Elemanları_Türü_Id
                                            select x
                ).FirstOrDefault()
            };



            return rd;
        }

        public Bağlantı_Elemanları_Türü bağlantı_Elemanları_Türü_Add(Bağlantı_Elemanları_Türü x)
        {
            _context.bağlantı_Elemanları_Türüs.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Bağlantı_Elemanları_Türü bağlantı_Elemanları_Türü_Delete(Bağlantı_Elemanları_Türü x)
        {
            var temp = _context.bağlantı_Elemanları_Türüs;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted=1;
            //_context.bağlantı_Elemanları_Türüs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Bağlantı_Elemanları_Türü bağlantı_Elemanları_Türü_Edit(Bağlantı_Elemanları_Türü x)
        {
            var temp = _context.bağlantı_Elemanları_Türüs;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Bağlantı_Elemanları_Türü_Text = x.Bağlantı_Elemanları_Türü_Text;
            _context.SaveChanges();

            return Değer;
        }

        public List<Bağlantı_Elemanları_Türü> bağlantı_Elemanları_Türü_Get_All()
        {
            var temp = (from x in _context.bağlantı_Elemanları_Türüs
            where x.Is_Deleted==0
                        select x
            );

            return temp.ToList();
        }

        public Bağlantı_Elemanları_Türü bağlantı_Elemanları_Türü_Get_By_Id(Bağlantı_Elemanları_Türü y)
        {
            var temp = (from x in _context.bağlantı_Elemanları_Türüs
                        where x.Id == y.Id && x.Is_Deleted==0
                        select x
            ).FirstOrDefault();
            return temp;

        }

        public List<BaglantıElemanları_Retun_Value> baglantıElemanları_Get_By_Bağlantı_Türü_Id(Bağlantı_Elemanları_Türü y)
        {
            var temp = (from x in _context.baglantıElemanlarıs
                        where y.Id == x.Bağlantı_Elemanları_Türü_Id && x.Is_Deleted==0
                        select new
                        {
                            x.Bağlantı_Elemanları_Türü_Id,
                            x.Bağlantı_Elemanı_Text,
                            x.Birim_Fiyat,
                            x.Id
                        }
            );

            IEnumerable<BaglantıElemanları_Retun_Value> rd = temp.Select(o => new BaglantıElemanları_Retun_Value
            {
                Id = o.Id,
                Bağlantı_Elemanları_Türü_Id = o.Bağlantı_Elemanları_Türü_Id,
                Bağlantı_Elemanı_Text = o.Bağlantı_Elemanı_Text,
                Birim_Fiyat = o.Birim_Fiyat,
                Bağlantı_Elemanları_Türü = (from x in _context.bağlantı_Elemanları_Türüs
                                            where x.Id == o.Id
                                            select x
                ).FirstOrDefault()

            });

            return rd.ToList();
        }

        public List<BaglantıElemanları_Retun_Value> baglantıElemanları_Get_By_Text(BaglantıElemanları malzeme)
        {
            var temp = _context.baglantıElemanlarıs;
            var Değer = (from x in temp
                         join Bağlantı_Elemanı_Türü in _context.bağlantı_Elemanları_Türüs
                         on x.Bağlantı_Elemanları_Türü_Id equals Bağlantı_Elemanı_Türü.Id


                         where x.Bağlantı_Elemanı_Text.StartsWith(malzeme.Bağlantı_Elemanı_Text) && x.Is_Deleted==0 && Bağlantı_Elemanı_Türü.Is_Deleted==0
                         select new
                         {
                             x.Bağlantı_Elemanları_Türü_Id,
                             x.Bağlantı_Elemanı_Text,
                             x.Birim_Fiyat,
                             x.Id,
                             Bağlantı_Elemanı_Türü
                         }
            );
            IEnumerable<BaglantıElemanları_Retun_Value> Return_değer = Değer.Select(o => new BaglantıElemanları_Retun_Value
            {
                Bağlantı_Elemanları_Türü = o.Bağlantı_Elemanı_Türü,
                Bağlantı_Elemanı_Text = o.Bağlantı_Elemanı_Text,
                Id = o.Id,
                Birim_Fiyat = o.Birim_Fiyat,
                Bağlantı_Elemanları_Türü_Id = o.Bağlantı_Elemanları_Türü_Id

            });
            return Return_değer.ToList();
        }
    }
}