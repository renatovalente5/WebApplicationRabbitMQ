using Microsoft.EntityFrameworkCore;
using WebApplicationRabbitMQ.Data.DataContext;
using WebApplicationRabbitMQ.Models;
using WebApplicationRabbitMQ.Repositoties.Interfaces;

namespace WebApplicationRabbitMQ.Repositoties.Implementation
{
    public class UsersGamesRepository : IUsersGamesRepository
    {
        private readonly DataContext _context;

        public UsersGamesRepository(DataContext context)
        {
            _context = context;
        }

        //public IQueryable<Game> GetAll(string userId)
        //{
        //    var a = _context.UsersUsersGames.Where(x => x.UserId == userId).Include(x => x.Game).AsQueryable();
        //    return a;
        //}
        //public IQueryable<Game> GetAll(string userId)
        //{
        //    var userUsersGames = _context.UsersUsersGames
        //        .Where(x => x.UserId == userId)
        //        .Select(x => x.Game);

        //    var publicUsersGames = _context.UsersGames
        //        .Where(x => x.GameTypeEnumId == (int)GameTypeValues.Public);

        //    var allUsersGames = userUsersGames.Union(publicUsersGames).Include(x => x.UsersUsersGames);

        //    return allUsersGames.AsQueryable();
        //}
        public async Task<List<UsersGame>> GetAll()
        {
            return await _context.UsersGames.ToListAsync();
        }

        public async Task<UsersGame?> GetById(int id)
        {
            return await _context.UsersGames.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsersGame>?> GetByGameId(int gameId)
        {
            return await _context.UsersGames.Where(x => x.GameId == gameId).ToListAsync();
        }

        public async Task<List<UsersGame>> GetAllByUserId(string userId)
        {
            return await _context.UsersGames.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<UsersGame>> GetAllByCreator(string userId)
        {
            return await _context.UsersGames.Where(x => x.UserId == userId && x.Creator == true).ToListAsync();
        }

        public async Task<UsersGame?> GetByGameIdAndUserId(string userId, int gameId)
        {
            return await _context.UsersGames.FirstOrDefaultAsync(x => x.UserId == userId && x.GameId == gameId); //Aqui chega um FirstOrDefault?!?
        }

        public async Task<UsersGame> Create(UsersGame usersGame)
        {
            _context.UsersGames.Add(usersGame);
            await _context.SaveChangesAsync();
            return usersGame;
        }

        public async Task<UsersGame> Update(UsersGame usersGame)
        {
            _context.UsersGames.Update(usersGame);
            await _context.SaveChangesAsync();
            return usersGame;
        }

        public async Task<UsersGame> Delete(int id)
        {
            var usersGame = await _context.UsersGames.FirstOrDefaultAsync(x => x.Id == id);
            _context.UsersGames.Remove(usersGame);
            await _context.SaveChangesAsync();
            return usersGame;
        }
    }
}
