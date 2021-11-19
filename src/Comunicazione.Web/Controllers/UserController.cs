using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views;
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

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{count}")]
        public IActionResult GetPopularUsers(int count)
        {
            var users = _userService.GetPopularUsers(count);
            var response = _mapper.Map<List<UserCountFollowersModel>>(users);
            return Ok(response);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound($"User with id: {id} doesn't exist in the database");
            }

            var response = _mapper.Map<UserViewModelForCreation>(user);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public IActionResult AddRange([FromBody] IEnumerable<UserViewModelForCreation> users)
        {
            var validator = new UserValidator();
            foreach(var item in users)
            {
                var result = validator.Validate(item);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }
            }

            var newUsers = _mapper.Map<IEnumerable<User>>(users);
            _userService.AddRange(newUsers);
            return Ok();
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
            
            return BadRequest(result.Errors);
        }

        [HttpPut("[action]/{id}")]
        public IActionResult UpdateInformation(int id, [FromBody] UserViewModelForCreation information)
        {
            var validator = new UserValidator();
            var result = validator.Validate(information);
            if (result.IsValid)
            {
                _userService.UpdateInformation(id, information);
                return Ok();

            }

            return BadRequest(result.Errors);
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
