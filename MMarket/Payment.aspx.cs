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
            if (Session["CartTable"] != null)
            {

                foreach (DataRow item in ((DataTable)Session["CartTable"]).Rows)
                {

                    HtmlGenericControl div1 = new HtmlGenericControl("div");
                    div1.Attributes["class"] = "form-group";

                    HtmlGenericControl div2 = new HtmlGenericControl("div");
                    div2.Attributes["class"] = "col-sm-3 col-xs-3";

                    HtmlImage img = new HtmlImage();
                    img.Attributes["class"] = "img-responsive";
                    img.Src = "Images/" + item.ItemArray[4];

                    HtmlGenericControl div3 = new HtmlGenericControl("div");
                    div3.Attributes["class"] = "col-sm-6 col-xs-6";

                    HtmlGenericControl innerdiv3 = new HtmlGenericControl("div");
                    innerdiv3.Attributes["class"] = "col-xs-12";
                    innerdiv3.InnerText = item.ItemArray[1].ToString();
                    div3.Controls.Add(innerdiv3);

                    HtmlGenericControl _innerdiv3 = new HtmlGenericControl("div");
                    _innerdiv3.Attributes["class"] = "col-xs-12";
                    innerdiv3.Controls.Add(_innerdiv3);

                    HtmlGenericControl small = new HtmlGenericControl("small");
                    small.InnerText = "Količina:";
                    _innerdiv3.Controls.Add(small);

                    HtmlGenericControl span = new HtmlGenericControl("span");
                    //ubaciti kod za broj komada
                    span.InnerText = "1";
                    small.Controls.Add(span);

                    HtmlGenericControl div4 = new HtmlGenericControl("div");
                    div4.Attributes["class"] = "col-sm-3 col-xs-3 text-right";

                    HtmlGenericControl h6 = new HtmlGenericControl("h6");
                    //ubaciti kod za cijenu pomnoženih proizvoda
                    h6.InnerText = "20";
                    div4.Controls.Add(h6);

                    HtmlGenericControl spanDiv4 = new HtmlGenericControl("span");
                    spanDiv4.InnerText = "Kn";
                    h6.Controls.Add(spanDiv4);

                    HtmlGenericControl div5 = new HtmlGenericControl("div");
                    div5.Attributes["class"] = "form-group";

                    HtmlGenericControl hr = new HtmlGenericControl("hr");
                    div5.Controls.Add(hr);




                    div1.Controls.Add(div2);
                    div1.Controls.Add(div3);
                    div1.Controls.Add(div4);
                    div2.Controls.Add(img);
                    Panel1.Controls.Add(div1);
                    Panel1.Controls.Add(div5);
                }

                //// Subtotal
                HtmlGenericControl subtotal = new HtmlGenericControl("div");
                subtotal.Attributes["class"] = "form-group";

                HtmlGenericControl _subtotal = new HtmlGenericControl("div");
                _subtotal.Attributes["class"] = "col-xs-12";
                subtotal.Controls.Add(_subtotal);

                HtmlGenericControl strong = new HtmlGenericControl("strong");
                strong.InnerText = "Subtotal:";
                _subtotal.Controls.Add(strong);

                HtmlGenericControl pullright = new HtmlGenericControl("div");
                pullright.Attributes["class"] = "pull-right";
                _subtotal.Controls.Add(pullright);

                HtmlGenericControl span2 = new HtmlGenericControl("span");
                // kod za subtotal
                span2.InnerText = "200";
                pullright.Controls.Add(span2);

                HtmlGenericControl span3 = new HtmlGenericControl("span");
                span3.InnerText = "Kn";
                pullright.Controls.Add(span3);


                //// Shipping
                HtmlGenericControl shipping = new HtmlGenericControl("div");
                shipping.Attributes["class"] = "form-group";

                HtmlGenericControl _shipping = new HtmlGenericControl("div");
                _shipping.Attributes["class"] = "col-xs-12";
                shipping.Controls.Add(_shipping);

                HtmlGenericControl smallshipp = new HtmlGenericControl("small");
                smallshipp.InnerText = "Dostava:";
                _shipping.Controls.Add(smallshipp);

                HtmlGenericControl pullright2 = new HtmlGenericControl("div");
                pullright2.Attributes["class"] = "pull-right";
                _shipping.Controls.Add(pullright2);

                HtmlGenericControl span4 = new HtmlGenericControl("span");
                // kod za shipping
                span4.InnerText = "20";
                pullright2.Controls.Add(span4);

                HtmlGenericControl span5 = new HtmlGenericControl("span");
                span5.InnerText = "Kn";
                pullright2.Controls.Add(span5);

                HtmlGenericControl divhr = new HtmlGenericControl("div");
                divhr.Attributes["class"] = "form-group";

                HtmlGenericControl hr2 = new HtmlGenericControl("hr");
                divhr.Controls.Add(hr2);


                //// Total
                HtmlGenericControl total = new HtmlGenericControl("div");
                total.Attributes["class"] = "form-group";

                HtmlGenericControl _total = new HtmlGenericControl("div");
                _total.Attributes["class"] = "col-xs-12";
                total.Controls.Add(_total);

                HtmlGenericControl strong3 = new HtmlGenericControl("strong");
                strong3.InnerText = "Ukupna Cijena:";
                _total.Controls.Add(strong3);

                HtmlGenericControl pullright3 = new HtmlGenericControl("div");
                pullright3.Attributes["class"] = "pull-right";
                _total.Controls.Add(pullright3);

                HtmlGenericControl span6 = new HtmlGenericControl("span");
                // kod za total
                span6.InnerText = "220";
                pullright3.Controls.Add(span6);

                HtmlGenericControl span7 = new HtmlGenericControl("span");
                span7.InnerText = "Kn";
                pullright3.Controls.Add(span7);


                Panel1.Controls.Add(subtotal);
                Panel1.Controls.Add(shipping);
                Panel1.Controls.Add(divhr);
                Panel1.Controls.Add(total);



            }

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