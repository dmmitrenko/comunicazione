using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views;

namespace Comunicazione.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddPost(int userId, Post post)
        {
            post.UserId = userId;
            _unitOfWork.Posts.Add(post);
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            var post = _unitOfWork.Posts.GetById(id);
            _unitOfWork.Posts.Remove(post);
            _unitOfWork.Complete();
        }

        public void Edit(int id, PostEditModel updatePost)
        {
            var post = _unitOfWork.Posts.GetById(id);
            _unitOfWork.Posts.Update(post, updatePost);
            _unitOfWork.Complete();
        }

        public Post GetById(int id)
            => _unitOfWork.Posts.GetById(id);

        public IEnumerable<Post> GetUserPosts(int userId)
            => _unitOfWork.Posts.GetUserPosts(userId);
        
    }
}
