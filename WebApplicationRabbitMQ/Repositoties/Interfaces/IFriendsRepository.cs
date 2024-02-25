using WebApplicationRabbitMQ.DTOs.Response;
using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Repositoties.Interfaces
{
    public interface IFriendsRepository
    {
        Task<Friend?> CheckIfFriend(string userId, string friendId);
        Task<Friend> SendInvite(Friend friend);
        Task<Friend?> GetInvite(string userId, string friendId);
        Task<FriendResponse> Update(Friend entity);
        Task<FriendResponse> Delete(Friend entity);
        IQueryable<Friend> GetAll(string userId);
    }
}