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
            if (Session["PreviousPage"] != "Main")
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
            if (Categorys.Count > 3)
            {
                HyperLink1.Text = Categorys[0].Name;
                HyperLink2.Text = Categorys[1].Name;
                HyperLink3.Text = Categorys[2].Name;
                HyperLink4.Text = Categorys[3].Name;
                LblTotalThreads1.Text = MainAdministration.NumberofThreadsPerCategory(Categorys[0]).ToString();
                LblTotalThreads2.Text = MainAdministration.NumberofThreadsPerCategory(Categorys[1]).ToString();
                LblTotalThreads3.Text = MainAdministration.NumberofThreadsPerCategory(Categorys[2]).ToString();
                LblTotalThreads4.Text = MainAdministration.NumberofThreadsPerCategory(Categorys[3]).ToString();

                HyperLink1.Visible = true;
                HyperLink2.Visible = true;
                HyperLink3.Visible = true;
                HyperLink4.Visible = true;
                LblTotalThreads1.Visible = true;
                LblTotalThreads2.Visible = true;
                LblTotalThreads3.Visible = true;
                LblTotalThreads4.Visible = true;
                CategoryButton1.Visible = true;
                CategoryButton2.Visible = true;
                CategoryButton3.Visible = true;
                CategoryButton4.Visible = true;
            }
            else if (Categorys.Count > 2)
            {
                HyperLink1.Text = Categorys[0].Name;
                HyperLink2.Text = Categorys[1].Name;
                HyperLink3.Text = Categorys[2].Name;
                LblTotalThreads1.Text = MainAdministration.NumberofThreadsPerCategory(Categorys[0]).ToString();
                LblTotalThreads2.Text = MainAdministration.NumberofThreadsPerCategory(Categorys[1]).ToString();
                LblTotalThreads3.Text = MainAdministration.NumberofThreadsPerCategory(Categorys[2]).ToString();

                HyperLink1.Visible = true;
                HyperLink2.Visible = true;
                HyperLink3.Visible = true;
                LblTotalThreads1.Visible = true;
                LblTotalThreads2.Visible = true;
                LblTotalThreads3.Visible = true;
                CategoryButton1.Visible = true;
                CategoryButton2.Visible = true;
                CategoryButton3.Visible = true;
            }
            else if (Categorys.Count > 1)
            {
                HyperLink1.Text = Categorys[0].Name;
                HyperLink2.Text = Categorys[1].Name;
                LblTotalThreads1.Text = MainAdministration.NumberofThreadsPerCategory(Categorys[0]).ToString();
                LblTotalThreads2.Text = MainAdministration.NumberofThreadsPerCategory(Categorys[1]).ToString();

                HyperLink1.Visible = true;
                HyperLink2.Visible = true;
                LblTotalThreads1.Visible = true;
                LblTotalThreads2.Visible = true;
                CategoryButton1.Visible = true;
                CategoryButton2.Visible = true;
            }
            else if (Categorys.Count > 0)
            {
                HyperLink1.Text = Categorys[0].Name;
                LblTotalThreads1.Text = MainAdministration.NumberofThreadsPerCategory(Categorys[0]).ToString();

                HyperLink1.Visible = true;
                LblTotalThreads1.Visible = true;
                CategoryButton1.Visible = true;
            }
        }
    }
}