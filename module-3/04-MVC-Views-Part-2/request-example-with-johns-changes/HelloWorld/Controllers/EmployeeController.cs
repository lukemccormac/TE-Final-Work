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
            // int id = 7;
            // Employee employee = employeeDao.GetEmployee(id);

            Employee employee = new Employee
            {
                Id = 15,
                Name = "John",
                Position = "instructor"
            };

            return View(employee);
        }

        public IActionResult List()
        {
            // int id = 7;
            // Employee employee = employeeDao.GetEmployee(id);

            Employee employee1 = new Employee
            {
                Id = 15,
                Name = "John",
                Position = "instructor"
            };

            Employee employee2 = new Employee
            {
                Id = 7,
                Name = "Katie",
                Position = "Campus Director"
            };

            Employee employee3 = new Employee
            {
                Id = 37,
                Name = "Steve",
                Position = "instructor"
            };

            List<Employee> employees = new List<Employee>();
            employees.Add(employee1);
            employees.Add(employee2);
            employees.Add(employee3);


            return View(employees);
        }

        public IActionResult Details(int id)
        {
            Employee employee = new Employee
            {
                Id = id,
                Name = "John",
                Position = "instructor"
            };

            return View(employee);
        }

    }
}