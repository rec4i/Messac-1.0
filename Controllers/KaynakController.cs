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
using KaynakKod.Entities.UretimMaliyeti.İşlemler;
using KaynakKod.Services;

namespace KaynakKod.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class KaynakController : ControllerBase
    {
        private IKaynakService _IKaynakService;
        public KaynakController(IKaynakService kaynakService)
        {
            _IKaynakService = kaynakService;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Add")]
        public IActionResult Kaynak_Add(Kaynak x)
        {
            var a = _IKaynakService.Kaynak_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Delete")]
        public IActionResult Kaynak_Delete(Kaynak x)
        {
            var a = _IKaynakService.Kaynak_Delete(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Edit")]
        public IActionResult Kaynak_Edit(Kaynak x)
        {
            var a = _IKaynakService.Kaynak_Edit(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Get_All")]
        public IActionResult Kaynak_Get_All()
        {
            var a = _IKaynakService.Kaynak_Get_All();
            return Ok(a);
        }
        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Get_By_Id")]
        public IActionResult Kaynak_Get_By_Id(Kaynak x)
        {
            var a = _IKaynakService.Kaynak_Get_By_Id(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("birimler_Add")]
        public IActionResult birimler_Add(Birimler x)
        {
            var a = _IKaynakService.birimler_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("birimler_Delete")]
        public IActionResult birimler_Delete(Birimler x)
        {
            var a = _IKaynakService.birimler_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("birimler_Edit")]
        public IActionResult birimler_Edit(Birimler x)
        {
            var a = _IKaynakService.birimler_Edit(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("birimler_Get_All")]
        public IActionResult birimler_Get_All()
        {
            var a = _IKaynakService.birimler_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("birimler_Get_By_Id")]
        public IActionResult birimler_Get_By_Id(Birimler x)
        {
            var a = _IKaynakService.birimler_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kaynak_Get_By_Text")]
        public IActionResult Kaynak_Get_By_Text(Kaynak x)
        {
            var a = _IKaynakService.Kaynak_Get_By_Text(x);
            return Ok(a);
        }


        //Kaynak_Get_By_Text





    }
}