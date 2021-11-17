using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comunicazione.Core.Views;

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

        public void DeleteComment(int id)
        {
            var comment = GetCommentById(id);
            _unitOfWork.Comments.Remove(comment);
            _unitOfWork.Complete();
        }

        public void EditComment(int id, CommentEditViewModel model)
        {
            var comment = _unitOfWork.Comments.GetById(id);
            _unitOfWork.Comments.Update(comment, model);
            _unitOfWork.Complete();
        }

        public IEnumerable<Comment> GetAllPostCommentaries()
        {
            throw new NotImplementedException();
        }

        public Comment GetCommentById(int id)
            => _unitOfWork.Comments.GetById(id);
        
            
        

        public IEnumerable<Comment> GetReplies()
        {
            throw new NotImplementedException();
        }
    }
}
