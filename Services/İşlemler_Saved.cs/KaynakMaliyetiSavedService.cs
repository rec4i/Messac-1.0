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
    public interface IKaynakMaliyetiSavedService
    {
        Kaynak_Maliyeti_Saved Kaynak_Maliyeti_Saved_Add(Kaynak_Maliyeti_Saved x);
        Kaynak_Maliyeti_Saved Kaynak_Maliyeti_Saved_Delete(Kaynak_Maliyeti_Saved x);
        void Kaynak_Maliyeti_Saved_Delete_By_Revize_Id(Revize x);

        Kaynak_Maliyeti_Saved Kaynak_Maliyeti_Saved_Edit(Kaynak_Maliyeti_Saved x);
        List<Kaynak_Maliyeti_Saved_Retrun_Value> Kaynak_Maliyeti_Saved_Get_All();
        Kaynak_Maliyeti_Saved_Retrun_Value Kaynak_Maliyeti_Saved_Get_By_Id(Kaynak_Maliyeti_Saved x);
        List<Kaynak_Maliyeti_Saved_Retrun_Value> Kaynak_Maliyeti_Saved_Get_By_Parça_Id(Revize x);






        Kaynak_Maliyeti_Saved_Row Kaynak_Maliyeti_Saved_Row_Add(Kaynak_Maliyeti_Saved_Row x);
        Kaynak_Maliyeti_Saved_Row Kaynak_Maliyeti_Saved_Row_Delete(Kaynak_Maliyeti_Saved_Row x);
        Kaynak_Maliyeti_Saved_Row Kaynak_Maliyeti_Saved_Row_Edit(Kaynak_Maliyeti_Saved_Row x);
        List<Kaynak_Maliyeti_Saved_Row> Kaynak_Maliyeti_Saved_Row_Get_All();
        Kaynak_Maliyeti_Saved_Row Kaynak_Maliyeti_Saved_Row_Get_By_Id(Kaynak_Maliyeti_Saved_Row x);



    }
    public class KaynakMaliyetiSavedService : IKaynakMaliyetiSavedService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public KaynakMaliyetiSavedService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Kaynak_Maliyeti_Saved Kaynak_Maliyeti_Saved_Add(Kaynak_Maliyeti_Saved x)
        {
            try
            {
                var temp = _context.Kaynak_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);

                _context.Kaynak_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }

            _context.Kaynak_Maliyeti_Saveds.Add(x);
            _context.SaveChanges();
            return x;

        }

        public Kaynak_Maliyeti_Saved Kaynak_Maliyeti_Saved_Delete(Kaynak_Maliyeti_Saved x)
        {
            var temp = _context.Kaynak_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }
        public void Kaynak_Maliyeti_Saved_Delete_By_Revize_Id(Revize x)
        {

            try
            {
                var temp = _context.Kaynak_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Id);

                _context.Kaynak_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }


        }

        public Kaynak_Maliyeti_Saved Kaynak_Maliyeti_Saved_Edit(Kaynak_Maliyeti_Saved x)
        {
            var temp = _context.Kaynak_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.SaveChanges();

            return Değer;
        }

        public List<Kaynak_Maliyeti_Saved_Retrun_Value> Kaynak_Maliyeti_Saved_Get_All()
        {
            var temp = (from x in _context.Kaynak_Maliyeti_Saveds
                        select x
            );

            IEnumerable<Kaynak_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Kaynak_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Kaynak_Maliyeti_Saved_Row = (from x in _context.Kaynak_Maliyeti_Saved_Rows
                                             where x.Kaynak_Maliyeti_Saved_Id == o.Id
                                             select x
               ).ToList()


            });

            return rt.ToList();
        }

        public Kaynak_Maliyeti_Saved_Retrun_Value Kaynak_Maliyeti_Saved_Get_By_Id(Kaynak_Maliyeti_Saved y)
        {
            var temp = (from x in _context.Kaynak_Maliyeti_Saveds
                        where x.Id == y.Id
                        select x
           );

            IEnumerable<Kaynak_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Kaynak_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Kaynak_Maliyeti_Saved_Row = (from x in _context.Kaynak_Maliyeti_Saved_Rows
                                             where x.Kaynak_Maliyeti_Saved_Id == o.Id
                                             select x
               ).ToList()


            });

            return rt.FirstOrDefault();
        }

        public List<Kaynak_Maliyeti_Saved_Retrun_Value> Kaynak_Maliyeti_Saved_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Kaynak_Maliyeti_Saveds
                        where x.Revize_Id == y.Id
                        select x
            );

            IEnumerable<Kaynak_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Kaynak_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Kaynak_Maliyeti_Saved_Row = (from x in _context.Kaynak_Maliyeti_Saved_Rows
                                             where x.Kaynak_Maliyeti_Saved_Id == o.Id
                                             select x
               ).ToList()


            });

            return rt.ToList();
        }



        public Kaynak_Maliyeti_Saved_Row Kaynak_Maliyeti_Saved_Row_Add(Kaynak_Maliyeti_Saved_Row x)
        {
            _context.Kaynak_Maliyeti_Saved_Rows.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Kaynak_Maliyeti_Saved_Row Kaynak_Maliyeti_Saved_Row_Delete(Kaynak_Maliyeti_Saved_Row x)
        {
            var temp = _context.Kaynak_Maliyeti_Saved_Rows;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Kaynak_Maliyeti_Saved_Row Kaynak_Maliyeti_Saved_Row_Edit(Kaynak_Maliyeti_Saved_Row x)
        {
            var temp = _context.Kaynak_Maliyeti_Saved_Rows;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Adet = x.Adet;
            Değer.Birim_Fiyat = x.Birim_Fiyat;
            Değer.Kaynak_Adı = x.Kaynak_Adı;
            Değer.Kaynak_Maliyeti_Saved_Id = x.Kaynak_Maliyeti_Saved_Id;
            Değer.Olusturlma_Tarihi = x.Olusturlma_Tarihi;
            Değer.Toplam_Fiyat = x.Toplam_Fiyat;
            _context.SaveChanges();

            return Değer;
        }

        public List<Kaynak_Maliyeti_Saved_Row> Kaynak_Maliyeti_Saved_Row_Get_All()
        {
            var temp = (from x in _context.Kaynak_Maliyeti_Saved_Rows
                        select x

            );
            return temp.ToList();
        }

        public Kaynak_Maliyeti_Saved_Row Kaynak_Maliyeti_Saved_Row_Get_By_Id(Kaynak_Maliyeti_Saved_Row y)
        {
            var temp = (from x in _context.Kaynak_Maliyeti_Saved_Rows
                        where x.Id == y.Id
                        select x

        );
            return temp.FirstOrDefault();
        }


    }
}