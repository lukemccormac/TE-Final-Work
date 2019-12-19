using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Validation.Web.Models;


namespace Validation.Web.Controllers
{
    public class UsersController : Controller
    {
        // GET: User
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View(); 
        }
        // GET: User/Register
        // Return the empty registration view

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegistrationViewModel registration)
        {
            if (!ModelState.IsValid)
            {
                return View("Registration", registration);
            }
            else
            {
                return RedirectToAction("confirmationreg", "users");
            }
        }
        // POST: User/Register
        // Validate the model and redirect to confirmation (if successful) or return the 
        // registration view (if validation fails)        


        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        // GET: User/Login
        // Return the empty login view


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View("LogIn", login);
            }
            else
            {
                return RedirectToAction("Confirmationlog", "users");
            }
        }

        // POST: User/Login  
        // Validate the model and redirect to login (if successful) or return the 
        // login view (if validation fails)
        public IActionResult ConfirmationReg()
        {
            return View(); 
        }

        public IActionResult ConfirmationLog()
        {
            return View();
        }
        // GET: User/Confirmation
        // Return the confirmation view

    }
}