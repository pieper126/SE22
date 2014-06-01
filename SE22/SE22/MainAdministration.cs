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
        /// 
        /// </summary>
        public static List<ForumCategory> Categorys { get; private set; }

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

        public static void CreateNewThread(User user, string content, int id)
        {

        }

        public static void DeletePost(int id)
        {

        }

        public static void DeletePost(Post post)
        {
            DatabaseManager.DeletePost(post.ID);
        }

        public static void DeleteThread(int id)
        {

        }

        public static void DeleteThread(Thread thread)
        {

        }

        public static void StartUp()
        {
            Categorys = DatabaseManager.UpdateCategorys();
            Threads = DatabaseManager.UpdateThreads();
        }
    }
}