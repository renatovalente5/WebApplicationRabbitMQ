using Microsoft.AspNetCore.Identity;

namespace WebApplicationRabbitMQ.Repositoties.Interfaces
{
    public interface IUsersRepository
    {
        Task<IdentityUser?> GetById(string id);
        Task<IdentityUser?> GetByName(string name);
    }
}