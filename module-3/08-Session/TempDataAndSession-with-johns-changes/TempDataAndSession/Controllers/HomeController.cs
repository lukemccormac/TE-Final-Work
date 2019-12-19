using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TempDataAndSession.Models;

namespace TempDataAndSession.Controllers
{
    public class HomeController : Controller
    { 

        public IActionResult Index()
        {
            Television television = new Television();
            television.Name = "Martha";
            television.SerialNumber = "J123DF4";

            ViewData["ViewTelevision"] = television;
            TempData["TempTelevision"] = television;
            ViewBag.ViewBagTelevision = television;

            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

      
    }
}
