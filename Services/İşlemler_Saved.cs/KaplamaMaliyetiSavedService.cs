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
    public interface IKaplamaMaliyetiServiceSavedService
    {
        Kaplama_Maliyeti_Saved Kaplama_Maliyeti_Saved_Add(Kaplama_Maliyeti_Saved x);
        Kaplama_Maliyeti_Saved Kaplama_Maliyeti_Saved_Delete(Kaplama_Maliyeti_Saved x);

        void Kaplama_Maliyeti_Saved_Delete_By_Revize_Id(Revize x);


        Kaplama_Maliyeti_Saved Kaplama_Maliyeti_Saved_Edit(Kaplama_Maliyeti_Saved x);

        List<Kaplama_Maliyeti_Saved_Retrun_Value> Kaplama_Maliyeti_Saved_Get_All();

        Kaplama_Maliyeti_Saved_Retrun_Value Kaplama_Maliyeti_Saved_Get_By_Id(Kaplama_Maliyeti_Saved x);
        List<Kaplama_Maliyeti_Saved_Retrun_Value> Kaplama_Maliyeti_Saved_Get_By_Parça_Id(Revize x);








        Kaplama_Maliyeti_Saved_Row Kaplama_Maliyeti_Saved_Row_Add(Kaplama_Maliyeti_Saved_Row x);
        Kaplama_Maliyeti_Saved_Row Kaplama_Maliyeti_Saved_Row_Delete(Kaplama_Maliyeti_Saved_Row x);
        Kaplama_Maliyeti_Saved_Row Kaplama_Maliyeti_Saved_Row_Edit(Kaplama_Maliyeti_Saved_Row x);
        List<Kaplama_Maliyeti_Saved_Row> Kaplama_Maliyeti_Saved_Row_Get_All();
        Kaplama_Maliyeti_Saved_Row Kaplama_Maliyeti_Saved_Row_Get_By_Id(Kaplama_Maliyeti_Saved_Row x);





    }
    public class KaplamaMaliyetiServiceSavedService : IKaplamaMaliyetiServiceSavedService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public KaplamaMaliyetiServiceSavedService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Kaplama_Maliyeti_Saved Kaplama_Maliyeti_Saved_Add(Kaplama_Maliyeti_Saved x)
        {
            try
            {
                var temp = _context.Kaplama_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Kaplama_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }
            _context.Kaplama_Maliyeti_Saveds.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Kaplama_Maliyeti_Saved Kaplama_Maliyeti_Saved_Delete(Kaplama_Maliyeti_Saved x)
        {
            var temp = _context.Kaplama_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public void Kaplama_Maliyeti_Saved_Delete_By_Revize_Id(Revize x)
        {

            try
            {
                var temp = _context.Kaplama_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Id);
                _context.Kaplama_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }



        }

        public Kaplama_Maliyeti_Saved Kaplama_Maliyeti_Saved_Edit(Kaplama_Maliyeti_Saved x)
        {
            var temp = _context.Kaplama_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);


            _context.SaveChanges();

            return Değer;
        }

        public List<Kaplama_Maliyeti_Saved_Retrun_Value> Kaplama_Maliyeti_Saved_Get_All()
        {
            var temp = (from x in _context.Kaplama_Maliyeti_Saveds
                        select x

            );

            IEnumerable<Kaplama_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Kaplama_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Kaplama_Maliyeti_Saved_Rows = (from x in _context.Kaplama_Maliyeti_Saved_Rows
                                               where x.Id == o.Revize_Id
                                               select x
                ).ToList()

            });

            return rt.ToList();
        }

        public Kaplama_Maliyeti_Saved_Retrun_Value Kaplama_Maliyeti_Saved_Get_By_Id(Kaplama_Maliyeti_Saved y)
        {
            var temp = (from x in _context.Kaplama_Maliyeti_Saveds
                        where x.Id == y.Id
                        select x

          );

            IEnumerable<Kaplama_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Kaplama_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Kaplama_Maliyeti_Saved_Rows = (from x in _context.Kaplama_Maliyeti_Saved_Rows
                                               where x.Id == o.Revize_Id
                                               select x
                ).ToList()

            });

            return rt.FirstOrDefault();
        }

        public List<Kaplama_Maliyeti_Saved_Retrun_Value> Kaplama_Maliyeti_Saved_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Kaplama_Maliyeti_Saveds
                        where x.Revize_Id == y.Id
                        select x

         );

            IEnumerable<Kaplama_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Kaplama_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Kaplama_Maliyeti_Saved_Rows = (from x in _context.Kaplama_Maliyeti_Saved_Rows
                                               join _Kaplama_maliyeti in _context.Kaplama_Maliyeti_Saveds
                                               on x.Kaplama_Maliyeti_Saved_Id equals _Kaplama_maliyeti.Id

                                               where _Kaplama_maliyeti.Revize_Id == o.Revize_Id
                                               select x
                ).ToList()

            });

            return rt.ToList();
        }





        public Kaplama_Maliyeti_Saved_Row Kaplama_Maliyeti_Saved_Row_Add(Kaplama_Maliyeti_Saved_Row x)
        {
            _context.Kaplama_Maliyeti_Saved_Rows.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Kaplama_Maliyeti_Saved_Row Kaplama_Maliyeti_Saved_Row_Delete(Kaplama_Maliyeti_Saved_Row x)
        {
            var temp = _context.Kaplama_Maliyeti_Saved_Rows;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Kaplama_Maliyeti_Saved_Row Kaplama_Maliyeti_Saved_Row_Edit(Kaplama_Maliyeti_Saved_Row x)
        {
            var temp = _context.Kaplama_Maliyeti_Saved_Rows;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Adet = x.Adet;
            Değer.Birim_Fiyat = x.Birim_Fiyat;
            Değer.Kaplama_Adı = x.Kaplama_Adı;
            Değer.Kaplama_Birimi = x.Kaplama_Birimi;
            Değer.Kaplama_Maliyeti_Saved_Id = x.Kaplama_Maliyeti_Saved_Id;
            Değer.Toplam_Fiyat = x.Toplam_Fiyat;

            _context.SaveChanges();

            return Değer;
        }

        public List<Kaplama_Maliyeti_Saved_Row> Kaplama_Maliyeti_Saved_Row_Get_All()
        {
            var temp = (from x in _context.Kaplama_Maliyeti_Saved_Rows
                        select x
            );

            return temp.ToList();
        }

        public Kaplama_Maliyeti_Saved_Row Kaplama_Maliyeti_Saved_Row_Get_By_Id(Kaplama_Maliyeti_Saved_Row y)
        {
            var temp = (from x in _context.Kaplama_Maliyeti_Saved_Rows
                        where x.Id == y.Id
                        select x
            );

            return temp.FirstOrDefault();
        }


    }
}