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
    public class RevizeController : ControllerBase
    {
        private IRevizeService _IRevizeService;
        public RevizeController(IRevizeService revizeService)
        {
            _IRevizeService = revizeService;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Revize_Add")]
        public IActionResult Revize_Add(Revize x)
        {
            var a = _IRevizeService.Revize_Add(x);
            return Ok(a);
        }
        [Authorize(Role.Admin)]
        [HttpPost("Revize_Delete")]
        public IActionResult Revize_Delete(Revize x)
        {
            var a = _IRevizeService.Revize_Delete(x);
            return Ok(a);
        }


        // [Authorize(Role.Admin)]
        // [HttpPost("Revize_Get_All")]
        // public IActionResult Revize_Get_All(Revize x)
        // {
        //     var a = _IRevizeService.Revize_Get_All(x);
        //     return Ok(a);
        // }

        [Authorize(Role.Admin)]
        [HttpPost("Revize_Get_By_Parça_Id")]
        public IActionResult Revize_Get_By_Parça_Id(Parça x)
        {
            var a = _IRevizeService.Revize_Get_By_Parça_Id(x);
            return Ok(a);
        }


        // [Authorize(Role.Admin)]
        // [HttpPost("Revize_Get_By_Id")]
        // public IActionResult Revize_Get_By_Id(Revize x)
        // {
        //     var a = _IRevizeService.Revize_Get_By_Id(x);
        //     return Ok(a);
        // }


    }
}