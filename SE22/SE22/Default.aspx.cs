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
        }

        protected void CategoryButton1_Click(object sender, EventArgs e)
        {
            Session["NextPage"] = TopCategorys[0];
            Session["PreviousPage"] = "Main";
            Page.Response.Redirect("SubCategory");
        }

        protected void CategoryButton2_Click(object sender, EventArgs e)
        {
            Session["NextPage"] = TopCategorys[1];
            Session["PreviousPage"] = "Main";
            Page.Response.Redirect("SubCategory");
        }

        protected void CategoryButton3_Click(object sender, EventArgs e)
        {
            Session["NextPage"] = TopCategorys[2];
            Session["PreviousPage"] = "Main";
            Page.Response.Redirect("SubCategory");
        }

        protected void CategoryButton4_Click(object sender, EventArgs e)
        {
            Session["NextPage"] = TopCategorys[3];
            Session["PreviousPage"] = "Main";
            Page.Response.Redirect("SubCategory");
        }

        private void initialization()
        {
            if (TopCategorys.Count > 3)
            {
                HyperLink1.Text = TopCategorys[0].Name;
                HyperLink2.Text = TopCategorys[1].Name;
                HyperLink3.Text = TopCategorys[2].Name;
                HyperLink4.Text = TopCategorys[3].Name;
                LblTotalThreads1.Text = MainAdministration.NumberofThreadsPerCategory(TopCategorys[0]).ToString();
                LblTotalThreads2.Text = MainAdministration.NumberofThreadsPerCategory(TopCategorys[1]).ToString();
                LblTotalThreads3.Text = MainAdministration.NumberofThreadsPerCategory(TopCategorys[2]).ToString();
                LblTotalThreads4.Text = MainAdministration.NumberofThreadsPerCategory(TopCategorys[3]).ToString();

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
            else if (TopCategorys.Count > 2)
            {
                HyperLink1.Text = TopCategorys[0].Name;
                HyperLink2.Text = TopCategorys[1].Name;
                HyperLink3.Text = TopCategorys[2].Name;
                LblTotalThreads1.Text = MainAdministration.NumberofThreadsPerCategory(TopCategorys[0]).ToString();
                LblTotalThreads2.Text = MainAdministration.NumberofThreadsPerCategory(TopCategorys[1]).ToString();
                LblTotalThreads3.Text = MainAdministration.NumberofThreadsPerCategory(TopCategorys[2]).ToString();

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
            else if (TopCategorys.Count > 1)
            {
                HyperLink1.Text = TopCategorys[0].Name;
                HyperLink2.Text = TopCategorys[1].Name;
                LblTotalThreads1.Text = MainAdministration.NumberofThreadsPerCategory(TopCategorys[0]).ToString();
                LblTotalThreads2.Text = MainAdministration.NumberofThreadsPerCategory(TopCategorys[1]).ToString();

                HyperLink1.Visible = true;
                HyperLink2.Visible = true;
                LblTotalThreads1.Visible = true;
                LblTotalThreads2.Visible = true;
                CategoryButton1.Visible = true;
                CategoryButton2.Visible = true;
            }
            else if (TopCategorys.Count > 0)
            {
                HyperLink1.Text = TopCategorys[0].Name;
                LblTotalThreads1.Text = MainAdministration.NumberofThreadsPerCategory(TopCategorys[0]).ToString();

                HyperLink1.Visible = true;
                LblTotalThreads1.Visible = true;
                CategoryButton1.Visible = true;
            }
        }
    }
}