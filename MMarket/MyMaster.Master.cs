using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MMarket
{
    public partial class MyMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null)
            {
                modal_trigger.Visible = false;
                adminLink.Visible = true;
                //btnLogout.ServerClick += btnLogout_Click;
                btnLogout.Visible = true;
            }
            else
            {
                adminLink.Visible = false;
                modal_trigger.Visible = true;
                //btnLogout.ServerClick -= btnLogout_Click;
                btnLogout.Visible = false;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string myUsername = Username.Value;
            string myPassword = Password.Value;

            if (myUsername == "admin" && myPassword == "admin123")
            {
                Session.Add("Admin", myUsername);

                Response.Redirect("AdminPage.aspx");
            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }
    }
}