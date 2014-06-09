using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE22
{
    public class Post
    {
        public Post(int id, string content, string username)
        {
            this.ID = id;
            this.Content = content;
            this.Username = username;
        }

        public string Content { get; set; }

        public int ID { get; private set; }

        public string Username { get; private set; }
    }
}