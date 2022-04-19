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
    public interface ITesfiyeSavedService
    {
        Tesfiye_Maliyeti_Saved Tesfiye_Maliyeti_Saved_Add(Tesfiye_Maliyeti_Saved x);
        Tesfiye_Maliyeti_Saved Tesfiye_Maliyeti_Saved_Delete(Tesfiye_Maliyeti_Saved x);
        Tesfiye_Maliyeti_Saved Tesfiye_Maliyeti_Saved_Edit(Tesfiye_Maliyeti_Saved x);
        List<Tesfiye_Maliyeti_Saved_Retrun_Value> Tesfiye_Maliyeti_Saved_Get_All();
        Tesfiye_Maliyeti_Saved_Retrun_Value Tesfiye_Maliyeti_Saved_Get_By_Id(Tesfiye_Maliyeti_Saved x);
        List<Tesfiye_Maliyeti_Saved_Retrun_Value> Tesfiye_Maliyeti_Saved_Get_By_Parça_Id(Revize x);






        Tesfiye_Maliyeti_Saved_Row Tesfiye_Maliyeti_Saved_Row_Add(Tesfiye_Maliyeti_Saved_Row x);
        Tesfiye_Maliyeti_Saved_Row Tesfiye_Maliyeti_Saved_Row_Delete(Tesfiye_Maliyeti_Saved_Row x);
        Tesfiye_Maliyeti_Saved_Row Tesfiye_Maliyeti_Saved_Row_Edit(Tesfiye_Maliyeti_Saved_Row x);
        List<Tesfiye_Maliyeti_Saved_Row> Tesfiye_Maliyeti_Saved_Row_Get_All();
        Tesfiye_Maliyeti_Saved_Row Tesfiye_Maliyeti_Saved_Row_Get_By_Id(Tesfiye_Maliyeti_Saved_Row x);


    }
    public class TesfiyeSavedService : ITesfiyeSavedService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public TesfiyeSavedService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Tesfiye_Maliyeti_Saved Tesfiye_Maliyeti_Saved_Add(Tesfiye_Maliyeti_Saved x)
        {
            try
            {
                var temp = _context.Tesfiye_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);

                _context.Tesfiye_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }

            _context.Tesfiye_Maliyeti_Saveds.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Tesfiye_Maliyeti_Saved Tesfiye_Maliyeti_Saved_Delete(Tesfiye_Maliyeti_Saved x)
        {
            var temp = _context.Tesfiye_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Tesfiye_Maliyeti_Saved Tesfiye_Maliyeti_Saved_Edit(Tesfiye_Maliyeti_Saved x)
        {
            var temp = _context.Tesfiye_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.SaveChanges();

            return Değer;
        }

        public List<Tesfiye_Maliyeti_Saved_Retrun_Value> Tesfiye_Maliyeti_Saved_Get_All()
        {
            var temp = (from x in _context.Tesfiye_Maliyeti_Saveds
                        select x
            );

            IEnumerable<Tesfiye_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Tesfiye_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Tesfiye_Maliyeti_Saved_Row = (from x in _context.Tesfiye_Maliyeti_Saved_Rows
                                              where x.Tesfiye_Maliyeti_Saved_Id == o.Id
                                              select x
               ).ToList()


            });

            return rt.ToList();
        }

        public Tesfiye_Maliyeti_Saved_Retrun_Value Tesfiye_Maliyeti_Saved_Get_By_Id(Tesfiye_Maliyeti_Saved y)
        {
            var temp = (from x in _context.Tesfiye_Maliyeti_Saveds
                        where x.Id == y.Id
                        select x
          );

            IEnumerable<Tesfiye_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Tesfiye_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Tesfiye_Maliyeti_Saved_Row = (from x in _context.Tesfiye_Maliyeti_Saved_Rows
                                              where x.Tesfiye_Maliyeti_Saved_Id == o.Id
                                              select x
               ).ToList()


            });

            return rt.FirstOrDefault();
        }

        public List<Tesfiye_Maliyeti_Saved_Retrun_Value> Tesfiye_Maliyeti_Saved_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Tesfiye_Maliyeti_Saveds
                        where x.Revize_Id == y.Id
                        select x
           );

            IEnumerable<Tesfiye_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Tesfiye_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Tesfiye_Maliyeti_Saved_Row = (from x in _context.Tesfiye_Maliyeti_Saved_Rows
                                              where x.Tesfiye_Maliyeti_Saved_Id == o.Id
                                              select x
               ).ToList()


            });

            return rt.ToList();
        }

        public Tesfiye_Maliyeti_Saved_Row Tesfiye_Maliyeti_Saved_Row_Add(Tesfiye_Maliyeti_Saved_Row x)
        {
            _context.Tesfiye_Maliyeti_Saved_Rows.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Tesfiye_Maliyeti_Saved_Row Tesfiye_Maliyeti_Saved_Row_Delete(Tesfiye_Maliyeti_Saved_Row x)
        {
            var temp = _context.Tesfiye_Maliyeti_Saved_Rows;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Tesfiye_Maliyeti_Saved_Row Tesfiye_Maliyeti_Saved_Row_Edit(Tesfiye_Maliyeti_Saved_Row x)
        {
            throw new NotImplementedException();
        }

        public List<Tesfiye_Maliyeti_Saved_Row> Tesfiye_Maliyeti_Saved_Row_Get_All()
        {
            throw new NotImplementedException();
        }

        public Tesfiye_Maliyeti_Saved_Row Tesfiye_Maliyeti_Saved_Row_Get_By_Id(Tesfiye_Maliyeti_Saved_Row x)
        {
            throw new NotImplementedException();
        }
    }
}