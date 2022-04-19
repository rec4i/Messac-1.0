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

namespace qrmenu.Services
{
    public interface IKesimService
    {
        Kesim_Türü Kesim_Türü_Add(Kesim_Türü kesim_Türü);

        Kesim_Türü Kesim_Türü_Delete(Kesim_Türü kesim_Türü);

        Kesim_Türü Kesim_Türü_Edit(Kesim_Türü kesim_Türü);

        List<Kesim_Türü> Kesim_Türü_Get_All();

        Kesim_Türü Kesim_Türü_Get_By_Id(Kesim_Türü kesim_Türü);

        Kesim Kesim_Add(Kesim kesim);

        Kesim Kesim_Delete(Kesim kesim);

        Kesim Kesim_Edit(Kesim kesim);

        List<Kesim_Retun_value> Kesim_Get_All();

        Kesim_Retun_value Kesim_Get_By_Id(Kesim kesim);

        List<Kesim_Retun_value> Kesim_Get_By_Kesim_Türü_Id(Kesim_Türü x);

        List<Kesim_Retun_value> Kesim_Uygun_Olanı_Getir(Kesim x);

        void Kesim_Türünden_Hepsini_Sil(Kesim_Türü x);


    }
    public class KesimService : IKesimService
    {

        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public KesimService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Kesim_Türü Kesim_Türü_Add(Kesim_Türü kesim_Türü)
        {
            _context.kesim_Türüs.Add(kesim_Türü);
            _context.SaveChanges();

            return kesim_Türü;

        }

        public Kesim_Türü Kesim_Türü_Delete(Kesim_Türü kesim_Türü)
        {
            var temp = _context.kesim_Türüs;
            var Değer = temp.FirstOrDefault(o => o.Id == kesim_Türü.Id);
            Değer.Is_Deleted = 1;
            //_context.kesim_Türüs.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Kesim_Türü Kesim_Türü_Edit(Kesim_Türü kesim_Türü)
        {
            var temp = _context.kesim_Türüs;
            var Değer = temp.FirstOrDefault(o => o.Id == kesim_Türü.Id);
            Değer.Kesim_Türü_Txt = kesim_Türü.Kesim_Türü_Txt;
            _context.SaveChanges();

            return Değer;
        }

        public List<Kesim_Türü> Kesim_Türü_Get_All()
        {
            var temp = (from x in _context.kesim_Türüs
                        where x.Is_Deleted == 0
                        select x
            );

            IEnumerable<Kesim_Türü> rv = temp.Select(o => new Kesim_Türü
            {
                Id = o.Id,
                Kesim_Türü_Txt = o.Kesim_Türü_Txt
            });

            return rv.ToList();

        }

        public Kesim_Türü Kesim_Türü_Get_By_Id(Kesim_Türü kesim_Türü)
        {
            var temp = _context.kesim_Türüs;
            var Değer = temp.FirstOrDefault(o => o.Id == kesim_Türü.Id && o.Is_Deleted == 0);
            return Değer;
        }

        public Kesim Kesim_Add(Kesim kesim)
        {
            _context.Add(kesim);
            _context.SaveChanges();
            return kesim;

        }

        public Kesim Kesim_Delete(Kesim kesim)
        {
            var temp = _context.Kesims;
            var Değer = temp.FirstOrDefault(o => o.Id == kesim.Id);
            Değer.Is_Deleted = 1;
            //_context.Kesims.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Kesim Kesim_Edit(Kesim kesim)
        {
            var temp = _context.Kesims;
            var Değer = temp.SingleOrDefault(o => o.Id == kesim.Id);
            Değer.Kesim_mm_Bas = kesim.Kesim_mm_Bas;
            Değer.Kesim_mm_Son = kesim.Kesim_mm_Son;
            Değer.Kesim_Türü_Id = kesim.Kesim_Türü_Id;
            Değer.Saat_Bası_Ucret = kesim.Saat_Bası_Ucret;
            _context.SaveChanges();

            return Değer;
        }

        public List<Kesim_Retun_value> Kesim_Get_All()
        {
            var temp = (from x in _context.Kesims
                        where x.Is_Deleted == 0
                        select x
            );

            IEnumerable<Kesim_Retun_value> rv = temp.Select(o => new Kesim_Retun_value
            {
                Id = o.Id,
                Kesim_mm_Bas = o.Kesim_mm_Bas,
                Kesim_mm_Son = o.Kesim_mm_Son,
                Kesim_Türü_Id = o.Kesim_Türü_Id,
                Saat_Bası_Ucret = o.Saat_Bası_Ucret,

                Birim_Id = o.Birim_Id,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                ).FirstOrDefault()
            });
            return rv.ToList();

        }

        public Kesim_Retun_value Kesim_Get_By_Id(Kesim kesim)
        {
            var temp = _context.Kesims;
            var Değer = temp.FirstOrDefault(o => o.Id == kesim.Id);

            Kesim_Retun_value rv = new Kesim_Retun_value
            {
                Id = Değer.Id,
                Kesim_mm_Bas = Değer.Kesim_mm_Bas,
                Kesim_mm_Son = Değer.Kesim_mm_Son,
                Kesim_Türü_Id = Değer.Kesim_Türü_Id,
                Saat_Bası_Ucret = Değer.Saat_Bası_Ucret,

                Birim_Id = Değer.Birim_Id,
                Birim = (from x in _context.Birimlers
                         where x.Id == Değer.Birim_Id
                         select x
                ).FirstOrDefault()
            };

            return rv;
        }

        public List<Kesim_Retun_value> Kesim_Get_By_Kesim_Türü_Id(Kesim_Türü x)
        {
            var temp = _context.Kesims;
            var Değer = (from y in temp
                         where y.Kesim_Türü_Id == x.Id && y.Is_Deleted == 0
                         
                         select y
            );

            IEnumerable<Kesim_Retun_value> Değer_ = Değer.Select(o => new Kesim_Retun_value
            {
                Id = o.Id,
                Kesim_mm_Bas = o.Kesim_mm_Bas,
                Kesim_mm_Son = o.Kesim_mm_Son,
                Kesim_Türü_Id = o.Kesim_Türü_Id,
                Saat_Bası_Ucret = o.Saat_Bası_Ucret,

                Birim_Id = o.Birim_Id,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                ).FirstOrDefault()

            });
            return Değer_.ToList();
        }

