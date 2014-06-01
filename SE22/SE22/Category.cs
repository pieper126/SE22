using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE22
{
    public class ForumCategory
    {
        public ForumCategory(int id, ForumCategory parentCategory, string name)
        {
            this.ID = id;
            this.ParentCategory = parentCategory;
            this.Name = name;
        }

        public int ID { get; private set; }

        public ForumCategory ParentCategory { get; private set; }

        public string Name { get; private set; }
    }
}