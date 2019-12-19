using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using ProjectOrganizer.DAL;
using System.Collections;

namespace ProjectOrgTest
{
    class ProjectSqlDAOTest
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
            public void AddProject_Should_IncreaseCountBy1()

            {
                Project project = new Project();
                project.Name = "USA";
                project.StartDate = new DateTime(1990, 10, 02);
                project.EndDate = new DateTime(1999, 11, 19);
                ProjectSqlDAO dao = new ProjectSqlDAO(ConnectionString);
                int startingRowCount = GetRowCount("project");

                dao.CreateProject(project);

                int endingRowCount = GetRowCount("project");
                Assert.AreEqual(startingRowCount + 1, endingRowCount);
            }

            [TestMethod]
            public void Remove_and_Assign_Employee_From_Project()
            {
                ProjectSqlDAO dao = new ProjectSqlDAO(ConnectionString);

                dao.AssignEmployeeToProject(3,3);

                int beforeDeleteCount = GetRowCount("project_employee");

                bool result = dao.RemoveEmployeeFromProject(3,3);
                int afterDeleteCount = GetRowCount("project_employee");

                Assert.IsTrue(result, "Removed Employee From Project returned false");
                Assert.AreEqual(beforeDeleteCount - 1, afterDeleteCount, "Row count did not decrease.");
            }
            [TestMethod]
            public void Listing_All_Pojects()
            {
                ProjectSqlDAO dao = new ProjectSqlDAO(ConnectionString);
                IList<Project> result1 = dao.GetAllProjects();
                Project project = new Project();
                
                project.Name = "USA";
                project.StartDate = new DateTime(1990, 10, 02);
                project.EndDate = new DateTime(1999, 11, 19);

                dao.CreateProject(project);

               IList<Project> result2 = dao.GetAllProjects();

                Assert.AreEqual(result1.Count + 1, result2.Count); 

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
