using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;
using BCryptNet = BCrypt.Net.BCrypt;
using WebApi.Models.Şehir_Request;
using qrmenu.Models.Uyeİşlemleri;
using qrmenu.Entities;
using qrmenu.Services;
using KaynakKod.Entities;

namespace qrmenu.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class Büküm_Maliyeti_SavedController : ControllerBase
    {
        private IBükümMaliyetiSavedService _IBükümMaliyetiSavedService;
        public Büküm_Maliyeti_SavedController(IBükümMaliyetiSavedService uyeIslemleriServices)
        {
            _IBükümMaliyetiSavedService = uyeIslemleriServices;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Ağırlık_Add")]
        public IActionResult Büküm_Maliyeti_Saved_Ağırlık_Add(Büküm_Maliyeti_Saved_Ağırlık x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Ağırlık_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Ağırlık_Edit")]
        public IActionResult Büküm_Maliyeti_Saved_Ağırlık_Edit(Büküm_Maliyeti_Saved_Ağırlık x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Ağırlık_Edit(x);
            return Ok(a);
        }
        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Ağırlık_Delete")]
        public IActionResult Büküm_Maliyeti_Saved_Ağırlık_Delete(Büküm_Maliyeti_Saved_Ağırlık x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Ağırlık_Delete(x);
            return Ok(a);
        }
        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Ağırlık_Get_All")]
        public IActionResult Büküm_Maliyeti_Saved_Ağırlık_Get_All()
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Ağırlık_Get_All();
            return Ok(a);
        }
        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Ağırlık_Get_By_Id")]
        public IActionResult Büküm_Maliyeti_Saved_Ağırlık_Get_By_Id(Büküm_Maliyeti_Saved_Ağırlık x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Ağırlık_Get_By_Id(x);
            return Ok(a);
        }
        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Ağırlık_Get_By_Parça_Id")]
        public IActionResult Büküm_Maliyeti_Saved_Ağırlık_Get_By_Parça_Id(Revize x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Ağırlık_Get_By_Parça_Id(x);
            return Ok(a);
        }








        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Adet_Add")]
        public IActionResult Büküm_Maliyeti_Saved_Adet_Add(Büküm_Maliyeti_Saved_Adet x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Adet_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Adet_Delete")]
        public IActionResult Büküm_Maliyeti_Saved_Adet_Delete(Büküm_Maliyeti_Saved_Adet x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Adet_Delete(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Adet_Edit")]
        public IActionResult Büküm_Maliyeti_Saved_Adet_Edit(Büküm_Maliyeti_Saved_Adet x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Adet_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Adet_Get_All")]
        public IActionResult Büküm_Maliyeti_Saved_Adet_Get_All()
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Adet_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Adet_Get_By_Id")]
        public IActionResult Büküm_Maliyeti_Saved_Adet_Get_By_Id(Büküm_Maliyeti_Saved_Adet x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Adet_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Adet_Get_By_Parça_Id")]
        public IActionResult Büküm_Maliyeti_Saved_Adet_Get_By_Parça_Id(Revize x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Adet_Get_By_Parça_Id(x);
            return Ok(a);
        }








        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Uzunluk_Add")]
        public IActionResult Büküm_Maliyeti_Saved_Uzunluk_Add(Büküm_Maliyeti_Saved_Uzunluk x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Uzunluk_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Uzunluk_Delete")]
        public IActionResult Büküm_Maliyeti_Saved_Uzunluk_Delete(Büküm_Maliyeti_Saved_Uzunluk x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Uzunluk_Delete(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Uzunluk_Edit")]
        public IActionResult Büküm_Maliyeti_Saved_Uzunluk_Edit(Büküm_Maliyeti_Saved_Uzunluk x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Uzunluk_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Uzunluk_Get_All")]
        public IActionResult Büküm_Maliyeti_Saved_Uzunluk_Get_All()
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Uzunluk_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Uzunluk_Get_By_Id")]
        public IActionResult Büküm_Maliyeti_Saved_Uzunluk_Get_By_Id(Büküm_Maliyeti_Saved_Uzunluk x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Uzunluk_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Maliyeti_Saved_Uzunluk_Get_By_Parça_Id")]
        public IActionResult Büküm_Maliyeti_Saved_Uzunluk_Get_By_Parça_Id(Revize x)
        {
            var a = _IBükümMaliyetiSavedService.Büküm_Maliyeti_Saved_Uzunluk_Get_By_Parça_Id(x);
            return Ok(a);
        }












































    }
}