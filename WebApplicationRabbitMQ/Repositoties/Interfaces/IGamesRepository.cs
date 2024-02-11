using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Repositoties.Interfaces
{
    public interface IGamesRepository
    {
        Task<Game> Create(Game game);
        Task<Game> Delete(int id);
        Task<IQueryable<Game>> GetAll();
        Task<Game> GetBy(int id);
        Task<Game> Update(Game game);
    }
}