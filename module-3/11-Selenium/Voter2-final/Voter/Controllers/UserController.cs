using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voter.DAL.Interfaces;
using Voter.Models;

namespace Voter.Controllers
{
    public class UserController : HomeController
    {
        IUserDao userDao;

        public UserController(IUserDao userDao)
        {
            this.userDao = userDao;
        }


        public IActionResult Register()
        {
            Register register = new Register();
            return View(register);
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            User user = userDao.SaveUser(register.UserName, register.Password, 0);

            if (user is null || user.Id <= 0)
            {
                TempData["ErrorMessage"] = "Unable to register user. Duplicate?";
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            Login login = new Login();
            return View(login);
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            bool OK = userDao.IsUsernameAndPasswordValid(login.UserName, login.Password);

            if (!OK)
            {
                return RedirectToAction("Login");
            }

            User user = userDao.GetUserByUserName(login.UserName);

            base.LogUserIn(user);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult List()
        {
            //for admin only
            return View();
        }
    }
}