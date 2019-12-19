using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            Employee employee = new Employee()
            {
                ID = 15,
                Name = "John",
                Position = "Instructor"
            };

            return View(employee);
        }

        public IActionResult List()
        {
            Employee employee1 = new Employee()
            {
                ID = 15,
                Name = "John",
                Position = "Instructor"
            };
            Employee employee2 = new Employee()
            {
                ID = 37,
                Name = "STeve",
                Position = "Instructor"
            };
            Employee employee3 = new Employee()
            {
                ID = 7,
                Name = "Katie",
                Position = "Campus Director"
            };
            List<Employee> employees = new List<Employee>();
            employees.Add(employee1);
            employees.Add(employee2);
            employees.Add(employee3);

            return View(employees);
        }
        public IActionResult Details(int id)
        {
            Employee employee = new Employee()
            {
                ID = id,
                Name = "John",
                Position = "Instructor"
            };
            return View(employee);
        }

    }
}