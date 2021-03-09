using Microsoft.AspNetCore.Mvc;

namespace FuegoDeQuasar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok($" Fuego de Quasar API is running...");
        }
    }
}
