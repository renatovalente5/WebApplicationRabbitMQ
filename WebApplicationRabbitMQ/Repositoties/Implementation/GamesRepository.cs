using Microsoft.EntityFrameworkCore;
using WebApplicationRabbitMQ.Data.DataContext;
using WebApplicationRabbitMQ.Models;
using WebApplicationRabbitMQ.Repositoties.Interfaces;

namespace WebApplicationRabbitMQ.Repositoties.Implementation
{
    public class GamesRepository : IGamesRepository
    {
        private readonly DataContext _context;

        public GamesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Game>> GetAll()
        {
            return _context.Games;
        }

        public async Task<Game> GetBy(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Game> Create(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game> Update(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game> Delete(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return game;
        }
    }
}
