using Comunicazione.Core.Entities;
using Comunicazione.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        IEnumerable<Post> GetUserPosts(int id);
        void Edit(int id, PostAddModel updatePost);
    }
}
