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
using KaynakKod.Entities.UretimMaliyeti.İşlemler;

namespace qrmenu.Services
{
    public interface IPaketlemeService
    {
        Paketleme Paketleme_Add(Paketleme x);
        Paketleme Paketleme_Delete(Paketleme x);
        Paketleme Paketleme_Edit(Paketleme x);
        List<Paketleme_Return_Value> Paketleme_Get_All();
        Paketleme_Return_Value Paketleme_Get_By_Id(Paketleme x);
        List<Paketleme_Return_Value> Paketleme_Get_By_Text(Paketleme x);



    }
    public class PaketlemeService : IPaketlemeService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public PaketlemeService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Paketleme Paketleme_Add(Paketleme x)
        {
            _context.Paketlemes.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Paketleme Paketleme_Delete(Paketleme x)
        {
            var temp = _context.Paketlemes;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            _context.SaveChanges();

            return Değer;
        }

        public Paketleme Paketleme_Edit(Paketleme x)
        {
            var temp = _context.Paketlemes;
            var Değer = temp.SingleOrDefault(o => o.Id == x.Id);
            Değer.Birim_Id = x.Birim_Id;
            Değer.Paketleme_Türü = x.Paketleme_Türü;
            Değer.Maliyet = x.Maliyet;

            _context.SaveChanges();

            return Değer;
        }

        public List<Paketleme_Return_Value> Paketleme_Get_All()
        {
            var temp = (from x in _context.Paketlemes
                        where x.Is_Deleted == 0
                        select x
            );
            IEnumerable<Paketleme_Return_Value> rt = temp.Select(o => new Paketleme_Return_Value
            {
                Id = o.Id,
                Birim_Id = o.Birim_Id,
                Paketleme_Türü = o.Paketleme_Türü,
                Maliyet = o.Maliyet,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                ).FirstOrDefault()

            });
            return rt.ToList();

        }

        public Paketleme_Return_Value Paketleme_Get_By_Id(Paketleme y)
        {
            var temp = (from x in _context.Paketlemes
                        where x.Id == y.Id && x.Is_Deleted == 0
                        select x
             );
            IEnumerable<Paketleme_Return_Value> rt = temp.Select(o => new Paketleme_Return_Value
            {
                Id = o.Id,
                Birim_Id = o.Birim_Id,
                Paketleme_Türü = o.Paketleme_Türü,
                Maliyet = o.Maliyet,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                ).FirstOrDefault()

            });

            return rt.FirstOrDefault();
        }

        public List<Paketleme_Return_Value> Paketleme_Get_By_Text(Paketleme y)
        {
            var temp = (from x in _context.Paketlemes
                        where x.Is_Deleted == 0 && x.Paketleme_Türü.StartsWith(y.Paketleme_Türü)
                        select x
            );
            IEnumerable<Paketleme_Return_Value> rt = temp.Select(o => new Paketleme_Return_Value
            {
                Id = o.Id,
                Birim_Id = o.Birim_Id,
                Paketleme_Türü = o.Paketleme_Türü,
                Maliyet = o.Maliyet,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                ).FirstOrDefault()

            });
            return rt.ToList();
        }
    }
}