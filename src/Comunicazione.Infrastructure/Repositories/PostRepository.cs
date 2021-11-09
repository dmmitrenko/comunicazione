using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Views;
using Comunicazione.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context) 
        {

        }

        public void Edit(int id, PostEditModel updatePost)
        {
            var entity = _context.Posts.Find(id);
            if (entity == null)
            {
                return;
            }

            _context.Entry(entity).CurrentValues.SetValues(updatePost);
        }

        public IEnumerable<Post> GetUserPosts(int id)
            => _context.Posts.Include(b => b.User).Where(item => item.UserId == id);
            
        
    }
}
