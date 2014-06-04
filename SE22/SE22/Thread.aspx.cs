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
                postCounter = 0;
                Pageinitialization(postCounter);
	        }
	        catch (Exception)
	        {
                Page.Response.Redirect("Default.aspx");
                Session["PreviousPage"] = null;
                Session["NextPage"] = "Main";
	        }
        }




        private void Pageinitialization(int counter)
        {
            if (currentThread.Posts.Count - counter > 4)
            {
                PostTB0.Text = currentThread.Posts[counter+0].Content;
                PostTB1.Text = currentThread.Posts[counter+1].Content;
                PostTB2.Text = currentThread.Posts[counter+2].Content;
                PostTB3.Text = currentThread.Posts[counter+3].Content;
                PostTB4.Text = currentThread.Posts[counter+4].Content;
                PostedBy0.Text = currentThread.Posts[counter+0].Username;
                PostedBy1.Text = currentThread.Posts[counter+1].Username;
                PostedBy2.Text = currentThread.Posts[counter+2].Username;
                PostedBy3.Text = currentThread.Posts[counter+3].Username;

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
            }
            else if (currentThread.Posts.Count - counter > 1)
            {
                PostTB0.Text = currentThread.Posts[counter+0].Content;
                PostTB1.Text = currentThread.Posts[counter+1].Content;
                PostedBy0.Text = currentThread.Posts[counter+0].Username;
                PostedBy1.Text = currentThread.Posts[counter+1].Username;

                PostedBy0.Visible = true;
                PostTB0.Visible = true;
                PostTB2.Visible = true;
                PostedBy1.Visible = true;
            }
            else if (currentThread.Posts.Count - counter > 0)
            {
                PostTB0.Text = currentThread.Posts[counter + 0].Content;
                PostedBy0.Text = currentThread.Posts[counter + 0].Username;

                PostedBy0.Visible = true;
                PostTB0.Visible = true;
            }
        }

        protected void BtnPrev_Click(object sender, EventArgs e)
        {
            postCounter -= 5;
            Pageinitialization(postCounter);

            if (postCounter == 0)
            {
                BtnNext.Enabled = false;
            }
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
            Pageinitialization(postCounter);

            if (postCounter > currentThread.Posts.Count)
            {
                BtnNext.Enabled = false;
            }
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
    }
}