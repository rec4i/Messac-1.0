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

        Revize_Retrun_Value Revize_Get_By_Id(Revize y);

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

        public Revize_Retrun_Value Revize_Get_By_Id(Revize y)
        {
            var temp =(from x in _context.Revizes

                        join _Parça in _context.Parças
                        on x.Parça_Id equals _Parça.Id

                        join _Takım in _context.Takıms
                        on _Parça.Takım_Id equals _Takım.Id

                        join _İş in _context.İşs
                        on _Takım.İş_Id equals _İş.Id
                        
                        where x.Id==y.Id

                        select new {
                            x.Id,
                            x.Is_Deleted,
                            x.Olusturlma_Tarihi,
                            x.Parça_Id,
                            _Parça,
                            _Takım,
                            _İş
                        }
            ).FirstOrDefault();

            Revize_Retrun_Value rv= new Revize_Retrun_Value{
                Id=temp.Id,
                Parça_Id=temp.Parça_Id,
                Is_Deleted=temp.Is_Deleted,
                Takım=temp._Takım,
                Parça=temp._Parça,
                İş=temp._İş
            };

            return rv;
        }

        public List<Revize> Revize_Get_By_Parça_Id(Parça y)
        {
           var temp =(from x in _context.Revizes
                        where x.Parça_Id == y.Id && x.Is_Deleted==0
                        select x
           );

           return temp.ToList();
        }
    }
}