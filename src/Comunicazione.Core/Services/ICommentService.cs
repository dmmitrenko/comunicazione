using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comunicazione.Core.Views;
using Comunicazione.Core.Views.Comments;

namespace Comunicazione.Core.Services
{
    public interface ICommentService
    {
        Task AddComment(CommentViewModelForCreation comment);
        Task<IEnumerable<ReplyViewModel>> GetReplies(int id);
        Task EditComment(int id, CommentEditViewModel comment);
        Task DeleteComment(int id);
        Task<IEnumerable<CommentViewModel>> GetAllPostCommentaries(int postId);
        Task<CommentViewModel> GetCommentById(int id);
    }
}
