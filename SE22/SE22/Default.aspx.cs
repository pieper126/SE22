using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE22
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(MainAdministration.Threads.Count == 0)
            {
                while(MainAdministration.Threads.Count == 0)
                {
                    //
                }
            }
            foreach(ForumCategory gategory in MainAdministration.Categorys)
            {
                string something = string.Empty;
                string something1 = string.Empty;
                LblCategoryName.Text = gategory.Name;
            }
        }
    }
}