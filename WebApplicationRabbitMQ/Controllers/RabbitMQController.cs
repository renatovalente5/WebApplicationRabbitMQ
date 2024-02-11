using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebApplicationRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
        public RabbitMQController()
        {
        }

        [HttpGet, Authorize]
        public IActionResult Get()
        {
            Log.Information("Ola!");
            return Ok("Ola!");
        }
    }
}
