using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Infrastructure.DTO;

namespace Comunicazione.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddUser(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
         
            try
            {
                _unitOfWork.Users.Remove(user);
                _unitOfWork.Complete();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }   
        }

        public IEnumerable<User> GetPopularUsers(int count)
            => _unitOfWork.Users.GetPopularUsers(count);

        public User GetUserById(int id)
            => _unitOfWork.Users.GetById(id);

        public IEnumerable<Post> GetUserPosts(int id)
        {
            var postsView = new Dictionary<User, IEnumerable<Post>>();
            throw new NotImplementedException();
        }

    }
}
