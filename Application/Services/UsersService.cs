using Application.Dtos;
using Application.Interfaces;
using Application.Mappers;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Resources;

namespace Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await _userRepository.GetSingleAsync(item => item.Id == id);

            if (user == null)
            {
                throw new ResourceNotFound(Messages.ResourceNotFound); 
            }

            return await _userRepository.DeleteAsync(user);
        }

        public async Task<UserDto> GetUserAsync(string id)
        {
            var user = await _userRepository.GetSingleAsync(item => item.Id == id);

            if (user == null)
            {
                throw new ResourceNotFound(Messages.ResourceNotFound);
            }

            return user.Map();
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAsync(item => true);

            return users.Select(user => user.Map());
        }

        public async Task<UserDto> SaveUserAsync(UserDto user)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            var createdUser = await _userRepository.SaveAsync(newUser);

            return createdUser.Map();
        }

        public async Task<UserDto> UpdateUserAsync(string userId, UserDto user)
        {
            var foundUser = await _userRepository.GetSingleAsync(item => item.Id == userId);

            if (foundUser == null)
            {
                throw new ResourceNotFound(Messages.ResourceNotFound);
            }

            foundUser.FirstName = user.FirstName;
            foundUser.LastName = user.LastName;

            var updatedUser = await _userRepository.UpdateAsync(foundUser);

            return updatedUser.Map();
        }
    }
}
