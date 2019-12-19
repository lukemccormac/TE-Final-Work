using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voter.DAL.Interfaces;
using Voter.Models;

namespace Voter.Controllers
{
    public class HomeController : Controller
    {

        private const string UserIdKey = "Voter_UserId";
        private const string UserAdminKey = "Voter_Admin";
        protected IUserDao userDao;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// "Logs" the current user in
        /// </summary>
        public void LogUserIn(User user)
        {
            HttpContext.Session.SetInt32(UserIdKey, user.Id);

            string userAdminValue = "false";
            if (user.Role == 1)
            {
                userAdminValue = "true";
            }
            HttpContext.Session.SetString(UserAdminKey, userAdminValue);
        }

        /// <summary>
        /// "Logs out" a user by removing the session.
        /// </summary>
        public void LogUserOut()
        {
            HttpContext.Session.Clear();
        }

        /// <summary>
        /// Gets the value from the Session
        /// </summary>
        public int CurrentUser
        {
            get
            {
                int? userId = -1;

                if (this.HttpContext.Session.GetInt32(UserIdKey) != null)
                {
                    userId = this.HttpContext.Session.GetInt32(UserIdKey);
                }
                if (userId == null)
                {
                    userId = -1;
                }
                return (int)userId;
            }
        }

        /// <summary>
        /// Returns bool if user has authenticated in
        /// </summary>        
        public bool IsAuthenticated
        {
            get
            {
                int? result = HttpContext.Session.GetInt32(UserIdKey);
                return (result != null && result > 0);
            }
        }

        /// <summary>
        /// Returns bool if user is admin
        /// </summary>        
        public bool IsAdmin
        {
            get
            {
                string adminString = HttpContext.Session.GetString(UserAdminKey);
                if (string.IsNullOrEmpty(adminString))
                {
                    adminString = "false";
                }
                if (adminString == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
