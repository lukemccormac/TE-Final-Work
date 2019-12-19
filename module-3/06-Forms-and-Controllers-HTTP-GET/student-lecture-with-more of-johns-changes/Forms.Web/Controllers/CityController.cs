using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Web.DAL;
using Forms.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Web.Controllers
{
    public class CityController : Controller
    {
        string connectionString = Startup.SqlConnectionString;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetForm()
        {
            CityView cityView = new CityView();
            cityView.CountryCode = "USA";

            return View(cityView);
        }

        //public IActionResult GetCities(string countryCode)
        //{
        //    CitySqlDAO dao = new CitySqlDAO(connectionString);
        //    IList<City> cities = dao.GetCities(countryCode);

        //    return View(cities);

        //}

        //public IActionResult GetCities(string countryCode, string district)
        //{
        //    CitySqlDAO dao = new CitySqlDAO(connectionString);
        //    IList<City> cities = dao.GetCities(countryCode, district);

        //    return View(cities);

        //}

        public IActionResult GetCities(CityView city)
        {
            CitySqlDAO dao = new CitySqlDAO(connectionString);
            IList<City> cities = dao.GetCities(city.CountryCode, city.District);

            return View(cities);

        }


    }
}