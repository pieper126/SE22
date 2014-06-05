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

        protected void CategoryButton1_Click(object sender, EventArgs e)
        {
            Session["NextPage"] = Categorys[0];
            Session["PreviousPage"] = "SubCategory";
            Page.Response.Redirect("Category");
        }

        protected void CategoryButton2_Click(object sender, EventArgs e)
        {
            Session["NextPage"] = Categorys[1];
            Session["PreviousPage"] = "SubCategory";
            Page.Response.Redirect("Category");
        }

        protected void CategoryButton3_Click(object sender, EventArgs e)
        {
            Session["NextPage"] = Categorys[2];
            Session["PreviousPage"] = "SubCategory";
            Page.Response.Redirect("Category");
        }

        protected void CategoryButton4_Click(object sender, EventArgs e)
        {
            Session["NextPage"] = Categorys[3];
            Session["PreviousPage"] = "SubCategory";
            Page.Response.Redirect("Category");
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

            if (panel.Controls.Count < 10)
            {
                int counter = (10 - panel.Controls.Count) / 2;

                for (int i = 0; i < counter; i++)
                {
                    PostThread control = (PostThread)LoadControl("PostThread.ascx");
                    panel.Controls.Add(control);
                }
            }
        }
    }
}