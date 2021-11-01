using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Services
{
    public interface IFollowService
    {
        Follow GetFollow(int userId, int recipientId);
        void FollowUser(int userId, int recipientId);
        IEnumerable<User> GetFollowers(int userId);
        IEnumerable<User> GetSubscriptions(int userId);
    }
}
