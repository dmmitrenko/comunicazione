using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comunicazione.Core.Views;
using AutoMapper;
using Comunicazione.Core.Views.Comments;

namespace Comunicazione.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddComment(CommentViewModelForCreation commentModel)
        {
            var comment = _mapper.Map<Comment>(commentModel);
            await _unitOfWork.Comments.Add(comment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteComment(int id)
        {
            var comment = await _unitOfWork.Comments.GetById(id);
            _unitOfWork.Comments.Remove(comment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task EditComment(int id, CommentEditViewModel model)
        {
            var comment = await _unitOfWork.Comments.GetById(id);
            _unitOfWork.Comments.Update(comment, model);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CommentViewModel>> GetAllPostCommentaries(int postId)
        {
            var comments = await _unitOfWork.Comments.GetAllPostCommentaries(postId);
            var response = _mapper.Map<IEnumerable<CommentViewModel>>(comments);
            return response;
        }

        public async Task<CommentViewModel> GetCommentById(int id)
        {
            var comment = await _unitOfWork.Comments.GetById(id);
            return _mapper.Map<CommentViewModel>(comment);
        }
        

        public async Task<IEnumerable<ReplyViewModel>> GetReplies(int id)
        {
            var replies = await _unitOfWork.Comments.GetCommentsReply(id);
            return _mapper.Map<IEnumerable<ReplyViewModel>>(replies);
        }
    }
}
