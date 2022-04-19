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
    public interface IDısOperasyonMaliyetiSavedService
    {

        Dıs_Operasyon_Maliyeti_Saved Dıs_Operasyon_Maliyeti_Saved_Add(Dıs_Operasyon_Maliyeti_Saved x);
        Dıs_Operasyon_Maliyeti_Saved Dıs_Operasyon_Maliyeti_Saved_Delete(Dıs_Operasyon_Maliyeti_Saved x);

        Dıs_Operasyon_Maliyeti_Saved Dıs_Operasyon_Maliyeti_Saved_Edit(Dıs_Operasyon_Maliyeti_Saved x);

        List<Dıs_Operasyon_Maliyeti_Saved_Retrun_Value> Dıs_Operasyon_Maliyeti_Saved_Get_All();

        Dıs_Operasyon_Maliyeti_Saved_Retrun_Value Dıs_Operasyon_Maliyeti_Saved_Get_By_Id(Dıs_Operasyon_Maliyeti_Saved x);

        List<Dıs_Operasyon_Maliyeti_Saved_Retrun_Value> Dıs_Operasyon_Maliyeti_Saved_Get_By_Parça_Id(Revize x);




        Dıs_Operasyon_Maliyeti_Saved_Row Dıs_Operasyon_Maliyeti_Saved_Row_Add(Dıs_Operasyon_Maliyeti_Saved_Row x);

        Dıs_Operasyon_Maliyeti_Saved_Row Dıs_Operasyon_Maliyeti_Saved_Row_Delete(Dıs_Operasyon_Maliyeti_Saved_Row x);

        Dıs_Operasyon_Maliyeti_Saved_Row Dıs_Operasyon_Maliyeti_Saved_Row_Edit(Dıs_Operasyon_Maliyeti_Saved_Row x);

        List<Dıs_Operasyon_Maliyeti_Saved_Row> Dıs_Operasyon_Maliyeti_Saved_Row_Get_All();
        Dıs_Operasyon_Maliyeti_Saved_Row Dıs_Operasyon_Maliyeti_Saved_Row_Get_By_Id(Dıs_Operasyon_Maliyeti_Saved_Row x);











    }
    public class DısOperasyonMaliyetiSavedService : IDısOperasyonMaliyetiSavedService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public DısOperasyonMaliyetiSavedService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Dıs_Operasyon_Maliyeti_Saved Dıs_Operasyon_Maliyeti_Saved_Add(Dıs_Operasyon_Maliyeti_Saved x)
        {
            try
            {
                var temp = _context.Dıs_Operasyon_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Dıs_Operasyon_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }

            _context.Dıs_Operasyon_Maliyeti_Saveds.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Dıs_Operasyon_Maliyeti_Saved Dıs_Operasyon_Maliyeti_Saved_Delete(Dıs_Operasyon_Maliyeti_Saved x)
        {


            var temp = _context.Dıs_Operasyon_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;


        }

        public Dıs_Operasyon_Maliyeti_Saved Dıs_Operasyon_Maliyeti_Saved_Edit(Dıs_Operasyon_Maliyeti_Saved x)
        {
            var temp = _context.Dıs_Operasyon_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.SaveChanges();

            return Değer;
        }

        public List<Dıs_Operasyon_Maliyeti_Saved_Retrun_Value> Dıs_Operasyon_Maliyeti_Saved_Get_All()
        {


            var temp = (from x in _context.Dıs_Operasyon_Maliyeti_Saveds
                        select x
            );

            IEnumerable<Dıs_Operasyon_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Dıs_Operasyon_Maliyeti_Saved_Retrun_Value
            {

                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Dıs_Operasyon_Maliyeti_Saved_Rows = (from x in _context.Dıs_Operasyon_Maliyeti_Saved_Rows
                                                     where x.Dıs_Operasyon_Maliyeti_Saved_Id == o.Id
                                                     select x
                ).ToList()


            });

            return rt.ToList();




        }

        public Dıs_Operasyon_Maliyeti_Saved_Retrun_Value Dıs_Operasyon_Maliyeti_Saved_Get_By_Id(Dıs_Operasyon_Maliyeti_Saved y)
        {
            var temp = (from x in _context.Dıs_Operasyon_Maliyeti_Saveds
                        where x.Id == y.Id
                        select x
            );

            IEnumerable<Dıs_Operasyon_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Dıs_Operasyon_Maliyeti_Saved_Retrun_Value
            {

                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Dıs_Operasyon_Maliyeti_Saved_Rows = (from x in _context.Dıs_Operasyon_Maliyeti_Saved_Rows
                                                     where x.Dıs_Operasyon_Maliyeti_Saved_Id == o.Id
                                                     select x
                ).ToList()


            });

            return rt.FirstOrDefault();

        }

        public List<Dıs_Operasyon_Maliyeti_Saved_Retrun_Value> Dıs_Operasyon_Maliyeti_Saved_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Dıs_Operasyon_Maliyeti_Saveds
                        where x.Revize_Id == y.Id
                        select x
           );

            IEnumerable<Dıs_Operasyon_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Dıs_Operasyon_Maliyeti_Saved_Retrun_Value
            {

                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Dıs_Operasyon_Maliyeti_Saved_Rows = (from x in _context.Dıs_Operasyon_Maliyeti_Saved_Rows
                                                     where x.Dıs_Operasyon_Maliyeti_Saved_Id == o.Id
                                                     select x
                ).ToList()


            });

            return rt.ToList();
        }

        public Dıs_Operasyon_Maliyeti_Saved_Row Dıs_Operasyon_Maliyeti_Saved_Row_Add(Dıs_Operasyon_Maliyeti_Saved_Row x)
        {
            _context.Dıs_Operasyon_Maliyeti_Saved_Rows.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Dıs_Operasyon_Maliyeti_Saved_Row Dıs_Operasyon_Maliyeti_Saved_Row_Delete(Dıs_Operasyon_Maliyeti_Saved_Row x)
        {
            var temp = _context.Dıs_Operasyon_Maliyeti_Saved_Rows;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Dıs_Operasyon_Maliyeti_Saved_Row Dıs_Operasyon_Maliyeti_Saved_Row_Edit(Dıs_Operasyon_Maliyeti_Saved_Row x)
        {
            var temp = _context.Dıs_Operasyon_Maliyeti_Saved_Rows;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Dıs_Operasyon_Adet = x.Dıs_Operasyon_Adet;
            Değer.Dıs_Operasyon_Adı = x.Dıs_Operasyon_Adı;
            Değer.Dıs_Operasyon_Birim_Fiyat = x.Dıs_Operasyon_Birim_Fiyat;
            Değer.Dıs_Operasyon_Maliyeti_Saved_Id = x.Dıs_Operasyon_Maliyeti_Saved_Id;
            Değer.Toplam_Maliyet = x.Toplam_Maliyet;
            _context.SaveChanges();

            return Değer;
        }

        public List<Dıs_Operasyon_Maliyeti_Saved_Row> Dıs_Operasyon_Maliyeti_Saved_Row_Get_All()
        {
            var temp = (from x in _context.Dıs_Operasyon_Maliyeti_Saved_Rows
                        select x
            );
            return temp.ToList();
        }

        public Dıs_Operasyon_Maliyeti_Saved_Row Dıs_Operasyon_Maliyeti_Saved_Row_Get_By_Id(Dıs_Operasyon_Maliyeti_Saved_Row y)
        {
            var temp = (from x in _context.Dıs_Operasyon_Maliyeti_Saved_Rows
                        where x.Id == y.Id
                        select x
            );

            return temp.FirstOrDefault();
        }
    }
}