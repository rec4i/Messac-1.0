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
    public interface IMalzemeMaliyetiSavedService
    {
        Malzeme_Maliyeti_Saved Malzeme_Maliyeti_Saved_Add(Malzeme_Maliyeti_Saved x);
        Malzeme_Maliyeti_Saved Malzeme_Maliyeti_Saved_Delete(Malzeme_Maliyeti_Saved x);
        Malzeme_Maliyeti_Saved Malzeme_Maliyeti_Saved_Edit(Malzeme_Maliyeti_Saved x);
        List<Malzeme_Maliyeti_Saved> Malzeme_Maliyeti_Saved_Get_All();
        Malzeme_Maliyeti_Saved Malzeme_Maliyeti_Saved_Get_By_Id(Malzeme_Maliyeti_Saved x);
        List<Malzeme_Maliyeti_Saved> Malzeme_Maliyeti_Saved_Get_By_Parça_Id(Revize x);

        Malzeme_Maliyeti_Saved Malzeme_Maliyeti_Saved_Delete_By_Revize_Id(Revize x);




    }
    public class MalzemeMaliyetiSavedService : IMalzemeMaliyetiSavedService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public MalzemeMaliyetiSavedService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Malzeme_Maliyeti_Saved Malzeme_Maliyeti_Saved_Add(Malzeme_Maliyeti_Saved x)
        {

            try
            {
                var temp = _context.Malzeme_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                //Değer.Is_Deleted = 1;
                _context.Malzeme_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }

            _context.Malzeme_Maliyeti_Saveds.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Malzeme_Maliyeti_Saved Malzeme_Maliyeti_Saved_Delete(Malzeme_Maliyeti_Saved x)
        {
            var temp = _context.Malzeme_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Malzeme_Maliyeti_Saved Malzeme_Maliyeti_Saved_Delete_By_Revize_Id(Revize y)
        {
            var temp = _context.Malzeme_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Revize_Id == y.Id);
            try
            {
                //Değer.Is_Deleted = 1;
                _context.Malzeme_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();

                return Değer;
            }
            catch (System.Exception)
            {
                return Değer;
            }

        }

        public Malzeme_Maliyeti_Saved Malzeme_Maliyeti_Saved_Edit(Malzeme_Maliyeti_Saved x)
        {
            var temp = _context.Malzeme_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Malzeme_Birim_Fiyatı = Değer.Malzeme_Birim_Fiyatı;
            Değer.Malzeme_Id = Değer.Malzeme_Id;
            Değer.Malzeme_Adı = Değer.Malzeme_Adı;

            Değer.Malzeme_Kesim_Türü_Id = x.Malzeme_Kesim_Türü_Id;
            Değer.Parça_Adeti = x.Parça_Adeti;
            Değer.Parça_Firesiz_Ağırlığı = x.Parça_Firesiz_Ağırlığı;
            Değer.Plaka_Boyu = x.Plaka_Boyu;
            Değer.Plaka_Eni = x.Plaka_Eni;
            Değer.Plaka_Kalınlığı = x.Plaka_Kalınlığı;
            Değer.Plaka_Maliyeti = x.Plaka_Maliyeti;

            _context.SaveChanges();

            return Değer;
        }

        public List<Malzeme_Maliyeti_Saved> Malzeme_Maliyeti_Saved_Get_All()
        {
            var temp = (from x in _context.Malzeme_Maliyeti_Saveds
                        select x
            );

            return temp.ToList();
        }

        public Malzeme_Maliyeti_Saved Malzeme_Maliyeti_Saved_Get_By_Id(Malzeme_Maliyeti_Saved y)
        {
            var temp = (from x in _context.Malzeme_Maliyeti_Saveds
                        where x.Id == y.Id
                        select x
             );

            return temp.FirstOrDefault();
        }

        public List<Malzeme_Maliyeti_Saved> Malzeme_Maliyeti_Saved_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Malzeme_Maliyeti_Saveds
                        where x.Revize_Id == y.Id
                        select x
             );

            return temp.ToList();
        }


    }
}