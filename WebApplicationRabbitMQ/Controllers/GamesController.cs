using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationRabbitMQ.Models;
using WebApplicationRabbitMQ.Services.Interfaces;

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
                var result = await _gamesService.GetAll();
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
        public async Task<IActionResult> Create(Game request)
        {
            try
            {
                var result = await _gamesService.Create(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

        [HttpPut, Authorize]
        [Route("Update")]
        public async Task<IActionResult> Update(Game request)
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
