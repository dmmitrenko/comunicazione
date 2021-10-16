using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Infrastructure.DTO;
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
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PostController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("[action]/{userId}")]
        public IActionResult AddPost(int userId, [FromBody] PostViewModel model)
        {
            var author = _unitOfWork.Users.GetById(userId);
            var post = new Post()
            {
                Content = model.Content,
                User = author
            };
            _unitOfWork.Posts.Add(post);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetPostById(int id)
        {
            return Ok();
        }

    }
}
