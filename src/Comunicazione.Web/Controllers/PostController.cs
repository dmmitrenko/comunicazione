using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views;
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
        private readonly IMapper _mapper;
        public PostController(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;
            _postService = postService;
        }

        [HttpPost("[action]/{userId}")]
        public IActionResult AddPost(int userId, [FromBody] PostAddModel model)
        {
            var post = _mapper.Map<Post>(model);
            _postService.AddPost(userId, post);
            return Ok();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetPostById(int id)
        {
            var model = _postService.GetById(id);
            var response = _mapper.Map<PostViewModel>(model);
            return Ok(response);
        }

    }
}
