using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE22
{
    public partial class SubCategory : System.Web.UI.Page
    {
        public List<ForumCategory> Categorys { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PreviousPage"] == null || Session["PreviousPage"].ToString() != "Category:")
            {
                Page.Response.Redirect("Default");
                return;
            }
            Categorys = MainAdministration.Categorys.FindAll(x => x.ParentCategory != null);
            Categorys = Categorys.FindAll(x => x.ParentCategory.ID == ((ForumCategory)Session["NextPage"]).ID);
            initialization();
        }

        private void initialization()
        {
            panel.Visible = true;
            foreach (ForumCategory category in Categorys)
            {
                PostThread control = (PostThread)LoadControl("PostThread.ascx");
                control.UrlNextPage = "~/Category.aspx";
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

            if (panel.Controls.Count < 5)
            {
                int counter = 5 - panel.Controls.Count;

                for (int i = 0; i < counter; i++)
                {
                    PostThread control = (PostThread)LoadControl("PostThread.ascx");
                    panel.Controls.Add(control);
                }
            }
        }
    }
}