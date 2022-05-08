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
    public interface IBağlantıElemanıSavedService
    {
        Bağlantı_Elemanı_Saved BağlantıElemanıSaved_Add(Bağlantı_Elemanı_Saved x);

        Bağlantı_Elemanı_Saved BağlantıElemanıSaved_Edit(Bağlantı_Elemanı_Saved x);
        Bağlantı_Elemanı_Saved BağlantıElemanıSaved_Delete(Bağlantı_Elemanı_Saved x);

        List<Bağlantı_Elemanı_Saved_Retrun_Value> BağlantıElemanıSaved_Get_All();
        Bağlantı_Elemanı_Saved_Retrun_Value BağlantıElemanıSaved_Get_By_Id(Bağlantı_Elemanı_Saved x);

        List<Bağlantı_Elemanı_Saved_Retrun_Value> BağlantıElemanıSaved_Get_By_Parça_Id(Revize y);






        Bağlantı_Elemanı_Saved_row BağlantıElemanıSaved_Row_Add(Bağlantı_Elemanı_Saved_row x);

        Bağlantı_Elemanı_Saved_row BağlantıElemanıSaved_Row_Edit(Bağlantı_Elemanı_Saved_row x);


        Bağlantı_Elemanı_Saved_row BağlantıElemanıSaved_Row_Delete(Bağlantı_Elemanı_Saved_row x);


        List<Bağlantı_Elemanı_Saved_row> BağlantıElemanıSaved_Row_Get_All();

        Bağlantı_Elemanı_Saved_row BağlantıElemanıSaved_Row_Get_By_Id(Bağlantı_Elemanı_Saved_row x);







    }
    public class BağlantıElemanıSavedService : IBağlantıElemanıSavedService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public BağlantıElemanıSavedService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Bağlantı_Elemanı_Saved BağlantıElemanıSaved_Add(Bağlantı_Elemanı_Saved x)
        {
            try
            {
                var temp = _context.Bağlantı_Elemanı_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);
                _context.Bağlantı_Elemanı_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }
            _context.Bağlantı_Elemanı_Saveds.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Bağlantı_Elemanı_Saved BağlantıElemanıSaved_Edit(Bağlantı_Elemanı_Saved x)
        {
            var temp = _context.Bağlantı_Elemanı_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.SaveChanges();

            return Değer;
        }

        public Bağlantı_Elemanı_Saved BağlantıElemanıSaved_Delete(Bağlantı_Elemanı_Saved x)
        {
            var temp = _context.Bağlantı_Elemanı_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public List<Bağlantı_Elemanı_Saved_Retrun_Value> BağlantıElemanıSaved_Get_All()
        {
            var temp = (from x in _context.Bağlantı_Elemanı_Saveds
                        select x
            );

            IEnumerable<Bağlantı_Elemanı_Saved_Retrun_Value> rt = temp.Select(o => new Bağlantı_Elemanı_Saved_Retrun_Value
            {
                Id = o.Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Revize_Id = o.Revize_Id,
                Bağlantı_Elemanı_Saved_rows = (from x in _context.Bağlantı_Elemanı_Saved_Rows
                                               where x.Bağlantı_Elemanı_Saved_Id == o.Id
                                               select x
                    ).ToList()

            });

            return rt.ToList();
        }

        public Bağlantı_Elemanı_Saved_Retrun_Value BağlantıElemanıSaved_Get_By_Id(Bağlantı_Elemanı_Saved y)
        {
            var temp = (from x in _context.Bağlantı_Elemanı_Saveds
                        where x.Id == y.Id
                        select x
             );

            IEnumerable<Bağlantı_Elemanı_Saved_Retrun_Value> rt = temp.Select(o => new Bağlantı_Elemanı_Saved_Retrun_Value
            {
                Id = o.Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Revize_Id = o.Revize_Id,
                Bağlantı_Elemanı_Saved_rows = (from x in _context.Bağlantı_Elemanı_Saved_Rows
                                               where x.Bağlantı_Elemanı_Saved_Id == o.Id
                                               select x
                    ).ToList()

            });

            return rt.FirstOrDefault();
        }

        public List<Bağlantı_Elemanı_Saved_Retrun_Value> BağlantıElemanıSaved_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Bağlantı_Elemanı_Saveds
                        where x.Revize_Id == y.Id
                        select x
                        );

            IEnumerable<Bağlantı_Elemanı_Saved_Retrun_Value> rt = temp.Select(o => new Bağlantı_Elemanı_Saved_Retrun_Value
            {
                Id = o.Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Revize_Id = o.Revize_Id,
                Bağlantı_Elemanı_Saved_rows = (from x in _context.Bağlantı_Elemanı_Saved_Rows
                                               where x.Bağlantı_Elemanı_Saved_Id == o.Id
                                               select x
                    ).ToList()

            });

            return rt.ToList();

        }






        public Bağlantı_Elemanı_Saved_row BağlantıElemanıSaved_Row_Add(Bağlantı_Elemanı_Saved_row x)
        {
            _context.Bağlantı_Elemanı_Saved_Rows.Add(x);
            _context.SaveChanges();
            return x;

        }

        public Bağlantı_Elemanı_Saved_row BağlantıElemanıSaved_Row_Edit(Bağlantı_Elemanı_Saved_row x)
        {
            var temp = _context.Bağlantı_Elemanı_Saved_Rows;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Adet = x.Adet;
            Değer.Bağlantı_Elemanı_Id = x.Bağlantı_Elemanı_Id;
            Değer.Bağlantı_Elemanı_Saved_Id = x.Bağlantı_Elemanı_Saved_Id;
            Değer.Birim_Fiyat = x.Birim_Fiyat;
            Değer.Toplam_Fiyat = x.Toplam_Fiyat;
            
            _context.SaveChanges();

            return Değer;
        }

        public Bağlantı_Elemanı_Saved_row BağlantıElemanıSaved_Row_Delete(Bağlantı_Elemanı_Saved_row x)
        {
            var temp = _context.Bağlantı_Elemanı_Saved_Rows;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;

        }

        public List<Bağlantı_Elemanı_Saved_row> BağlantıElemanıSaved_Row_Get_All()
        {
            var temp = (from x in _context.Bağlantı_Elemanı_Saved_Rows
                        select x
            );

            return temp.ToList();


        }

        public Bağlantı_Elemanı_Saved_row BağlantıElemanıSaved_Row_Get_By_Id(Bağlantı_Elemanı_Saved_row y)
        {
            var temp = (from x in _context.Bağlantı_Elemanı_Saved_Rows
                        where x.Id == y.Id
                        select x
           );

            return temp.FirstOrDefault();
        }
    }
}