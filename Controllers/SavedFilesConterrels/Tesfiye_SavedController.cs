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
    public class TesfiyeSavedController : ControllerBase
    {
        private ITesfiyeSavedService _ITesfiyeSavedService;
        public TesfiyeSavedController(ITesfiyeSavedService uyeIslemleriServices)
        {
            _ITesfiyeSavedService = uyeIslemleriServices;
        }
        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Maliyeti_Saved_Add")]
        public IActionResult Tesfiye_Maliyeti_Saved_Add(Tesfiye_Maliyeti_Saved x)
        {
            var a = _ITesfiyeSavedService.Tesfiye_Maliyeti_Saved_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Maliyeti_Saved_Delete")]
        public IActionResult Tesfiye_Maliyeti_Saved_Delete(Tesfiye_Maliyeti_Saved x)
        {
            var a = _ITesfiyeSavedService.Tesfiye_Maliyeti_Saved_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Maliyeti_Saved_Edit")]
        public IActionResult Tesfiye_Maliyeti_Saved_Edit(Tesfiye_Maliyeti_Saved x)
        {
            var a = _ITesfiyeSavedService.Tesfiye_Maliyeti_Saved_Edit(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Maliyeti_Saved_Get_All")]
        public IActionResult Tesfiye_Maliyeti_Saved_Get_All()
        {
            var a = _ITesfiyeSavedService.Tesfiye_Maliyeti_Saved_Get_All();
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Maliyeti_Saved_Get_By_Id")]
        public IActionResult Tesfiye_Maliyeti_Saved_Get_By_Id(Tesfiye_Maliyeti_Saved x)
        {
            var a = _ITesfiyeSavedService.Tesfiye_Maliyeti_Saved_Get_By_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Maliyeti_Saved_Get_By_Parça_Id")]
        public IActionResult Tesfiye_Maliyeti_Saved_Get_By_Parça_Id(Revize x)
        {
            var a = _ITesfiyeSavedService.Tesfiye_Maliyeti_Saved_Get_By_Parça_Id(x);
            return Ok(a);
        }





        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Maliyeti_Saved_Row_Add")]
        public IActionResult Tesfiye_Maliyeti_Saved_Row_Add(Tesfiye_Maliyeti_Saved_Row x)
        {
            var a = _ITesfiyeSavedService.Tesfiye_Maliyeti_Saved_Row_Add(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Tesfiye_Maliyeti_Saved_Row_Delete")]
        public IActionResult Tesfiye_Maliyeti_Saved_Row_Delete(Tesfiye_Maliyeti_Saved_Row x)
        {
            var a = _ITesfiyeSavedService.Tesfiye_Maliyeti_Saved_Row_Delete(x);
            return Ok(a);
        }


    }
}