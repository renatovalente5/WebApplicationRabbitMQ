using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationRabbitMQ.DTOs.Requests;
using WebApplicationRabbitMQ.Services.Implementation;

namespace WebApplicationRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet, Authorize]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var userId = HttpContext.User.Identities.ToList()[0].Claims.ToList()[0].Value;
                var result = await _gamesService.GetAll(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

        [HttpPost, Authorize]
        [Route("EnterInGame")]
        public async Task<IActionResult> EnterInGame(int gameId)
        {
            try
            {
                var userId = HttpContext.User.Identities.ToList()[0].Claims.ToList()[0].Value;
                var result = await _gamesService.EnterInGame(userId, gameId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

        [HttpGet, Authorize]
        [Route("GetBy")]
        public async Task<IActionResult> GetBy(int id)
        {
            try
            {
                var result = await _gamesService.GetBy(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

        [HttpPost, Authorize]
        [Route("Create")]
        public async Task<IActionResult> Create(GameRequest request)
        {
            try
            {
                var userId = HttpContext.User.Identities.ToList()[0].Claims.ToList()[0].Value;
                var result = await _gamesService.Create(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

        [HttpPut, Authorize]
        [Route("Update")]
        public async Task<IActionResult> Update(GameRequest request)
        {
            try
            {
                var result = await _gamesService.Update(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

        [HttpDelete, Authorize]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _gamesService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }
    }
}
