using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectOrganizer.DAL
{
    public class ProjectSqlDAO : IProjectDAO
    {
        private string connectionString;
        private string sql_GetProjects = "SELECT * FROM project";
        private string sql_AddToProject = "insert into project_employee(project_id, employee_id) Values(@projectId, @employeeId);";
        private string sql_NewProject = "Select project_id from project where name = @name;";
        private string sql_AddProject = "Insert into project(name,from_date,to_date) Values (@name, @from_date, @to_date);";
        private string sql_DeleteProjectFromEmployee = "DELETE FROM project_employee where employee_id = @employeeId and project_id = @projectId;";

        // Single Parameter Constructor
        public ProjectSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns all projects.
        /// </summary>
        /// <returns></returns>
        public IList<Project> GetAllProjects()
        {
            IList<Project> projects = new List<Project>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_GetProjects, conn))
                    {
                        //cmd.Parameters.AddWithValue("@department_id", departments);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Project project = new Project();

                            project.ProjectId = Convert.ToInt32(reader["project_id"]);
                            project.Name = Convert.ToString(reader["name"]);
                            project.StartDate = Convert.ToDateTime(reader["from_date"]);
                            project.EndDate = Convert.ToDateTime(reader["to_date"]);

                            projects.Add(project);

                        }
                        return projects;

                    }
                }
            }
            catch
            {
                projects = new List<Project>();
            }
            return projects;
        }

        /// <summary>
        /// Assigns an employee to a project using their IDs.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool AssignEmployeeToProject(int projectId, int employeeId)
        {
            bool result = false;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql_AddToProject, conn))
                    {

                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@projectId", projectId);
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

        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql_DeleteProjectFromEmployee, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@projectId", projectId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred removing the employee from the project.");
                throw;
            }

            return true;
        }

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="newProject">The new project object.</param>
        /// <returns>The new id of the project.</returns>
        public int CreateProject(Project newProject)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql_AddProject, conn))
                    {

                        cmd.Parameters.AddWithValue("@name", newProject.Name);
                        cmd.Parameters.AddWithValue("@from_date", newProject.StartDate);
                        cmd.Parameters.AddWithValue("@to_date", newProject.EndDate);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(sql_NewProject, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", newProject.Name);
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

    }
}
