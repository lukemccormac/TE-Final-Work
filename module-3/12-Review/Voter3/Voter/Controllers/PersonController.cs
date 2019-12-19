using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voter.DAL.Interfaces;
using Voter.Models;

namespace Voter.Controllers
{
    public class PersonController : HomeController
    {
        IPersonDao personDao;

        public PersonController(IPersonDao personDao)
        {
            this.personDao = personDao;
        }

        public IActionResult List()
        {
            IList<Person> person = personDao.GetPersons();
            return View(person);
        }
    }
}