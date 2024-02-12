using AutoMapper;
using WebApplicationRabbitMQ.DTOs.Requests;
using WebApplicationRabbitMQ.DTOs.Response;
using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ
{
    public class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }

        public static void Configure()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AllowNullCollections = true;
                FriendMapper(config);
                GameMapper(config);
            });

            Mapper = new Mapper(configuration);
        }

        private static void FriendMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<FriendRequest, Friend>();
            config.CreateMap<Friend, FriendResponse>();
        }

        private static void GameMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<GameRequest, Game>();
            config.CreateMap<Game, GameResponse>();
        }
    }
}
