using Microsoft.EntityFrameworkCore;
using WebApplicationRabbitMQ.Data.DataContext;
using WebApplicationRabbitMQ.Helpers.RabbitMQ;
using WebApplicationRabbitMQ.Repositoties.Implementation;
using WebApplicationRabbitMQ.Repositoties.Interfaces;
using WebApplicationRabbitMQ.Services.Implementation;
using WebApplicationRabbitMQ.Services.Interfaces;

namespace WebApplicationRabbitMQ
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            return services;
        }
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            RabbitMQConfiguration rabbitMQConfiguration = new();
            configuration.GetSection("RabbitMQ").Bind(rabbitMQConfiguration);
            services.AddSingleton(rabbitMQConfiguration);

            services.AddHostedService<RabbitMQHostedService>();
            services.AddScoped<IRabbitMQOperations<string>, RabbitMQOperations<string>>();

            //Main Services
            services.AddScoped<IRabbitMQService, RabbitMQService>();
            services.AddScoped<IGamesService, GamesService>();
            services.AddScoped<IFriendsService, FriendsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUsersGamesService, UsersGamesService>();


            return services;
        }

        public static IServiceCollection AddRepositoriesDependencies(this IServiceCollection services)
        {

            //Main Repository
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddScoped<IFriendsRepository, FriendsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersGamesRepository, UsersGamesRepository>();

            return services;
        }
    }
}
