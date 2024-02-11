using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Services.Interfaces
{
    public interface IGamesService
    {
        Task<Game> Create(Game game);
        Task<Game> Delete(int id);
        Task<IEnumerable<Game>> GetAll();
        Task<Game> GetBy(int id);
        Task<Game> Update(Game game);
    }
}