        public void Kesim_Türünden_Hepsini_Sil(Kesim_Türü x)
        {
            int Id_ = x.Id;


            var temp = _context.kesim_Türüs;
            var Değer = temp.FirstOrDefault(o => o.Id == Id_);
            Değer.Is_Deleted = 1;
            //_context.kesim_Türüs.Remove(Değer);

            _context.SaveChanges();

            // var temp_ = _context.Kesims;
            // var Değer_ = temp_.FirstOrDefault(o => o.Kesim_Türü_Id == Id_);
            // _context.Kesims.Remove(Değer_);
            // _context.SaveChanges();

            var temp_ = _context.Kesims;
            //var Değer_ = temp_.RemoveMultiple();
            //_context.Kesims.Remove(Değer_);

            var query = _context.Set<Kesim>().Where(o => o.Kesim_Türü_Id == Id_ && o.Is_Deleted == 0);

            foreach (var item in query)
            {
                item.Is_Deleted = 1;
            }

            //_context.Set<Kesim>().RemoveRange(query.AsNoTracking());

            _context.SaveChanges();





        }

        public List<Kesim_Retun_value> Kesim_Uygun_Olanı_Getir(Kesim x)
        {
            var temp = _context.Kesims;
            var Değer = (from y in temp
                         where y.Kesim_Türü_Id == x.Kesim_Türü_Id &&
                         (x.Kesim_mm_Bas >= y.Kesim_mm_Bas && x.Kesim_mm_Bas <= y.Kesim_mm_Son
                         ) && y.Is_Deleted == 0
                         select y
            );

            IEnumerable<Kesim_Retun_value> Değer_ = Değer.Select(o => new Kesim_Retun_value
            {
                Id = o.Id,
                Kesim_mm_Bas = o.Kesim_mm_Bas,
                Kesim_mm_Son = o.Kesim_mm_Son,
                Kesim_Türü_Id = o.Kesim_Türü_Id,
                Saat_Bası_Ucret = o.Saat_Bası_Ucret,

                Birim_Id = o.Birim_Id,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                ).FirstOrDefault()

            });
            return Değer_.ToList();
        }
    }
}