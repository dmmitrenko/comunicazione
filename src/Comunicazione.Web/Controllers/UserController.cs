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
        public IActionResult Index()
        {
            return View();
        }


    }
}
