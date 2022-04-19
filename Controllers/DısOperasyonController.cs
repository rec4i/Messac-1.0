using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using qrmenu.Entities;
using KaynakKod.Services;
using KaynakKod.Entities;

namespace KaynakKod.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class DısOperasyonController : ControllerBase
    {
        private IDıs_OperasyonService _IDıs_OperasyonService;
        public DısOperasyonController(IDıs_OperasyonService dıs_OperasyonService)
        {
            _IDıs_OperasyonService = dıs_OperasyonService;
        }

        [Authorize(Role.Admin)]
        [HttpPost("DısOperasyon_Add")]
        public IActionResult DısOperasyon_Add(DısOperasyon x)
        {
            var a = _IDıs_OperasyonService.DısOperasyon_Add(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("DısOperasyon_Delete")]
        public IActionResult DısOperasyon_Delete(DısOperasyon x)
        {
            var a = _IDıs_OperasyonService.DısOperasyon_Delete(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("DısOperasyon_Edit")]
        public IActionResult DısOperasyon_Edit(DısOperasyon x)
        {
            var a = _IDıs_OperasyonService.DısOperasyon_Edit(x);
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("DısOperasyon_Get_All")]
        public IActionResult DısOperasyon_Get_All()
        {
            var a = _IDıs_OperasyonService.DısOperasyon_Get_All();
            return Ok(a);
        }


        [Authorize(Role.Admin)]
        [HttpPost("DısOperasyon_Get_By_Id")]
        public IActionResult DısOperasyon_Get_By_Id(DısOperasyon x)
        {
            var a = _IDıs_OperasyonService.DısOperasyon_Get_By_Id(x);
            return Ok(a);
        }

        [Authorize(Role.Admin)]
        [HttpPost("DısOperasyon_Get_By_text")]
        public IActionResult DısOperasyon_Get_By_text(DısOperasyon x)
        {
            var a = _IDıs_OperasyonService.DısOperasyon_Get_By_text(x);
            return Ok(a);
        }

    }

}