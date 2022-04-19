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
    public class TesfiyeController : ControllerBase
    {
        private ITesfiyeService _ITesfiyeService;
        public TesfiyeController(ITesfiyeService uyeIslemleriServices)
        {
            _ITesfiyeService = uyeIslemleriServices;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Add")]
        public IActionResult Tesfiye_Add(Tesfiye x)
        {
            var a = _ITesfiyeService.Tesfiye_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Delete")]
        public IActionResult Tesfiye_Delete(Tesfiye x)
        {
            var a = _ITesfiyeService.Tesfiye_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Edit")]
        public IActionResult Tesfiye_Edit(Tesfiye x)
        {
            var a = _ITesfiyeService.Tesfiye_Edit(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Get_All")]
        public IActionResult Tesfiye_Get_All()
        {
            var a = _ITesfiyeService.Tesfiye_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Get_By_Id")]
        public IActionResult Tesfiye_Get_By_Id(Tesfiye x)
        {
            var a = _ITesfiyeService.Tesfiye_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Get_By_Text")]
        public IActionResult Tesfiye_Get_By_Text(Tesfiye x)
        {
            var a = _ITesfiyeService.Tesfiye_Get_By_Text(x);
            return Ok(a);
        }


    }
}