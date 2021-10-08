using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static ISet<Post> _post = new HashSet<Post>();

        public async Task<Post> GetAsync(int id)
            => await Task.FromResult(_post.SingleOrDefault(x => x.Id == id));

        public async Task AddAsync(Post post)
        {
            _post.Add(post);
            await Task.CompletedTask;
        }

        public Task UpdateAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Post post)
        {
            _post.Remove(post);
            await Task.CompletedTask;
        }
    }
}
