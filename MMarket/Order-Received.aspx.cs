using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MMarket
{
    public partial class Order_Received : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Pouzece"] != null)
            {
                Label1.Text = "Plaćanje gotovinom prilikom dostave";
                Label2.Visible = false;
                Control div = FindControl("div");
                div.Visible = false;
            }
            if (Session["Banka"]!=null)
            {
                Label1.Text = "Direktna bankovna transakcija";
            }

        }


    }
}