using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views;

namespace Comunicazione.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILoggerManager _logger;

        public UserService(IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public void AddRange(IEnumerable<User> users)
        {
            _unitOfWork.Users.AddRange(users);
            _unitOfWork.Complete();
        }

        public void AddUser(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
         
            if(user == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database");
                throw new ArgumentNullException($"User with id: {id} doesn't exist in the database");
            }

            _unitOfWork.Users.Remove(user);
            _unitOfWork.Complete();   
        }

        public IEnumerable<User> GetPopularUsers(int count)
            => _unitOfWork.Users.GetPopularUsers(count);

        public User GetUserById(int id)
            => _unitOfWork.Users.GetById(id);

        public void UpdateInformation(int id, UserViewModelForCreation updateUser)
        {
            var user = _unitOfWork.Users.GetById(id);
            _unitOfWork.Users.Update(user, updateUser);
            _unitOfWork.Complete();
        }
    }
}
