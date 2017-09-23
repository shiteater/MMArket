using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MMarket
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Pouzece"] = null;
            Session["Banka"] = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string value = RadioButtonList1.SelectedItem.Value.ToString();

            if (value == "Plaćanje prilikom preuzimanja")
            {
                Session["Pouzece"] = 1;
                Response.Redirect("Order-Received.aspx");
            }
            else
            {
                Session["Banka"] = 1;
                Response.Redirect("Order-Received.aspx");
            }
        }
    }
}