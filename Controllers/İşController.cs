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
using KaynakKod.Models.pagenation_request;

namespace KaynakKod.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class İşController : ControllerBase
    {
        private IişService _IişService;
        public İşController(IişService işService)
        {
            _IişService = işService;
        }


        [Authorize(Role.Admin)]
        [HttpPost("iş_Add")]
        public IActionResult iş_Add(İş x)
        {
            var a = _IişService.iş_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("İş_Delete")]
        public IActionResult İş_Delete(İş x)
        {
            var a = _IişService.İş_Delete(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("İş_Edit")]
        public IActionResult İş_Edit(İş x)
        {
            var a = _IişService.İş_Edit(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("İş_Get_All")]
        public IActionResult İş_Get_All()
        {
            var a = _IişService.İş_Get_All();
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("İş_Get_By_Id")]
        public IActionResult İş_Get_By_Id(İş x)
        {
            var a = _IişService.İş_Get_By_Id(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("İş_Get_By_Text")]
        public IActionResult İş_Get_By_Text(İş x)
        {
            var a = _IişService.İş_Get_By_Text(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("İş_Get_The_List")]
        public IActionResult İş_Get_The_List(pagenation_request x)
        {
            var a = _IişService.İş_Get_The_List(x);
            return Ok(a);
        }




    }
}