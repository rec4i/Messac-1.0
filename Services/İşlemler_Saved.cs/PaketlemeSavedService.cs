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
    public interface IPaketlemeSavedService
    {
        Paketleme_Maliyeti_Saved Paketleme_Maliyeti_Saved_Add(Paketleme_Maliyeti_Saved x);
        Paketleme_Maliyeti_Saved Paketleme_Maliyeti_Saved_Delete(Paketleme_Maliyeti_Saved x);
        void Paketleme_Maliyeti_Saved_Delete_By_Revize_Id(Revize x);

        Paketleme_Maliyeti_Saved Paketleme_Maliyeti_Saved_Edit(Paketleme_Maliyeti_Saved x);
        List<Paketleme_Maliyeti_Saved_Retrun_Value> Paketleme_Maliyeti_Saved_Get_All();
        Paketleme_Maliyeti_Saved_Retrun_Value Paketleme_Maliyeti_Saved_Get_By_Id(Paketleme_Maliyeti_Saved x);
        List<Paketleme_Maliyeti_Saved_Retrun_Value> Paketleme_Maliyeti_Saved_Get_By_Parça_Id(Revize x);






        Paketleme_Maliyeti_Saved_Row Paketleme_Maliyeti_Saved_Row_Add(Paketleme_Maliyeti_Saved_Row x);
        Paketleme_Maliyeti_Saved_Row Paketleme_Maliyeti_Saved_Row_Delete(Paketleme_Maliyeti_Saved_Row x);
        Paketleme_Maliyeti_Saved_Row Paketleme_Maliyeti_Saved_Row_Edit(Paketleme_Maliyeti_Saved_Row x);
        List<Paketleme_Maliyeti_Saved_Row> Paketleme_Maliyeti_Saved_Row_Get_All();
        Paketleme_Maliyeti_Saved_Row Paketleme_Maliyeti_Saved_Row_Get_By_Id(Paketleme_Maliyeti_Saved_Row x);


    }
    public class PaketlemeSavedService : IPaketlemeSavedService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public PaketlemeSavedService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Paketleme_Maliyeti_Saved Paketleme_Maliyeti_Saved_Add(Paketleme_Maliyeti_Saved x)
        {
            try
            {
                var temp = _context.Paketleme_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);

                _context.Paketleme_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }

            _context.Paketleme_Maliyeti_Saveds.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Paketleme_Maliyeti_Saved Paketleme_Maliyeti_Saved_Delete(Paketleme_Maliyeti_Saved x)
        {
            var temp = _context.Paketleme_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }
        public void Paketleme_Maliyeti_Saved_Delete_By_Revize_Id(Revize x)
        {
            try
            {
                var temp = _context.Paketleme_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Id);

                _context.Paketleme_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }

        }
        public Paketleme_Maliyeti_Saved Paketleme_Maliyeti_Saved_Edit(Paketleme_Maliyeti_Saved x)
        {
            var temp = _context.Paketleme_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.SaveChanges();

            return Değer;
        }

        public List<Paketleme_Maliyeti_Saved_Retrun_Value> Paketleme_Maliyeti_Saved_Get_All()
        {
            var temp = (from x in _context.Paketleme_Maliyeti_Saveds
                        select x
            );

            IEnumerable<Paketleme_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Paketleme_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Paketleme_Maliyeti_Saved_Row = (from x in _context.Paketleme_Maliyeti_Saved_Rows
                                                where x.Paketleme_Maliyeti_Saved_Id == o.Id
                                                select x
               ).ToList()


            });

            return rt.ToList();
        }

        public Paketleme_Maliyeti_Saved_Retrun_Value Paketleme_Maliyeti_Saved_Get_By_Id(Paketleme_Maliyeti_Saved y)
        {
            var temp = (from x in _context.Paketleme_Maliyeti_Saveds
                        where x.Id == y.Id
                        select x
          );

            IEnumerable<Paketleme_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Paketleme_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Paketleme_Maliyeti_Saved_Row = (from x in _context.Paketleme_Maliyeti_Saved_Rows
                                                where x.Paketleme_Maliyeti_Saved_Id == o.Id
                                                select x
               ).ToList()


            });

            return rt.FirstOrDefault();
        }

        public List<Paketleme_Maliyeti_Saved_Retrun_Value> Paketleme_Maliyeti_Saved_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Paketleme_Maliyeti_Saveds
                        where x.Revize_Id == y.Id
                        select x
           );

            IEnumerable<Paketleme_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Paketleme_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Paketleme_Maliyeti_Saved_Row = (from x in _context.Paketleme_Maliyeti_Saved_Rows
                                                where x.Paketleme_Maliyeti_Saved_Id == o.Id
                                                select x
               ).ToList()


            });

            return rt.ToList();
        }

        public Paketleme_Maliyeti_Saved_Row Paketleme_Maliyeti_Saved_Row_Add(Paketleme_Maliyeti_Saved_Row x)
        {
            _context.Paketleme_Maliyeti_Saved_Rows.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Paketleme_Maliyeti_Saved_Row Paketleme_Maliyeti_Saved_Row_Delete(Paketleme_Maliyeti_Saved_Row x)
        {
            var temp = _context.Paketleme_Maliyeti_Saved_Rows;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Paketleme_Maliyeti_Saved_Row Paketleme_Maliyeti_Saved_Row_Edit(Paketleme_Maliyeti_Saved_Row x)
        {
            throw new NotImplementedException();
        }

        public List<Paketleme_Maliyeti_Saved_Row> Paketleme_Maliyeti_Saved_Row_Get_All()
        {
            throw new NotImplementedException();
        }

        public Paketleme_Maliyeti_Saved_Row Paketleme_Maliyeti_Saved_Row_Get_By_Id(Paketleme_Maliyeti_Saved_Row x)
        {
            throw new NotImplementedException();
        }


    }
}