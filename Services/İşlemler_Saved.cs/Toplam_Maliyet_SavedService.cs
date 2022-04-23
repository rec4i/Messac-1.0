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
    public interface IToplam_Maliyet_SavedService
    {
        Toplam_Maliyet_Saved Toplam_Maliyet_Saved_Add(Toplam_Maliyet_Saved x);

        Toplam_Maliyet_Saved_Return_Value Toplam_Maliyet_Saved_Get_By_Revize_Id(Toplam_Maliyet_Saved x);

        Toplam_Maliyet_Saved_Return_Value Toplam_Maliyet_Saved_Get_By_Id(Toplam_Maliyet_Saved x);




        İşçilik_Maliyeti_Selected İşçilik_Maliyeti_Selected_Add(İşçilik_Maliyeti_Selected x);

        İşçilik_Maliyeti_Selected İşçilik_Maliyeti_Selected_Get_By_Id(İşçilik_Maliyeti_Selected x);

        İşçilik_Maliyeti_Selected İşçilik_Maliyeti_Selected_Get_By_Toplam_Maliyet_Saved_Id(İşçilik_Maliyeti_Selected x);



        Malzeme_Maliyeti_Selected Malzeme_Maliyeti_Selected_Add(Malzeme_Maliyeti_Selected x);

        Malzeme_Maliyeti_Selected Malzeme_Maliyeti_Selected_Get_By_Id(Malzeme_Maliyeti_Selected x);

        Malzeme_Maliyeti_Selected Malzeme_Maliyeti_Selected_Get_By_Toplam_Maliyet_Saved_Id(Malzeme_Maliyeti_Selected x);





    }
    public class Toplam_Maliyet_SavedService : IToplam_Maliyet_SavedService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public Toplam_Maliyet_SavedService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Toplam_Maliyet_Saved Toplam_Maliyet_Saved_Add(Toplam_Maliyet_Saved x)
        {
            try
            {
                var temp = _context.Toplam_Maliyet_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Toplam_Maliyet_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }


            _context.Toplam_Maliyet_Saveds.Add(x);
            _context.SaveChanges();
            return x;


        }

        public Toplam_Maliyet_Saved_Return_Value Toplam_Maliyet_Saved_Get_By_Revize_Id(Toplam_Maliyet_Saved y)
        {
            var temp = (from x in _context.Toplam_Maliyet_Saveds
                        where x.Revize_Id == y.Revize_Id
                        select x
             );

            IEnumerable<Toplam_Maliyet_Saved_Return_Value> rt = temp.Select(o => new Toplam_Maliyet_Saved_Return_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,

                İşçilik_Maliyeti = o.İşçilik_Maliyeti,
                İşçilik_Kar_Oranı = o.İşçilik_Kar_Oranı,
                İşçilik_Karlı_Toplam = o.İşçilik_Karlı_Toplam,


                Malzeme_Maliyeti = o.Malzeme_Maliyeti,
                Malzeme_Kar_Oranı = o.Malzeme_Kar_Oranı,
                Malzeme_Karlı_Toplam = o.Malzeme_Karlı_Toplam,


                Malzeme_Birim_Fiyatı = o.Malzeme_Birim_Fiyatı,
                Hurda_Birim_Satış_Oranı = o.Hurda_Birim_Satış_Oranı,
                Malzeme_Hurda_Fiyatı = o.Malzeme_Hurda_Fiyatı,
                Malzeme_Fire_Oranı = o.Malzeme_Fire_Oranı,
                Fire_Maliyeti = o.Fire_Maliyeti,

                Parça_Genel_Kar_Oranı = o.Parça_Genel_Kar_Oranı,
                Parça_Toplam_Maliyeti = o.Parça_Toplam_Maliyeti,

                O_Günki_Kur = o.O_Günki_Kur,
                Parça_Toplam_Maliyeti_Güncel_Kur = o.Parça_Toplam_Maliyeti_Güncel_Kur,

                İşçilik_Maliyeti_Selecteds = (from x in _context.İşçilik_Maliyeti_Selecteds
                                              where x.Toplam_Maliyet_Saved_Id == o.Id
                                              select x
                ).ToList(),

                Malzeme_Maliyeti_Selected = (from x in _context.Malzeme_Maliyeti_Selecteds
                                             where x.Toplam_Maliyet_Saved_Id == o.Id
                                             select x
                ).ToList()



            });
            return rt.FirstOrDefault();
        }

        public Toplam_Maliyet_Saved_Return_Value Toplam_Maliyet_Saved_Get_By_Id(Toplam_Maliyet_Saved y)
        {
            var temp = (from x in _context.Toplam_Maliyet_Saveds
                        where x.Id == y.Id
                        select x
           );

            IEnumerable<Toplam_Maliyet_Saved_Return_Value> rt = temp.Select(o => new Toplam_Maliyet_Saved_Return_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,

                İşçilik_Maliyeti = o.İşçilik_Maliyeti,
                İşçilik_Kar_Oranı = o.İşçilik_Kar_Oranı,
                İşçilik_Karlı_Toplam = o.İşçilik_Karlı_Toplam,


                Malzeme_Maliyeti = o.Malzeme_Maliyeti,
                Malzeme_Kar_Oranı = o.Malzeme_Kar_Oranı,
                Malzeme_Karlı_Toplam = o.Malzeme_Karlı_Toplam,


                Malzeme_Birim_Fiyatı = o.Malzeme_Birim_Fiyatı,
                Hurda_Birim_Satış_Oranı = o.Hurda_Birim_Satış_Oranı,
                Malzeme_Hurda_Fiyatı = o.Malzeme_Hurda_Fiyatı,
                Malzeme_Fire_Oranı = o.Malzeme_Fire_Oranı,
                Fire_Maliyeti = o.Fire_Maliyeti,

                Parça_Genel_Kar_Oranı = o.Parça_Genel_Kar_Oranı,
                Parça_Toplam_Maliyeti = o.Parça_Toplam_Maliyeti,

                O_Günki_Kur = o.O_Günki_Kur,
                Parça_Toplam_Maliyeti_Güncel_Kur = o.Parça_Toplam_Maliyeti_Güncel_Kur,

                İşçilik_Maliyeti_Selecteds = (from x in _context.İşçilik_Maliyeti_Selecteds
                                              where x.Toplam_Maliyet_Saved_Id == o.Id
                                              select x
                ).ToList(),

                Malzeme_Maliyeti_Selected = (from x in _context.Malzeme_Maliyeti_Selecteds
                                             where x.Toplam_Maliyet_Saved_Id == o.Id
                                             select x
                ).ToList()



            });
            return rt.FirstOrDefault();
        }



        public İşçilik_Maliyeti_Selected İşçilik_Maliyeti_Selected_Add(İşçilik_Maliyeti_Selected x)
        {
            _context.İşçilik_Maliyeti_Selecteds.Add(x);
            _context.SaveChanges();
            return x;
        }

        public İşçilik_Maliyeti_Selected İşçilik_Maliyeti_Selected_Get_By_Id(İşçilik_Maliyeti_Selected y)
        {
            var temp = (from x in _context.İşçilik_Maliyeti_Selecteds
                        where x.Id == y.Id
                        select x
            );

            return temp.FirstOrDefault();

        }

        public İşçilik_Maliyeti_Selected İşçilik_Maliyeti_Selected_Get_By_Toplam_Maliyet_Saved_Id(İşçilik_Maliyeti_Selected y)
        {
            var temp = (from x in _context.İşçilik_Maliyeti_Selecteds
                        where x.Toplam_Maliyet_Saved_Id == y.Toplam_Maliyet_Saved_Id
                        select x
            );

            return temp.FirstOrDefault();
        }


        public Malzeme_Maliyeti_Selected Malzeme_Maliyeti_Selected_Add(Malzeme_Maliyeti_Selected x)
        {
            _context.Malzeme_Maliyeti_Selecteds.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Malzeme_Maliyeti_Selected Malzeme_Maliyeti_Selected_Get_By_Id(Malzeme_Maliyeti_Selected y)
        {
            var temp = (from x in _context.Malzeme_Maliyeti_Selecteds
                        where x.Id == y.Id
                        select x
           );

            return temp.FirstOrDefault();
        }

        public Malzeme_Maliyeti_Selected Malzeme_Maliyeti_Selected_Get_By_Toplam_Maliyet_Saved_Id(Malzeme_Maliyeti_Selected y)
        {
            var temp = (from x in _context.Malzeme_Maliyeti_Selecteds
                        where x.Toplam_Maliyet_Saved_Id == y.Toplam_Maliyet_Saved_Id
                        select x
           );

            return temp.FirstOrDefault();
        }
    }
}