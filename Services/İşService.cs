using System.Collections.Generic;
using System.Linq;
using KaynakKod.Entities;
using KaynakKod.Entities.UretimMaliyeti.İşlemler;
using Microsoft.Extensions.Options;
using qrmenu.Entities;
using WebApi.Authorization;
using WebApi.Helpers;
using KaynakKod.Models;
using KaynakKod.Models.pagenation_request;
using System;

namespace KaynakKod.Services
{
    public interface IişService
    {
        İş iş_Add(İş x);

        İş İş_Delete(İş x);

        İş İş_Edit(İş x);

        List<İş> İş_Get_All();

        İş İş_Get_By_Id(İş x);

        List<İş> İş_Get_By_Text(İş x);
        pagination_Request_Result<İş> İş_Get_The_List(pagenation_request request);
    }

    public class İşService : IişService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public İşService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public İş iş_Add(İş x)
        {
            _context.İşs.Add(x);
            _context.SaveChanges();
            return x;
        }

        public İş İş_Delete(İş x)
        {
            var temp = _context.İşs;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Is_Deleted = 1;
            // _context.kaplamas.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public İş İş_Edit(İş x)
        {
            var temp = _context.İşs;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.İşin_Adı = x.İşin_Adı;
            _context.SaveChanges();

            return Değer;
        }

        public List<İş> İş_Get_All()
        {
            var temp = (from x in _context.İşs
                        where x.Is_Deleted == 0
                        select x
            );

            return temp.ToList();

        }

        public İş İş_Get_By_Id(İş y)
        {
            var temp = (from x in _context.İşs
                        where x.Is_Deleted == 0 && y.Id == x.Id
                        select x
           );

            return temp.FirstOrDefault();
        }

        public List<İş> İş_Get_By_Text(İş y)
        {
            var temp = (from x in _context.İşs
                        where x.Is_Deleted == 0 && x.İşin_Adı.StartsWith(y.İşin_Adı)
                        select x
            );

            return temp.ToList();
        }
        public pagination_Request_Result<İş> İş_Get_The_List(pagenation_request request)
        {
            var temp = (from x in _context.İşs
                        where x.Is_Deleted==0
                        select x
              ).Skip(Convert.ToInt32(request.offset)).Take(Convert.ToInt32(request.limit)).ToList();




            var Result = new pagination_Request_Result<İş>
            {
                rows = temp.ToList(),
                totalNotFiltered = _context.İşs.Count(),
                total = temp.Count()
            };

            return Result;


        }
    }


}