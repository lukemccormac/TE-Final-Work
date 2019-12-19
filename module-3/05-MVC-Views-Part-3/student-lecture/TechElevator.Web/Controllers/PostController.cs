using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechElevator.Web.DAL;
using TechElevator.Web.Models;

namespace TechElevator.Web.Controllers
{
    public class PostController : Controller
    {

        private string connectonString = @"Data Source=.\sqlexpress;Initial Catalog=TEgram;Integrated Security=True";

        public IActionResult List()
        {
            PostDAO dao = new PostDAO(connectonString);
            List<Post> posts = dao.GetPosts(); 
            return View(posts);
        }

        public IActionResult Details(int id)
        {
            PostDAO dao = new PostDAO(connectonString);
            Post post = dao.GetPost(id);
            return View(post);
        }
    }
}