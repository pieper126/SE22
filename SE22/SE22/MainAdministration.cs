using System;
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

        public List<Category> Categorys { get; set; }

        public List<Thread> Threads { get; set; }

        /// <summary>
        /// Makes a new user
        /// </summary>
        /// <param name="username">username this person uses</param>
        /// <param name="email">email of this person</param>
        /// <param name="rights">rights this person holds</param>
        public void AddUser(string username, string email, List<Rights> rights)
        {

        }

        public void CreateNewThread(User user, string content, int id)
        {

        }

        public void DeletePost(int id)
        {

        }

        public void DeletePost(Post post)
        {

        }

        public void DeleteThread(int id)
        {

        }

        public void DeleteThread(Thread thread)
        {

        }
    }
}