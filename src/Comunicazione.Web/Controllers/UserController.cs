using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Infrastructure.DTO;
using Comunicazione.Infrastructure.Services;
using Comunicazione.Infrastructure.Validators;
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
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserValidator validator = new UserValidator();

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetPopularUsers")]
        public IActionResult GetPopularUsers(int count)
        {
            var popularUsers = _unitOfWork.Users.GetPopularUsers(count);
            return Ok(popularUsers);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public IActionResult GetUserById(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            var responce = _mapper.Map<UserViewModel>(user);
            return Ok(responce);
        }

        [HttpGet("{id}", Name ="GetUserPosts")]
        public IActionResult GetUserPosts(int id)
        {
            var user =_unitOfWork.Users.GetById(id);
            var posts = _unitOfWork.Posts.GetAll();
            var response = UserService.GetUserPosts(user, posts);

            return Ok(response);
        }

        [HttpPost(Name = "AddUser")]
        public IActionResult AddUser([FromBody]UserViewModel model)
        {
            var result = validator.Validate(model);
            if (result.IsValid)
            {
                var user = _mapper.Map<User>(model);
                _unitOfWork.Users.Add(user);
                _unitOfWork.Complete();
                return Ok();
            }
            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            _unitOfWork.Users.Remove(_unitOfWork.Users.GetById(id));
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
