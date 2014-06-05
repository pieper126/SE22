using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE22
{
    public partial class Thread : System.Web.UI.Page
    {
        private ForumThread currentThread;

        private int postCounter;

        protected void Page_Load(object sender, EventArgs e)
        {
            try 
	        {
                currentThread = MainAdministration.UpdateThread(((ForumThread)Session["NextPage"]).ID);
                postCounter = Convert.ToInt32(Session["POSTCOUNTER"]);
                Pageinitialization(postCounter);
	        }
	        catch (Exception)
	        {
                Page.Response.Redirect("Default.aspx");
                Session["PreviousPage"] = null;
                Session["NextPage"] = "Main";
	        }
        }

        protected void BtnPrev_Click(object sender, EventArgs e)
        {
            postCounter -= 5;
            Session["POSTCOUNTER"] = postCounter;
            Pageinitialization(postCounter);

            if (postCounter == 0)
            {
                postCounter += 5;
                Session["POSTCOUNTER"] = postCounter;
                BtnNext.Enabled = false;
                return;
            }
            Response.Redirect(Request.RawUrl);
            //if(postCounter > 10)
            //{
            //    postCounter -= 5;
            //    Pageinitialization(postCounter);
            //}
            //else if (postCounter == 5)
            //{
            //    postCounter -= 5;
            //    Pageinitialization(postCounter);
            //    BtnPrev.Enabled = false;
            //}
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            postCounter += 5;
            Session["POSTCOUNTER"] = postCounter;

            if (postCounter >= currentThread.Posts.Count)
            {
                BtnNext.Enabled = false;
                postCounter -= 5;
                Session["POSTCOUNTER"] = postCounter;
                return;
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void BtnNewPost_click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                LoggedInUserValidator.IsValid = false;
                return;
            }
            if (currentThread == null)
            {
                LoggedInUserValidator.Text = "Please go to the homepage";
                LoggedInUserValidator.IsValid = false;
                return;
            }
            MainAdministration.CreateNewPost((User)Session["user"], Tb.Text, currentThread);
            Response.Redirect(Request.RawUrl);
        }

        #region AlterButtons
        protected void BtnAlter0_Click(object sender, EventArgs e)
        {

        }
        protected void BtnAlter1_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAlter2_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAlter3_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAlter4_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region DeleteButtons
        protected void BtnDelete0_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                ThreadValidator1.ErrorMessage = "User needs to be logged in";
                ThreadValidator1.IsValid = false;
                return;
            }
            if (currentThread == null)
            {
                ThreadValidator1.Text = "Please go to the homepage";
                ThreadValidator1.IsValid = false;
                return;
            }

            if (currentThread.Posts[postCounter].Username != ((User)Session["user"]).Username && !((User)Session["user"]).Functions.Contains(Rights.Moderator))
            {
                ThreadValidator1.Text = "You don't own sufficient rights to delete this file";
                ThreadValidator1.IsValid = false;
                return;
            }
            MainAdministration.DeletePost(currentThread.Posts[postCounter].ID);
            Response.Redirect(Request.RawUrl);
        }

        protected void BtnDelete1_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                ThreadValidator2.ErrorMessage = "User needs to be logged in";
                ThreadValidator2.IsValid = false;
                return;
            }
            if (currentThread == null)
            {
                ThreadValidator2.Text = "Please go to the homepage";
                ThreadValidator2.IsValid = false;
                return;
            }

            if (currentThread.Posts[postCounter + 1].Username != ((User)Session["user"]).Username && !((User)Session["user"]).Functions.Contains(Rights.Moderator))
            {
                ThreadValidator2.Text = "You don't own sufficient rights to delete this file";
                ThreadValidator2.IsValid = false;
                return;
            }
            MainAdministration.DeletePost(currentThread.Posts[postCounter + 1].ID);
            Response.Redirect(Request.RawUrl);
        }

        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                ThreadValidator3.ErrorMessage = "User needs to be logged in";
                ThreadValidator3.IsValid = false;
                return;
            }
            if (currentThread == null)
            {
                ThreadValidator3.Text = "Please go to the homepage";
                ThreadValidator3.IsValid = false;
                return;
            }

            if (currentThread.Posts[postCounter + 2].Username != ((User)Session["user"]).Username && !((User)Session["user"]).Functions.Contains(Rights.Moderator))
            {
                ThreadValidator3.Text = "You don't own sufficient rights to delete this file";
                ThreadValidator3.IsValid = false;
                return;
            }
            MainAdministration.DeletePost(currentThread.Posts[postCounter + 2].ID);
            Response.Redirect(Request.RawUrl);
        }

        protected void BtnDelete3_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                ThreadValidator4.ErrorMessage = "User needs to be logged in";
                ThreadValidator4.IsValid = false;
                return;
            }
            if (currentThread == null)
            {
                ThreadValidator4.Text = "Please go to the homepage";
                ThreadValidator4.IsValid = false;
                return;
            }

            if (currentThread.Posts[postCounter + 3].Username != ((User)Session["user"]).Username && !((User)Session["user"]).Functions.Contains(Rights.Moderator))
            {
                ThreadValidator4.Text = "You don't own sufficient rights to delete this file";
                ThreadValidator4.IsValid = false;
                return;
            }
            MainAdministration.DeletePost(currentThread.Posts[postCounter + 3].ID);
            Response.Redirect(Request.RawUrl);
        }

        protected void BtnDelete4_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                ThreadValidator5.ErrorMessage = "User needs to be logged in";
                ThreadValidator5.IsValid = false;
                return;
            }
            if (currentThread == null)
            {
                ThreadValidator5.Text = "Please go to the homepage";
                ThreadValidator5.IsValid = false;
                return;
            }

            if (currentThread.Posts[postCounter + 4].Username != ((User)Session["user"]).Username && !((User)Session["user"]).Functions.Contains(Rights.Moderator))
            {
                ThreadValidator5.Text = "You don't own sufficient rights to delete this file";
                ThreadValidator5.IsValid = false;
                return;
            }
            MainAdministration.DeletePost(currentThread.Posts[postCounter + 4].ID);
            Response.Redirect(Request.RawUrl);
        }
        #endregion

        private void Pageinitialization(int counter)
        {
            if (currentThread.Posts.Count - counter > 4)
            {
                PostTB0.Text = currentThread.Posts[counter + 0].Content;
                PostTB1.Text = currentThread.Posts[counter + 1].Content;
                PostTB2.Text = currentThread.Posts[counter + 2].Content;
                PostTB3.Text = currentThread.Posts[counter + 3].Content;
                PostTB4.Text = currentThread.Posts[counter + 4].Content;
                PostedBy0.Text = currentThread.Posts[counter + 0].Username;
                PostedBy1.Text = currentThread.Posts[counter + 1].Username;
                PostedBy2.Text = currentThread.Posts[counter + 2].Username;
                PostedBy3.Text = currentThread.Posts[counter + 3].Username;
                PostedBy4.Text = currentThread.Posts[counter + 3].Username;

                PostTB0.Visible = true;
                PostTB1.Visible = true;
                PostTB2.Visible = true;
                PostTB3.Visible = true;
                PostTB4.Visible = true;
                PostedBy0.Visible = true;
                PostedBy1.Visible = true;
                PostedBy2.Visible = true;
                PostedBy3.Visible = true;
                PostedBy4.Visible = true;
                BtnAlter0.Visible = true;
                BtnAlter1.Visible = true;
                BtnAlter2.Visible = true;
                BtnAlter3.Visible = true;
                BtnAlter4.Visible = true;
                BtnDelete0.Visible = true;
                BtnDelete1.Visible = true;
                BtnDelete2.Visible = true;
                BtnDelete3.Visible = true;
                BtnDelete4.Visible = true;
            }
            else if (currentThread.Posts.Count - counter > 3)
            {
                PostTB0.Text = currentThread.Posts[counter + 0].Content;
                PostTB1.Text = currentThread.Posts[counter + 1].Content;
                PostTB2.Text = currentThread.Posts[counter + 2].Content;
                PostTB3.Text = currentThread.Posts[counter + 3].Content;
                PostedBy0.Text = currentThread.Posts[counter + 0].Username;
                PostedBy1.Text = currentThread.Posts[counter + 1].Username;
                PostedBy2.Text = currentThread.Posts[counter + 2].Username;
                PostedBy3.Text = currentThread.Posts[counter + 3].Username;

                PostTB0.Visible = true;
                PostTB1.Visible = true;
                PostTB2.Visible = true;
                PostTB3.Visible = true;
                PostedBy0.Visible = true;
                PostedBy1.Visible = true;
                PostedBy2.Visible = true;
                PostedBy3.Visible = true;
                BtnAlter0.Visible = true;
                BtnAlter1.Visible = true;
                BtnAlter2.Visible = true;
                BtnAlter3.Visible = true;
                BtnDelete0.Visible = true;
                BtnDelete1.Visible = true;
                BtnDelete2.Visible = true;
                BtnDelete3.Visible = true;
            }
            else if (currentThread.Posts.Count - counter > 2)
            {
                PostTB0.Text = currentThread.Posts[counter + 0].Content;
                PostTB1.Text = currentThread.Posts[counter + 1].Content;
                PostTB2.Text = currentThread.Posts[counter + 2].Content;
                PostedBy0.Text = currentThread.Posts[counter + 0].Username;
                PostedBy1.Text = currentThread.Posts[counter + 1].Username;
                PostedBy2.Text = currentThread.Posts[counter + 2].Username;

                PostTB0.Visible = true;
                PostTB1.Visible = true;
                PostTB2.Visible = true;
                PostedBy0.Visible = true;
                PostedBy1.Visible = true;
                PostedBy2.Visible = true;
                BtnAlter0.Visible = true;
                BtnAlter1.Visible = true;
                BtnAlter2.Visible = true;
                BtnDelete0.Visible = true;
                BtnDelete1.Visible = true;
                BtnDelete2.Visible = true;
            }
            else if (currentThread.Posts.Count - counter > 1)
            {
                PostTB0.Text = currentThread.Posts[counter + 0].Content;
                PostTB1.Text = currentThread.Posts[counter + 1].Content;
                PostedBy0.Text = currentThread.Posts[counter + 0].Username;
                PostedBy1.Text = currentThread.Posts[counter + 1].Username;

                PostTB0.Visible = true;
                PostTB1.Visible = true;
                PostedBy0.Visible = true;
                PostedBy1.Visible = true;
                BtnAlter0.Visible = true;
                BtnAlter1.Visible = true;
                BtnDelete0.Visible = true;
                BtnDelete1.Visible = true;
            }
            else if (currentThread.Posts.Count - counter > 0)
            {
                PostTB0.Text = currentThread.Posts[counter + 0].Content;
                PostedBy0.Text = currentThread.Posts[counter + 0].Username;

                PostedBy0.Visible = true;
                PostTB0.Visible = true;
                BtnAlter0.Visible = true;
                BtnDelete0.Visible = true;
            }
        }
    }
}