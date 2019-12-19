using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;

namespace ProjectOrgTest
{

    class DepartmentSqlDAOTest
    {
        [TestClass]
        public class DepartmentSqlDAOTests
        {
           // private string sql_UpdateDepartment = "Update department set name = Russia Where department_id = 45";


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
            public void Listing_All_Departments()
            {
                DepartmentSqlDAO dao = new DepartmentSqlDAO(ConnectionString);
                IList<Department> result = dao.GetDepartments();
                Department Departments = new Department();

                Departments.Name = "USA";

                dao.CreateDepartment(Departments);

                IList<Department> result2 = dao.GetDepartments();

                Assert.AreEqual(result.Count + 1, result2.Count);

            }
            [TestMethod]
            public void Creating_New_Department()
            {
                Department Department = new Department();
                Department.Name = "USA";
                DepartmentSqlDAO dao = new DepartmentSqlDAO(ConnectionString);
                int startingRowCount = GetRowCount("Department");
                dao.CreateDepartment(Department);
                int endingRowCount = GetRowCount("Department");

                Assert.AreEqual(startingRowCount+1, endingRowCount);

            }
            [TestMethod]
            public void UpdateDepartment_Test()
            {
                Department Department = new Department();
                Department.Id = 45;
                Department.Name = "USA";
                DepartmentSqlDAO dao = new DepartmentSqlDAO(ConnectionString);
                dao.CreateDepartment(Department);
                Department.Name = "Russia";
                dao.UpdateDepartment(Department);
                

                Assert.AreEqual("Russia", Department.Name);

            }


            protected int GetRowCount(string table)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
        }
    }
}
