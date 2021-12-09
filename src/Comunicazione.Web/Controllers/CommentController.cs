using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views.Comments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunicazione.Web.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private ICommentService _commentService;
        
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddComment([FromBody] CommentViewModelForCreation commentModel)
        {
            await _commentService.AddComment(commentModel);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteComment(id);
            return Ok();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetReplies(int id)
        {
            var response = await _commentService.GetReplies(id);
            return Ok(response);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            return Ok(comment);
        }

        [HttpGet("[action]/{postID}")]
        public async Task<IActionResult> GetAllPostCommentaries(int postID)
        {
            var comments = await _commentService.GetAllPostCommentaries(postID);
            return Ok(comments);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> EditComment(int id, [FromBody] CommentEditViewModel comment)
        {
            await _commentService.EditComment(id, comment);
            return Ok();
        }
    }
}
