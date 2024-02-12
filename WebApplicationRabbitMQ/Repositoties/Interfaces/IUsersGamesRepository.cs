using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Repositoties.Interfaces
{
    public interface IUsersGamesRepository
    {
        Task<UsersGame> Create(UsersGame usersGame);
        Task<UsersGame> Delete(int id);
        Task<List<UsersGame>> GetAll();
        Task<List<UsersGame>> GetAllByCreator(string userId);
        Task<List<UsersGame>> GetAllByUserId(string userId);
        Task<UsersGame?> GetById(int id);
        Task<List<UsersGame>?> GetByGameId(int gameId);
        Task<UsersGame?> GetByGameIdAndUserId(string userId, int gameId);
        Task<UsersGame> Update(UsersGame usersGame);
    }
}