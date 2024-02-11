using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationRabbitMQ.Services.Interfaces;

namespace WebApplicationRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost, Authorize]
        [Route("Get")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userId = HttpContext.User.Identities.ToList()[0].Claims.ToList()[0].Value;
                var result = await _usersService.GetById(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }
    }
}
