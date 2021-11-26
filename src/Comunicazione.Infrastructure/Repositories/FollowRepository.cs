using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Repositories
{
    public class FollowRepository : GenericRepository<Follow>, IFollowRepository
    {
        public FollowRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Follow> GetFollow(int userId, int recipientId)
        {
            return await _context.Follow
                .FirstOrDefaultAsync(u => u.FollowerId == userId &&
                                          u.FolloweeId == recipientId);
        }

        public async Task<IEnumerable<User>> GetFollowers(int userId)
        {
            return await _context.Follow.Where(u => u.FolloweeId == userId)
                .Select(item => item.Followee).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetSubscriptions(int userId)
        {
            return await _context.Follow.Where(u => u.FollowerId == userId)
                .Select(item => item.Follower).ToListAsync();  
        }
    }
}
