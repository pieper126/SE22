using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE22
{
    public class ForumThread
    {
        public ForumThread(int id, List<Post> posts, ForumCategory category, string name)
        {
            this.ID = id;
            this.Posts = posts;
            this.Category = category;
            this.Name = name;
        }

        public List<Post> Posts { get; private set; }

        public ForumCategory Category { get; private set; }

        public int ID { get; private set; }

        public string Name { get; private set; }

        public void AddPost(Post post, User user)
        {

        }
    }
}