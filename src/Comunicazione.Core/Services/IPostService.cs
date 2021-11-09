using Comunicazione.Core.Entities;
using Comunicazione.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Services
{
    public interface IPostService
    {
        void AddPost(int userId, Post post);
        Post GetById(int id);
        void Delete(int id);
        void Edit(int id, PostEditModel post);
        IEnumerable<Post> GetUserPosts(int userId);

    }
}
