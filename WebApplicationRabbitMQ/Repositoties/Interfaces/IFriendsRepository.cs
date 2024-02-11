using WebApplicationRabbitMQ.DTOs.Results;
using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Repositoties.Interfaces
{
    public interface IFriendsRepository
    {
        Task<Friend?> CheckIfFriend(string userId, string friendId);
        Task<Friend> SendInvite(Friend friend);
        Task<List<Friend>> PendingInvites(string userId);
        Task<List<Friend>> SendedInvites(string userId);
        Task<Friend?> CancelInvite(string userId, string friendId);
        Task<Friend?> MyPendentInvite(string userId, string friendId);
        Task<FriendResponse> Update(Friend entity);
        Task<FriendResponse> Delete(Friend entity);
        Task<List<FriendResponse>> GetAll(string userId);
    }
}