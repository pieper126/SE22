using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE22
{
    public partial class Category : System.Web.UI.Page
    {

        List<ForumThread> currentThreads = new List<ForumThread>();

        protected void Page_Load(object sender, EventArgs e)
        {
            PostThread postthread = new PostThread();
            postthread.Visible = true;
            currentThreads = MainAdministration.GiveAllThreadsOfAGivenCategory(((ForumCategory)Session["NextPage"]).ID);
            Initialization();
        }

        protected void ThreadButton1_Click(object sender, EventArgs e)
        {
            Session["PreviousPage"] = "Category:" + Session["NextPage"];
            Session["NextPage"] = currentThreads[0];
            Session["POSTCOUNTER"] = 0;
            Page.Response.Redirect("Thread");
        }

        protected void ThreadButton2_Click(object sender, EventArgs e)
        {
            Session["PreviousPage"] = "Category:" + Session["NextPage"];
            Session["NextPage"] = currentThreads[1];
            Session["POSTCOUNTER"] = 0;
            Page.Response.Redirect("Thread");

        }

        protected void ThreadButton3_Click(object sender, EventArgs e)
        {
            Session["PreviousPage"] = "Category:" + Session["NextPage"];
            Session["NextPage"] = currentThreads[2];
            Session["POSTCOUNTER"] = 0;
            Page.Response.Redirect("Thread");
        }

        protected void ThreadButton4_Click(object sender, EventArgs e)
        {
            Session["PreviousPage"] = "Category:" + Session["NextPage"];
            Session["NextPage"] = currentThreads[3];
            Session["POSTCOUNTER"] = 0;
            Page.Response.Redirect("Thread");
        }

        protected void NewThreadbutton_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                LoggedInUserValidator.IsValid = false;
                return;
            }
            if (currentThreads == null)
            {
                LoggedInUserValidator.Text = "Please go to the homepage";
                LoggedInUserValidator.IsValid = false;
                return;
            }
            MainAdministration.CreateNewThread((User)Session["user"], TbContent.Text, currentThreads[0].Category, TbName.Text);
            Response.Redirect(Request.RawUrl);
        }

        #region DeleteButtons
        protected void DeleteButton1_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                ThreadValidator1.ErrorMessage = "User needs to be logged in";
                ThreadValidator1.IsValid = false;
                return;
            }
            if (currentThreads == null)
            {
                ThreadValidator1.Text = "Please go to the homepage";
                ThreadValidator1.IsValid = false;
                return;
            }

            if (currentThreads[0].Username != ((User)Session["user"]).Username && !((User)Session["user"]).Functions.Contains(Rights.Moderator))
            {
                ThreadValidator1.Text = "You don't own sufficient rights to delete this file";
                ThreadValidator1.IsValid = false;
                return;
            }
            MainAdministration.DeleteThread(currentThreads[0].ID);
            Response.Redirect(Request.RawUrl);
        }

        protected void DeleteButton2_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                ThreadValidator2.ErrorMessage = "User needs to be logged in";
                ThreadValidator2.IsValid = false;
                return;
            }
            if (currentThreads == null)
            {
                ThreadValidator2.Text = "Please go to the homepage";
                ThreadValidator2.IsValid = false;
                return;
            }

            if (currentThreads[1].Username != ((User)Session["user"]).Username && !((User)Session["user"]).Functions.Contains(Rights.Moderator))
            {
                ThreadValidator2.Text = "You don't own sufficient rights to delete this file";
                ThreadValidator2.IsValid = false;
                return;
            }
            MainAdministration.DeleteThread(currentThreads[1].ID);
            Response.Redirect(Request.RawUrl);
        }

        protected void DeleteButton3_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                ThreadValidator3.ErrorMessage = "User needs to be logged in";
                ThreadValidator3.IsValid = false;
                return;
            }
            if (currentThreads == null)
            {
                ThreadValidator3.Text = "Please go to the homepage";
                ThreadValidator3.IsValid = false;
                return;
            }

            if (currentThreads[2].Username != ((User)Session["user"]).Username && !((User)Session["user"]).Functions.Contains(Rights.Moderator))
            {
                ThreadValidator3.Text = "You don't own sufficient rights to delete this file";
                ThreadValidator3.IsValid = false;
                return;
            }
            MainAdministration.DeleteThread(currentThreads[2].ID);
            Response.Redirect(Request.RawUrl);
        }

        protected void DeleteButton4_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                ThreadValidator4.ErrorMessage = "User needs to be logged in";
                ThreadValidator4.IsValid = false;
                return;
            }
            if (currentThreads == null)
            {
                ThreadValidator4.Text = "Please go to the homepage";
                ThreadValidator4.IsValid = false;
                return;
            }

            if (currentThreads[3].Username != ((User)Session["user"]).Username && !((User)Session["user"]).Functions.Contains(Rights.Moderator))
            {
                ThreadValidator4.Text = "You don't own sufficient rights to delete this file";
                ThreadValidator4.IsValid = false;
                return;
            }
            MainAdministration.DeleteThread(currentThreads[3].ID);
            Response.Redirect(Request.RawUrl);
        }
        #endregion

        #region AlterButtons
        protected void AlterButton1_Click(object sender, EventArgs e)
        {

        }

        protected void AlterButton2_Click(object sender, EventArgs e)
        {

        }

        protected void AlterButton3_Click(object sender, EventArgs e)
        {

        }

        protected void AlterButton4_Click(object sender, EventArgs e)
        {

        }

        protected void AlterButton5_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void Initialization()
        {
            if (currentThreads.Count > 3)
            {
                HyperLink1.Text = currentThreads[0].Name;
                HyperLink2.Text = currentThreads[1].Name;
                HyperLink3.Text = currentThreads[2].Name;
                HyperLink4.Text = currentThreads[3].Name;
                LblTotalPosts1.Text = currentThreads[0].Posts.Count.ToString();
                LblTotalPosts2.Text = currentThreads[1].Posts.Count.ToString();
                LblTotalPosts3.Text = currentThreads[2].Posts.Count.ToString();
                LblTotalPosts4.Text = currentThreads[3].Posts.Count.ToString();

                HyperLink1.Visible = true;
                HyperLink2.Visible = true;
                HyperLink3.Visible = true;
                HyperLink4.Visible = true;
                LblTotalPosts1.Visible = true;
                LblTotalPosts2.Visible = true;
                LblTotalPosts3.Visible = true;
                LblTotalPosts4.Visible = true;
                ThreadButton1.Visible = true;
                ThreadButton2.Visible = true;
                ThreadButton3.Visible = true;
                ThreadButton4.Visible = true;
                AlterButton1.Visible = true;
                AlterButton2.Visible = true;
                AlterButton3.Visible = true;
                AlterButton4.Visible = true;
                DeleteButton1.Visible = true;
                DeleteButton2.Visible = true;
                DeleteButton3.Visible = true;
                DeleteButton4.Visible = true;
            }
            else if (currentThreads.Count > 2)
            {
                HyperLink1.Text = currentThreads[0].Name;
                HyperLink2.Text = currentThreads[1].Name;
                HyperLink3.Text = currentThreads[2].Name;
                LblTotalPosts1.Text = currentThreads[0].Posts.Count.ToString();
                LblTotalPosts2.Text = currentThreads[1].Posts.Count.ToString();
                LblTotalPosts3.Text = currentThreads[2].Posts.Count.ToString();

                HyperLink1.Visible = true;
                HyperLink2.Visible = true;
                HyperLink3.Visible = true;
                LblTotalPosts1.Visible = true;
                LblTotalPosts2.Visible = true;
                LblTotalPosts3.Visible = true;
                ThreadButton1.Visible = true;
                ThreadButton2.Visible = true;
                ThreadButton3.Visible = true;
                AlterButton1.Visible = true;
                AlterButton2.Visible = true;
                AlterButton3.Visible = true;
                DeleteButton1.Visible = true;
                DeleteButton2.Visible = true;
                DeleteButton3.Visible = true;
            }
            else if (currentThreads.Count > 1)
            {
                HyperLink1.Text = currentThreads[0].Name;
                HyperLink2.Text = currentThreads[1].Name;
                LblTotalPosts1.Text = currentThreads[0].Posts.Count.ToString();
                LblTotalPosts2.Text = currentThreads[1].Posts.Count.ToString();

                LblTotalPosts2.Visible = true;
                HyperLink1.Visible = true;
                HyperLink2.Visible = true;
                LblTotalPosts1.Visible = true;
                ThreadButton1.Visible = true;
                ThreadButton2.Visible = true;
                AlterButton1.Visible = true;
                AlterButton2.Visible = true;
                DeleteButton1.Visible = true;
                DeleteButton2.Visible = true;
            }
            else if (currentThreads.Count > 0)
            {
                HyperLink1.Text = currentThreads[0].Name;
                LblTotalPosts1.Text = currentThreads[0].Posts.Count.ToString();

                LblTotalPosts1.Visible = true;
                HyperLink1.Visible = true;
                ThreadButton1.Visible = true;
                AlterButton1.Visible = true;
                DeleteButton1.Visible = true;
            }
        }
    }
}