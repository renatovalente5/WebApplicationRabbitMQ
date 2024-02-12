using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Services.Interfaces
{
    public interface IUsersGamesService
    {
        Task<UsersGame> Create(UsersGame usersGame);
        Task<List<UsersGame>> GetAll();
        Task<List<UsersGame>> GetAllByCreator(string userId);
        Task<List<UsersGame>> GetAllByUserId(string userId);
        Task<UsersGame?> GetById(int id);
        Task<List<UsersGame>?> GetByGameId(int id);
        Task<UsersGame?> GetByGameIdAndUserId(string userId, int gameId);
        Task<UsersGame> Update(UsersGame usersGame);
    }
}