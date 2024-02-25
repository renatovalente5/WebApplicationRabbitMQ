using WebApplicationRabbitMQ.DTOs.Requests;
using WebApplicationRabbitMQ.DTOs.Response;
using WebApplicationRabbitMQ.Models;
using WebApplicationRabbitMQ.Repositoties.Interfaces;
using WebApplicationRabbitMQ.Services.Interfaces;

namespace WebApplicationRabbitMQ.Services.Implementation
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IUsersGamesService _usersGamesService;
        private readonly IFriendsService _friendsService;

        public GamesService(IGamesRepository gamesRepository, IUsersGamesService usersGamesService, IFriendsService friendsService)
        {
            _gamesRepository = gamesRepository;
            _usersGamesService = usersGamesService;
            _friendsService = friendsService;
        }

        public async Task<IEnumerable<Game>> GetAll(string userId) //, ODataQueryOptions<Friend> options)
        {
            //var a = _gamesRepository.GetAll(userId);
            //var b = a.Where(x => x)
            return await _gamesRepository.GetAll(userId);
        }


        //maybe passar isto para o serviço do UserGame
        public async Task<Game> EnterInGame(string userId, int gameId)
        {
            var game = await _gamesRepository.GetById(gameId);
            if (game == null)
            {
                throw new Exception("The game doesn't exist.");
            }

            var alreadyInGame = await _usersGamesService.GetByGameIdAndUserId(userId, gameId);
            if (alreadyInGame != null)
            {
                throw new Exception("You are already in the game.");
            }

            ////if the game is OnlyFriends, check if the user is friend of the creator
            //if (game.GameTypeEnumId == (int)GameTypeValues.OnlyFriends)
            //{
            //    var getFriends = await _friendsService.GetAll(userId, null);
            //    //convert getFriends in a list of UserNames

            //    var getCreator = await _usersGamesService.GetByGameId(gameId);
            //    if (getFriends.Contains(getCreator)) //Somethings Like this!
            //    {

            //    }
            //}


            var gameNumPlayers = game.NumPlayers;

            var listUserGames = await _usersGamesService.GetByGameId(gameId);
            if (listUserGames?.Count() >= game.NumPlayers)
            {
                throw new Exception("The game is full.");
            }

            var userGame = new UsersGame
            {
                UserId = userId,
                GameId = gameId,
                DbStatus = true,
                DbCreatedOn = DateTime.Now
            };

            var entity = await _usersGamesService.Create(userGame);

            return game;
        }

        public async Task<Game> GetBy(int id)
        {
            return await _gamesRepository.GetById(id);
        }

        public async Task<GameResponse> Create(string userId, GameRequest request)
        {
            //Adicionar aqui a ceno do Transaction!!
            var entity = AutoMapperConfiguration.Mapper.Map<GameRequest, Game>(request);
            entity.DbCreatedOn = DateTime.Now;
            entity.DbStatus = true;

            var result = await _gamesRepository.Create(entity);

            var userGame = new UsersGame
            {
                UserId = userId,
                GameId = result.Id,
                Creator = true,
                DbStatus = true,
                DbCreatedOn = DateTime.Now
            };

            await _usersGamesService.Create(userGame);

            return AutoMapperConfiguration.Mapper.Map<Game, GameResponse>(result);
        }

        public async Task<GameResponse> Update(GameRequest request)
        {
            var entity = await _gamesRepository.GetById(request.Id);
            if (entity == null)
            {
                throw new Exception("The game doesn't exist.");
            }
            //Alterar isto, para apenas alterar o que é necessário
            //var entity = AutoMapperConfiguration.Mapper.Map<GameRequest, Game>(request);
            entity.NumPlayers = request.NumPlayers;
            entity.Level = request.Level;
            entity.Link = request.Link;
            entity.GameTypeEnumId = request.GameTypeEnumId;
            entity.DbStatus = request.DbStatus;

            var result = await _gamesRepository.Update(entity);

            return AutoMapperConfiguration.Mapper.Map<Game, GameResponse>(result);
        }

        public async Task<Game> Delete(int id) //Este delete apaga permanentemente! 
        {
            var entity = await _gamesRepository.GetById(id);
            if (entity == null)
            {
                throw new Exception("The game doesn't exist.");
            }

            return await _gamesRepository.Delete(id);
        }
    }
}
