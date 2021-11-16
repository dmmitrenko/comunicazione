using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Services
{
    public interface ICommentService
    {
        void AddComment(Comment comment);
        IEnumerable<Comment> GetReplies();
        void EditComment();
        void DeleteComment(int id);
        IEnumerable<Comment> GetAllPostCommentaries();
        Comment GetCommentById(int id);
    }
}
