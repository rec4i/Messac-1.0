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
    public class TesviyeController : ControllerBase
    {
        private ITesviyeService _ITesviyeService;
        public TesviyeController(ITesviyeService uyeIslemleriServices)
        {
            _ITesviyeService = uyeIslemleriServices;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Add")]
        public IActionResult Tesviye_Add(Tesviye x)
        {
            var a = _ITesviyeService.Tesviye_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Delete")]
        public IActionResult Tesviye_Delete(Tesviye x)
        {
            var a = _ITesviyeService.Tesviye_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Edit")]
        public IActionResult Tesviye_Edit(Tesviye x)
        {
            var a = _ITesviyeService.Tesviye_Edit(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Get_All")]
        public IActionResult Tesviye_Get_All()
        {
            var a = _ITesviyeService.Tesviye_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Get_By_Id")]
        public IActionResult Tesviye_Get_By_Id(Tesviye x)
        {
            var a = _ITesviyeService.Tesviye_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Get_By_Text")]
        public IActionResult Tesviye_Get_By_Text(Tesviye x)
        {
            var a = _ITesviyeService.Tesviye_Get_By_Text(x);
            return Ok(a);
        }


    }
}