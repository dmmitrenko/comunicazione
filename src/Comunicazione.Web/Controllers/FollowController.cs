using AutoMapper;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunicazione.Web.Controllers
{
    public class FollowController : Controller
    {
        private readonly IFollowService _followService;
        private readonly IMapper _mapper;
        public FollowController(IFollowService followService, IMapper mapper)
        {
            _followService = followService;
            _mapper = mapper;
        }

        [HttpPost("{id}/follow/{recipientId}")]
        public IActionResult FollowUser(int id, int recipientId)
        {
            _followService.FollowUser(id, recipientId);
            return Ok();
        }

        [HttpGet("{userId}/followers")]
        public IActionResult GetFollowers(int userId)
        {
            var followers = _followService.GetFollowers(userId);
            var response = _mapper.Map<List<UserFullNameModel>>(followers);
            return Ok(response);
        }

        [HttpGet("{userId}/subscriptions")]
        public IActionResult GetSubscriptions(int userId)
        {
            var subscriptions = _followService.GetSubscriptions(userId);
            var response = _mapper.Map<List<UserFullNameModel>>(subscriptions);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteSubscription([FromBody] int followerId, [FromBody] int followeeId)
        {
            var follow = _followService.GetFollow(followerId, followeeId);
            _followService.DeleteSubscription(follow);
            return Ok();
        }
    }
}
