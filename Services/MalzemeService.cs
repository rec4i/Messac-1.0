using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Authorization;
using WebApi.Models.Şehir_Request;
using qrmenu.Models.Uyeİşlemleri;
using qrmenu.Entities;
using Microsoft.EntityFrameworkCore;

namespace KaynakKod.Services
{
    public interface IMalzemeService
    {
        Malzeme_Genel_Adı malzeme_Genel_Adı_Add(Malzeme_Genel_Adı x);

        Malzeme_Genel_Adı malzeme_Genel_Adı_Delete(Malzeme_Genel_Adı x);
        Malzeme_Genel_Adı malzeme_Genel_Adı_Edit(Malzeme_Genel_Adı x);

        List<Malzeme_Genel_Adı> malzeme_Genel_Adı_Get_All();

        Malzeme_Genel_Adı malzeme_Genel_Adı_Get_By_Id(Malzeme_Genel_Adı x);


        Malzeme malzeme_Add(Malzeme x);

        Malzeme malzeme_Delete(Malzeme x);

        Malzeme malzeme_Edit(Malzeme x);

        List<Malzeme_Return_Value> Malzeme_Get_All();

        Malzeme_Return_Value malzeme_Get_By_Id(Malzeme x);

        List<Malzeme_Return_Value> Malzeme_Get_By_Text(Malzeme x);


    }
    public class MalzemeService : IMalzemeService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public MalzemeService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Malzeme malzeme_Add(Malzeme x)
        {
            _context.malzemes.Add(x);
            _context.SaveChanges();
            return x;


        }

        public Malzeme malzeme_Delete(Malzeme x)
        {
            var temp = _context.malzemes;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted=1;
           // _context.malzemes.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Malzeme malzeme_Edit(Malzeme x)
        {
            var temp = _context.malzemes;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);

            Değer.Büküm_Kriteri = x.Büküm_Kriteri;
            Değer.Fiyat = x.Fiyat;
            Değer.Kesim_TürüId = x.Kesim_TürüId;
            Değer.Malzeme_Cinsi = x.Malzeme_Cinsi;
            Değer.Malzeme_Genel_AdıId = x.Malzeme_Genel_AdıId;
            Değer.Özgül_Ağırlık = x.Özgül_Ağırlık;

            _context.SaveChanges();

            return Değer;
        }

        public Malzeme_Genel_Adı malzeme_Genel_Adı_Add(Malzeme_Genel_Adı x)
        {
            _context.Malzeme_Genel_Adıs.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Malzeme_Genel_Adı malzeme_Genel_Adı_Delete(Malzeme_Genel_Adı x)
        {
            var temp = _context.Malzeme_Genel_Adıs;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted=1;
            //_context.Malzeme_Genel_Adıs.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Malzeme_Genel_Adı malzeme_Genel_Adı_Edit(Malzeme_Genel_Adı x)
        {
            var temp = _context.Malzeme_Genel_Adıs;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);

            Değer.Malzeme_Genel_Adı_Txt = x.Malzeme_Genel_Adı_Txt;
            _context.SaveChanges();

            return Değer;
        }

        public List<Malzeme_Genel_Adı> malzeme_Genel_Adı_Get_All()
        {
            var temp = (from x in _context.Malzeme_Genel_Adıs
                        where x.Is_Deleted==0
                        select x                                   
            );

            IEnumerable<Malzeme_Genel_Adı> rv = temp.Select(o => new Malzeme_Genel_Adı{
                Id=o.Id,
                Malzeme_Genel_Adı_Txt=o.Malzeme_Genel_Adı_Txt
            });


            return rv.ToList();

        }

        public Malzeme_Genel_Adı malzeme_Genel_Adı_Get_By_Id(Malzeme_Genel_Adı x)
        {
            var temp = _context.Malzeme_Genel_Adıs;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id &&o.Is_Deleted ==0);
            return Değer;
        }

