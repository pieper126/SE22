﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE22
{
    public class MainAdministration
    {
        public MainAdministration()
        {

        }

        /// <summary>
        /// All categorys
        /// </summary>
        public static List<ForumCategory> Categorys { get; private set; }

        /// <summary>
        /// All threads
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

        }

        public static void CreateNewThread(User user, string content, ForumCategory category, string threadName)
        {
            DatabaseManager.CreateNewThread(user.Username, category.ID, content, threadName);
        }

        public static void CreateNewPost(User user, string content, ForumThread thread)
        {
            DatabaseManager.CreateNewPost(thread.ID, content, user.Username);
        }

        public static void DeletePost(int id)
        {
            DatabaseManager.DeletePost(id);
        }

        public static void DeletePost(Post post)
        {
            DatabaseManager.DeletePost(post.ID);
        }

        public static void DeleteThread(int id)
        {
            DatabaseManager.DeleteThread(id);
        }

        public static void DeleteThread(ForumThread thread)
        {
            DatabaseManager.DeleteThread(thread.ID);
        }

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

        public static void StartUp()
        {
            Categorys = DatabaseManager.UpdateCategorys();
            Threads = DatabaseManager.UpdateThreads();
        }

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

        public static List<ForumThread> GiveAllThreadsOfAGivenCategory(int id)
        {
            return DatabaseManager.GiveAllThreadsOfAGivenCategory(id);
        }

        public static ForumThread UpdateThread(int ID)
        {
            return DatabaseManager.UpdateThread(ID);
        }

        public static int NumberofThreadsPerCategory(ForumCategory category)
        {
            return (Threads.FindAll(x => x.Category.ID == category.ID)).Count;
        }
    }
}