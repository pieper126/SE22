//-----------------------------------------------------------------------
// <copyright file="Rights.cs" company="SE22">
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
    /// All the rights accounts can have
    /// </summary>
    public enum Rights
    {
        /// <summary>
        /// Moderator controls the forum
        /// </summary>
        Moderator,

        /// <summary>
        /// Editor is allowed to post articles
        /// </summary>
        Editor
    }
}