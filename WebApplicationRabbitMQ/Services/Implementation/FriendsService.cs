using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using WebApplicationRabbitMQ.Data.Entities;
using WebApplicationRabbitMQ.DTOs.Requests;
using WebApplicationRabbitMQ.DTOs.Response;
using WebApplicationRabbitMQ.Models;
using WebApplicationRabbitMQ.Repositoties.Interfaces;
using WebApplicationRabbitMQ.Services.Interfaces;

namespace WebApplicationRabbitMQ.Services.Implementation
{
    public class FriendsService : IFriendsService
    {
        private readonly IFriendsRepository _friendsRepository;
        private readonly IUsersService _usersService;

        public FriendsService(IFriendsRepository friendsRepository, IUsersService usersService)
        {
            _friendsRepository = friendsRepository;
            _usersService = usersService;
        }

        public async Task<List<FriendResponse>> GetAll(string userId, ODataQueryOptions<Friend> options)
        {
            IQueryable<Friend> query = _friendsRepository.GetAll(userId)
                .Where(x => (x.UserId == userId || x.FriendId == userId) && x.DbStatus == true);

            var result = options.ApplyTo(query) is IQueryable<Friend> dataFiltered ? await dataFiltered.ToListAsync() : new List<Friend>();

            var resultFinal = result
                .Select(async x => new FriendResponse
                {
                    Name = _usersService.GetById(x.FriendId).Result?.UserName ?? "Unknown",
                    InviteEnum = ((InviteEnumValues)x.InviteEnumId).ToString(),
                })
                .ToList();

            var final = await Task.WhenAll(resultFinal);

            return final.ToList();
        }

        public async Task<FriendResponse> SendInvite(string userId, FriendRequest request)
        {
            var friend = await _usersService.GetByName(request.UserName);
            if (friend == null)
            {
                throw new Exception($"The user {request.UserName} doen't exist.");
            }

            var checkIfFriend = await _friendsRepository.CheckIfFriend(userId, friend.Id);
            if (checkIfFriend != null)
            {
                throw new Exception($"The user is already a friend of {request.UserName}.");
            }

            var newFriend = new Friend
            {
                UserId = userId,
                FriendId = friend.Id,
                InviteEnumId = (int)InviteEnumValues.Pending,
                DbStatus = true,
                DbCreatedOn = DateTime.Now
            };

            await _friendsRepository.SendInvite(newFriend);

            return new FriendResponse { Name = request.UserName };
        }

        public async Task<FriendResponse> CancelInvite(string userId, string friendName)
        {
            var friend = await _usersService.GetByName(friendName);
            if (friend == null)
            {
                throw new Exception($"The user {friendName} doen't exist.");
            }

            var checkIfFriend = await _friendsRepository.CheckIfFriend(userId, friend.Id);
            if (checkIfFriend != null)
            {
                throw new Exception($"The user is already a friend of {friendName}.");
            }

            var getPendentInvite = await _friendsRepository.GetInvite(userId, friend.Id);
            if (getPendentInvite == null)
            {
                throw new Exception($"There is no pending invitation for {friendName}."); //Isto não devia nunca acontecer.
            }

            getPendentInvite.DbStatus = false;
            return await _friendsRepository.Update(getPendentInvite);
            //Retirar isto de dentro do Update e meter aqui !!!
            //return new FriendResponse { Name = _usersService.GetById(entity.FriendId).Result?.UserName ?? "Unknown" };
        }

        public async Task<FriendResponse> AcceptInvite(string userId, string friendName)
        {
            var friend = await _usersService.GetByName(friendName);
            if (friend == null)
            {
                throw new Exception($"The user {friendName} doen't exist.");
            }

            var checkIfFriend = await _friendsRepository.CheckIfFriend(userId, friend.Id);
            if (checkIfFriend != null)
            {
                throw new Exception($"The user is already a friend of {friendName}.");
            }

            var cheackIfPendentInvite = await _friendsRepository.GetInvite(friend.Id, userId);
            if (cheackIfPendentInvite == null)
            {
                throw new Exception($"There is no pending invitation for {friendName}."); //Isto não devia nunca acontecer.
            }

            cheackIfPendentInvite.InviteEnumId = (int)InviteEnumValues.Accepted;
            return await _friendsRepository.Update(cheackIfPendentInvite);
            //Retirar isto de dentro do Update e meter aqui !!!  É inverso ao de cima !!!
            //return new FriendResponse { Name = _usersService.GetById(entity.UserId).Result?.UserName ?? "Unknown" }; 
        }

        public async Task<FriendResponse> Delete(string userId, FriendRequest request)
        {
            var friend = await _usersService.GetByName(request.UserName);
            if (friend == null)
            {
                throw new Exception($"The user {request.UserName} doen't exist.");
            }

            var checkIfFriend = await _friendsRepository.CheckIfFriend(userId, friend.Id);
            if (checkIfFriend == null)
            {
                throw new Exception($"The user is not a friend of {request.UserName}.");
            }

            return await _friendsRepository.Delete(checkIfFriend);
        }
    }
}
