using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddComment(Comment comment)
        {
            _unitOfWork.Comments.Add(comment);
            _unitOfWork.Complete();
        }

        public void DeleteComment()
        {
            throw new NotImplementedException();
        }

        public void EditComment()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAllPostCommentaries()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetReplies()
        {
            throw new NotImplementedException();
        }
    }
}
