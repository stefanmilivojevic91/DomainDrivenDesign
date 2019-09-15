using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> SaveUserAsync(UserDto user);
        Task<UserDto> GetUserAsync(string id);
        Task<UserDto> UpdateUserAsync(string userId, UserDto user);
        Task<bool> DeleteUserAsync(string id);
    }
}
