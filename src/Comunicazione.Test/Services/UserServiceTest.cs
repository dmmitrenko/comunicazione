using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Infrastructure.EF;
using Comunicazione.Infrastructure.Repositories;
using Comunicazione.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunicazione.Core.Views.Users;

namespace Comunicazione.Test
{
    internal class UserServiceTest
    {
        private AppDbContext _context;
        private UserService _userService;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IMapper> _mapper;
        private Mock<ILoggerManager> _logger;
        

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Fake DB")
                .Options;
            _context = new AppDbContext(options);
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILoggerManager>();
            
            _userService = new UserService(
                _unitOfWork.Object,
                _logger.Object,
                _mapper.Object
                );
        }

        [SetUp]
        public void TestSetUp()
        {
            _unitOfWork.Invocations.Clear();
        }

        #region GetById

        [Test]
        public async Task GetById_UserNotExist_ReturnsNull()
        {

            var userId = 1;
            var user = new User() { UserId = userId };
            var userDto = new UserFullNameModel();

            _unitOfWork.Setup(s => s.Users.GetById(userId))
                .ReturnsAsync(user);
            _mapper.Setup(s => s.Map<UserFullNameModel>(user))
                .Returns(userDto);

            var usersResult = await _userService.GetUserById(2);

            

            Assert.IsNull(usersResult);
        }

        [Test]
        public async Task GetById_UserExists_Returns_UserModel()
        {
            var userId = 1;
            var user = new User { UserId = userId };
            var userDto = new UserFullNameModel();

            _unitOfWork.Setup(s => s.Users.GetById(userId))
                .ReturnsAsync(user);
            _mapper.Setup(s => s.Map<UserFullNameModel>(user))
                .Returns(userDto);

            var userResult = await _userService.GetUserById(userId);

            Assert.IsTrue(userResult is UserFullNameModel);
            
        }
        #endregion

        #region Post
        [Test]
        public async Task AddUser()
        {
            var user = new User();
            _unitOfWork.Setup(s => s.Users.Add(user))
                .ReturnsAsync(true);
            _unitOfWork.Setup(x => x.CompleteAsync())
                .ReturnsAsync(1);

            var userDto = new UserViewModelForCreation();
                 
            
            var userResult = await _userService.AddUser(userDto);

            Assert.IsTrue(userResult);

        }
        #endregion

        #region Delete

        [Test]
        public async Task RemoveUser_UserExists_ReturnsTrue()
        {
            var userId = 1;
            var user = new User { UserId = userId };
            _unitOfWork.Setup(s => s.Users.GetById(userId))
                .ReturnsAsync(user);
            _unitOfWork.Setup(x => x.CompleteAsync())
                .ReturnsAsync(1);

            var userResult = await _userService.DeleteUser(userId);

            _unitOfWork.Verify(x => x.Users.Remove(user), Times.Once);
            _unitOfWork.Verify(x => x.CompleteAsync(), Times.Once);

            Assert.AreEqual(userResult, true);
        }

        [Test]
        public async Task RemoveUser_UserViewModelNotExist_ReturnsFalse()
        {
            var userId = 1;
            _unitOfWork.Setup(s => s.Users.GetById(userId))
                .ReturnsAsync(value: null);

            var userResult = await _userService.DeleteUser(userId);

            Assert.AreEqual(userResult, false); 
        }
        #endregion

        #region Update
        [TestCase(0, ExpectedResult = false, Description = "Returns false if there are no affected rows after saving changes to database")]
        [TestCase(1, ExpectedResult = true, Description = "Returns true if there are affected rows after saving changes to database")]
        public async Task<bool> UpdateUser(int affectedRows)
        {
            var userId = 1;
            var user = new User() {UserId = userId };
            var userModel = new UserViewModelForCreation();

            _unitOfWork.Setup(s => s.Users.GetById(userId))
                .ReturnsAsync(user);

            _unitOfWork.Setup(x => x.CompleteAsync())
                .ReturnsAsync(affectedRows);

            var result = await _userService.UpdateInformation(userId, userModel);

            _unitOfWork.Verify(x => x.Users.Update(user, userModel), Times.Once);
            _unitOfWork.Verify(x => x.CompleteAsync(), Times.Once);

            return result;
        }
        
        #endregion
    }
}