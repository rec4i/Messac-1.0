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

namespace qrmenu.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PaketlemeController : ControllerBase
    {
        private IPaketlemeService _IPaketlemeService;
        public PaketlemeController(IPaketlemeService uyeIslemleriServices)
        {
            _IPaketlemeService = uyeIslemleriServices;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Paketleme_Add")]
        public IActionResult Paketleme_Add(Paketleme x)
        {
            var a = _IPaketlemeService.Paketleme_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Paketleme_Delete")]
        public IActionResult Paketleme_Delete(Paketleme x)
        {
            var a = _IPaketlemeService.Paketleme_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Paketleme_Edit")]
        public IActionResult Paketleme_Edit(Paketleme x)
        {
            var a = _IPaketlemeService.Paketleme_Edit(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Paketleme_Get_All")]
        public IActionResult Paketleme_Get_All()
        {
            var a = _IPaketlemeService.Paketleme_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Paketleme_Get_By_Id")]
        public IActionResult Paketleme_Get_By_Id(Paketleme x)
        {
            var a = _IPaketlemeService.Paketleme_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Paketleme_Get_By_Text")]
        public IActionResult Paketleme_Get_By_Text(Paketleme x)
        {
            var a = _IPaketlemeService.Paketleme_Get_By_Text(x);
            return Ok(a);
        }


    }
}