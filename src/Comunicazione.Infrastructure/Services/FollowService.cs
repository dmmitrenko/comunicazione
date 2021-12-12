using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views.Users;
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
        private readonly IMapper _mapper;
        public FollowService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Follow> GetFollow(int userId, int recipientId) 
            => await _unitOfWork.Follows.GetFollow(userId, recipientId);

        public async Task FollowUser(int id, int recipientId)
        {
            Follow follow = new Follow()
            {
                FollowerId = id,
                FolloweeId = recipientId
            };

            await _unitOfWork.Follows.Add(follow);
            await _unitOfWork.CompleteAsync(); 
        }

        public async Task<IEnumerable<UserFullNameModel>> GetFollowers(int userId)
        { 
            var followers = await _unitOfWork.Follows.GetFollowers(userId);
            return _mapper.Map<IEnumerable<UserFullNameModel>>(followers);
        }


        public async Task<IEnumerable<UserFullNameModel>> GetSubscriptions(int userId)
        { 
            var subscriptions = await _unitOfWork.Follows.GetSubscriptions(userId);
            return _mapper.Map<IEnumerable<UserFullNameModel>>(subscriptions);
        }

        public void DeleteSubscription(Follow follow)
        {
            _unitOfWork.Follows.Remove(follow);
            _unitOfWork.CompleteAsync();
        }
    }
}
