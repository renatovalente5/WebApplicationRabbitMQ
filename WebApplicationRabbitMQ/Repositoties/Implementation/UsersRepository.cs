using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplicationRabbitMQ.Data.DataContext;
using WebApplicationRabbitMQ.Repositoties.Interfaces;

namespace WebApplicationRabbitMQ.Repositoties.Implementation
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersRepository(DataContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityUser?> GetById(string id)
        {
            return await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IdentityUser?> GetByName(string name)
        {
            return await _userManager.Users.Where(x => x.UserName == name).FirstOrDefaultAsync();
        }
    }
}
