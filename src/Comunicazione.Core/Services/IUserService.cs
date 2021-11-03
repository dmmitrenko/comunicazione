using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetPopularUsers(int count);
        void AddUser(User user);
        void DeleteUser(int id);
    }
}
