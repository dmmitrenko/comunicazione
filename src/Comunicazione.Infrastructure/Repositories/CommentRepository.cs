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

		public async Task<IEnumerable<Comment>> GetAllPostCommentaries(int postId)
		{
			return await _context.Comments.Include(b => b.User).Where(item => item.PostId == postId)
				.OrderByDescending(item => item.DateCreated).ToListAsync();
		}

		public async Task<IEnumerable<Comment>> GetCommentsReply(int id)
		{
			
			var result =  await _context.Comments.FromSqlRaw(
				@"WITH organization (CommentId, Content, DateCreated, DateUpdated, PostId, ParentCommentId, UserId, below) AS (
					SELECT CommentId, Content, DateCreated, DateUpdated, PostId, ParentCommentId, UserId, 0
					FROM Comments
					WHERE Comments.CommentId = {0}
					UNION ALL
					SELECT e.CommentId, e.Content, e.DateCreated, e.DateUpdated, e.PostId, e.ParentCommentId, e.UserId, o.below + 1
					FROM Comments e
					INNER JOIN organization o
						ON o.CommentId = e.ParentCommentId
				)
				SELECT * FROM organization", id).ToListAsync();

			var author = await _context.Comments.Include(b => b.User).Where(item => item.CommentId == id).ToListAsync();

			return result;
		}
	}
}
