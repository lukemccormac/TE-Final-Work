using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Voter.DAL.Interfaces;
using Voter.Models;
using Voter.Security;

namespace Voter.DAL
{
    public class UserDao : IUserDao

    {
        private readonly string connectionString;
        private readonly PasswordHasher passwordHasher;

        private readonly string sql_GetAllUsers = "SELECT id, username, role FROM users";

        private readonly string sql_GetUserByUserName = "SELECT id, username, role FROM users " +
            "WHERE username = @username;";

        private readonly string sql_IsUsernameAndPasswordValid = "SELECT password, salt FROM users WHERE username = @username;";

        private readonly string sql_SaveUser = @"INSERT INTO users(username, password, salt, role) " +
            "VALUES(@username, @password, @salt, @role); " +
            "SELECT SCOPE_IDENTITY();";

        /// <summary>
        /// Create a new user dao with the supplied data source and the password hasher
        /// that will salt and hash all the passwords for users.
        /// </summary>
        /// <param name="connectionString">database connection string</param>
        public UserDao(string connectionString)
        {
            PasswordHasher passwordHasher = new PasswordHasher();
            this.connectionString = connectionString;
            this.passwordHasher = passwordHasher;
        }

        public IList<User> GetAllUsers()
        {
            IList<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql_GetAllUsers;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Username = Convert.ToString(reader["username"]),
                        Role = Convert.ToInt32(reader["role"])
                    });
                }
            }

            return users;
        }

        public User GetUserByUserName(string userName)
        {
            User user = new User();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = sql_GetUserByUserName;

                    command.Parameters.AddWithValue("@username", userName);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {

                        user.Id = Convert.ToInt32(reader["id"]);
                        user.Username = Convert.ToString(reader["username"]);
                        user.Role = Convert.ToInt32(reader["role"]);

                    }
                }
            }
            catch (Exception ex)
            {
                user = new User();
            }

            return user;
        }

        public bool IsUsernameAndPasswordValid(string userName, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql_IsUsernameAndPasswordValid;
                command.Parameters.AddWithValue("@username", userName);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string storedPassword = (string)reader["password"];
                    string storedSalt = (string)reader["salt"];
                    string computedHash = passwordHasher.ComputeHash(password, Convert.FromBase64String(storedSalt));

                    return computedHash.Equals(storedPassword);
                }

                return false;
            }
        }

        public User SaveUser(string username, string password, int role)
        {
            User user = new User();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    byte[] salt = passwordHasher.GenerateRandomSalt();
                    string hashedPassword = passwordHasher.ComputeHash(password, salt);

                    connection.Open();

                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = sql_SaveUser;

                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", hashedPassword);
                    command.Parameters.AddWithValue("@salt", Convert.ToBase64String(salt));
                    command.Parameters.AddWithValue("@role", role);

                    int id = Convert.ToInt32(command.ExecuteScalar());

                    user.Id = id;
                    user.Username = username;
                    user.Role = role;
                }
            }
            catch (Exception ex)
            {
                user = new User();
            }

            return user;
        }
    }
}
