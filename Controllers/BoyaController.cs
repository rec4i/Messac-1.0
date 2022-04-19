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
using System.Net;
using System.IO;
using KaynakKod.Entities.UretimMaliyeti.İşlemler;

namespace qrmenu.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BoyaController : ControllerBase
    {
        private IBoyaService _IBoyaService;
        public BoyaController(IBoyaService uyeIslemleriServices)
        {
            _IBoyaService = uyeIslemleriServices;
        }


        [Authorize(Role.Admin)]
        [HttpPost("Boya_Türü_Add")]
        public IActionResult Boya_Türü_Add(Boya_Türü x)
        {
            var a = _IBoyaService.Boya_Türü_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Boya_Türü_Delete")]
        public IActionResult Boya_Türü_Delete(Boya_Türü x)
        {
            var a = _IBoyaService.Boya_Türü_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Boya_Türü_Edit")]
        public IActionResult Boya_Türü_Edit(Boya_Türü x)
        {
            var a = _IBoyaService.Boya_Türü_Edit(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Boya_Türü_Get_All")]
        public IActionResult Boya_Türü_Get_All()
        {
            var a = _IBoyaService.Boya_Türü_Get_All();
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Boya_Türü_Gey_By_Id")]
        public IActionResult Boya_Türü_Gey_By_Id(Boya_Türü x)
        {
            var a = _IBoyaService.Boya_Türü_Gey_By_Id(x);
            return Ok(a);
        }






        [Authorize(Role.Admin)]
        [HttpPost("Boya_Add")]
        public IActionResult Boya_Add(Boya x)
        {
            var a = _IBoyaService.Boya_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Boya_Delete")]
        public IActionResult Boya_Delete(Boya x)
        {
            var a = _IBoyaService.Boya_Delete(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Boya_Edit")]
        public IActionResult Boya_Edit(Boya x)
        {
            var a = _IBoyaService.Boya_Edit(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Boya_Get_All")]
        public IActionResult Boya_Get_All()
        {
            var a = _IBoyaService.Boya_Get_All();
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Boya_Get_By_Text")]
        public IActionResult Boya_Get_By_Text(Boya x)
        {
            var a = _IBoyaService.Boya_Get_By_Text(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Boya_Get_By_Boya_Türü_Id")]
        public IActionResult Boya_Get_By_Boya_Türü_Id(Boya x)
        {
            var a = _IBoyaService.Boya_Get_By_Boya_Türü_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Boya_Get_By_Id")]
        public IActionResult Boya_Get_By_Id(Boya x)
        {
            var a = _IBoyaService.Boya_Get_By_Id(x);
            return Ok(a);
        }


    }
}