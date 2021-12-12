using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views.Posts;
using Comunicazione.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunicazione.Web.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private IPostService _postService;
        
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("[action]/{userId}")]
        public async Task<IActionResult> AddPost([FromBody] PostEditModel model)
        {
            await _postService.AddPost(model);
            return Ok();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postService.GetById(id);
            return Ok(post);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUserPosts(int id)
        {
            var userPosts = await _postService.GetUserPosts(id);     
            return Ok(userPosts);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> EditPost(int id, [FromBody] PostEditModel information)
        {
            await _postService.Edit(id, information);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.Delete(id);
            return Ok();
        }
    }
}
