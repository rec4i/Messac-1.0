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
    public class Malzeme_Maliyeti_SavedController : ControllerBase
    {
        private IMalzemeMaliyetiSavedService _IMalzemeMaliyetiSavedService;
        public Malzeme_Maliyeti_SavedController(IMalzemeMaliyetiSavedService uyeIslemleriServices)
        {
            _IMalzemeMaliyetiSavedService = uyeIslemleriServices;
        }


        [Authorize(Role.Admin)]
        [HttpPost("Malzeme_Maliyeti_Saved_Add")]
        public IActionResult Malzeme_Maliyeti_Saved_Add(Malzeme_Maliyeti_Saved x)
        {
            var a = _IMalzemeMaliyetiSavedService.Malzeme_Maliyeti_Saved_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Malzeme_Maliyeti_Saved_Delete")]
        public IActionResult Malzeme_Maliyeti_Saved_Delete(Malzeme_Maliyeti_Saved x)
        {
            var a = _IMalzemeMaliyetiSavedService.Malzeme_Maliyeti_Saved_Delete(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Malzeme_Maliyeti_Saved_Edit")]
        public IActionResult Malzeme_Maliyeti_Saved_Edit(Malzeme_Maliyeti_Saved x)
        {
            var a = _IMalzemeMaliyetiSavedService.Malzeme_Maliyeti_Saved_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Malzeme_Maliyeti_Saved_Get_All")]
        public IActionResult Malzeme_Maliyeti_Saved_Get_All()
        {
            var a = _IMalzemeMaliyetiSavedService.Malzeme_Maliyeti_Saved_Get_All();
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Malzeme_Maliyeti_Saved_Get_By_Id")]
        public IActionResult Malzeme_Maliyeti_Saved_Get_By_Id(Malzeme_Maliyeti_Saved x)
        {
            var a = _IMalzemeMaliyetiSavedService.Malzeme_Maliyeti_Saved_Get_By_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Malzeme_Maliyeti_Saved_Get_By_Parça_Id")]
        public IActionResult Malzeme_Maliyeti_Saved_Get_By_Parça_Id(Revize x)
        {
            var a = _IMalzemeMaliyetiSavedService.Malzeme_Maliyeti_Saved_Get_By_Parça_Id(x);
            return Ok(a);
        }


    }
}