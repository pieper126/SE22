﻿using System;
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
                postCounter = Convert.ToInt32(Session["COUNTER"]);
                Pageinitialization();
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
            if (!BtnNext.Enabled)
            {
                BtnNext.Enabled = true;
            }
            postCounter -= 5;
            Session["COUNTER"] = postCounter;

            if (postCounter == 0)
            {
                postCounter += 5;
                Session["COUNTER"] = postCounter;
                BtnNext.Enabled = false;
                return;
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            if (!BtnPrev.Enabled)
            {
                BtnPrev.Enabled = true;
            }

            postCounter += 5;
            Session["COUNTER"] = postCounter;

            if (postCounter >= currentThread.Posts.Count)
            {
                BtnNext.Enabled = false;
                postCounter -= 5;
                Session["COUNTER"] = postCounter;
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

        private void Pageinitialization()
        {
            if (currentThread.Posts.Count < 5)
            {
                panel.Controls.Clear();
                panel.Visible = true;
                foreach (Post post in currentThread.Posts)
                {
                    PostThread control = (PostThread)LoadControl("PostThread.ascx");
                    control.UrlNextPage = string.Empty;
                    control.ObjectOfTHeControl = post;
                    control.TypeOfObject = "Post";
                    control.Visible = true;
                    control.SetTextBox(post.Content);
                    control.SetLabel(post.Username);
                    control.EnableLabel();
                    control.EnableTextBox();
                    control.EnableDelete();
                    panel.Controls.Add(control);
                }

                int counter = 5 - panel.Controls.Count;

                for (int i = 0; i < counter; i++)
                {
                    PostThread control = (PostThread)LoadControl("PostThread.ascx");
                    panel.Controls.Add(control);
                }
            }
            else
            {
                panel.Controls.Clear();
                panel.Visible = true;

                int length = Int32.MinValue;
                if ((currentThread.Posts.Count - postCounter) < 5)
                {
                    length = currentThread.Posts.Count - postCounter;
                }
                else
                {
                    length = 5;
                }

                for (int i = 0; i < length; i++)
                {
                    Post post = currentThread.Posts[postCounter + i];
                    PostThread control = (PostThread)LoadControl("PostThread.ascx");
                    control.UrlNextPage = string.Empty;
                    control.ObjectOfTHeControl = post;
                    control.TypeOfObject = "Post";
                    control.Visible = true;
                    control.SetTextBox(post.Content);
                    control.SetLabel(post.Username);
                    control.EnableLabel();
                    control.EnableTextBox();
                    control.EnableDelete();
                    panel.Controls.Add(control);
                }
            }
        }
    }
}