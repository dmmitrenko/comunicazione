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
        Task AddPost(PostEditModel post);
        Task<PostViewModel> GetById(int id);
        Task Delete(int id);
        Task Edit(int id, PostEditModel post);
        Task<IEnumerable<PostViewModel>> GetUserPosts(int userId);

    }
}
