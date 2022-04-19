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
    public class Kaynak_Maliyeti_SavedController : ControllerBase
    {
        private IKaynakMaliyetiSavedService _IKaynakMaliyetiSavedService;
        public Kaynak_Maliyeti_SavedController(IKaynakMaliyetiSavedService uyeIslemleriServices)
        {
            _IKaynakMaliyetiSavedService = uyeIslemleriServices;
        }


        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Maliyeti_Saved_Add")]
        public IActionResult Kaynak_Maliyeti_Saved_Add(Kaynak_Maliyeti_Saved x)
        {
            var a = _IKaynakMaliyetiSavedService.Kaynak_Maliyeti_Saved_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Maliyeti_Saved_Delete")]
        public IActionResult Kaynak_Maliyeti_Saved_Delete(Kaynak_Maliyeti_Saved x)
        {
            var a = _IKaynakMaliyetiSavedService.Kaynak_Maliyeti_Saved_Delete(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Maliyeti_Saved_Edit")]
        public IActionResult Kaynak_Maliyeti_Saved_Edit(Kaynak_Maliyeti_Saved x)
        {
            var a = _IKaynakMaliyetiSavedService.Kaynak_Maliyeti_Saved_Edit(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Maliyeti_Saved_Get_All")]
        public IActionResult Kaynak_Maliyeti_Saved_Get_All()
        {
            var a = _IKaynakMaliyetiSavedService.Kaynak_Maliyeti_Saved_Get_All();
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Maliyeti_Saved_Get_By_Id")]
        public IActionResult Kaynak_Maliyeti_Saved_Get_By_Id(Kaynak_Maliyeti_Saved x)
        {
            var a = _IKaynakMaliyetiSavedService.Kaynak_Maliyeti_Saved_Get_By_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Maliyeti_Saved_Get_By_Parça_Id")]
        public IActionResult Kaynak_Maliyeti_Saved_Get_By_Parça_Id(Revize x)
        {
            var a = _IKaynakMaliyetiSavedService.Kaynak_Maliyeti_Saved_Get_By_Parça_Id(x);
            return Ok(a);
        }




























        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Maliyeti_Saved_Row_Add")]
        public IActionResult Kaynak_Maliyeti_Saved_Row_Add(Kaynak_Maliyeti_Saved_Row x)
        {
            var a = _IKaynakMaliyetiSavedService.Kaynak_Maliyeti_Saved_Row_Add(x);
            return Ok(a);
        }




        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Maliyeti_Saved_Row_Delete")]
        public IActionResult Kaynak_Maliyeti_Saved_Row_Delete(Kaynak_Maliyeti_Saved_Row x)
        {
            var a = _IKaynakMaliyetiSavedService.Kaynak_Maliyeti_Saved_Row_Delete(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Maliyeti_Saved_Row_Edit")]
        public IActionResult Kaynak_Maliyeti_Saved_Row_Edit(Kaynak_Maliyeti_Saved_Row x)
        {
            var a = _IKaynakMaliyetiSavedService.Kaynak_Maliyeti_Saved_Row_Edit(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Maliyeti_Saved_Row_Get_All")]
        public IActionResult Kaynak_Maliyeti_Saved_Row_Get_All()
        {
            var a = _IKaynakMaliyetiSavedService.Kaynak_Maliyeti_Saved_Row_Get_All();
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Maliyeti_Saved_Row_Get_By_Id")]
        public IActionResult Kaynak_Maliyeti_Saved_Row_Get_By_Id(Kaynak_Maliyeti_Saved_Row x)
        {
            var a = _IKaynakMaliyetiSavedService.Kaynak_Maliyeti_Saved_Row_Get_By_Id(x);
            return Ok(a);
        }










    }
}