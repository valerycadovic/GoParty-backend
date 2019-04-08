using System;
using System.Threading.Tasks;
using AutoMapper;
using GoParty.Business.Contract.Core.Exceptions;
using GoParty.Business.Contract.Users.Models;
using GoParty.Business.Contract.Users.Services;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;

namespace GoParty.Business.Users.Services
{
    public class UserService : IUserRetrievingService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetById(Guid id)
        {
            UserEntity user = await GetInternal(id);
            return Mapper.Map<UserEntity, User>(user);
        }

        public async Task<ShortUser> GetShortByName(Guid id)
        {
            UserEntity user = await GetInternal(id);
            return Mapper.Map<UserEntity, ShortUser>(user);
        }

        private async Task<UserEntity> GetInternal(Guid id)
        {
            UserEntity user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new MessageException("Current user not exists");
            }

            return user;
        }
    }
}
