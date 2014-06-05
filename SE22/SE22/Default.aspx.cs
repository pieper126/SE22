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
        public List<ForumCategory> TopCategorys { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MainAdministration.StartUp();
            TopCategorys = MainAdministration.Categorys.FindAll(x => x.ParentCategory == null);                   
            initialization();
            Session["NextPage"] = string.Empty;
        }

        private void initialization()
        {
            panel.Visible = true;
            foreach (ForumCategory category in TopCategorys)
            {
                PostThread control = (PostThread)LoadControl("PostThread.ascx");
                control.UrlNextPage = "~/SubCategory.aspx";
                control.ObjectOfTHeControl = category;
                control.TypeOfObject = "Category";
                control.Visible = true;
                control.SetHyperLink(category.Name);
                control.EnableHyperlink();
                control.SetLabel(MainAdministration.NumberofThreadsPerCategory(category).ToString());
                control.EnableLabel();
                control.EnableGo();
                panel.Controls.Add(control);
            }

            if (panel.Controls.Count < 10)
            {
                int counter = (10 - panel.Controls.Count)/2;

                for (int i = 0; i < counter; i++)
                {
                    PostThread control = (PostThread)LoadControl("PostThread.ascx");
                    panel.Controls.Add(control);
                }
            }
        }
    }
}