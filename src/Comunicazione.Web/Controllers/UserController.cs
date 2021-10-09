using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Infrastructure.DTO;
using Comunicazione.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunicazione.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private UsersService _userService;
   
        public UserController(IMapper mapper, UsersService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
       

        [HttpGet("get-user-posts/{id}")]
        public UserViewModel GetUserPostsById(int id)
        {
            var response = _userService.GetUserPostsById(id);
            
            return _mapper.Map<UserViewModel>(response);
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
