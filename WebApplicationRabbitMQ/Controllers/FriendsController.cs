using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebApplicationRabbitMQ.DTOs.Requests;
using WebApplicationRabbitMQ.Models;
using WebApplicationRabbitMQ.Services.Implementation;

namespace WebApplicationRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendsService _friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        [HttpGet, Authorize]
        //[SwaggerOData]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll(ODataQueryOptions<Friend> options)
        {
            try
            {
                var userId = HttpContext.User.Identities.ToList()[0].Claims.ToList()[0].Value;
                var result = await _friendsService.GetAll(userId, options);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

        [HttpPost, Authorize]
        [Route("SendInvite")]
        public async Task<IActionResult> SendInvite(FriendRequest request)
        {
            try
            {
                var userId = HttpContext.User.Identities.ToList()[0].Claims.ToList()[0].Value;
                var result = await _friendsService.SendInvite(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }


        [HttpPost, Authorize]
        [Route("CancelInvite")]
        public async Task<IActionResult> CancelInvite(FriendRequest request)
        {
            try
            {
                var userId = HttpContext.User.Identities.ToList()[0].Claims.ToList()[0].Value;
                var result = await _friendsService.CancelInvite(userId, request.UserName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

        [HttpPost, Authorize]
        [Route("AcceptInvite")]
        public async Task<IActionResult> AcceptInvite(FriendRequest request)
        {
            try
            {
                var userId = HttpContext.User.Identities.ToList()[0].Claims.ToList()[0].Value;
                var result = await _friendsService.AcceptInvite(userId, request.UserName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

        [HttpDelete, Authorize]
        [Route("Remove")]
        public async Task<IActionResult> Remove(FriendRequest request)
        {
            try
            {
                var userId = HttpContext.User.Identities.ToList()[0].Claims.ToList()[0].Value;
                var result = await _friendsService.Delete(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }
    }
}
