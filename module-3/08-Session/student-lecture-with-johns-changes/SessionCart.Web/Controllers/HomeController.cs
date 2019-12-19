using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionCart.Web.Models;

namespace SessionCart.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string value = "Bobo";
            HttpContext.Session.SetString("Name",value);
            return View("Index", value);
        }

        public IActionResult Index2()
        {

            string value = HttpContext.Session.GetString("Name");
            return View("Index2", value);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
