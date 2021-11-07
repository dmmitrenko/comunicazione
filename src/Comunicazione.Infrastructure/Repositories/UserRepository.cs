using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Views;
using Comunicazione.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
            
        }

        public IEnumerable<User> GetPopularUsers(int count)
        {
             
            return _context.Users.Include(b => b.Follower).OrderByDescending(d => d.Follower.Count()).Take(count).ToList();
        }

        public void UpdateUser(int id, UserViewModelForCreation updateUser)
        {
            var entity = _context.Users.Find(id);
            if (entity == null)
            {
                return;
            }

            _context.Entry(entity).CurrentValues.SetValues(updateUser);
        }
        
        
    }
}
