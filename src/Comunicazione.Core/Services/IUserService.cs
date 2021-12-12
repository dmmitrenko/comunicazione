using Comunicazione.Core.Entities;
using Comunicazione.Core.Views.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserCountFollowersModel>> GetPopularUsers(int count);
        Task<bool> AddUser(UserViewModelForCreation user);
        Task<UserFullNameModel> GetUserById(int id);
        Task<bool> DeleteUser(int id);
        Task<bool> UpdateInformation(int id, UserViewModelForCreation user);
        Task<bool> AddRange(IEnumerable<UserViewModelForCreation> users);
    }
}
