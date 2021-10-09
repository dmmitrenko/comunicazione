using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Infrastructure.EF;
using System;
using System.Collections.Generic;
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
            return _context.Users.OrderByDescending(d => d.DateCreated).Take(count).ToList();
        }
    }
}
