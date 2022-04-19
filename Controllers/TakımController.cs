using WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using KaynakKod.Services;
using qrmenu.Entities;
using KaynakKod.Entities;

namespace KaynakKod.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TakımController : ControllerBase
    {
        private ITakımService _ITakımService;
        public TakımController(ITakımService takımService)
        {
            _ITakımService = takımService;
        }
        [Authorize(Role.Admin)]
        [HttpPost("Takım_Add")]
        public IActionResult Takım_Add(Takım x)
        {
            var a = _ITakımService.Takım_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Takım_Delete")]
        public IActionResult Takım_Delete(Takım x)
        {
            var a = _ITakımService.Takım_Delete(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Takım_Edit")]
        public IActionResult Takım_Edit(Takım x)
        {
            var a = _ITakımService.Takım_Edit(x);
            return Ok(a);
        }




        [Authorize(Role.Admin)]
        [HttpPost("Takım_Get_All")]
        public IActionResult Takım_Get_All()
        {
            var a = _ITakımService.Takım_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Takım_Get_By_Id")]
        public IActionResult Takım_Get_By_Id(Takım x)
        {
            var a = _ITakımService.Takım_Get_By_Id(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Takım_Get_By_Text")]
        public IActionResult Takım_Get_By_Text(Takım x)
        {
            var a = _ITakımService.Takım_Get_By_Text(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Takım_Get_By_İş_Id")]
        public IActionResult Takım_Get_By_İş_Id(İş x)
        {
            var a = _ITakımService.Takım_Get_By_İş_Id(x);
            return Ok(a);
        }


    }
}