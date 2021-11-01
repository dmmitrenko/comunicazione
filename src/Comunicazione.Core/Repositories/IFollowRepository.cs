using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Repositories
{
    public interface IFollowRepository : IGenericRepository<Follow>
    {
        Follow GetFollow(int userId, int recipientId);
        public IEnumerable<User> GetFollowers(int userId);
        public IEnumerable<User> GetSubscriptions(int userId);
    }
}
