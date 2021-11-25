using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        IEnumerable<Comment> GetAllPostCommentaries(int postId);
        IEnumerable<Comment> GetCommentsReply(int id);
    }
}
