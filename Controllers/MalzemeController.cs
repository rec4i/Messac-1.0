using WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using KaynakKod.Services;
using qrmenu.Entities;

namespace KaynakKod.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MalzemeController : ControllerBase
    {
        private IMalzemeService _IMalzemeService;
        public MalzemeController(IMalzemeService malzemeService)
        {
            _IMalzemeService = malzemeService;
        }


        [Authorize(Role.Admin)]
        [HttpPost("malzeme_Add")]
        public IActionResult malzeme_Add(Malzeme x)
        {
            var a = _IMalzemeService.malzeme_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("malzeme_Delete")]
        public IActionResult malzeme_Delete(Malzeme x)
        {
            var a = _IMalzemeService.malzeme_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("malzeme_Edit")]
        public IActionResult malzeme_Edit(Malzeme x)
        {
            var a = _IMalzemeService.malzeme_Edit(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("malzeme_Genel_Adı_Add")]
        public IActionResult malzeme_Genel_Adı_Add(Malzeme_Genel_Adı x)
        {
            var a = _IMalzemeService.malzeme_Genel_Adı_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("malzeme_Genel_Adı_Delete")]
        public IActionResult malzeme_Genel_Adı_Delete(Malzeme_Genel_Adı x)
        {
            var a = _IMalzemeService.malzeme_Genel_Adı_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("malzeme_Genel_Adı_Edit")]
        public IActionResult malzeme_Genel_Adı_Edit(Malzeme_Genel_Adı x)
        {
            var a = _IMalzemeService.malzeme_Genel_Adı_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("malzeme_Genel_Adı_Get_All")]
        public IActionResult malzeme_Genel_Adı_Get_All()
        {
            var a = _IMalzemeService.malzeme_Genel_Adı_Get_All();
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("malzeme_Genel_Adı_Get_By_Id")]
        public IActionResult malzeme_Genel_Adı_Get_By_Id(Malzeme_Genel_Adı x)
        {
            var a = _IMalzemeService.malzeme_Genel_Adı_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Malzeme_Get_All")]
        public IActionResult Malzeme_Get_All()
        {
            var a = _IMalzemeService.Malzeme_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("malzeme_Get_By_Id")]
        public IActionResult malzeme_Get_By_Id(Malzeme x)
        {
            var a = _IMalzemeService.malzeme_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Malzeme_Get_By_Text")]
        public IActionResult Malzeme_Get_By_Text(Malzeme x)
        {
            var a = _IMalzemeService.Malzeme_Get_By_Text(x);
            return Ok(a);
        }

    }
}