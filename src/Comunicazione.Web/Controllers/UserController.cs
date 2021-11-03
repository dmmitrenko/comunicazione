using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Infrastructure.DTO;
using Comunicazione.Infrastructure.Services;
using Comunicazione.Infrastructure.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunicazione.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly IMapper _mapper;
        private ILoggerManager _logger;

        public UserController(IUserService userService, IMapper mapper,
            ILoggerManager logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("[action]/{count}")]
        public IActionResult GetPopularUsers(int count)
        {
            var users = _userService.GetPopularUsers(count);
            var response = _mapper.Map<List<UserViewModelForCreation>>(users);
            return Ok(response);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database");
                return BadRequest($"User with id: {id} doesn't exist in the database");
            }
            var response = _mapper.Map<UserViewModelForCreation>(user);
            return Ok(response);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetUserPosts(int id)
        {
            var response = _userService.GetUserPosts(id);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public IActionResult AddUser([FromBody] UserViewModelForCreation model)
        {
            var validator = new UserValidator();
            var result = validator.Validate(model);
            
            if (result.IsValid)
            {
                var user = _mapper.Map<User>(model);
                _userService.AddUser(user);
                return Ok();
            }
            _logger.LogError("Wrong data format");
            return BadRequest(result.Errors);
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database");
                return BadRequest($"User with id: {id} doesn't exist in the database");
            }
        }
    }
}
