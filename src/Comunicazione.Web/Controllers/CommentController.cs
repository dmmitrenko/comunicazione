using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunicazione.Web.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult AddComment(int userId, int postId)
        {
            return View();
        }
    }
}
