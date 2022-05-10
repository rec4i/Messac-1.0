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
    public class Bağlantı_Elemanı_SavedController : ControllerBase
    {
        private IBağlantıElemanıSavedService _IBağlantıElemanıSavedService;
        public Bağlantı_Elemanı_SavedController(IBağlantıElemanıSavedService uyeIslemleriServices)
        {
            _IBağlantıElemanıSavedService = uyeIslemleriServices;
        }


        [Authorize(Role.Admin)]
        [HttpPost("BaglantıElemanları_Add")]
        public IActionResult BaglantıElemanları_Add(Bağlantı_Elemanı_Saved x)
        {
            var a = _IBağlantıElemanıSavedService.BağlantıElemanıSaved_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("BağlantıElemanıSaved_Edit")]
        public IActionResult BağlantıElemanıSaved_Edit(Bağlantı_Elemanı_Saved x)
        {
            var a = _IBağlantıElemanıSavedService.BağlantıElemanıSaved_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("BağlantıElemanıSaved_Delete")]
        public IActionResult BağlantıElemanıSaved_Delete(Bağlantı_Elemanı_Saved x)
        {
            var a = _IBağlantıElemanıSavedService.BağlantıElemanıSaved_Delete(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("BağlantıElemanıSaved_Get_All")]
        public IActionResult BağlantıElemanıSaved_Get_All()
        {
            var a = _IBağlantıElemanıSavedService.BağlantıElemanıSaved_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("BağlantıElemanıSaved_Get_By_Id")]
        public IActionResult BağlantıElemanıSaved_Get_By_Id(Bağlantı_Elemanı_Saved x)
        {
            var a = _IBağlantıElemanıSavedService.BağlantıElemanıSaved_Get_By_Id(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("BağlantıElemanıSaved_Get_By_Parça_Id")]
        public IActionResult BağlantıElemanıSaved_Get_By_Parça_Id(Revize x)
        {
            var a = _IBağlantıElemanıSavedService.BağlantıElemanıSaved_Get_By_Parça_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("BağlantıElemanıSaved_Delete_By_Revize_Id")]
        public IActionResult BağlantıElemanıSaved_Delete_By_Revize_Id(Revize x)
        {
            _IBağlantıElemanıSavedService.BağlantıElemanıSaved_Delete_By_Revize_Id(x);
            return Ok();
        }







        //BağlantıElemanıSaved_Delete_By_Revize_Id

















        [Authorize(Role.Admin)]
        [HttpPost("BağlantıElemanıSaved_Row_Add")]
        public IActionResult BağlantıElemanıSaved_Row_Add(Bağlantı_Elemanı_Saved_row x)
        {
            var a = _IBağlantıElemanıSavedService.BağlantıElemanıSaved_Row_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("BağlantıElemanıSaved_Row_Edit")]
        public IActionResult BağlantıElemanıSaved_Row_Edit(Bağlantı_Elemanı_Saved_row x)
        {
            var a = _IBağlantıElemanıSavedService.BağlantıElemanıSaved_Row_Edit(x);
            return Ok(a);
        }




        [Authorize(Role.Admin)]
        [HttpPost("BağlantıElemanıSaved_Row_Delete")]
        public IActionResult BağlantıElemanıSaved_Row_Delete(Bağlantı_Elemanı_Saved_row x)
        {
            var a = _IBağlantıElemanıSavedService.BağlantıElemanıSaved_Row_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("BağlantıElemanıSaved_Row_Get_All")]
        public IActionResult BağlantıElemanıSaved_Row_Get_All()
        {
            var a = _IBağlantıElemanıSavedService.BağlantıElemanıSaved_Row_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("BağlantıElemanıSaved_Row_Get_By_Id")]
        public IActionResult BağlantıElemanıSaved_Row_Get_By_Id(Bağlantı_Elemanı_Saved_row x)
        {
            var a = _IBağlantıElemanıSavedService.BağlantıElemanıSaved_Row_Get_By_Id(x);
            return Ok(a);
        }

        //BağlantıElemanıSaved_Row_Get_By_Id





    }
}