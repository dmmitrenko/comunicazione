using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Infrastructure.DTO;
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
   
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
            
        }
       

        [HttpGet("get-user-posts")]
        public UserViewModel GetUserPosts()
        {
            UserViewModel userViewModel = new UserViewModel()
            {
                FirstName = "Serhii",
                LastName = "Dmytrenko",
                Role = "admin",
                Email = "dmmytrenko@gmail.com",
                Status = "student",
                Posts = new List<PostViewModel>() 
                { 
                    new PostViewModel() { Content = "Hello!"},
                    new PostViewModel() {Content = "Buy!"}
                }  
            };
            return _mapper.Map<UserViewModel>(userViewModel);
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
