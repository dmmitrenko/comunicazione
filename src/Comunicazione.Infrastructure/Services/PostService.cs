using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;

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

        public Post GetById(int id)
            => _unitOfWork.Posts.GetById(id);
        
    }
}
