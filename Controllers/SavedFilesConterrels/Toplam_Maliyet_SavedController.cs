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
    public class Toplam_Maliyet_SavedController : ControllerBase
    {
        private IToplam_Maliyet_SavedService _IToplam_Maliyet_SavedService;
        public Toplam_Maliyet_SavedController(IToplam_Maliyet_SavedService x)
        {
            _IToplam_Maliyet_SavedService = x;
        }


        [Authorize(Role.Admin)]
        [HttpPost("Toplam_Maliyet_Saved_Add")]
        public IActionResult Toplam_Maliyet_Saved_Add(Toplam_Maliyet_Saved x)
        {
            var a = _IToplam_Maliyet_SavedService.Toplam_Maliyet_Saved_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Toplam_Maliyet_Saved_Get_By_Revize_Id")]
        public IActionResult Toplam_Maliyet_Saved_Get_By_Revize_Id(Toplam_Maliyet_Saved x)
        {
            var a = _IToplam_Maliyet_SavedService.Toplam_Maliyet_Saved_Get_By_Revize_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Toplam_Maliyet_Saved_Get_By_Id")]
        public IActionResult Toplam_Maliyet_Saved_Get_By_Id(Toplam_Maliyet_Saved x)
        {
            var a = _IToplam_Maliyet_SavedService.Toplam_Maliyet_Saved_Get_By_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("İşçilik_Maliyeti_Selected_Add")]
        public IActionResult İşçilik_Maliyeti_Selected_Add(İşçilik_Maliyeti_Selected x)
        {
            var a = _IToplam_Maliyet_SavedService.İşçilik_Maliyeti_Selected_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("İşçilik_Maliyeti_Selected_Get_By_Id")]
        public IActionResult İşçilik_Maliyeti_Selected_Get_By_Id(İşçilik_Maliyeti_Selected x)
        {
            var a = _IToplam_Maliyet_SavedService.İşçilik_Maliyeti_Selected_Get_By_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("İşçilik_Maliyeti_Selected_Get_By_Toplam_Maliyet_Saved_Id")]
        public IActionResult İşçilik_Maliyeti_Selected_Get_By_Toplam_Maliyet_Saved_Id(İşçilik_Maliyeti_Selected x)
        {
            var a = _IToplam_Maliyet_SavedService.İşçilik_Maliyeti_Selected_Get_By_Toplam_Maliyet_Saved_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Malzeme_Maliyeti_Selected_Add")]
        public IActionResult Malzeme_Maliyeti_Selected_Add(Malzeme_Maliyeti_Selected x)
        {
            var a = _IToplam_Maliyet_SavedService.Malzeme_Maliyeti_Selected_Add(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Malzeme_Maliyeti_Selected_Get_By_Id")]
        public IActionResult Malzeme_Maliyeti_Selected_Get_By_Id(Malzeme_Maliyeti_Selected x)
        {
            var a = _IToplam_Maliyet_SavedService.Malzeme_Maliyeti_Selected_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Malzeme_Maliyeti_Selected_Get_By_Toplam_Maliyet_Saved_Id")]
        public IActionResult Malzeme_Maliyeti_Selected_Get_By_Toplam_Maliyet_Saved_Id(Malzeme_Maliyeti_Selected x)
        {
            var a = _IToplam_Maliyet_SavedService.Malzeme_Maliyeti_Selected_Get_By_Toplam_Maliyet_Saved_Id(x);
            return Ok(a);
        }





    }
}