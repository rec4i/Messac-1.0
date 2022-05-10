using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Authorization;
using WebApi.Helpers;
using WebApi.Services;
using BCryptNet = BCrypt.Net.BCrypt;
using WebApi.Models.Şehir_Request;
using qrmenu.Models.Uyeİşlemleri;
using qrmenu.Entities;
using qrmenu.Services;
using KaynakKod.Entities;
using WebApi.Entities;

namespace qrmenu.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BoyaSavedController : ControllerBase
    {
        private IBoyaSavedService _IBoyaSavedService;
        public BoyaSavedController(IBoyaSavedService uyeIslemleriServices)
        {
            _IBoyaSavedService = uyeIslemleriServices;
        }
        [Authorize(Role.Admin)]
        [HttpPost("Boya_Maliyeti_Saved_Add")]
        public IActionResult Boya_Maliyeti_Saved_Add(Boya_Maliyeti_Saved x)
        {
            var a = _IBoyaSavedService.Boya_Maliyeti_Saved_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Boya_Maliyeti_Saved_Delete")]
        public IActionResult Boya_Maliyeti_Saved_Delete(Boya_Maliyeti_Saved x)
        {
            var a = _IBoyaSavedService.Boya_Maliyeti_Saved_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Boya_Maliyeti_Saved_Edit")]
        public IActionResult Boya_Maliyeti_Saved_Edit(Boya_Maliyeti_Saved x)
        {
            var a = _IBoyaSavedService.Boya_Maliyeti_Saved_Edit(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Boya_Maliyeti_Saved_Get_All")]
        public IActionResult Boya_Maliyeti_Saved_Get_All()
        {
            var a = _IBoyaSavedService.Boya_Maliyeti_Saved_Get_All();
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Boya_Maliyeti_Saved_Get_By_Id")]
        public IActionResult Boya_Maliyeti_Saved_Get_By_Id(Boya_Maliyeti_Saved x)
        {
            var a = _IBoyaSavedService.Boya_Maliyeti_Saved_Get_By_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Boya_Maliyeti_Saved_Get_By_Parça_Id")]
        public IActionResult Boya_Maliyeti_Saved_Get_By_Parça_Id(Revize x)
        {
            var a = _IBoyaSavedService.Boya_Maliyeti_Saved_Get_By_Parça_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Boya_Maliyeti_Saved_Delete_By_Revize_Id")]
        public IActionResult Boya_Maliyeti_Saved_Delete_By_Revize_Id(Revize x)
        {
            _IBoyaSavedService.Boya_Maliyeti_Saved_Delete_By_Revize_Id(x);
            return Ok();
        }




        [Authorize(Role.Admin)]
        [HttpPost("Boya_Maliyeti_Saved_Row_Add")]
        public IActionResult Boya_Maliyeti_Saved_Row_Add(Boya_Maliyeti_Saved_Row x)
        {
            var a = _IBoyaSavedService.Boya_Maliyeti_Saved_Row_Add(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Boya_Maliyeti_Saved_Row_Delete")]
        public IActionResult Boya_Maliyeti_Saved_Row_Delete(Boya_Maliyeti_Saved_Row x)
        {
            var a = _IBoyaSavedService.Boya_Maliyeti_Saved_Row_Delete(x);
            return Ok(a);
        }


    }
}