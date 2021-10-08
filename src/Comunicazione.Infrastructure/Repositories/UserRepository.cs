using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static ISet<User> _user = new HashSet<User>();

        public async Task<User> GetAsync(int id)
            => await Task.FromResult(_user.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_user.SingleOrDefault(x => x.Email == email));

        public async Task AddAsync(User user)
        {
            _user.Add(user);
            await Task.CompletedTask;
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(User user)
        {
            _user.Remove(user);
            await Task.CompletedTask;
        }
    }
}