        public List<Malzeme_Return_Value> Malzeme_Get_All()
        {
            var temp = _context.malzemes;


            var Değer = (from x in temp
                         join Malzeme_Adı in _context.Malzeme_Genel_Adıs
                         on x.Kesim_TürüId equals Malzeme_Adı.Id

                         join Kesim_Türü in _context.kesim_Türüs
                         on x.Kesim_TürüId equals Kesim_Türü.Id

                        where x.Is_Deleted ==0

                         select new
                         {
                             x.Büküm_Kriteri,
                             x.Fiyat,
                             x.Id,
                             x.Kesim_TürüId,
                             Kesim_Türü.Kesim_Türü_Txt,
                             Malzeme_Adı.Malzeme_Genel_Adı_Txt,
                             x.Malzeme_Genel_AdıId,
                             x.Özgül_Ağırlık,
                             x.Malzeme_Cinsi
                         }
            );

            IEnumerable<Malzeme_Return_Value> Return_değer = Değer.Select(o => new Malzeme_Return_Value
            {
                Id = o.Id,
                Malzeme_Cinsi = o.Malzeme_Cinsi,
                Büküm_Kriteri = o.Büküm_Kriteri,
                Fiyat = o.Fiyat,
                Kesim_Türü = new Kesim_Türü
                {
                    Id = o.Kesim_TürüId,
                    Kesim_Türü_Txt = o.Kesim_Türü_Txt
                },
                Malzeme_Genel_AdıId = new Malzeme_Genel_Adı
                {
                    Id = o.Malzeme_Genel_AdıId,
                    Malzeme_Genel_Adı_Txt = o.Malzeme_Genel_Adı_Txt
                },
                Özgül_Ağırlık = o.Özgül_Ağırlık

            });




            return Return_değer.ToList();
        }

        public Malzeme_Return_Value malzeme_Get_By_Id(Malzeme malzeme)
        {
            var temp = _context.malzemes;
            var Değer = (from x in temp
                         join Malzeme_Adı in _context.Malzeme_Genel_Adıs
                         on x.Kesim_TürüId equals Malzeme_Adı.Id

                         join Kesim_Türü in _context.kesim_Türüs
                         on x.Kesim_TürüId equals Kesim_Türü.Id
                         where x.Id == malzeme.Id && x.Is_Deleted ==0
                         select new
                         {
                             x.Büküm_Kriteri,
                             x.Fiyat,
                             x.Id,
                             x.Kesim_TürüId,
                             Kesim_Türü.Kesim_Türü_Txt,
                             Malzeme_Adı.Malzeme_Genel_Adı_Txt,
                             x.Malzeme_Genel_AdıId,
                             x.Özgül_Ağırlık,
                             x.Malzeme_Cinsi
                         }
            );
            IEnumerable<Malzeme_Return_Value> Return_değer = Değer.Select(o => new Malzeme_Return_Value
            {
                Id = o.Id,
                Malzeme_Cinsi = o.Malzeme_Cinsi,
                Büküm_Kriteri = o.Büküm_Kriteri,
                Fiyat = o.Fiyat,
                Kesim_Türü = new Kesim_Türü
                {
                    Id = o.Kesim_TürüId,
                    Kesim_Türü_Txt = o.Kesim_Türü_Txt
                },
                Malzeme_Genel_AdıId = new Malzeme_Genel_Adı
                {
                    Id = o.Malzeme_Genel_AdıId,
                    Malzeme_Genel_Adı_Txt = o.Malzeme_Genel_Adı_Txt
                },
                Özgül_Ağırlık = o.Özgül_Ağırlık

            });



            return Return_değer.FirstOrDefault(o => o.Id == malzeme.Id);
        }

        public List<Malzeme_Return_Value> Malzeme_Get_By_Text(Malzeme malzeme)
        {
             var temp = _context.malzemes;
            var Değer = (from x in temp
                         join Malzeme_Adı in _context.Malzeme_Genel_Adıs
                         on x.Kesim_TürüId equals Malzeme_Adı.Id

                         join Kesim_Türü in _context.kesim_Türüs
                         on x.Kesim_TürüId equals Kesim_Türü.Id
                         where x.Malzeme_Cinsi.StartsWith(malzeme.Malzeme_Cinsi) &&  x.Is_Deleted ==0
                         select new
                         {
                             x.Büküm_Kriteri,
                             x.Fiyat,
                             x.Id,
                             x.Kesim_TürüId,
                             Kesim_Türü.Kesim_Türü_Txt,
                             Malzeme_Adı.Malzeme_Genel_Adı_Txt,
                             x.Malzeme_Genel_AdıId,
                             x.Özgül_Ağırlık,
                             x.Malzeme_Cinsi
                         }
            );
            IEnumerable<Malzeme_Return_Value> Return_değer = Değer.Select(o => new Malzeme_Return_Value
            {
                Id = o.Id,
                Malzeme_Cinsi = o.Malzeme_Cinsi,
                Büküm_Kriteri = o.Büküm_Kriteri,
                Fiyat = o.Fiyat,
                Kesim_Türü = new Kesim_Türü
                {
                    Id = o.Kesim_TürüId,
                    Kesim_Türü_Txt = o.Kesim_Türü_Txt
                },
                Malzeme_Genel_AdıId = new Malzeme_Genel_Adı
                {
                    Id = o.Malzeme_Genel_AdıId,
                    Malzeme_Genel_Adı_Txt = o.Malzeme_Genel_Adı_Txt
                },
                Özgül_Ağırlık = o.Özgül_Ağırlık

            });
            return Return_değer.ToList();
        }
    }
}