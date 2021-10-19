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

        public bool CheckFollow(int userId, int recipientId)
        {
            var follow = _unitOfWork.Follows.GetSubscriptions(userId, recipientId);

            if (follow != null)
                return true;
            return false;
        }
    }
}
