using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SSGeek.Web.Models;

namespace SSGeek.Web.DAL
{

    public class ForumPostSqlDAO : IForumPostDAO
    {
        private string ConnectionString { get; }

        public ForumPostSqlDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IList<ForumPost> GetAllPosts()
        {
            IList<ForumPost> posts = new List<ForumPost>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM forum_post", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ForumPost post = new ForumPost()
                        {
                            Subject = Convert.ToString(reader["subject"]),
                            UserName = Convert.ToString(reader["username"]),
                            Message = Convert.ToString(reader["message"]),
                            TimeOfPost = Convert.ToDateTime(reader["post_date"]),
                        };
                        posts.Add(post);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return posts;
        }

        public bool SaveNewPost(ForumPost post)
        {
            throw new NotImplementedException();
        }

        public bool AddNewPost(ForumPost post)
        {
            bool successful = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO forum_post (username, subject, message) VALUES (@username, @subject, @message);", conn);
                    cmd.Parameters.AddWithValue("@username", post.UserName);
                    cmd.Parameters.AddWithValue("@subject", post.Subject);
                    cmd.Parameters.AddWithValue("@message", post.Message);

                    cmd.ExecuteNonQuery();
                    successful = true;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return successful;
        }
    }
}
