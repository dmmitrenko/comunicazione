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

        public Follow GetFollow(int userId, int recipientId)
        {
            return _context.Follow
                .FirstOrDefault(u => u.FollowerId == userId &&
                                          u.FolloweeId == recipientId);
        }

        public IEnumerable<User> GetFollowers(int userId)
        {
            var followers = _context.Follow.Where(u => u.FolloweeId == userId)
                .Select(item => item.Followee).ToList();
            
            return followers;
        }
        
    }
}
