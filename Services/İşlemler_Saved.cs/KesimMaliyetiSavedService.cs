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
using KaynakKod.Entities;

namespace qrmenu.Services
{
    public interface IKesimMaliyetiSavedService
    {
        Kesim_Maliyeti_Saved Kesim_Maliyeti_Saved_Add(Kesim_Maliyeti_Saved x);
        Kesim_Maliyeti_Saved Kesim_Maliyeti_Saved_Delete(Kesim_Maliyeti_Saved x);

        Kesim_Maliyeti_Saved Kesim_Maliyeti_Saved_Edit(Kesim_Maliyeti_Saved x);

        List<Kesim_Maliyeti_Saved> Kesim_Maliyeti_Saved_Get_All();

        Kesim_Maliyeti_Saved Kesim_Maliyeti_Saved_Get_By_Id(Kesim_Maliyeti_Saved x);
        List<Kesim_Maliyeti_Saved> Kesim_Maliyeti_Saved_Get_By_Parça_Id(Revize x);

    }
    public class KesimMaliyetiSavedService : IKesimMaliyetiSavedService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public KesimMaliyetiSavedService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Kesim_Maliyeti_Saved Kesim_Maliyeti_Saved_Add(Kesim_Maliyeti_Saved x)
        {
            try
            {
                var temp = _context.Kesim_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                //Değer.Is_Deleted = 1;
                 _context.Kesim_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

              
            }

            _context.Kesim_Maliyeti_Saveds.Add(x);
            _context.SaveChanges();
            return x;

        }

        public Kesim_Maliyeti_Saved Kesim_Maliyeti_Saved_Delete(Kesim_Maliyeti_Saved x)
        {
            var temp = _context.Kesim_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Kesim_Maliyeti_Saved Kesim_Maliyeti_Saved_Edit(Kesim_Maliyeti_Saved x)
        {
            var temp = _context.Kesim_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);

            Değer.Kesim_Fiyatı = x.Kesim_Fiyatı;
            Değer.Kesim_Maliyeti = x.Kesim_Maliyeti;
            Değer.Kesim_Süresi_Saat = x.Kesim_Süresi_Saat;
            Değer.Kesim_Süresi_Saniye = x.Kesim_Süresi_Saniye;
            Değer.Kesim_Verimliliği = x.Kesim_Verimliliği;
            Değer.Parça_Adeti = x.Parça_Adeti;

            _context.SaveChanges();

            return Değer;
        }

        public List<Kesim_Maliyeti_Saved> Kesim_Maliyeti_Saved_Get_All()
        {
            var temp = (from x in _context.Kesim_Maliyeti_Saveds
                        select x
            );

            return temp.ToList();


        }

        public Kesim_Maliyeti_Saved Kesim_Maliyeti_Saved_Get_By_Id(Kesim_Maliyeti_Saved y)
        {
            var temp = (from x in _context.Kesim_Maliyeti_Saveds
                        where x.Id == y.Id
                        select x
           );

            return temp.FirstOrDefault();
        }

        public List<Kesim_Maliyeti_Saved> Kesim_Maliyeti_Saved_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Kesim_Maliyeti_Saveds
                        where x.Revize_Id == y.Id
                        select x
        );

            return temp.ToList();
        }
    }
}