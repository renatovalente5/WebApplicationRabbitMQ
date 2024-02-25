using Microsoft.EntityFrameworkCore;
using WebApplicationRabbitMQ.Data.DataContext;
using WebApplicationRabbitMQ.Data.Entities;
using WebApplicationRabbitMQ.DTOs.Response;
using WebApplicationRabbitMQ.Models;
using WebApplicationRabbitMQ.Repositoties.Interfaces;
using WebApplicationRabbitMQ.Services.Interfaces;

namespace WebApplicationRabbitMQ.Repositoties.Implementation
{
    public class FriendsRepository : IFriendsRepository
    {
        private readonly DataContext _context;
        private readonly IUsersService _usersService;

        public FriendsRepository(DataContext context, IUsersService usersService)
        {
            _context = context;
            _usersService = usersService;
        }

        //Check this Method
        public IQueryable<Friend> GetAll(string userId)
        {
            return _context.Set<Friend>().AsQueryable();
        }

        public async Task<Friend?> CheckIfFriend(string userId, string friendId)
        {
            return await _context.Friends
                .Where(x => x.UserId == userId && x.FriendId == friendId && x.InviteEnumId == (int)InviteEnumValues.Accepted && x.DbStatus)
                .FirstOrDefaultAsync();
        }

        public async Task<Friend> SendInvite(Friend friend)
        {
            try
            {
                await _context.Friends.AddAsync(friend);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return friend;
        }

        public async Task<Friend?> GetInvite(string userId, string friendId)
        {
            return await _context.Friends
                .Where(x => x.UserId == userId && x.FriendId == friendId && x.InviteEnumId == (int)InviteEnumValues.Pending && x.DbStatus)
                .FirstOrDefaultAsync();
        }


        public async Task<FriendResponse> Update(Friend entity)
        {
            _context.Friends.Update(entity);
            await _context.SaveChangesAsync();
            return new FriendResponse { Name = _usersService.GetById(entity.FriendId).Result?.UserName ?? "Unknown" };
        }

        public async Task<FriendResponse> Delete(Friend entity)
        {
            entity.DbStatus = false; //Falta acrescentar o DbUpdateOn na tabela!
            _context.Friends.Update(entity);
            await _context.SaveChangesAsync();
            return new FriendResponse { Name = _usersService.GetById(entity.FriendId).Result?.UserName ?? "Unknown" };
        }
    }
}
