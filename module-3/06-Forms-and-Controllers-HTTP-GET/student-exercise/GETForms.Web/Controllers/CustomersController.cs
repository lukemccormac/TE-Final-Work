using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GETForms.Web.DAL;
using GETForms.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GETForms.Web.Controllers
{
    public class CustomersController : Controller
    {
        /// <summary>
        /// The request to display an empty search page.
        /// </summary>
        /// <returns></returns>
        string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=dvdstore;Integrated Security=True";

        public ActionResult Index()
        {
            Customer customers = new Customer();
            return View(customers);
        }

        /// <summary>
        /// The request to display search results.
        /// </summary>
        /// <param name="request">A request model that contains the search parameters.</param>
        /// <returns></returns>
        public IActionResult FindCustomers(string search, string Sortby)
        {
            CustomerDAO dao = new CustomerDAO(connectionString);
            IList<Customer> customers = dao.SearchForCustomers(search, Sortby);

            return (View(customers));

        }
        /* Call the DAL and pass the values as a model back to the View */

    }
}