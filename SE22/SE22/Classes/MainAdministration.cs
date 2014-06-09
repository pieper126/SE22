//-----------------------------------------------------------------------
// <copyright file="MainAdministration.cs" company="SE22">
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
    /// The main Administration
    /// </summary>
    public class MainAdministration
    {
        /// <summary>
        /// Gets All category's
        /// </summary>
        public static List<ForumCategory> Categorys { get; private set; }

        /// <summary>
        /// Gets All threads
        /// </summary>
        public static List<ForumThread> Threads { get; private set; }

        /// <summary>
        /// Makes a new user
        /// </summary>
        /// <param name="username">username this person uses</param>
        /// <param name="email">email of this person</param>
        /// <param name="rights">rights this person holds</param>
        public static void AddUser(string username, string email, List<Rights> rights)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new thread
        /// </summary>
        /// <param name="user"> User that posted this thread</param>
        /// <param name="content">content of the first post</param>
        /// <param name="category">category this thread belongs to</param>
        /// <param name="threadName">name of this thread</param>
        public static void CreateNewThread(User user, string content, ForumCategory category, string threadName)
        {
            DatabaseManager.CreateNewThread(user.Username, category.ID, content, threadName);
        }

        /// <summary>
        /// create a new post
        /// </summary>
        /// <param name="user">User that posted this post</param>
        /// <param name="content">Content of this post</param>
        /// <param name="thread">thread this post belongs to</param>
        public static void CreateNewPost(User user, string content, ForumThread thread)
        {
            DatabaseManager.CreateNewPost(thread.ID, content, user.Username);
        }

        /// <summary>
        /// Deletes a Post
        /// </summary>
        /// <param name="id">id is used to identify the post <see cref="Post"/></param>
        public static void DeletePost(int id)
        {
            DatabaseManager.DeletePost(id);
        }

        /// <summary>
        /// Deletes a Post
        /// </summary>
        /// <param name="post">Post that needs to be deleted</param>
        public static void DeletePost(Post post)
        {
            DatabaseManager.DeletePost(post.ID);
        }

        /// <summary>
        /// Deletes a thread
        /// </summary>
        /// <param name="id">id is used to identify the post <see cref="Thread"/></param>
        public static void DeleteThread(int id)
        {
            DatabaseManager.DeleteThread(id);
        }

        /// <summary>
        /// Deletes a thread
        /// </summary>
        /// <param name="thread">thread that needs to be deleted</param>
        public static void DeleteThread(ForumThread thread)
        {
            DatabaseManager.DeleteThread(thread.ID);
        }

        /// <summary>
        /// Delete a object
        /// It must either be a <see cref="Thread"/> or a <see cref="Post"/>
        /// </summary>
        /// <param name="o">object that needs to be deleted</param>
        /// <exception cref="InvalidCastException">Gets thrown when the object Isn't supported</exception>
        public static void DeleteObject(object o)
        {
            if (o is ForumThread)
            {
                DatabaseManager.DeleteThread(((ForumThread)o).ID);
            }
            else if (o is Post)
            {
                DatabaseManager.DeletePost(((Post)o).ID);
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// Alters a object
        /// It must either be a <see cref="Thread"/> or a <see cref="Post"/>
        /// </summary>
        /// <param name="o">The object that needs to be altered</param>
        /// <exception cref="InvalidCastException">Gets thrown when the object Isn't supported</exception>
        public static void AlterObject(object o)
        {
            List<string> parameterToChange;
            List<string> changes;
            if (o is ForumThread)
            {
                ForumThread forumThread = (ForumThread)o;
                parameterToChange = new List<string>() { "THREADNAME" };
                changes = new List<string>() { forumThread.Name };
                DatabaseManager.AlterThread(forumThread.ID, changes, parameterToChange);
            }
            else if (o is Post)
            {
                Post post = (Post)o;
                parameterToChange = new List<string>() { "INHOUD" };
                changes = new List<string>() { post.Content };
                DatabaseManager.AlterPost(post.ID, changes, parameterToChange);
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// Configures the Administration
        /// </summary>
        public static void StartUp()
        {
            Categorys = DatabaseManager.UpdateCategorys();
            Threads = DatabaseManager.UpdateThreads();
        }

        /// <summary>
        /// verifies a user
        /// </summary>
        /// <param name="username">username is used to verify the user</param>
        /// <param name="password">password is used to verify the user</param>
        /// <returns>User that you just verified</returns>
        public static User Inlog(string username, string password)
        {
            User user = null;

            try
            {
                user = DatabaseManager.LogIn(username, password);
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }

        /// <summary>
        /// returns the up to date version of the given category
        /// </summary>
        /// <param name="id">id used identify the category</param>
        /// <returns>forum threads that belong to the given category</returns>
        public static List<ForumThread> GiveAllThreadsOfAGivenCategory(int id)
        {
            return DatabaseManager.GiveAllThreadsOfAGivenCategory(id);
        }

        /// <summary>
        /// returns the up to date version of the given thread
        /// </summary>
        /// <param name="id">id used to identify the thread</param>
        /// <returns>forum thread that belongs to the given ID</returns>
        public static ForumThread UpdateThread(int id)
        {
            return DatabaseManager.UpdateThread(id);
        }

        /// <summary>
        /// counts the number of threads in a given category
        /// </summary>
        /// <param name="category">is used to identify what category you want</param>
        /// <returns>The number of posts that belong to the given category</returns>
        public static int NumberofThreadsPerCategory(ForumCategory category)
        {
            return Threads.FindAll(x => x.Category.ID == category.ID).Count;
        }
    }
}