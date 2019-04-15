﻿using System;
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
    public class UserService : IUserRetrievingService, IUserStore<User, Guid>
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

            _userRepository.Add(userData);

            await _userRepository.CommitAsync();
        }

        public async Task UpdateAsync(User user)
        {
            UserEntity userData = await _userRepository.GetByIdAsync(user.Id);
            FillUserData(userData, user);

            _userRepository.Update(userData);
            await _userRepository.CommitAsync();
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

            if (userData == null)
            {
                throw new MessageException($"user with {userName} not exists");
            }

            return Mapper.Map<UserEntity, User>(userData);
        }

        private void FillUserData(UserEntity userData, User user)
        {
            userData.City = Mapper.Map<Location, CityEntity>(user.Location);
            userData.Id = Guid.NewGuid();
            userData.Email = user.Email;
            userData.Image = user.Image;
            userData.UserName = user.UserName;
            userData.Surname = user.Surname;
            userData.Name = user.Name;
            userData.Password = user.Password;
        }
    }
}
