using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetPopularUsers(int count);
    }
}
