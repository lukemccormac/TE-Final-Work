using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectOrganizer.Models;
using ProjectOrganizer.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;

namespace ProjectOrgTest
{
    class EmployeeSqlTest
    {
        [TestClass]
        public class LanguageSqlDAOTests
        {

            protected string ConnectionString { get; } = "Data Source=.\\sqlexpress;Initial Catalog=EmployeeDB;Integrated Security=True";

            private TransactionScope transaction;

            [TestInitialize]
            public void Setup()
            {
                transaction = new TransactionScope();
            }
            [TestCleanup]
            public void Cleanup()
            {
                transaction.Dispose();
            }
            [TestMethod]
            public void Employee_List_All_Test()
            {

                EmployeeSqlDAO dao = new EmployeeSqlDAO(ConnectionString);

                IList<Employee> result1 = dao.GetAllEmployees();

                IList<Employee> employees = new List<Employee>();
                Employee employee = new Employee();
                employee.EmployeeId = 45;
                employee.FirstName = "Rick";
                employee.LastName = "James";
                employee.JobTitle = "Boss";
                employee.Gender = "M";
                employee.BirthDate = new DateTime(1999, 11, 19);

                result1.Add(employee);

                IList<Employee> result2 = dao.GetAllEmployees();

                Assert.AreEqual(result1.Count, result2.Count + 1);

            }
            [TestMethod]
            public void Employee_Search_Test()
            {
                int count = 0;
                EmployeeSqlDAO dao = new EmployeeSqlDAO(ConnectionString);
                IList<Employee> result = dao.GetAllEmployees();
                foreach (Employee item in result)
                {
                    if (item.FirstName == "Delora" && item.LastName == "Coty")
                    {
                        count++;
                    }
                }
                Assert.AreEqual(1, count);
            }
            [TestMethod]
            public void Employee_NullProject()
            {
                EmployeeSqlDAO dao = new EmployeeSqlDAO(ConnectionString);

                IList<Employee> result = dao.GetEmployeesWithoutProjects();
                Assert.AreEqual(2, result.Count);
            }
            [TestMethod]
            public void Employee_NullProject1()
            {
                EmployeeSqlDAO dao = new EmployeeSqlDAO(ConnectionString);

                IList<Employee> result = dao.GetEmployeesWithoutProjects();
                IList<Employee> employees = new List<Employee>();
                Employee employee = new Employee();
                employee.EmployeeId = 45;
                employee.FirstName = "Rick";
                employee.LastName = "James";
                employee.JobTitle = "Boss";
                employee.Gender = "M";
                employee.BirthDate = new DateTime(1999, 11, 19);

                result.Add(employee);

                IList<Employee> allEmployees = dao.GetEmployeesWithoutProjects();

                Assert.AreEqual(result.Count, allEmployees.Count +1);
            }
        }
    }
}
