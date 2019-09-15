using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new List<User>();

        static UserRepository()
        {
            _users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Test 1",
                    LastName = "Test 1"
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Test 2",
                    LastName = "Test 2"
                }
            };
        }

        public UserRepository()
        {
        }

        public Task<bool> DeleteAsync(User entity)
        {
            return Task.FromResult(_users.Remove(entity));
        }

        public Task<IEnumerable<User>> GetAsync(Expression<Func<User, bool>> predicate)
        {
            return Task.FromResult(_users.Where(predicate.Compile()));
        }

        public Task<User> GetSingleAsync(Expression<Func<User, bool>> predicate)
        {
            return Task.FromResult(_users.SingleOrDefault(predicate.Compile()));
        }

        public Task<User> SaveAsync(User entity)
        {
            _users.Add(entity);

            return Task.FromResult(entity);
        }

        public Task<User> UpdateAsync(User entity)
        {
            var user = _users.SingleOrDefault(item => item.Id == entity.Id);

            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;

            return Task.FromResult(user);
        }
    }
}
