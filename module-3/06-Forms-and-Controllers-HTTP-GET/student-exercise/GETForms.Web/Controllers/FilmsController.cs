using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GETForms.Web.DAL;
using GETForms.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GETForms.Web.Controllers
{
    public class FilmsController : Controller
    {
        string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=dvdstore;Integrated Security=True";

        /// <summary>
        /// The request to display an empty search page.
        /// </summary>
        /// <returns></returns>

        public IActionResult Index()
        {
            Film films = new Film();
            return View(films);
        }

        public IActionResult FindFilms(string genre, int minLength, int maxLength=1000)
        {
            FilmDAO dao = new FilmDAO(connectionString);
            IList<Film> films = dao.GetFilmsBetween(genre, minLength, maxLength);

            return (View(films));
        }
        /// <summary>
        /// Receives the search result request and goes to th database looking for the information.
        /// </summary>
        /// <param name="request">A request model that contains the search parameters.</param>
        //    /// <returns></returns>
        //    public ActionResult SearchResult(/*FilmSearch request */)
        //{
        //    /* Call the DAL and pass the values as a model back to the View */
        //    return null;
        //}
    }
}