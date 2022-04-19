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
    public class ParçaController : ControllerBase
    {
        private IParçaService _IParçaService;
        public ParçaController(IParçaService parçaService)
        {
            _IParçaService = parçaService;
        }


        [Authorize(Role.Admin)]
        [HttpPost("Parça_Add")]
        public IActionResult Parça_Add(Parça x)
        {
            var a = _IParçaService.Parça_Add(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Parça_Delete")]
        public IActionResult Parça_Delete(Parça x)
        {
            var a = _IParçaService.Parça_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Parça_Edit")]
        public IActionResult Parça_Edit(Parça x)
        {
            var a = _IParçaService.Parça_Edit(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Parça_Get_All")]
        public IActionResult Parça_Get_All()
        {
            var a = _IParçaService.Parça_Get_All();
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Parça_By_Id")]
        public IActionResult Parça_By_Id(Parça x)
        {
            var a = _IParçaService.Parça_By_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Parça_Get_By_Takım_Id")]
        public IActionResult Parça_Get_By_Takım_Id(Takım x)
        {
            var a = _IParçaService.Parça_Get_By_Takım_Id(x);
            return Ok(a);
        }




    }
}