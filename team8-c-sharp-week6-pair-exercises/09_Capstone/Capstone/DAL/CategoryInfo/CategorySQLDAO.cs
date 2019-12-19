using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL.CategoryInfo
{
    public class CategorySQLDAO : ICategoryDAO
    {
        private string sql_GetCategories = "Select * from category_venue " +
            "Join category ON category_venue.category_id = category.id WHERE venue_id = @input ";
        private string connectionString;
        public CategorySQLDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public IList<Category> GetAllCategories(int input)
        {
            IList<Category> categories = new List<Category>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_GetCategories, conn))
                    {
                        cmd.Parameters.AddWithValue("@input", input);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Category category = ConvertReaderToCategory(reader);
                            categories.Add(category);
                        }
                    }
                    return categories;
                }
            }
            catch (SqlException ex)
            {
                categories = new List<Category>();
            }
            return categories;
        }
        public Category ConvertReaderToCategory(SqlDataReader reader)
        {
            Category category = new Category();

            category.ID = Convert.ToInt32(reader["id"]);
            category.Name = Convert.ToString(reader["name"]);

            return category;
        }
    }
    }

