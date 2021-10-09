using AutoMapper;
using Comunicazione.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunicazione.Web.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IMapper _mapper;
        public PostController(IMapper mapper)
        {
            _mapper = mapper;
        }

    }
}
