using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MMarket
{
    public partial class ProizvodDetaljno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!Page.IsPostBack)
            {

                Label1.Text = "našao nešto";

                foreach (string key in Request.Form)
                {
                    if (key.StartsWith("")) { Label1.Text = "našao nešto";  }
                    else
                    {
                        Label1.Text = "našao nešto";
                    }
                    
                }
            }
        }
    }
}