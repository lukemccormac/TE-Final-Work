using GETForms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETForms.Web.DAL
{
    public interface ICustomerDAO
    {
        /// <summary>
        /// Searches for customers.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        IList<Customer> SearchForCustomers(string search, string sortBy);
    }
}