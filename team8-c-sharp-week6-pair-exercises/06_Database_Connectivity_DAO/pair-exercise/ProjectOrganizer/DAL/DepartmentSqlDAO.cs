using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectOrganizer.DAL
{
    public class DepartmentSqlDAO : IDepartmentDAO
    {
        private string connectionString;
        private string sql_GetDepartments = "SELECT * FROM department ";
        private string sql_AddDepartment = "Insert into department(name) Values (@newDepartment)";
        private string sql_NewDepartment = "Select department_id from department where name = @newDepartment";
        private string sql_UpdateDepartment = "Update department set name = @updatedName Where department_id = @departmentId";

        // Single Parameter Constructor
        public DepartmentSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public void ListDepartments(Department department)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of all of the departments.
        /// </summary>
        /// <returns></returns>
        public IList<Department> GetDepartments()
        {
            IList<Department> departments = new List<Department>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_GetDepartments, conn))
                    {
                        //cmd.Parameters.AddWithValue("@department_id", departments);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Department department = new Department();

                            department.Name = Convert.ToString(reader["name"]);

                            departments.Add(department);

                        }
                        return departments;

                    }
                }
            }
            catch
            {
                departments = new List<Department>();
            }
            return departments;
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="newDepartment">The department object.</param>
        /// <returns>The id of the new department (if successful).</returns>
        public int CreateDepartment(Department newDepartment)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql_AddDepartment, conn))
                    {

                        cmd.Parameters.AddWithValue("@newDepartment", newDepartment.Name);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(sql_NewDepartment, conn))
                    {
                        cmd.Parameters.AddWithValue("@newDepartment", newDepartment.Name);
                        int result = Convert.ToInt32(cmd.ExecuteScalar());
                        return result;

                    }


                }
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="updatedDepartment">The department object.</param>
        /// <returns>True, if successful.</returns>
        public bool UpdateDepartment(Department updatedDepartment)
        {
            bool result = false;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql_UpdateDepartment, conn))
                    {

                        cmd.Parameters.AddWithValue("@departmentId", updatedDepartment.Id);
                        cmd.Parameters.AddWithValue("@updatedName", updatedDepartment.Name);
                        int count = cmd.ExecuteNonQuery();

                        if (count > 0)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}

