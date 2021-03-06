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
    public interface ITesviyeSavedService
    {
        Tesviye_Maliyeti_Saved Tesviye_Maliyeti_Saved_Add(Tesviye_Maliyeti_Saved x);
        Tesviye_Maliyeti_Saved Tesviye_Maliyeti_Saved_Delete(Tesviye_Maliyeti_Saved x);

        void Tesviye_Maliyeti_Saved_Delete_By_Revize_Id(Revize x);



        Tesviye_Maliyeti_Saved Tesviye_Maliyeti_Saved_Edit(Tesviye_Maliyeti_Saved x);
        List<Tesviye_Maliyeti_Saved_Retrun_Value> Tesviye_Maliyeti_Saved_Get_All();
        Tesviye_Maliyeti_Saved_Retrun_Value Tesviye_Maliyeti_Saved_Get_By_Id(Tesviye_Maliyeti_Saved x);
        List<Tesviye_Maliyeti_Saved_Retrun_Value> Tesviye_Maliyeti_Saved_Get_By_Parça_Id(Revize x);






        Tesviye_Maliyeti_Saved_Row Tesviye_Maliyeti_Saved_Row_Add(Tesviye_Maliyeti_Saved_Row x);
        Tesviye_Maliyeti_Saved_Row Tesviye_Maliyeti_Saved_Row_Delete(Tesviye_Maliyeti_Saved_Row x);
        Tesviye_Maliyeti_Saved_Row Tesviye_Maliyeti_Saved_Row_Edit(Tesviye_Maliyeti_Saved_Row x);
        List<Tesviye_Maliyeti_Saved_Row> Tesviye_Maliyeti_Saved_Row_Get_All();
        Tesviye_Maliyeti_Saved_Row Tesviye_Maliyeti_Saved_Row_Get_By_Id(Tesviye_Maliyeti_Saved_Row x);


    }
    public class TesviyeSavedService : ITesviyeSavedService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public TesviyeSavedService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Tesviye_Maliyeti_Saved Tesviye_Maliyeti_Saved_Add(Tesviye_Maliyeti_Saved x)
        {
            try
            {
                var temp = _context.Tesviye_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);

                _context.Tesviye_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }

            _context.Tesviye_Maliyeti_Saveds.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Tesviye_Maliyeti_Saved Tesviye_Maliyeti_Saved_Delete(Tesviye_Maliyeti_Saved x)
        {
            var temp = _context.Tesviye_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }


        public void Tesviye_Maliyeti_Saved_Delete_By_Revize_Id(Revize x)
        {
            try
            {
                var temp = _context.Tesviye_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Id);

                _context.Tesviye_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }

        }
        public Tesviye_Maliyeti_Saved Tesviye_Maliyeti_Saved_Edit(Tesviye_Maliyeti_Saved x)
        {
            var temp = _context.Tesviye_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.SaveChanges();

            return Değer;
        }

        public List<Tesviye_Maliyeti_Saved_Retrun_Value> Tesviye_Maliyeti_Saved_Get_All()
        {
            var temp = (from x in _context.Tesviye_Maliyeti_Saveds
                        select x
            );

            IEnumerable<Tesviye_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Tesviye_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Tesviye_Maliyeti_Saved_Row = (from x in _context.Tesviye_Maliyeti_Saved_Rows
                                              where x.Tesviye_Maliyeti_Saved_Id == o.Id
                                              select x
               ).ToList()


            });

            return rt.ToList();
        }

        public Tesviye_Maliyeti_Saved_Retrun_Value Tesviye_Maliyeti_Saved_Get_By_Id(Tesviye_Maliyeti_Saved y)
        {
            var temp = (from x in _context.Tesviye_Maliyeti_Saveds
                        where x.Id == y.Id
                        select x
          );

            IEnumerable<Tesviye_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Tesviye_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Tesviye_Maliyeti_Saved_Row = (from x in _context.Tesviye_Maliyeti_Saved_Rows
                                              where x.Tesviye_Maliyeti_Saved_Id == o.Id
                                              select x
               ).ToList()


            });

            return rt.FirstOrDefault();
        }

        public List<Tesviye_Maliyeti_Saved_Retrun_Value> Tesviye_Maliyeti_Saved_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Tesviye_Maliyeti_Saveds
                        where x.Revize_Id == y.Id
                        select x
           );

            IEnumerable<Tesviye_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Tesviye_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Tesviye_Maliyeti_Saved_Row = (from x in _context.Tesviye_Maliyeti_Saved_Rows
                                              where x.Tesviye_Maliyeti_Saved_Id == o.Id
                                              select x
               ).ToList()


            });

            return rt.ToList();
        }

        public Tesviye_Maliyeti_Saved_Row Tesviye_Maliyeti_Saved_Row_Add(Tesviye_Maliyeti_Saved_Row x)
        {
            _context.Tesviye_Maliyeti_Saved_Rows.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Tesviye_Maliyeti_Saved_Row Tesviye_Maliyeti_Saved_Row_Delete(Tesviye_Maliyeti_Saved_Row x)
        {
            var temp = _context.Tesviye_Maliyeti_Saved_Rows;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Tesviye_Maliyeti_Saved_Row Tesviye_Maliyeti_Saved_Row_Edit(Tesviye_Maliyeti_Saved_Row x)
        {
            throw new NotImplementedException();
        }

        public List<Tesviye_Maliyeti_Saved_Row> Tesviye_Maliyeti_Saved_Row_Get_All()
        {
            throw new NotImplementedException();
        }

        public Tesviye_Maliyeti_Saved_Row Tesviye_Maliyeti_Saved_Row_Get_By_Id(Tesviye_Maliyeti_Saved_Row x)
        {
            throw new NotImplementedException();
        }


    }
}