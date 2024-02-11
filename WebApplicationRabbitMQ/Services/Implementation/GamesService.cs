using WebApplicationRabbitMQ.Models;
using WebApplicationRabbitMQ.Repositoties.Interfaces;
using WebApplicationRabbitMQ.Services.Interfaces;

namespace WebApplicationRabbitMQ.Services.Implementation
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesService(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _gamesRepository.GetAll();
        }

        public async Task<Game> GetBy(int id)
        {
            return await _gamesRepository.GetBy(id);
        }

        public async Task<Game> Create(Game game)
        {
            return await _gamesRepository.Create(game);
        }

        public async Task<Game> Update(Game game)
        {
            return await _gamesRepository.Update(game);
        }

        public async Task<Game> Delete(int id)
        {
            return await _gamesRepository.Delete(id);
        }
    }
}
