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
using KaynakKod.Models.pagenation_request;

namespace KaynakKod.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class UretimMaliyetiController : ControllerBase
    {
        private IUretimMaliyetiService _IUretimMaliyetiService;
        public UretimMaliyetiController(IUretimMaliyetiService uretimMaliyetiService)
        {
            _IUretimMaliyetiService = uretimMaliyetiService;
        }

        [Authorize(Role.Admin)]
        [HttpPost("UretimMaliyeti_Pagenation_List")]
        public IActionResult UretimMaliyeti_Pagenation_List(pagenation_request x)
        {
            var a = _IUretimMaliyetiService.UretimMaliyeti_Pagenation_List(x);
            return Ok(a);
        }


    }
}