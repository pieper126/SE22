using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE22
{
    public class Category
    {
        public Category(int id, Category parentCategory)
        {
            this.ID = id;
            this.ParentCategory = parentCategory;
        }

        public int ID { get; private set; }

        public Category ParentCategory { get; private set; }
    }
}