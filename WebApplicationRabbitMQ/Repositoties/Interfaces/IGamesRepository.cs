using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Repositoties.Interfaces
{
    public interface IGamesRepository
    {
        Task<Game> Create(Game game);
        Task<Game> Delete(int id);
        Task<List<Game>> GetAll(string userId);
        Task<Game?> GetById(int id);
        Task<Game> Update(Game game);
    }
}