using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Views;
using Comunicazione.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<User>> GetPopularUsers(int count)
            =>  await _context.Users.Include(b => b.Followee).OrderByDescending(d => d.Followee.Count()).Take(count).ToListAsync();

    }
}
