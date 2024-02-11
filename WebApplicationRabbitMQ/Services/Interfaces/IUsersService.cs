using Microsoft.AspNetCore.Identity;

namespace WebApplicationRabbitMQ.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IdentityUser?> GetById(string id);
        Task<IdentityUser?> GetByName(string name);
    }
}