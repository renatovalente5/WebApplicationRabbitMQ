using WebApplicationRabbitMQ.DTOs.Requests;
using WebApplicationRabbitMQ.DTOs.Response;
using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Services.Implementation
{
    public interface IGamesService
    {
        Task<GameResponse> Create(string userId, GameRequest request);
        Task<Game> Delete(int id);
        Task<Game> EnterInGame(string id, int gameId);
        Task<IEnumerable<Game>> GetAll(string userId);
        Task<Game> GetBy(int id);
        Task<GameResponse> Update(GameRequest request);
    }
}