using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Services
{
    public class FollowService : IFollowService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FollowService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Follow GetFollow(int userId, int recipientId) 
            => _unitOfWork.Follows.GetFollow(userId, recipientId);

        public void FollowUser(int id, int recipientId)
        {
            Follow follow = new Follow()
            {
                FollowerId = id,
                FolloweeId = recipientId
            };

            _unitOfWork.Follows.Add(follow);
            _unitOfWork.Complete(); 
        }

        public IEnumerable<User> GetFollowers(int userId) 
            => _unitOfWork.Follows.GetFollowers(userId);
            
        
        

        public IEnumerable<User> GetSubscriptions(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
