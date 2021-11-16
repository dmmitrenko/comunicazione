using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {

        }
        public new Comment GetById(int id)
        {
            return _context.Comments.Include(b => b.User).
                FirstOrDefault(item => item.CommentId == id);
        }
    }
}
