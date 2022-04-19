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
    public interface ITesfiyeService
    {
        Tesfiye Tesfiye_Add(Tesfiye x);
        Tesfiye Tesfiye_Delete(Tesfiye x);
        Tesfiye Tesfiye_Edit(Tesfiye x);
        List<Tesfiye_Return_Value> Tesfiye_Get_All();
        Tesfiye_Return_Value Tesfiye_Get_By_Id(Tesfiye x);
        List<Tesfiye_Return_Value> Tesfiye_Get_By_Text(Tesfiye x);



    }
    public class TesfiyeService : ITesfiyeService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public TesfiyeService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Tesfiye Tesfiye_Add(Tesfiye x)
        {
            _context.Tesfiyes.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Tesfiye Tesfiye_Delete(Tesfiye x)
        {
            var temp = _context.Tesfiyes;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            _context.SaveChanges();

            return Değer;
        }

        public Tesfiye Tesfiye_Edit(Tesfiye x)
        {
            var temp = _context.Tesfiyes;
            var Değer = temp.SingleOrDefault(o => o.Id == x.Id);
            Değer.Birim_Id = x.Birim_Id;
            Değer.Tesfiye_Türü = x.Tesfiye_Türü;
            Değer.Maliyet = x.Maliyet;

            _context.SaveChanges();

            return Değer;
        }

        public List<Tesfiye_Return_Value> Tesfiye_Get_All()
        {
            var temp = (from x in _context.Tesfiyes
                        where x.Is_Deleted == 0
                        select x
            );
            IEnumerable<Tesfiye_Return_Value> rt = temp.Select(o => new Tesfiye_Return_Value
            {
                Id = o.Id,
                Birim_Id = o.Birim_Id,
                Tesfiye_Türü = o.Tesfiye_Türü,
                Maliyet = o.Maliyet,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                ).FirstOrDefault()

            });
            return rt.ToList();

        }

        public Tesfiye_Return_Value Tesfiye_Get_By_Id(Tesfiye y)
        {
            var temp = (from x in _context.Tesfiyes
                        where x.Id == y.Id && x.Is_Deleted == 0
                        select x
             );
            IEnumerable<Tesfiye_Return_Value> rt = temp.Select(o => new Tesfiye_Return_Value
            {
                Id = o.Id,
                Birim_Id = o.Birim_Id,
                Tesfiye_Türü = o.Tesfiye_Türü,
                Maliyet = o.Maliyet,
                Birim = (from x in _context.Birimlers
                         where x.Id == o.Birim_Id
                         select x
                ).FirstOrDefault()

            });

            return rt.FirstOrDefault();
        }

        public List<Tesfiye_Return_Value> Tesfiye_Get_By_Text(Tesfiye y)
        {
            var temp = (from x in _context.Tesfiyes
                        where x.Is_Deleted == 0 && x.Tesfiye_Türü.StartsWith(y.Tesfiye_Türü)
                        select x
            );
            IEnumerable<Tesfiye_Return_Value> rt = temp.Select(o => new Tesfiye_Return_Value
            {
                Id = o.Id,
                Birim_Id = o.Birim_Id,
                Tesfiye_Türü = o.Tesfiye_Türü,
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