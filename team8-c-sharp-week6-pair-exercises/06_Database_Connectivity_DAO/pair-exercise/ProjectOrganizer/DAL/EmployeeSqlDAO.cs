using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectOrganizer.DAL
{
    public class EmployeeSqlDAO : IEmployeeDAO
    {
        private string connectionString;
        private string sql_GetAllEmployees = "SELECT * FROM Employee";
        private string sql_SearchEmployees = "Select * from Employee where first_name like '%'+@firstname+'%' "+
            "or last_name like '%'+@lastname+'%'";
        private string sql_NoProject = "select * from employee e " +
        "full outer join project_employee on e.employee_id = project_employee.employee_id " +
        "where project_id is null;";

        // Single Parameter Constructor
        public EmployeeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the employees.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        public IList<Employee> GetAllEmployees()
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_GetAllEmployees, conn))
                    {
                        //cmd.Parameters.AddWithValue("@Employee_id", Employees);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Employee Employee = new Employee();

                            Employee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                            Employee.DepartmentId = Convert.ToInt32(reader["department_id"]);
                            Employee.JobTitle = Convert.ToString(reader["job_title"]);
                            Employee.FirstName = Convert.ToString(reader["first_name"]);
                            Employee.LastName = Convert.ToString(reader["last_name"]);
                            Employee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                            Employee.Gender = Convert.ToString(reader["gender"]);
                            Employee.HireDate = Convert.ToDateTime(reader["hire_date"]);

                            employees.Add(Employee);

                        }
                        return employees;

                    }
                }
            }
            catch
            {
                employees = new List<Employee>();
            }
            return employees;
        }

        /// <summary>
        /// Searches the system for an employee by first name or last name.
        /// </summary>
        /// <remarks>The search performed is a wildcard search.</remarks>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns>A list of employees that match the search.</returns>
        public IList<Employee> Search(string firstname, string lastname)
        {
            IList<Employee> search = new List<Employee>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_SearchEmployees, conn))
                    {
                        cmd.Parameters.AddWithValue("@firstname", firstname);
                        cmd.Parameters.AddWithValue("@lastname", lastname);

                        
                        SqlDataReader reader = cmd.ExecuteReader();
                 
                        while (reader.Read())
                        {
                            Employee employee = new Employee();
                            employee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                            employee.FirstName = Convert.ToString(reader["first_name"]);
                            employee.LastName = Convert.ToString(reader["last_name"]);
                            employee.JobTitle = Convert.ToString(reader["job_title"]);
                            employee.Gender = Convert.ToString(reader["gender"]);
                            employee.BirthDate = Convert.ToDateTime(reader["birth_date"]);


                            search.Add(employee);

                        }
                        return search;

                    }
                }
            }
            catch(Exception ex)
            {
                search = new List<Employee>();
            }
            return search;
        }

        /// <summary>
        /// Gets a list of employees who are not assigned to any active projects.
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetEmployeesWithoutProjects()
        {
            IList<Employee> search = new List<Employee>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_NoProject, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Employee employee = new Employee();
                            employee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                            employee.FirstName = Convert.ToString(reader["first_name"]);
                            employee.LastName = Convert.ToString(reader["last_name"]);
                            employee.JobTitle = Convert.ToString(reader["job_title"]);
                            employee.Gender = Convert.ToString(reader["gender"]);
                            employee.BirthDate = Convert.ToDateTime(reader["birth_date"]);


                            search.Add(employee);

                        }
                        return search;

                    }
                }
            }
            catch (Exception ex)
            {
                search = new List<Employee>();
            }
            return search;
        }
    }
}
