using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers
{
    public static class UsersMapper
    {
        public static UserDto Map(this User userEntity)
        {
            return new UserDto
            {
                Id = userEntity?.Id,
                FirstName = userEntity?.FirstName,
                LastName = userEntity?.LastName
            };
        }
    }
}
