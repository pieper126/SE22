//-----------------------------------------------------------------------
// <copyright file="User.cs" company="SE22">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace SE22
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Represents a user
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="username">username to identify this user</param>
        /// <param name="email">email of this user</param>
        /// <param name="functions">functions of this user</param>
        public User(string username, string email, List<Rights> functions)
        {
            this.Username = username;
            this.Email = email;
            this.Functions = functions;
        }

        /// <summary>
        /// Gets the username used to identify this user
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets or sets the email of this user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets the functions of this person possesses 
        /// </summary>
        public List<Rights> Functions { get; private set; }
    }
}