using Post.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Web.DAL
{
    public class ReviewSqlDAO : IReviewDAO
    {
        private  string ConnectionString { get; }

        public ReviewSqlDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all reviews
        /// </summary>
        /// <returns></returns>
        public IList<Review> GetAllReviews()
        {
            IList<Review> posts = new List<Review>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM reviews ", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Review review = new Review()
                        {
                            Id = Convert.ToInt32(reader["review_id"]),
                            Username = Convert.ToString(reader["username"]),
                            Rating = Convert.ToInt32(reader["rating"]),
                            ReviewTitle = Convert.ToString(reader["review_title"]),
                            ReviewText = Convert.ToString(reader["review_text"]),
                            ReviewDate = Convert.ToDateTime(reader["review_date"]),
                        };
                        posts.Add(review);
                    }
                }
            }
            catch (SqlException ex)
            {
             
            }
            return posts;
        }

        /// <summary>
        /// Saves a new review to the system.
        /// </summary>
        /// <param name="newReview"></param>
        /// <returns></returns>
        public int SaveReview(Review newReview)
        {
            int result = 4;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO reviews (username, rating, review_title, review_text, review_date) VALUES (@username, @rating, @reviewtitle, @reviewtext, @reviewdate);", conn);

                    cmd.Parameters.AddWithValue("@username", newReview.Username);
                    cmd.Parameters.AddWithValue("@rating", newReview.Rating);
                    cmd.Parameters.AddWithValue("@reviewtitle", newReview.ReviewTitle);
                    cmd.Parameters.AddWithValue("@reviewtext", newReview.ReviewText);
                    cmd.Parameters.AddWithValue("@reviewdate", newReview.ReviewDate);

                    cmd.ExecuteNonQuery();
                }
                
            }
            
            catch (SqlException ex)
            {
              
            }
            return result++;
        }
    }
}
