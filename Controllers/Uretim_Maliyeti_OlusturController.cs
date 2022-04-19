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

    public class Uretim_Maliyeti_OlusturController : ControllerBase
    {
        private IUretim_Maliyeti_OlusturService _IUretim_Maliyeti_OlusturService;
        public Uretim_Maliyeti_OlusturController(Uretim_Maliyeti_OlusturService uretim_Maliyeti_OlusturService)
        {
            _IUretim_Maliyeti_OlusturService = uretim_Maliyeti_OlusturService;
        }


    }
}