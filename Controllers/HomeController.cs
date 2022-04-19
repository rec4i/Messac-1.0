using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.Services;

namespace dotnet_5_jwt_refresh_tokens_api_master.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {

       

    }
}