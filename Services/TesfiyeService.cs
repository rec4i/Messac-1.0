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
    public interface ITesviyeService
    {
        Tesviye Tesviye_Add(Tesviye x);
        Tesviye Tesviye_Delete(Tesviye x);
        Tesviye Tesviye_Edit(Tesviye x);
        List<Tesviye_Return_Value> Tesviye_Get_All();
        Tesviye_Return_Value Tesviye_Get_By_Id(Tesviye x);
        List<Tesviye_Return_Value> Tesviye_Get_By_Text(Tesviye x);



    }
    public class TesviyeService : ITesviyeService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public TesviyeService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Tesviye Tesviye_Add(Tesviye x)
        {
            _context.Tesviyes.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Tesviye Tesviye_Delete(Tesviye x)
        {
            var temp = _context.Tesviyes;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            _context.SaveChanges();

            return Değer;
        }

        public Tesviye Tesviye_Edit(Tesviye x)
        {
            var temp = _context.Tesviyes;
            var Değer = temp.SingleOrDefault(o => o.Id == x.Id);
            Değer.Birim_Id = x.Birim_Id;
            Değer.Tesviye_Türü = x.Tesviye_Türü;
            Değer.Maliyet = x.Maliyet;

            _context.SaveChanges();

            return Değer;
        }

        public List<Tesviye_Return_Value> Tesviye_Get_All()
        {
            var temp = (from x in _context.Tesviyes
                        where x.Is_Deleted == 0
                        select x
            );
            IEnumerable<Tesviye_Return_Value> rt = temp.Select(o => new Tesviye_Return_Value
            {
                Id = o.Id,
                Birim_Id = o.Birim_Id,
                Tesviye_Türü = o.Tesviye_Türü,
                Maliyet = o.Maliyet,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                ).FirstOrDefault()

            });
            return rt.ToList();

        }

        public Tesviye_Return_Value Tesviye_Get_By_Id(Tesviye y)
        {
            var temp = (from x in _context.Tesviyes
                        where x.Id == y.Id && x.Is_Deleted == 0
                        select x
             );
            IEnumerable<Tesviye_Return_Value> rt = temp.Select(o => new Tesviye_Return_Value
            {
                Id = o.Id,
                Birim_Id = o.Birim_Id,
                Tesviye_Türü = o.Tesviye_Türü,
                Maliyet = o.Maliyet,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                ).FirstOrDefault()

            });

            return rt.FirstOrDefault();
        }

        public List<Tesviye_Return_Value> Tesviye_Get_By_Text(Tesviye y)
        {
            var temp = (from x in _context.Tesviyes
                        where x.Is_Deleted == 0 && x.Tesviye_Türü.StartsWith(y.Tesviye_Türü)
                        select x
            );
            IEnumerable<Tesviye_Return_Value> rt = temp.Select(o => new Tesviye_Return_Value
            {
                Id = o.Id,
                Birim_Id = o.Birim_Id,
                Tesviye_Türü = o.Tesviye_Türü,
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