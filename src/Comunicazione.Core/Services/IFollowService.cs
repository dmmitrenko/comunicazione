using Comunicazione.Core.Entities;
using Comunicazione.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Services
{
    public interface IFollowService
    {
        Task<Follow> GetFollow(int userId, int recipientId);
        Task FollowUser(int userId, int recipientId);
        Task<IEnumerable<UserFullNameModel>> GetFollowers(int userId);
        Task<IEnumerable<UserFullNameModel>> GetSubscriptions(int userId);
        void DeleteSubscription(Follow follow);
    }
}
