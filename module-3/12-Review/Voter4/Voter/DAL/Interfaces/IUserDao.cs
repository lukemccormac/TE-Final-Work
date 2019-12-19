using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voter.Models;

namespace Voter.DAL.Interfaces
{
    public interface IUserDao
    {
        /// <summary>
        /// Look for a user with the given username and password. Since we don't
        /// know the password, we will have to get the user's salt from the database,
        /// hash the password, and compare that against the hash in the database.
        /// </summary>
        /// <returns>true if the user is found and their password matches.</returns>
        /// <param name="userName">The user name of the user we are checking.</param>
        /// <param name="password">The password of the user we are checking.</param>
        bool IsUsernameAndPasswordValid(string userName, string password);

        /// <summary>
        /// Save a new user to the database. The password that is passed in will be
        /// salted and hashed before being saved. The original password is never
        /// stored in the system. We will never have any idea what it is!
        /// </summary>
        /// <returns>The new user.</returns>
        /// <param name="username">The username to give the new user.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="role">The user's role. 0 for user, 1 for admin.</param>
        User SaveUser(string userName, string password, int role);


        /// <summary>Get all of the users from the database.</summary>
        /// <returns>A List of user objects.</returns>
        IList<User> GetAllUsers();

        User GetUserByUserName(string userName);
    }
}
