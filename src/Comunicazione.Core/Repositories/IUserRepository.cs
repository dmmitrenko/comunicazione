using Comunicazione.Core.Entities;
using Comunicazione.Core.Views;
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
        void UpdateUser(int id, UserViewModelForCreation updateUser);
    }
}
