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
    public interface IRevizeService
    {
        Revize Revize_Add(Revize x);
        Revize Revize_Delete(Revize x);

        Revize Revize_Edit(Revize x);

        List<Revize> Revize_Get_All();

        Revize Revize_Get_By_Id(Revize x);

        List<Revize> Revize_Get_By_Parça_Id(Parça x);


    }
    public class RevizeService : IRevizeService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public RevizeService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Revize Revize_Add(Revize x)
        {
            _context.Revizes.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Revize Revize_Delete(Revize x)
        {
            var temp = _context.Revizes;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            //_context.Büküm_KiloHesabı.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Revize Revize_Edit(Revize x)
        {
            throw new NotImplementedException();
        }

        public List<Revize> Revize_Get_All()
        {
            throw new NotImplementedException();
        }

        public Revize Revize_Get_By_Id(Revize x)
        {
            throw new NotImplementedException();
        }

        public List<Revize> Revize_Get_By_Parça_Id(Parça y)
        {
           var temp =(from x in _context.Revizes
                        where x.Parça_Id == y.Id
                        select x
           );

           return temp.ToList();
        }
    }
}