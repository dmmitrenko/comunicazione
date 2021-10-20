using Comunicazione.Core.Repositories;
using Comunicazione.Infrastructure.EF;
using Comunicazione.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Posts = new PostRepository(_context);
            Follows = new FollowRepository(_context);
        }
        public IUserRepository Users { get; private set; }

        public IPostRepository Posts { get; private set; }
        public IFollowRepository Follows { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
