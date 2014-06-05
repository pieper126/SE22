using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE22
{
    public partial class PostThread : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets or sets the username to identify who is logged in
        /// </summary>
        public string Username { get; set;}

        /// <summary>
        /// Gets or sets the Object this control controls
        /// </summary>
        public object ObjectOfTHeControl { get; set;  }

        /// <summary>
        /// Gets or sets the counter holds at what point we are in the list on the page
        /// </summary>
        public int counter { get; set; }

        /// <summary>
        /// Gets or sets the string that is used to transfer Date the page to the correct page
        /// </summary>
        public string TypeOfObject { get; set; }

        /// <summary>
        /// Gets or sets the string that is used to transfer the page to the correct page
        /// </summary>
        public string UrlNextPage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ThreadButton_Click(object sender, EventArgs e)
        {
            Session["PreviousPage"] = TypeOfObject + ":" + Session["NextPage"];
            Session["NextPage"] = ObjectOfTHeControl;
            Session["COUNTER"] = 0;
            Page.Response.Redirect(UrlNextPage);
        }

        protected void AlterButton_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                ThreadValidator1.ErrorMessage = "User needs to be logged in";
                ThreadValidator1.IsValid = false;
                return;
            }

            if (Username != ((User)Session["user"]).Username && !((User)Session["user"]).Functions.Contains(Rights.Moderator))
            {
                ThreadValidator1.Text = "You don't own sufficient rights to delete this file";
                ThreadValidator1.IsValid = false;
                return;
            }

            try
            {
                MainAdministration.DeleteObject(ObjectOfTHeControl);
            }
            catch (InvalidCastException)
            {
                ThreadValidator1.Text = "The type you are trying to use isn't supported by the system";
                ThreadValidator1.IsValid = false;
                return;
            }

            Response.Redirect(Request.RawUrl);
        }

        public void EnableTextBox()
        {
            PostTB.Enabled = true;
            PostTB.Visible = true;
        }

        public void DisableTextBox()
        {
            PostTB.Enabled = false;
            PostTB.Visible = false;
        }

        public void EnableGo()
        {
            ThreadButton.Enabled = true;
            ThreadButton.Visible = true;
        }

        public void DisableGo()
        {
            ThreadButton.Enabled = false;
            ThreadButton.Visible = false;
        }

        public void EnableAlter()
        {
            AlterButton.Enabled = true;
            AlterButton.Visible = true;
        }

        public void DisableAlter()
        {
            AlterButton.Enabled = false;
            AlterButton.Visible = false;
        }

        public void EnableHyperlink()
        {
            HyperLink.Enabled = true;
            HyperLink.Visible = true;
        }

        public void EnableLabel()
        {
            Lbl.Enabled = true;
            Lbl.Visible = true;
        }
    }
}