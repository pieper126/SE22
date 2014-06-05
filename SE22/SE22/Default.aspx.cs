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
            MainAdministration.StartUp();
            initialization();
        }

        protected void CategoryButton1_Click(object sender, EventArgs e)
        {
            Session["NextPage"] = MainAdministration.Categorys[0];
            Session["PreviousPage"] = "Main";
            Page.Response.Redirect("Category");
        }

        protected void CategoryButton2_Click(object sender, EventArgs e)
        {
            Session["NextPage"] = MainAdministration.Categorys[1];
            Session["PreviousPage"] = "Main";
            Page.Response.Redirect("Category");
        }

        protected void CategoryButton3_Click(object sender, EventArgs e)
        {
            Session["NextPage"] = MainAdministration.Categorys[2];
            Session["PreviousPage"] = "Main";
            Page.Response.Redirect("Category");
        }

        protected void CategoryButton4_Click(object sender, EventArgs e)
        {
            Session["NextPage"] = MainAdministration.Categorys[3];
            Session["PreviousPage"] = "Main";
            Page.Response.Redirect("Category");
        }

        private void initialization()
        {
            if (MainAdministration.Categorys.Count > 3)
            {
                HyperLink1.Text = MainAdministration.Categorys[0].Name;
                HyperLink2.Text = MainAdministration.Categorys[1].Name;
                HyperLink3.Text = MainAdministration.Categorys[2].Name;
                HyperLink4.Text = MainAdministration.Categorys[3].Name;
                LblTotalThreads1.Text = MainAdministration.NumberofThreadsPerCategory(MainAdministration.Categorys[0]).ToString();
                LblTotalThreads2.Text = MainAdministration.NumberofThreadsPerCategory(MainAdministration.Categorys[1]).ToString();
                LblTotalThreads3.Text = MainAdministration.NumberofThreadsPerCategory(MainAdministration.Categorys[2]).ToString();
                LblTotalThreads4.Text = MainAdministration.NumberofThreadsPerCategory(MainAdministration.Categorys[3]).ToString();

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
            else if (MainAdministration.Categorys.Count > 2)
            {
                HyperLink1.Text = MainAdministration.Categorys[0].Name;
                HyperLink2.Text = MainAdministration.Categorys[1].Name;
                HyperLink3.Text = MainAdministration.Categorys[2].Name;
                LblTotalThreads1.Text = MainAdministration.NumberofThreadsPerCategory(MainAdministration.Categorys[0]).ToString();
                LblTotalThreads2.Text = MainAdministration.NumberofThreadsPerCategory(MainAdministration.Categorys[1]).ToString();
                LblTotalThreads3.Text = MainAdministration.NumberofThreadsPerCategory(MainAdministration.Categorys[2]).ToString();

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
            else if (MainAdministration.Categorys.Count > 1)
            {
                HyperLink1.Text = MainAdministration.Categorys[0].Name;
                HyperLink2.Text = MainAdministration.Categorys[1].Name;
                LblTotalThreads1.Text = MainAdministration.NumberofThreadsPerCategory(MainAdministration.Categorys[0]).ToString();
                LblTotalThreads2.Text = MainAdministration.NumberofThreadsPerCategory(MainAdministration.Categorys[1]).ToString();

                HyperLink1.Visible = true;
                HyperLink2.Visible = true;
                LblTotalThreads1.Visible = true;
                LblTotalThreads2.Visible = true;
                CategoryButton1.Visible = true;
                CategoryButton2.Visible = true;
            }
            else if (MainAdministration.Categorys.Count > 0)
            {
                HyperLink1.Text = MainAdministration.Categorys[0].Name;
                LblTotalThreads1.Text = MainAdministration.NumberofThreadsPerCategory(MainAdministration.Categorys[0]).ToString();

                HyperLink1.Visible = true;
                LblTotalThreads1.Visible = true;
                CategoryButton1.Visible = true;
            }
        }
    }
}