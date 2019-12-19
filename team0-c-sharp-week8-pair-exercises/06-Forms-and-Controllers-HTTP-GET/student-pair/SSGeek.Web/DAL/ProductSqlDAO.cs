using SSGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.DAL
{
    public class ProductSqlDAO : IProductDAO
    {
        private string ConnectionString { get; }

        public ProductSqlDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public Product GetProduct(int id)
        {
            Product product = new Product();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM products WHERE product_id = @id ", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        product.Name = Convert.ToString(reader["name"]);
                        product.Description = Convert.ToString(reader["description"]);
                        product.Price = Convert.ToDecimal(reader["price"]);
                        product.ImageName = Convert.ToString(reader["image_name"]);
                        product.ProductId = Convert.ToInt32(reader["product_id"]);
                    };

                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return product;
        }

        public IList<Product> GetProducts()
        {
            IList<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM products", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product();
                        {
                            product.Name = Convert.ToString(reader["name"]);
                            product.Description = Convert.ToString(reader["description"]);
                            product.Price = Convert.ToDecimal(reader["price"]);
                            product.ImageName = Convert.ToString(reader["image_name"]);
                            product.ProductId = Convert.ToInt32(reader["product_id"]);
                        };
                        products.Add(product);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return products;
        }


    }

}
