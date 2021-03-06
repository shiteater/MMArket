﻿using System;
using System.Collections.Generic;
using System.Data;
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
            if (Session["naruceno"] != null)
            {
                Session.Clear();
                Session.Abandon();
            }

            if (Session["Admin"] != null)
            {
                modal_trigger.Visible = false;
                adminLink.Visible = true;
                btnLogout.Visible = true;
            }
            else
            {
                adminLink.Visible = false;
                modal_trigger.Visible = true;
                btnLogout.Visible = false;
            }

            Page.LoadComplete += new EventHandler(Page_LoadComplete);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Opcija register trenutno nije dostupna!');</script>");
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

        void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Session["CartTable"] != null)
            {
                cartBadge.Attributes["data-badge"] = ((DataTable)Session["CartTable"]).Rows.Count.ToString();
            }
        }
    }
}