using Microsoft.AspNetCore.OData.Query;
using WebApplicationRabbitMQ.DTOs.Requests;
using WebApplicationRabbitMQ.DTOs.Response;
using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Services.Implementation
{
    public interface IFriendsService
    {
        Task<FriendResponse> CancelInvite(string userId, string friendName);
        Task<FriendResponse> Delete(string userId, FriendRequest request);
        Task<List<FriendResponse>> GetAll(string userId, ODataQueryOptions<Friend> options);
        Task<FriendResponse> AcceptInvite(string userId, string friendName);
        Task<FriendResponse> SendInvite(string userId, FriendRequest request);
    }
}