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
    public class FollowRepository : GenericRepository<Follow>, IFollowRepository
    {
        public FollowRepository(AppDbContext context) : base(context)
        {

        }

        public Follow GetSubscriptions(int userId, int recipientId)
        {
           return _context.Follow.FirstOrDefault(u => u.FollowerId == userId &&
                                                      u.FolloweeId == recipientId);
        }
    }
}
