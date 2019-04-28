using System;
using System.Threading.Tasks;
using AutoMapper;
using GoParty.Business.Contract.Core.Exceptions;
using GoParty.Business.Contract.Geography.Models;
using GoParty.Business.Contract.Users.Models;
using GoParty.Business.Contract.Users.Services;
using Microsoft.AspNet.Identity;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;

namespace GoParty.Business.Users.Services
{
    public class UserService : IUserRetrievingService, IUserPasswordStore<User, Guid>, IUserModifyingService
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

        public async Task<ShortUser> GetShortById(Guid id)
        {
            UserEntity user = await GetInternal(id);
            return Mapper.Map<UserEntity, ShortUser>(user);
        }

        public async Task<User> GetByUserName(string userName)
        {
            UserEntity user = await _userRepository.GetByUsernameAsync(userName);
            return Mapper.Map<UserEntity, User>(user);
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

        /// <summary>
        /// This method is redundant. Resource managing is responsibility of Ninject.
        /// </summary>
        public void Dispose()
        {
        }

        public async Task CreateAsync(User user)
        {
            UserEntity userData = new UserEntity();
            FillUserData(userData, user);
            userData.Id = Guid.NewGuid();

            _userRepository.Add(userData);

            await _userRepository.CommitAsync();
        }

        async Task IUserStore<User, Guid>.UpdateAsync(User user)
        {
            await UpdateAsync(user);
        }
        
        public async Task<User> UpdateAsync(User user)
        {
            UserEntity userData = await _userRepository.GetByIdAsync(user.Id);
            FillUserData(userData, user);
            
            _userRepository.Update(userData);
            await _userRepository.CommitAsync();

            return Mapper.Map<UserEntity, User>(userData);
        }

        public async Task DeleteAsync(User user)
        {
            UserEntity userData = await _userRepository.GetByIdAsync(user.Id);

            _userRepository.Delete(userData);

            await _userRepository.CommitAsync();
        }

        public async Task<User> FindByIdAsync(Guid userId)
        {
            return await GetById(userId);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            UserEntity userData = await _userRepository.GetByUsernameAsync(userName);
            
            return Mapper.Map<UserEntity, User>(userData);
        }

        private void FillUserData(UserEntity userData, User user)
        {
            userData.City = Mapper.Map<Location, CityEntity>(user.Location);
            userData.Id = user.Id;
            userData.Email = user.Email;
            userData.Image = user.Image;
            userData.UserName = user.UserName;
            userData.Surname = user.Surname;
            userData.Name = user.Name;
            userData.Password = user.Password;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.Password));
        }
    }
}
