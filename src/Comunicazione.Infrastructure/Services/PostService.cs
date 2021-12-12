using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views.Posts;

namespace Comunicazione.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddPost(PostEditModel model)
        {
            var post = _mapper.Map<Post>(model);
     
            await _unitOfWork.Posts.Add(post);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Delete(int id)
        {
            var post = await _unitOfWork.Posts.GetById(id);
            _unitOfWork.Posts.Remove(post);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Edit(int id, PostEditModel updatePost)
        {
            var post = await _unitOfWork.Posts.GetById(id);
            _unitOfWork.Posts.Update(post, updatePost);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<PostViewModel> GetById(int id)
        { 
            var post = await _unitOfWork.Posts.GetById(id);
            return _mapper.Map<PostViewModel>(post);
        }

        public async Task<IEnumerable<PostViewModel>> GetUserPosts(int userId)
        {
            var users = await _unitOfWork.Posts.GetUserPosts(userId);
            return _mapper.Map<IEnumerable<PostViewModel>>(users);
        }
        
    }
}
