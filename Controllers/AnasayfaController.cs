using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize(Role.Admin, Role.il, Role.İlçe)]
    [Route("/Anasayfa")]
    public class AnasayfaController : Controller
    {

        public IActionResult Anasayfa()
        {
            return View();
        }
        [Route("/Talepolustur")]
        public IActionResult Talepolustur()
        {
            return View();
        }
        [Route("/UyeIslemleri")]
        public IActionResult UyeIslemleri()
        {
            return View();
        }
        [Route("/Ayarlar")]
        public IActionResult Ayarlar()
        {
            return View();
        }
        [Route("/Aidatİşlemleri")]
        public IActionResult Aidatİşlemleri()
        {
            return View();
        }
        [Route("/UretimMaliyeti")]
        public IActionResult UretimMaliyeti()
        {
            return View();
        }
        [Route("/Uretim_Maliyeti_Olustur")]
        public IActionResult Uretim_Maliyeti_Olustur()
        {
            return View();
        }


    }
}
