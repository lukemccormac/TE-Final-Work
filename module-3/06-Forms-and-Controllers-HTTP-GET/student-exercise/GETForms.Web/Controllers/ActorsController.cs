﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GETForms.Web.DAL;
using GETForms.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GETForms.Web.Controllers
{
    public class ActorsController : Controller
    {
        /// <summary>
        /// The request to display an empty search page.
        /// </summary>
        /// <returns></returns>
        string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=dvdstore;Integrated Security=True";


        public IActionResult Index()
        {
            Actor actors = new Actor();
            return View(actors);
        }
        /// <summary>
        /// The request to display search results.
        /// </summary>
        /// <param name="request">A request model that contains the search parameters.</param>
        /// <returns></returns>
        public IActionResult FindActors(Actor actor)
        {
            ActorDAO dao = new ActorDAO(connectionString);
            IList<Actor> actors = dao.FindActors(actor.LastName);

            return (View(actors));

        }
        /* Call the DAL and pass the values as a model back to the View */

    
    }
}