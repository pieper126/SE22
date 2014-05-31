using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE22
{
    public class Thread
    {
        public Thread(int id, string content, User user)
        {

        }

        public Thread(int id, List<Post> posts)
        {

        }

        public List<Post> Posts { get; private set; }

        public Category Thread { get; private set; }

        public void AddPost(Post post, User user)
        {

        }
    }
}