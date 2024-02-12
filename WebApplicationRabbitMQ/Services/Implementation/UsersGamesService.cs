using WebApplicationRabbitMQ.Models;
using WebApplicationRabbitMQ.Repositoties.Interfaces;
using WebApplicationRabbitMQ.Services.Interfaces;

namespace WebApplicationRabbitMQ.Services.Implementation
{
    public class UsersGamesService : IUsersGamesService
    {
        private readonly IUsersGamesRepository _usersGamesRepository;

        public UsersGamesService(IUsersGamesRepository usersGamesRepository)
        {
            _usersGamesRepository = usersGamesRepository;
        }

        public async Task<List<UsersGame>> GetAll()
        {
            return await _usersGamesRepository.GetAll();
        }

        public async Task<UsersGame?> GetById(int id)
        {
            return await _usersGamesRepository.GetById(id);
        }

        public async Task<List<UsersGame>?> GetByGameId(int id)
        {
            return await _usersGamesRepository.GetByGameId(id);
        }

        public async Task<UsersGame?> GetByGameIdAndUserId(string userId, int gameId)
        {
            return await _usersGamesRepository.GetByGameIdAndUserId(userId, gameId);
        }

        public async Task<List<UsersGame>> GetAllByUserId(string userId)
        {
            return await _usersGamesRepository.GetAllByUserId(userId);
        }

        public async Task<List<UsersGame>> GetAllByCreator(string userId)
        {
            return await _usersGamesRepository.GetAllByCreator(userId);
        }

        public async Task<UsersGame> Create(UsersGame usersGame)
        {
            return await _usersGamesRepository.Create(usersGame);
        }

        public async Task<UsersGame> Update(UsersGame usersGame)
        {
            return await _usersGamesRepository.Update(usersGame);
        }

        async Task<UsersGame> Delete(int id)
        {
            return await _usersGamesRepository.Delete(id);
        }
    }
}
