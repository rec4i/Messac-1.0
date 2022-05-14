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
using KaynakKod.Models.pagenation_request;

namespace qrmenu.Services
{
    public interface IUretimMaliyetiService
    {
        pagination_Request_Result<UretimMaliyeti_Return> UretimMaliyeti_Pagenation_List(pagenation_request request);

    }
    public class UretimMaliyetiService : IUretimMaliyetiService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public UretimMaliyetiService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public pagination_Request_Result<UretimMaliyeti_Return> UretimMaliyeti_Pagenation_List(pagenation_request request)
        {
            var temp = _context.uretimMaliyetis.ToList();

            var uretimMaliyeti_Pagenation_List = (from x in temp
                                                    
                                                  select new
                                                  {
                                                      x.Id,
                                                      x.İşin_Adı,
                                                      x.Musteri_Id,
                                                      x.Olusturan_kullanıcı,
                                                      x.Oluşturlma_Tar,
                                                      x.Son_Düzenleme_Tar,
                                                      x.Teslim_Tarihi_Beklentisi,
                                                      x.Ödeme_Şekli_Beklentisi
                                                  }).Skip(Convert.ToInt32(request.offset)).Take(Convert.ToInt32(request.limit)).ToList();

            
        

            IEnumerable<UretimMaliyeti_Return> uretimMaliyeti_Pagenation_List_result = uretimMaliyeti_Pagenation_List.Select(o => new UretimMaliyeti_Return
            {
                Id = o.Id,
                İşin_Adı = o.İşin_Adı,
                Musteri_Id = o.Musteri_Id,
                Oluşturlma_Tar = o.Oluşturlma_Tar.ToString(),
                Son_Düzenleme_Tar = o.Son_Düzenleme_Tar.ToString(),
                Teslim_Tarihi_Beklentisi = o.Teslim_Tarihi_Beklentisi,
                Ödeme_Şekli_Beklentisi = o.Ödeme_Şekli_Beklentisi,
            });

            var Result = new pagination_Request_Result<UretimMaliyeti_Return>
            {
                rows = uretimMaliyeti_Pagenation_List_result.ToList(),
                totalNotFiltered = temp.Count(),
                total = uretimMaliyeti_Pagenation_List_result.Count()
            };


            return Result;

        }
    }
}