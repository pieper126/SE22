//-----------------------------------------------------------------------
// <copyright file="ForumThread.cs" company="SE22">
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
    /// represents a thread in the forum
    /// </summary>
    public class ForumThread
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForumThread"/> class.
        /// </summary>
        /// <param name="id">id used to identify this thread</param>
        /// <param name="posts">posts this thread holds</param>
        /// <param name="category">category this thread is part of</param>
        /// <param name="name">name of this thread</param>
        /// <param name="username">username of the person that posted this thread</param>
        public ForumThread(int id, List<Post> posts, ForumCategory category, string name, string username)
        {
            this.ID = id;
            this.Posts = posts;
            this.Category = category;
            this.Name = name;
            this.Username = username;
        }

        /// <summary>
        /// Gets the Posts of this thread
        /// </summary>
        public List<Post> Posts { get; private set; }

        /// <summary>
        /// Gets the category of this thread
        /// </summary>
        public ForumCategory Category { get; private set; }

        /// <summary>
        /// Gets the ID used to identify this thread
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Gets the name of this thread
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the username of the person that posted this thread
        /// </summary>
        public string Username { get; private set; }
    }
}