using WebApplicationRabbitMQ.DTOs.Requests;
using WebApplicationRabbitMQ.DTOs.Response;

namespace WebApplicationRabbitMQ.Services.Implementation
{
    public interface IFriendsService
    {
        Task<FriendResponse> CancelInvite(string userId, string friendName);
        Task<FriendResponse> Delete(string userId, FriendRequest request);
        Task<List<FriendResponse>> GetAll(string userId);
        Task<List<FriendResponse>> PendingInvites(string userId);
        Task<List<FriendResponse>> SendedInvites(string userId);
        Task<FriendResponse> AcceptInvite(string userId, string friendName);
        Task<FriendResponse> SendInvite(string userId, FriendRequest request);
    }
}