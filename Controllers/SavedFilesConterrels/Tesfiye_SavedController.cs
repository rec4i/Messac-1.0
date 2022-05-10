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
    public class TesviyeSavedController : ControllerBase
    {
        private ITesviyeSavedService _ITesviyeSavedService;
        public TesviyeSavedController(ITesviyeSavedService uyeIslemleriServices)
        {
            _ITesviyeSavedService = uyeIslemleriServices;
        }
        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Maliyeti_Saved_Add")]
        public IActionResult Tesviye_Maliyeti_Saved_Add(Tesviye_Maliyeti_Saved x)
        {
            var a = _ITesviyeSavedService.Tesviye_Maliyeti_Saved_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Maliyeti_Saved_Delete")]
        public IActionResult Tesviye_Maliyeti_Saved_Delete(Tesviye_Maliyeti_Saved x)
        {
            var a = _ITesviyeSavedService.Tesviye_Maliyeti_Saved_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Maliyeti_Saved_Edit")]
        public IActionResult Tesviye_Maliyeti_Saved_Edit(Tesviye_Maliyeti_Saved x)
        {
            var a = _ITesviyeSavedService.Tesviye_Maliyeti_Saved_Edit(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Maliyeti_Saved_Get_All")]
        public IActionResult Tesviye_Maliyeti_Saved_Get_All()
        {
            var a = _ITesviyeSavedService.Tesviye_Maliyeti_Saved_Get_All();
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Maliyeti_Saved_Get_By_Id")]
        public IActionResult Tesviye_Maliyeti_Saved_Get_By_Id(Tesviye_Maliyeti_Saved x)
        {
            var a = _ITesviyeSavedService.Tesviye_Maliyeti_Saved_Get_By_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Maliyeti_Saved_Get_By_Parça_Id")]
        public IActionResult Tesviye_Maliyeti_Saved_Get_By_Parça_Id(Revize x)
        {
            var a = _ITesviyeSavedService.Tesviye_Maliyeti_Saved_Get_By_Parça_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Maliyeti_Saved_Delete_By_Revize_Id")]
        public IActionResult Tesviye_Maliyeti_Saved_Delete_By_Revize_Id(Revize x)
        {
             _ITesviyeSavedService.Tesviye_Maliyeti_Saved_Delete_By_Revize_Id(x);
            return Ok();
        }

        //Tesviye_Maliyeti_Saved_Delete_By_Revize_Id


        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Maliyeti_Saved_Row_Add")]
        public IActionResult Tesviye_Maliyeti_Saved_Row_Add(Tesviye_Maliyeti_Saved_Row x)
        {
            var a = _ITesviyeSavedService.Tesviye_Maliyeti_Saved_Row_Add(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Tesviye_Maliyeti_Saved_Row_Delete")]
        public IActionResult Tesviye_Maliyeti_Saved_Row_Delete(Tesviye_Maliyeti_Saved_Row x)
        {
            var a = _ITesviyeSavedService.Tesviye_Maliyeti_Saved_Row_Delete(x);
            return Ok(a);
        }


    }
}