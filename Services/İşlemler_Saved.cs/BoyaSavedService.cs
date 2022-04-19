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
    public interface IBoyaSavedService
    {
        Boya_Maliyeti_Saved Boya_Maliyeti_Saved_Add(Boya_Maliyeti_Saved x);
        Boya_Maliyeti_Saved Boya_Maliyeti_Saved_Delete(Boya_Maliyeti_Saved x);
        Boya_Maliyeti_Saved Boya_Maliyeti_Saved_Edit(Boya_Maliyeti_Saved x);
        List<Boya_Maliyeti_Saved_Retrun_Value> Boya_Maliyeti_Saved_Get_All();
        Boya_Maliyeti_Saved_Retrun_Value Boya_Maliyeti_Saved_Get_By_Id(Boya_Maliyeti_Saved x);
        List<Boya_Maliyeti_Saved_Retrun_Value> Boya_Maliyeti_Saved_Get_By_Parça_Id(Revize x);






        Boya_Maliyeti_Saved_Row Boya_Maliyeti_Saved_Row_Add(Boya_Maliyeti_Saved_Row x);
        Boya_Maliyeti_Saved_Row Boya_Maliyeti_Saved_Row_Delete(Boya_Maliyeti_Saved_Row x);
        Boya_Maliyeti_Saved_Row Boya_Maliyeti_Saved_Row_Edit(Boya_Maliyeti_Saved_Row x);
        List<Boya_Maliyeti_Saved_Row> Boya_Maliyeti_Saved_Row_Get_All();
        Boya_Maliyeti_Saved_Row Boya_Maliyeti_Saved_Row_Get_By_Id(Boya_Maliyeti_Saved_Row x);


    }
    public class BoyaSavedService : IBoyaSavedService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public BoyaSavedService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Boya_Maliyeti_Saved Boya_Maliyeti_Saved_Add(Boya_Maliyeti_Saved x)
        {
            try
            {
                var temp = _context.Boya_Maliyeti_Saveds;
                var Değer = temp.FirstOrDefault(o => o.Revize_Id == x.Revize_Id);

                _context.Boya_Maliyeti_Saveds.Remove(Değer);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

            }

            _context.Boya_Maliyeti_Saveds.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Boya_Maliyeti_Saved Boya_Maliyeti_Saved_Delete(Boya_Maliyeti_Saved x)
        {
            var temp = _context.Boya_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Boya_Maliyeti_Saved Boya_Maliyeti_Saved_Edit(Boya_Maliyeti_Saved x)
        {
            var temp = _context.Boya_Maliyeti_Saveds;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.SaveChanges();

            return Değer;
        }

        public List<Boya_Maliyeti_Saved_Retrun_Value> Boya_Maliyeti_Saved_Get_All()
        {
            var temp = (from x in _context.Boya_Maliyeti_Saveds
                        select x
            );

            IEnumerable<Boya_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Boya_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Boya_Maliyeti_Saved_Row = (from x in _context.Boya_Maliyeti_Saved_Rows
                                              where x.Boya_Maliyeti_Saved_Id == o.Id
                                              select x
               ).ToList()


            });

            return rt.ToList();
        }

        public Boya_Maliyeti_Saved_Retrun_Value Boya_Maliyeti_Saved_Get_By_Id(Boya_Maliyeti_Saved y)
        {
            var temp = (from x in _context.Boya_Maliyeti_Saveds
                        where x.Id == y.Id
                        select x
          );

            IEnumerable<Boya_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Boya_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Boya_Maliyeti_Saved_Row = (from x in _context.Boya_Maliyeti_Saved_Rows
                                              where x.Boya_Maliyeti_Saved_Id == o.Id
                                              select x
               ).ToList()


            });

            return rt.FirstOrDefault();
        }

        public List<Boya_Maliyeti_Saved_Retrun_Value> Boya_Maliyeti_Saved_Get_By_Parça_Id(Revize y)
        {
            var temp = (from x in _context.Boya_Maliyeti_Saveds
                        where x.Revize_Id == y.Id
                        select x
           );

            IEnumerable<Boya_Maliyeti_Saved_Retrun_Value> rt = temp.Select(o => new Boya_Maliyeti_Saved_Retrun_Value
            {
                Id = o.Id,
                Revize_Id = o.Revize_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi,
                Boya_Maliyeti_Saved_Row = (from x in _context.Boya_Maliyeti_Saved_Rows
                                              where x.Boya_Maliyeti_Saved_Id == o.Id
                                              select x
               ).ToList()


            });

            return rt.ToList();
        }

        public Boya_Maliyeti_Saved_Row Boya_Maliyeti_Saved_Row_Add(Boya_Maliyeti_Saved_Row x)
        {
            _context.Boya_Maliyeti_Saved_Rows.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Boya_Maliyeti_Saved_Row Boya_Maliyeti_Saved_Row_Delete(Boya_Maliyeti_Saved_Row x)
        {
            var temp = _context.Boya_Maliyeti_Saved_Rows;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.baglantıElemanlarıs.Remove(Değer);
            _context.SaveChanges();
            return Değer;
        }

        public Boya_Maliyeti_Saved_Row Boya_Maliyeti_Saved_Row_Edit(Boya_Maliyeti_Saved_Row x)
        {
            throw new NotImplementedException();
        }

        public List<Boya_Maliyeti_Saved_Row> Boya_Maliyeti_Saved_Row_Get_All()
        {
            throw new NotImplementedException();
        }

        public Boya_Maliyeti_Saved_Row Boya_Maliyeti_Saved_Row_Get_By_Id(Boya_Maliyeti_Saved_Row x)
        {
            throw new NotImplementedException();
        }
    }
}