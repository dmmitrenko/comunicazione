using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IPostRepository Posts { get; }
        IFollowRepository Follows { get; }
        ICommentRepository Comments { get; }
        IAddressRepository Addresses { get; }
        Task<int> CompleteAsync();
    }
}
