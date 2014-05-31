using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE22
{
    public class Post
    {
        public Post(int id, string content)
        {
            this.ID = id;
            this.Content = content;
        }

        public string Content { get; private set; }

        public int ID { get; private set; }
    }
}