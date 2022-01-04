using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockChecker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "test";
        }
    }
}
