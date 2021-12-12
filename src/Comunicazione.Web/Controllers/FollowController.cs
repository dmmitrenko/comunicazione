using AutoMapper;
using Comunicazione.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunicazione.Web.Controllers
{
    [Route("api/[controller]")]
    public class FollowController : Controller
    {
        private readonly IFollowService _followService;
        
        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }

        [HttpPost("{id}/follow/{recipientId}")]
        public async Task<IActionResult> FollowUser(int id, int recipientId)
        {
            await _followService.FollowUser(id, recipientId);
            return Ok();
        }

        [HttpGet("{userId}/followers")]
        public async Task<IActionResult> GetFollowers(int userId)
        {
            var followers = await _followService.GetFollowers(userId);
            return Ok(followers);
        }

        [HttpGet("{userId}/subscriptions")]
        public async Task<IActionResult> GetSubscriptions(int userId)
        {
            var subscriptions = await _followService.GetSubscriptions(userId);
            return Ok(subscriptions);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSubscription([FromBody] int followerId, [FromBody] int followeeId)
        {
            var follow = await _followService.GetFollow(followerId, followeeId);
            _followService.DeleteSubscription(follow);
            return Ok();
        }
    }
}
