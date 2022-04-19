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
    public class Kesim_Maliyeti_SavedController : ControllerBase
    {
        private IKesimMaliyetiSavedService _IKesimMaliyetiSavedService;
        public Kesim_Maliyeti_SavedController(IKesimMaliyetiSavedService uyeIslemleriServices)
        {
            _IKesimMaliyetiSavedService = uyeIslemleriServices;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Maliyeti_Saved_Add")]
        public IActionResult Kesim_Maliyeti_Saved_Add(Kesim_Maliyeti_Saved x)
        {
            var a = _IKesimMaliyetiSavedService.Kesim_Maliyeti_Saved_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Maliyeti_Saved_Delete")]
        public IActionResult Kesim_Maliyeti_Saved_Delete(Kesim_Maliyeti_Saved x)
        {
            var a = _IKesimMaliyetiSavedService.Kesim_Maliyeti_Saved_Delete(x);
            return Ok(a);
        }

     




        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Maliyeti_Saved_Edit")]
        public IActionResult Kesim_Maliyeti_Saved_Edit(Kesim_Maliyeti_Saved x)
        {
            var a = _IKesimMaliyetiSavedService.Kesim_Maliyeti_Saved_Edit(x);
            return Ok(a);
        }




        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Maliyeti_Saved_Get_All")]
        public IActionResult Kesim_Maliyeti_Saved_Get_All()
        {
            var a = _IKesimMaliyetiSavedService.Kesim_Maliyeti_Saved_Get_All();
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Maliyeti_Saved_Get_By_Id")]
        public IActionResult Kesim_Maliyeti_Saved_Get_By_Id(Kesim_Maliyeti_Saved x)
        {
            var a = _IKesimMaliyetiSavedService.Kesim_Maliyeti_Saved_Get_By_Id(x);
            return Ok(a);
        }


        
        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Maliyeti_Saved_Get_By_Parça_Id")]
        public IActionResult Kesim_Maliyeti_Saved_Get_By_Parça_Id(Revize x)
        {
            var a = _IKesimMaliyetiSavedService.Kesim_Maliyeti_Saved_Get_By_Parça_Id(x);
            return Ok(a);
        }







    }
}