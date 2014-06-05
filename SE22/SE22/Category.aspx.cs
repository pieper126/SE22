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

        private int counter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NextPage"] == null || Session["COUNTER"] == null || Session["NextPage"] == string.Empty)
            {
                Page.Response.Redirect("Default");
            }
            counter = (int)Session["COUNTER"];
            currentThreads = MainAdministration.GiveAllThreadsOfAGivenCategory(((ForumCategory)Session["NextPage"]).ID);
            Initialization();
        }

        protected void BtnPrev_Click(object sender, EventArgs e)
        {
            if (!BtnNext.Enabled)
            {
                BtnNext.Enabled = true;
            }

            counter -= 5;
            Session["COUNTER"] = counter;

            if (counter == 0)
            {
                counter += 5;
                Session["COUNTER"] = counter;
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

            counter += 5;
            Session["COUNTER"] = counter;

            if (counter >= currentThreads.Count)
            {
                BtnNext.Enabled = false;
                counter -= 5;
                Session["COUNTER"] = counter;
                return;
            }
            Response.Redirect(Request.RawUrl);
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

        private void Initialization()
        {           
            if (currentThreads.Count < 5)
            {
                panel.Controls.Clear();
                panel.Visible = true;
                foreach (ForumThread thread in currentThreads)
                {
                    PostThread control = (PostThread)LoadControl("PostThread.ascx");
                    control.UrlNextPage = "~/Thread.aspx";
                    control.ObjectOfTHeControl = thread;
                    control.TypeOfObject = "Thread";
                    control.Visible = true;
                    control.SetHyperLink(thread.Name);
                    control.EnableHyperlink();
                    control.SetLabel(thread.Posts.Count.ToString());
                    control.EnableLabel();
                    control.EnableGo();
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
                if ((currentThreads.Count - counter) < 5)
                {
                    length = currentThreads.Count - counter;
                }
                else
                {
                    length = 5;
                }

                for (int i = 0; i < length; i++)
                {
                    ForumThread thread = currentThreads[counter + i];
                    PostThread control = (PostThread)LoadControl("PostThread.ascx");
                    control.UrlNextPage = "~/Thread.aspx";
                    control.ObjectOfTHeControl = thread;
                    control.TypeOfObject = "Thread";
                    control.Visible = true;
                    control.SetHyperLink(thread.Name);
                    control.EnableHyperlink();
                    control.SetLabel(thread.Posts.Count.ToString());
                    control.EnableLabel();
                    control.EnableGo();
                    control.EnableDelete();
                    panel.Controls.Add(control);
                }
            }
        }
    }
}