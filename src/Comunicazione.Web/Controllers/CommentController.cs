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

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteComment(int id)
        {
            _commentService.DeleteComment(id);
            return Ok();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetCommentById(int id)
        {
            var comment = _commentService.GetCommentById(id);
            var response = _mapper.Map<CommentViewModel>(comment);
            return Ok(response);
        }

        [HttpPut("[action]/{id}")]
        public IActionResult EditComment(int id, [FromBody] CommentEditViewModel comment)
        {
            _commentService.EditComment(id, comment);
            return Ok();
        }

    }
}
