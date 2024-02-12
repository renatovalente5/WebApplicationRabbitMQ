using Microsoft.EntityFrameworkCore;
using WebApplicationRabbitMQ.Data.DataContext;
using WebApplicationRabbitMQ.Data.Entities;
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

        //Dividir isto nos repositorios certos e agrupar no service do Games.
        //Verificar se tem && x.DbStatus em todo o projeto!!
        public async Task<List<Game>> GetAll(string userId)
        {
            var userGames = await _context.UsersGames
                .Where(x => x.UserId == userId)
                .Select(x => x.Game)
                .ToListAsync();

            var publicGames = await _context.Games
                .Where(x => x.GameTypeEnumId == (int)GameTypeValues.Public).ToListAsync();

            //Jogos que foram criados por amigos e GameTypeEnumId == (int)GameTypeValues.OnlyFriends
            var listFriendId = await _context.Friends
                .Where(x => (x.UserId == userId || x.FriendId == userId) && x.InviteEnumId == (int)InviteEnumValues.Accepted && x.DbStatus)
                .Select(x => x.FriendId)
                 .ToListAsync();

            var friendsGames = await _context.UsersGames
                .Where(x => listFriendId.Contains(x.UserId) && x.Creator == true)
                .Select(x => x.Game)
                .Where(x => x.GameTypeEnumId == (int)GameTypeValues.OnlyFriends)
                 .ToListAsync();

            var listFriendId2 = await _context.Friends
                .Where(x => (x.UserId == userId || x.FriendId == userId) && x.InviteEnumId == (int)InviteEnumValues.Accepted && x.DbStatus)
                .Select(x => x.UserId)
                 .ToListAsync();

            var friendsGames2 = await _context.UsersGames
                .Where(x => listFriendId2.Contains(x.UserId) && x.Creator == true)
                .Select(x => x.Game)
                .Where(x => x.GameTypeEnumId == (int)GameTypeValues.OnlyFriends)
                 .ToListAsync();


            var result = userGames.Concat(publicGames).DistinctBy(c => c.Id).ToList();
            result = result.Concat(friendsGames).DistinctBy(c => c.Id).ToList();
            result = result.Concat(friendsGames2).DistinctBy(c => c.Id).ToList();

            return result;
        }

        public async Task<Game?> GetById(int id)
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
