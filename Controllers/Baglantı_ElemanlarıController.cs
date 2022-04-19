using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using KaynakKod.Services;
using WebApi.Entities;
using KaynakKod.Entities.UretimMaliyeti.İşlemler;

namespace qrmenu.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class Baglantı_ElemanlarıController : ControllerBase
    {
        private IBaglantıElemanlarıService _IBaglantıElemanlarıService;
        public Baglantı_ElemanlarıController(IBaglantıElemanlarıService baglantıElemanlarıService)
        {
            _IBaglantıElemanlarıService = baglantıElemanlarıService;
        }

        [Authorize(Role.Admin)]
        [HttpPost("BaglantıElemanları_Add")]
        public IActionResult BaglantıElemanları_Add(BaglantıElemanları x)
        {
            var a = _IBaglantıElemanlarıService.BaglantıElemanları_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("baglantıElemanları_Delete")]
        public IActionResult baglantıElemanları_Delete(BaglantıElemanları x)
        {
            var a = _IBaglantıElemanlarıService.baglantıElemanları_Delete(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("baglantıElemanları_Edit")]
        public IActionResult baglantıElemanları_Edit(BaglantıElemanları x)
        {
            var a = _IBaglantıElemanlarıService.baglantıElemanları_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("baglantıElemanları_Get_All")]
        public IActionResult baglantıElemanları_Get_All()
        {
            var a = _IBaglantıElemanlarıService.baglantıElemanları_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("baglantıElemanları_Get_By_Id")]
        public IActionResult baglantıElemanları_Get_By_Id(BaglantıElemanları x)
        {
            var a = _IBaglantıElemanlarıService.baglantıElemanları_Get_By_Id(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("bağlantı_Elemanları_Türü_Add")]
        public IActionResult bağlantı_Elemanları_Türü_Add(Bağlantı_Elemanları_Türü x)
        {
            var a = _IBaglantıElemanlarıService.bağlantı_Elemanları_Türü_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("bağlantı_Elemanları_Türü_Delete")]
        public IActionResult bağlantı_Elemanları_Türü_Delete(Bağlantı_Elemanları_Türü x)
        {
            var a = _IBaglantıElemanlarıService.bağlantı_Elemanları_Türü_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("bağlantı_Elemanları_Türü_Edit")]
        public IActionResult bağlantı_Elemanları_Türü_Edit(Bağlantı_Elemanları_Türü x)
        {
            var a = _IBaglantıElemanlarıService.bağlantı_Elemanları_Türü_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("bağlantı_Elemanları_Türü_Get_All")]
        public IActionResult bağlantı_Elemanları_Türü_Get_All()
        {
            var a = _IBaglantıElemanlarıService.bağlantı_Elemanları_Türü_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("bağlantı_Elemanları_Türü_Get_By_Id")]
        public IActionResult bağlantı_Elemanları_Türü_Get_By_Id(Bağlantı_Elemanları_Türü x)
        {
            var a = _IBaglantıElemanlarıService.bağlantı_Elemanları_Türü_Get_By_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("baglantıElemanları_Get_By_Bağlantı_Türü_Id")]
        public IActionResult baglantıElemanları_Get_By_Bağlantı_Türü_Id(Bağlantı_Elemanları_Türü x)
        {
            var a = _IBaglantıElemanlarıService.baglantıElemanları_Get_By_Bağlantı_Türü_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("baglantıElemanları_Get_By_Text")]
        public IActionResult baglantıElemanları_Get_By_Text(BaglantıElemanları x)
        {
            var a = _IBaglantıElemanlarıService.baglantıElemanları_Get_By_Text(x);
            return Ok(a);
        }
    }
}