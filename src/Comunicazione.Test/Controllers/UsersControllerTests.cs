using Comunicazione.Core.Services;
using Comunicazione.Core.Views.Users;
using Comunicazione.Infrastructure.Validators;
using Comunicazione.Web.Controllers;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Test.Controllers
{
    [TestFixture]
    public class UsersControllerTests
    {
        private Mock<IUserService> _mockUserService;
        private UserController _userController;

        [SetUp]
        public void Init()
        {
            _mockUserService = new Mock<IUserService>();
            _userController = new UserController(_mockUserService.Object);
        }

        #region GetById
        [Test]
        public async Task GetUser_UserExists_Returns_Ok()
        {
            int id = 1;
            var expectedUser = new UserFullNameModel();
            _mockUserService.Setup(s => s.GetUserById(It.IsAny<int>()))
                .ReturnsAsync(expectedUser);

            var result = await _userController.GetUserById(id);
            var user = (UserFullNameModel)((OkObjectResult)result).Value;

            Assert.IsTrue(result is OkObjectResult);
        }

        [Test]
        public async Task GetUser_UserDoesNotExist_ReturnsNotFoundResult()
        {
            _mockUserService.Setup(s => s.GetUserById(It.IsAny<int>()))
                .ReturnsAsync(null as UserFullNameModel);

            var result = await _userController.GetUserById(It.IsAny<int>());

            Assert.IsTrue(result is NotFoundObjectResult);
                
        }
        #endregion


        #region Delete
        [Test]
        public async Task DeleteUser_UserExists_Returns_OkResult()
        {
            _mockUserService.Setup(s => s.DeleteUser((It.IsAny<int>())))
                .ReturnsAsync(true);

            var result = await _userController.DeleteUser(It.IsAny<int>());

            Assert.IsTrue(result is OkResult);
        }

        [Test]
        public async Task DeleteUser_UserDoesNotExist_Returns_NotFoundResult()
        {
            _mockUserService.Setup(s => s.DeleteUser(It.IsAny<int>()))
                .ReturnsAsync(false);

            var result = await _userController.DeleteUser(It.IsAny<int>());

            Assert.IsTrue(result is NotFoundResult);
        }
        #endregion
    }
}
