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

namespace KaynakKod.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class KesimController : ControllerBase
    {
        private IKesimService _IKesimService;
        public KesimController(IKesimService uyeIslemleriServices)
        {
            _IKesimService = uyeIslemleriServices;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Türü_Add")]
        public IActionResult Kesim_Türü_Add(Kesim_Türü x)
        {
            var a = _IKesimService.Kesim_Türü_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Türü_Delete")]
        public IActionResult Kesim_Türü_Delete(Kesim_Türü x)
        {
            var a = _IKesimService.Kesim_Türü_Delete(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Türü_Edit")]
        public IActionResult Kesim_Türü_Edit(Kesim_Türü x)
        {
            var a = _IKesimService.Kesim_Türü_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Türü_Get_By_Id")]
        public IActionResult Kesim_Türü_Get_By_Id(Kesim_Türü x)
        {
            var a = _IKesimService.Kesim_Türü_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Türü_Get_All")]
        public IActionResult Kesim_Türü_Get_All()
        {
            var a = _IKesimService.Kesim_Türü_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Add")]
        public IActionResult Kesim_Add(Kesim x)
        {
            var a = _IKesimService.Kesim_Add(x);
            return Ok(a);
        }
        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Delete")]
        public IActionResult Kesim_Delete(Kesim x)
        {
            var a = _IKesimService.Kesim_Delete(x);
            return Ok(a);
        }
        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Edit")]
        public IActionResult Kesim_Edit(Kesim x)
        {
            var a = _IKesimService.Kesim_Edit(x);
            return Ok(a);
        }
        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Get_By_Id")]
        public IActionResult Kesim_Get_By_Id(Kesim x)
        {
            var a = _IKesimService.Kesim_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Get_All")]
        public IActionResult Kesim_Get_All()
        {
            var a = _IKesimService.Kesim_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Get_By_Kesim_Türü_Id")]
        public IActionResult Kesim_Get_By_Kesim_Türü_Id(Kesim_Türü x)
        {
            var a = _IKesimService.Kesim_Get_By_Kesim_Türü_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Türünden_Hepsini_Sil")]
        public IActionResult Kesim_Türünden_Hepsini_Sil(Kesim_Türü x)
        {
            _IKesimService.Kesim_Türünden_Hepsini_Sil(x);
            return Ok();
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kesim_Uygun_Olanı_Getir")]
        public IActionResult Kesim_Uygun_Olanı_Getir(Kesim x)
        {
           var a =  _IKesimService.Kesim_Uygun_Olanı_Getir(x);
            return Ok(a);
        }


        //
    }
}