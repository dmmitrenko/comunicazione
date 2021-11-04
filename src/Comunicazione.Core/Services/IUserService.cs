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
        User GetUserById(int id);
        void DeleteUser(int id);
        void UpdatePassword(int id, string password);
        void UpdateInformation(int id, User user);
    }
}
