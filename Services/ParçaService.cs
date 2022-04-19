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
    public interface IParçaService
    {
        Parça Parça_Add(Parça x);
        Parça Parça_Delete(Parça x);

        Parça Parça_Edit(Parça x);

        List<Parça_Retrun_Value> Parça_Get_All();

        Parça_Retrun_Value Parça_By_Id(Parça x);

        List<Parça_Retrun_Value> Parça_Get_By_Takım_Id(Takım x);


    }
    public class ParçaService : IParçaService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public ParçaService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Parça Parça_Add(Parça x)
        {
            _context.Parças.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Parça Parça_Delete(Parça x)
        {
            var temp = _context.Parças;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            //_context.Büküm_KiloHesabı.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Parça Parça_Edit(Parça x)
        {
            var temp = _context.Parças;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id && x.Is_Deleted == 0);
            Değer.Parça_Adı = x.Parça_Adı;
            _context.SaveChanges();

            return Değer;
        }

        public List<Parça_Retrun_Value> Parça_Get_All()
        {
            var temp = (from x in _context.Parças
                        select x
            );

            IEnumerable<Parça_Retrun_Value> rt = temp.Select(o => new Parça_Retrun_Value
            {
                Id = o.Id,
                Parça_Adı = o.Parça_Adı,
                Parça_Adeti = (from x in _context.Malzeme_Maliyeti_Saveds
                               where x.Revize_Id == x.Id
                               orderby x.Id descending
                               select x.Parça_Adeti
                ).FirstOrDefault(),
                Birim_Maliyet = (from x in _context.Toplam_Maliyet_Saveds
                                 where x.Revize_Id == x.Id
                                 orderby x.Id descending
                                 select x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti
                ).FirstOrDefault(),
                Takım_Id = o.Takım_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi


            });

            return rt.ToList();
        }

        public Parça_Retrun_Value Parça_By_Id(Parça y)
        {



            var temp = (from x in _context.Parças
                        where y.Id == x.Id
                        select x
            );

            IEnumerable<Parça_Retrun_Value> rt = temp.Select(o => new Parça_Retrun_Value
            {
                Id = o.Id,
                Parça_Adı = o.Parça_Adı,
                Parça_Adeti = (from x in _context.Malzeme_Maliyeti_Saveds
                               where x.Revize_Id == x.Id
                               orderby x.Id descending
                               select x.Parça_Adeti
                ).FirstOrDefault(),
                Birim_Maliyet = (from x in _context.Toplam_Maliyet_Saveds
                                 where x.Revize_Id == x.Id
                                 orderby x.Id descending
                                 select x.Malzeme_Karlı_Toplam + x.İşçilik_Karlı_Toplam - x.Fire_Maliyeti
                ).FirstOrDefault(),
                Takım_Id = o.Takım_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi


            });

            return rt.FirstOrDefault();



        }

        public List<Parça_Retrun_Value> Parça_Get_By_Takım_Id(Takım y)
        {



            var temp = (from x in _context.Parças
                        where y.Id == x.Takım_Id
                        select x
           );

            IEnumerable<Parça_Retrun_Value> rt = temp.Select(o => new Parça_Retrun_Value
            {
                Id = o.Id,
                Parça_Adı = o.Parça_Adı,
                Parça_Adeti = o.Parça_Adeti,
                Birim_Maliyet = (from x in _context.Toplam_Maliyet_Saveds

                                 join _revises in _context.Revizes
                                on x.Revize_Id equals _revises.Id
                                 orderby _revises.Id descending
                                 where _revises.Parça_Id == o.Id

                                 select (x.Malzeme_Karlı_Toplam+x.İşçilik_Karlı_Toplam-x.Fire_Maliyeti)
                ).FirstOrDefault(),
                Takım_Id = o.Takım_Id,
                Olusturlma_Tarihi = o.Olusturlma_Tarihi


            });

            return rt.ToList();
        }

    }

}