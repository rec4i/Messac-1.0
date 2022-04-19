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
    public class KaplamaController : ControllerBase
    {
        private IKaplamaService _IKaplamaService;
        public KaplamaController(IKaplamaService kaplamaService)
        {
            _IKaplamaService = kaplamaService;
        }


        [Authorize(Role.Admin)]
        [HttpPost("kaplama_Add")]
        public IActionResult kaplama_Add(Kaplama x)
        {
            var a = _IKaplamaService.kaplama_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Kaplama_Delete")]
        public IActionResult Kaplama_Delete(Kaplama x)
        {
            var a = _IKaplamaService.Kaplama_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Kaplama_Edit")]
        public IActionResult Kaplama_Edit(Kaplama x)
        {
            var a = _IKaplamaService.Kaplama_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("kaplama_Get_All")]
        public IActionResult kaplama_Get_All()
        {
            var a = _IKaplamaService.kaplama_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("kaplama_Get_By_Id")]
        public IActionResult kaplama_Get_By_Id(Kaplama x)
        {
            var a = _IKaplamaService.kaplama_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("kaplama_Get_By_Text")]
        public IActionResult kaplama_Get_By_Text(Kaplama x)
        {
            var a = _IKaplamaService.kaplama_Get_By_Text(x);
            return Ok(a);
        }
        //kaplama_Get_By_Text



    }
}