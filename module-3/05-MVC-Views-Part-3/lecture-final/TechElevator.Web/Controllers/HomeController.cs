using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechElevator.Web.DAL;
using TechElevator.Web.Models;

namespace TechElevator.Web.Controllers
{
    public class HomeController : Controller
    {
        IPostDAO dao;

        public HomeController()
        {
            if (Startup.Source == "file")
            {
                string filePath = Startup.FilePath;
                dao = new PostFileDAO(filePath);
            }
            else if (Startup.Source == "sql")
            {
                string connectionString = Startup.SqlConnectionString;
                dao = new PostSqlDAO(connectionString);
            }
        }

        public IActionResult Index()
        {
            if (dao == null)
            {
                string errorMessage = $"Error creating Data Access Object in Home Controller.";
                return RedirectToAction("Error", "Home", new { message = errorMessage });
            }
        
            IList<Post> posts = dao.GetPosts();

            return View(posts);
        }

        public IActionResult Error(string message = "")
        {
            return View("Error", message);
        }

    }
}