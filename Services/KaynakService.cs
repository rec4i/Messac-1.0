using System.Collections.Generic;
using System.Linq;
using KaynakKod.Entities.UretimMaliyeti.İşlemler;
using Microsoft.Extensions.Options;
using qrmenu.Entities;
using WebApi.Authorization;
using WebApi.Helpers;

namespace KaynakKod.Services
{

    public interface IKaynakService
    {
        Kaynak Kaynak_Add(Kaynak x);

        Kaynak Kaynak_Delete(Kaynak x);

        Kaynak Kaynak_Edit(Kaynak x);

        List<Kaynak_Return_Value> Kaynak_Get_All();

        Kaynak_Return_Value Kaynak_Get_By_Id(Kaynak x);

        List<Kaynak_Return_Value> Kaynak_Get_By_Text(Kaynak x);


        Birimler birimler_Add(Birimler x);

        Birimler birimler_Delete(Birimler x);

        Birimler birimler_Edit(Birimler x);

        List<Birimler> birimler_Get_All();

        Birimler birimler_Get_By_Id(Birimler x);

    }
    public class KaynakService : IKaynakService
    {

        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public KaynakService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Kaynak Kaynak_Add(Kaynak x)
        {
            _context.Kaynaks.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Kaynak Kaynak_Delete(Kaynak x)
        {
            var temp = _context.Kaynaks;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted=1;
            //_context.Kaynaks.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Kaynak Kaynak_Edit(Kaynak x)
        {
            var temp = _context.Kaynaks;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Birim_Id = x.Birim_Id;
            Değer.Kaynak_Türü = x.Kaynak_Türü;
            Değer.Maliyet = x.Maliyet;
            _context.SaveChanges();

            return Değer;
        }

        public List<Kaynak_Return_Value> Kaynak_Get_All()
        {
            var temp = _context.Kaynaks;

            var Değer = (from x in temp
                         join Birim in _context.Birimlers
                         on x.Birim_Id equals Birim.Id
                         where x.Is_Deleted==0
                         select new
                         {
                             x.Birim_Id,
                             x.Id,
                             x.Kaynak_Türü,
                             x.Maliyet,
                             Birim
                         }
            );

            IEnumerable<Kaynak_Return_Value> rd = Değer.Select(o => new Kaynak_Return_Value
            {
                Birim_Id = o.Birim_Id,
                Id = o.Id,
                Kaynak_Türü = o.Kaynak_Türü,
                Maliyet = o.Maliyet,
                Birim = o.Birim
            });

            return rd.ToList();

        }

        public Kaynak_Return_Value Kaynak_Get_By_Id(Kaynak x)
        {
            var temp = _context.Kaynaks;

            var Değer = (from y in temp
                         join Birim in _context.Birimlers
                         on y.Birim_Id equals Birim.Id
                         where x.Is_Deleted==0
                         select new
                         {
                             y.Birim_Id,
                             y.Id,
                             y.Kaynak_Türü,
                             y.Maliyet,
                             Birim
                         }

            ).FirstOrDefault(o => o.Id == x.Id);
            Kaynak_Return_Value rd = new Kaynak_Return_Value
            {
                Birim_Id = Değer.Birim_Id,
                Id = Değer.Id,
                Kaynak_Türü = Değer.Kaynak_Türü,
                Maliyet = Değer.Maliyet,
                Birim = Değer.Birim

            };
            return rd;

        }

        public Birimler birimler_Add(Birimler x)
        {
            _context.Birimlers.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Birimler birimler_Delete(Birimler x)
        {
            var temp = _context.Birimlers;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted=1;
            //_context.Birimlers.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Birimler birimler_Edit(Birimler x)
        {
            var temp = _context.Birimlers;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Birim_Uzun_Ad = x.Birim_Uzun_Ad;
            Değer.Birim_Kısa_ad = x.Birim_Kısa_ad;
            _context.SaveChanges();
            return Değer;
        }

        public List<Birimler> birimler_Get_All()
        {
            var temp = (from x in _context.Birimlers
                        where x.Is_Deleted==0
                        select x
            );

            return temp.ToList();

        }

        public Birimler birimler_Get_By_Id(Birimler x)
        {
            var temp = _context.Birimlers.FirstOrDefault(o => o.Id == x.Id && o.Is_Deleted==0);
            return temp;
        }

      
        public List<Kaynak_Return_Value> Kaynak_Get_By_Text(Kaynak malzeme)
        {
            var temp = _context.Kaynaks;
            var Değer = (from x in temp
                         join Birim in _context.Birimlers
                         on x.Birim_Id equals Birim.Id


                        
                         where x.Kaynak_Türü.StartsWith(malzeme.Kaynak_Türü)  && x.Is_Deleted==0
                         select new
                         {
                            x.Birim_Id,
                            x.Id,
                            x.Kaynak_Türü,
                            x.Maliyet,
                            Birim
                         }
            );
            IEnumerable<Kaynak_Return_Value> Return_değer = Değer.Select(o => new Kaynak_Return_Value
            {
                Birim=o.Birim,
                Birim_Id=o.Birim_Id,
                Id=o.Id,
                Maliyet=o.Maliyet,
                Kaynak_Türü=o.Kaynak_Türü
            });
            return Return_değer.ToList();
        }
    }
}