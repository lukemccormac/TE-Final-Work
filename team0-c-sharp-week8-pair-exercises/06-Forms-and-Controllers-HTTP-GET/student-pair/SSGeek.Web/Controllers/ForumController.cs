using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    
    public class ForumController : Controller
    {
        private IForumPostDAO forumPostDAO;

        public ForumController(IForumPostDAO forumPostDAO)
        {
            this.forumPostDAO = forumPostDAO; 
        }

        public IActionResult Index()
        {
            
            IList<ForumPost> list = forumPostDAO.GetAllPosts();
            return View(list);
        }

        public IActionResult NewPost()
        {
            ForumPost post = new ForumPost();
            return View(post);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult NewPost(ForumPost post)
        {
            if (!ModelState.IsValid)
            {
                return View("NewPost", post);
            }

            forumPostDAO.AddNewPost(post);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Confirmation()
        {
            return View();
        }
    }

}