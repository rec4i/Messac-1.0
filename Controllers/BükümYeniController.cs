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
using KaynakKod.Services;

namespace KaynakKod.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class BükümYeniController : ControllerBase
    {
        private IBükümYeniService _IBükümYeniService;
        public BükümYeniController(IBükümYeniService bükümYeniService)
        {
            _IBükümYeniService = bükümYeniService;
        }


        [Authorize(Role.Admin)]
        [HttpPost("Büküm_KiloHesabı_Add")]
        public IActionResult Büküm_KiloHesabı_Add(Büküm_KiloHesabı x)
        {
            var a = _IBükümYeniService.Büküm_KiloHesabı_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Büküm_KiloHesabı_Delete")]
        public IActionResult Büküm_KiloHesabı_Delete(Büküm_KiloHesabı x)
        {
            var a = _IBükümYeniService.Büküm_KiloHesabı_Delete(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Büküm_KiloHesabı_Edit")]
        public IActionResult Büküm_KiloHesabı_Edit(Büküm_KiloHesabı x)
        {
            var a = _IBükümYeniService.Büküm_KiloHesabı_Edit(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Büküm_KiloHesabı_Get_All")]
        public IActionResult Büküm_KiloHesabı_Get_All()
        {
            var a = _IBükümYeniService.Büküm_KiloHesabı_Get_All();
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Büküm_KiloHesabı_Get_By_Id")]
        public IActionResult Büküm_KiloHesabı_Get_By_Id(Büküm_KiloHesabı x)
        {
            var a = _IBükümYeniService.Büküm_KiloHesabı_Get_By_Id(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Büküm_AdetHesabı_Add")]
        public IActionResult Büküm_AdetHesabı_Add(Büküm_AdetHesabı x)
        {
            var a = _IBükümYeniService.Büküm_AdetHesabı_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_AdetHesabı_Delete")]
        public IActionResult Büküm_AdetHesabı_Delete(Büküm_AdetHesabı x)
        {
            var a = _IBükümYeniService.Büküm_AdetHesabı_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Büküm_AdetHesabı_Edit")]
        public IActionResult Büküm_AdetHesabı_Edit(Büküm_AdetHesabı x)
        {
            var a = _IBükümYeniService.Büküm_AdetHesabı_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_AdetHesabı_Get_All")]
        public IActionResult Büküm_AdetHesabı_Get_All()
        {
            var a = _IBükümYeniService.Büküm_AdetHesabı_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_AdetHesabı_Get_By_Id")]
        public IActionResult Büküm_AdetHesabı_Get_By_Id(Büküm_AdetHesabı x)
        {
            var a = _IBükümYeniService.Büküm_AdetHesabı_Get_By_Id(x);
            return Ok(a);
        }





        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Uzunluk_Hesabı_Add")]
        public IActionResult Büküm_Uzunluk_Hesabı_Add(Büküm_Uzunluk_Hesabı x)
        {
            var a = _IBükümYeniService.Büküm_Uzunluk_Hesabı_Add(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Uzunluk_Hesabı_Delete")]
        public IActionResult Büküm_Uzunluk_Hesabı_Delete(Büküm_Uzunluk_Hesabı x)
        {
            var a = _IBükümYeniService.Büküm_Uzunluk_Hesabı_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Uzunluk_Hesabı_Edit")]
        public IActionResult Büküm_Uzunluk_Hesabı_Edit(Büküm_Uzunluk_Hesabı x)
        {
            var a = _IBükümYeniService.Büküm_Uzunluk_Hesabı_Edit(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Uzunluk_Hesabı_Get_All")]
        public IActionResult Büküm_Uzunluk_Hesabı_Get_All()
        {
            var a = _IBükümYeniService.Büküm_Uzunluk_Hesabı_Get_All();
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Uzunluk_Hesabı_Get_By_Id")]
        public IActionResult Büküm_Uzunluk_Hesabı_Get_By_Id(Büküm_Uzunluk_Hesabı x)
        {
            var a = _IBükümYeniService.Büküm_Uzunluk_Hesabı_Get_By_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Uzunluk_Hesabı_Zorluk_Add")]
        public IActionResult Büküm_Uzunluk_Hesabı_Zorluk_Add(Büküm_Uzunluk_Hesabı_Zorluk x)
        {
            var a = _IBükümYeniService.Büküm_Uzunluk_Hesabı_Zorluk_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Uzunluk_Hesabı_Zorluk_Delete")]
        public IActionResult Büküm_Uzunluk_Hesabı_Zorluk_Delete(Büküm_Uzunluk_Hesabı_Zorluk x)
        {
            var a = _IBükümYeniService.Büküm_Uzunluk_Hesabı_Zorluk_Delete(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Uzunluk_Hesabı_Zorluk_Edit")]
        public IActionResult Büküm_Uzunluk_Hesabı_Zorluk_Edit(Büküm_Uzunluk_Hesabı_Zorluk x)
        {
            var a = _IBükümYeniService.Büküm_Uzunluk_Hesabı_Zorluk_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Uzunluk_Hesabı_Zorluk_Get_All")]
        public IActionResult Büküm_Uzunluk_Hesabı_Zorluk_Get_All()
        {
            var a = _IBükümYeniService.Büküm_Uzunluk_Hesabı_Zorluk_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Uzunluk_Hesabı_Zorluk_Get_By_Id")]
        public IActionResult Büküm_Uzunluk_Hesabı_Zorluk_Get_By_Id(Büküm_Uzunluk_Hesabı_Zorluk x)
        {
            var a = _IBükümYeniService.Büküm_Uzunluk_Hesabı_Zorluk_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Uzunluk_Hesabı_Zorluk_Get_Genel_Id")]
        public IActionResult Büküm_Uzunluk_Hesabı_Zorluk_Get_Genel_Id(Büküm_Uzunluk_Hesabı x)
        {
            var a = _IBükümYeniService.Büküm_Uzunluk_Hesabı_Zorluk_Get_Genel_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Uygun_Büküm_Kilo_Getir")]
        public IActionResult Uygun_Büküm_Kilo_Getir(Büküm_KiloHesabı x)
        {
            var a = _IBükümYeniService.Uygun_Büküm_Kilo_Getir(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Malzeme_Uzunuğuna_Göre_Katsayı_Getir")]
        public IActionResult Malzeme_Uzunuğuna_Göre_Katsayı_Getir(Büküm_Uzunluk_Hesabı x)
        {
            var a = _IBükümYeniService.Malzeme_Uzunuğuna_Göre_Katsayı_Getir(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Büküm_Uzunluk_Hesabı_Zorluk_Get_By_Uzunluk_Hesabı_Id")]
        public IActionResult Büküm_Uzunluk_Hesabı_Zorluk_Get_By_Uzunluk_Hesabı_Id(Büküm_Uzunluk_Hesabı x)
        {
            var a = _IBükümYeniService.Büküm_Uzunluk_Hesabı_Zorluk_Get_By_Uzunluk_Hesabı_Id(x);
            return Ok(a);
        }












    }
}