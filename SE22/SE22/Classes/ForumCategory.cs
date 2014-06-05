//-----------------------------------------------------------------------
// <copyright file="ForumCategory.cs" company="SE22">
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
    /// represents a category on the forum
    /// </summary>
    public class ForumCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForumCategory"/> class.
        /// </summary>
        /// <param name="id">used to identify the category</param>
        /// <param name="parentCategory">the parent of this category</param>
        /// <param name="name">Name of this category</param>
        public ForumCategory(int id, ForumCategory parentCategory, string name)
        {
            this.ID = id;
            this.ParentCategory = parentCategory;
            this.Name = name;
        }

        /// <summary>
        /// Gets the id used to identify the category
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Gets the parent of this category
        /// </summary>
        public ForumCategory ParentCategory { get; private set; }

        /// <summary>
        /// Gets the name of this category
        /// </summary>
        public string Name { get; private set; }
    }
}