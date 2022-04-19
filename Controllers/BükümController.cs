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
using System.Net;
using System.IO;

namespace KaynakKod.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class BükümController : ControllerBase
    {

        private IBükümService _IBükümService;
        public BükümController(IBükümService bükümService)
        {
            _IBükümService = bükümService;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Döviz_Getir")]
        public IActionResult Döviz_Getir()
        {
            var url = "https://www.tcmb.gov.tr/kurlar/today.xml";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            return Ok(data);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Kalınlık_Add")]
        public IActionResult Kalınlık_Add(Kalınlık x)
        {
            var a = _IBükümService.Kalınlık_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kalınlık_Delete")]
        public IActionResult Kalınlık_Delete(Kalınlık x)
        {
            var a = _IBükümService.Kalınlık_Delete(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kalınlık_Edit")]
        public IActionResult Kalınlık_Edit(Kalınlık x)
        {
            var a = _IBükümService.Kalınlık_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kalınlık_Get_All")]
        public IActionResult Kalınlık_Get_All()
        {
            var a = _IBükümService.Kalınlık_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kalınlık_Get_By_Id")]
        public IActionResult Kalınlık_Get_By_Id(Kalınlık x)
        {
            var a = _IBükümService.Kalınlık_Get_By_Id(x);
            return Ok(a);
        }





        //aaaaaaaaaaaaaaaa



        [Authorize(Role.Admin)]
        [HttpPost("Uzunluk_Fiyat_Add")]
        public IActionResult Uzunluk_Fiyat_Add(Uzunluk_Fiyat x)
        {
            var a = _IBükümService.Uzunluk_Fiyat_Add(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Uzunluk_Fiyat_Delete")]
        public IActionResult Uzunluk_Fiyat_Delete(Uzunluk_Fiyat x)
        {
            var a = _IBükümService.Uzunluk_Fiyat_Delete(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Uzunluk_Fiyat_Edit")]
        public IActionResult Uzunluk_Fiyat_Edit(Uzunluk_Fiyat x)
        {
            var a = _IBükümService.Uzunluk_Fiyat_Edit(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Uzunluk_Fiyat_Get_All")]
        public IActionResult Uzunluk_Fiyat_Get_All()
        {
            var a = _IBükümService.Uzunluk_Fiyat_Get_All();
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Uzunluk_Fiyat_Get_By_Id")]
        public IActionResult Uzunluk_Fiyat_Get_By_Id(Uzunluk_Fiyat x)
        {
            var a = _IBükümService.Uzunluk_Fiyat_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Uzunluk_Fiyat_Get_Kalınlık_Id")]
        public IActionResult Uzunluk_Fiyat_Get_Kalınlık_Id(Uzunluk_Fiyat x)
        {
            var a = _IBükümService.Uzunluk_Fiyat_Get_Kalınlık_Id(x);
            return Ok(a);
        }


        //aaaaaaaaaaaaaaaaaaaaaaaaa



        [Authorize(Role.Admin)]
        [HttpPost("Adet_Başına_Fiyat_Add")]
        public IActionResult Adet_Başına_Fiyat_Add(Adet_Başına_Fiyat x)
        {
            var a = _IBükümService.Adet_Başına_Fiyat_Add(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Adet_Başına_Fiyat_Delete")]
        public IActionResult Adet_Başına_Fiyat_Delete(Adet_Başına_Fiyat x)
        {
            var a = _IBükümService.Adet_Başına_Fiyat_Delete(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Adet_Başına_Fiyat_Edit")]
        public IActionResult Adet_Başına_Fiyat_Edit(Adet_Başına_Fiyat x)
        {
            var a = _IBükümService.Adet_Başına_Fiyat_Edit(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Adet_Başına_Fiyat_Get_All")]
        public IActionResult Adet_Başına_Fiyat_Get_All()
        {
            var a = _IBükümService.Adet_Başına_Fiyat_Get_All();
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Adet_Başına_Fiyat_Get_By_Id")]
        public IActionResult Adet_Başına_Fiyat_Get_By_Id(Adet_Başına_Fiyat x)
        {
            var a = _IBükümService.Adet_Başına_Fiyat_Get_By_Id(x);
            return Ok(a);
        }



        //****************************



        [Authorize(Role.Admin)]
        [HttpPost("Kilo_Başına_Büküm_Add")]
        public IActionResult Kilo_Başına_Büküm_Add(Kilo_Başına_Büküm x)
        {
            var a = _IBükümService.Kilo_Başına_Büküm_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Kilo_Başına_Büküm_Delet")]
        public IActionResult Kilo_Başına_Büküm_Delet(Kilo_Başına_Büküm x)
        {
            var a = _IBükümService.Kilo_Başına_Büküm_Delet(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Kilo_Başına_Büküm_Edit")]
        public IActionResult Kilo_Başına_Büküm_Edit(Kilo_Başına_Büküm x)
        {
            var a = _IBükümService.Kilo_Başına_Büküm_Edit(x);
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Kilo_Başına_Büküm_Get_All")]
        public IActionResult Kilo_Başına_Büküm_Get_All()
        {
            var a = _IBükümService.Kilo_Başına_Büküm_Get_All();
            return Ok(a);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Kilo_Başına_Büküm_Get_By_Id")]
        public IActionResult Kilo_Başına_Büküm_Get_By_Id(Kilo_Başına_Büküm x)
        {
            var a = _IBükümService.Kilo_Başına_Büküm_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Kilo_Başına_Büküm_Get_By_Malzeme_Id")]
        public IActionResult Kilo_Başına_Büküm_Get_By_Malzeme_Id(Kilo_Başına_Büküm x)
        {
            var a = _IBükümService.Kilo_Başına_Büküm_Get_By_Malzeme_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Uygun_Adet_İle_Büküm_Getir")]
        public IActionResult Uygun_Adet_İle_Büküm_Getir(Uzunluk_Fiyat_Return_Value x)
        {
            var a = _IBükümService.Uygun_Adet_İle_Büküm_Getir(x);
            return Ok(a);
        }
        [Authorize(Role.Admin)]
        [HttpPost("Uygun_Kilo_İle_Büküm_Getir")]
        public IActionResult Uygun_Kilo_İle_Büküm_Getir(Kilo_Başına_Büküm_Return_Value x)
        {
            var a = _IBükümService.Uygun_Kilo_İle_Büküm_Getir(x);
            return Ok(a);
        }




        //Uygun_Kilo_İle_Büküm_Getir
        //Uygun_Adet_İle_Büküm_Getir

    }
}