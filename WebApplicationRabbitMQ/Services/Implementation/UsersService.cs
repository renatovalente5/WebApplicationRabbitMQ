using Microsoft.AspNetCore.Identity;
using WebApplicationRabbitMQ.Repositoties.Interfaces;
using WebApplicationRabbitMQ.Services.Interfaces;

namespace WebApplicationRabbitMQ.Services.Implementation
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IdentityUser?> GetById(string id)
        {
            return await _usersRepository.GetById(id);
        }

        public async Task<IdentityUser?> GetByName(string name)
        {
            return await _usersRepository.GetByName(name);
        }
    }
}
