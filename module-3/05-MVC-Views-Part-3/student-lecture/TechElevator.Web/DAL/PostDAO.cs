using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TechElevator.Web.Models; 

namespace TechElevator.Web.DAL
{
    public class PostDAO
    {
        string connectiontring; 

        public PostDAO(string connectionSring)
        {
            this.connectiontring = connectionSring;
        }
        public Post GetPost(int id)
        {
            Post post = new Post();

            SqlConnection conn = new SqlConnection(connectiontring);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM posts WHERE id = @id;", conn);

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                post.Id = Convert.ToInt32(reader["id"]);
                post.UserName = Convert.ToString(reader["userName"]);
                post.PostImage = Convert.ToString(reader["postImage"]);

            }

            return post;

        }

    public List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();

            SqlConnection conn = new SqlConnection(connectiontring);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM posts;", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Post post = new Post();

                post.Id = Convert.ToInt32(reader["id"]);
                post.UserName = Convert.ToString(reader["userName"]);
                post.PostImage = Convert.ToString(reader["postImage"]);

                posts.Add(post); 

            }



            return posts; 
        }
    }
}
