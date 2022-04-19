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

namespace WebApi.Controllers
{
  
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class Talep_Olustur_Api : ControllerBase
    {
        private Talep_Servis _Talep_Servis;

        [HttpPost("Teklif_Şarları_Ekle")]
        public IActionResult Teklif_Şarları_Ekle()
        {

            _Talep_Servis.Teklif_Şarları_Ekle();
                       

            // var testUser = new User
            // {
            //     FirstName = "Test3",
            //     LastName = "User",
            //     Username = "test3",
            //     PasswordHash = BCryptNet.HashPassword("test3")
            // };
            // _context.Users.Add(testUser);
            // _context.SaveChanges();


            return Ok();
        }

    }
}