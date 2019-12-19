using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TechElevator.Web.Models;

namespace TechElevator.Web.DAL
{
    public class PostDao
    {
        string connectionString;

        public PostDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM posts;", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Post post = new Post();

                    post.Id = Convert.ToInt32(reader["id"]);
                    post.UserName = Convert.ToString(reader["username"]);
                    post.PostImage = Convert.ToString(reader["postImage"]);

                    posts.Add(post);
                }
            }
            catch (Exception ex)
            {

            }

            return posts;
        }

        public Post GetPost(int id)
        {
            Post post = new Post();

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM posts WHERE id = @id;", conn);

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                post.Id = Convert.ToInt32(reader["id"]);
                post.UserName = Convert.ToString(reader["username"]);
                post.PostImage = Convert.ToString(reader["postImage"]);
            }

            return post;
        }
    }
}
