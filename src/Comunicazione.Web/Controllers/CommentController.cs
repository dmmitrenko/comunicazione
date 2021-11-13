using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunicazione.Web.Controllers
{
    public class CommentController : Controller
    {
        private ICommentService _commentService;
        private IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        [HttpPost("[action]")]
        public IActionResult AddComment([FromBody] CommentViewModelForCreation commentModel)
        {
            var comment = _mapper.Map<Comment>(commentModel);
            _commentService.AddComment(comment);
            return Ok();
        }
    }
}
