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
        Task<Follow> GetFollow(int userId, int recipientId);
        Task<IEnumerable<User>> GetFollowers(int userId);
        Task<IEnumerable<User>> GetSubscriptions(int userId);
    }
}
