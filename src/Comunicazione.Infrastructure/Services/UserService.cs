using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views.Users;

namespace Comunicazione.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, ILoggerManager logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> AddRange(IEnumerable<UserViewModelForCreation> users)
        {
            var newUsers = _mapper.Map<IEnumerable<User>>(users);
            await _unitOfWork.Users.AddRange(newUsers);
            var affectedRows = await _unitOfWork.CompleteAsync();
            return affectedRows > 0;
        }

        public async Task<bool> AddUser(UserViewModelForCreation model)
        {
            var user = _mapper.Map<User>(model);
            await _unitOfWork.Users.Add(user);
            var affectedRows = await _unitOfWork.CompleteAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _unitOfWork.Users.GetById(id);
         
            if(user == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database");
                return false;
            }

            _unitOfWork.Users.Remove(user);
            var affectedRows = await _unitOfWork.CompleteAsync();
            return affectedRows > 0;
        }

        public async Task<IEnumerable<UserCountFollowersModel>> GetPopularUsers(int count)
        { 
            var users = await _unitOfWork.Users.GetPopularUsers(count);
            return _mapper.Map<List<UserCountFollowersModel>>(users);
        }

        public async Task<UserFullNameModel> GetUserById(int id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            return _mapper.Map<UserFullNameModel>(user);
        }

        public async Task<bool> UpdateInformation(int id, UserViewModelForCreation updateUser)
        {
            var user = await _unitOfWork.Users.GetById(id);
            _unitOfWork.Users.Update(user, updateUser);
            var affectedRows = await _unitOfWork.CompleteAsync();
            return affectedRows > 0;
        }
    }
}
