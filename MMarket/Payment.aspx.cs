﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MMarket
{
    public partial class Payment : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["naruceno"] != null && (bool)Session["naruceno"])
            {
                Response.Redirect("orderreceived.aspx");
            }

            if (Session["total"] == null || Session["shipping"] == null)
            {
                Response.Redirect("Cart.aspx");
            }

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
                    span.InnerText = item.ItemArray[6].ToString();
                    small.Controls.Add(span);

                    HtmlGenericControl div4 = new HtmlGenericControl("div");
                    div4.Attributes["class"] = "col-sm-3 col-xs-3 text-right";

                    HtmlGenericControl h6 = new HtmlGenericControl("h6");
                    //ubaciti kod za cijenu pomnoženih proizvoda
                    h6.InnerText = (float.Parse(item.ItemArray[3].ToString()) * float.Parse(item.ItemArray[6].ToString())).ToString();
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
                span2.InnerText = String.Format("{0:0.00}", (float)Session["total"]);
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
                span4.InnerText = String.Format("{0:0.00}", (float)Session["shipping"]);
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
                span6.InnerText = String.Format("{0:0.00}", (float)Session["shipping"] + (float)Session["total"]);
                pullright3.Controls.Add(span6);

                HtmlGenericControl span7 = new HtmlGenericControl("span");
                span7.InnerText = "Kn";
                pullright3.Controls.Add(span7);


                Panel1.Controls.Add(subtotal);
                Panel1.Controls.Add(shipping);
                Panel1.Controls.Add(divhr);
                Panel1.Controls.Add(total);


                Session["Pouzece"] = null;
                Session["Banka"] = null;
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(form_ime.Value) && !string.IsNullOrWhiteSpace(form_prezime.Value) && !string.IsNullOrWhiteSpace(form_adresa.Value)
                && !string.IsNullOrWhiteSpace(form_grad.Value) && !string.IsNullOrWhiteSpace(form_postanskibroj.Value) && !string.IsNullOrWhiteSpace(form_telefon.Value)
                && !string.IsNullOrWhiteSpace(form_email.Value))
            {
                int posBr;
                Regex regImePrez = new Regex("[A-Za-zÀ-ž]{3,30}");
                Regex regAdresa = new Regex("[A-z0-9À-ž\\s\\/\\-]{5,200}");
                Regex regPhone = new Regex("[0-9\\s\\/\\+]{8,20}");
                Regex regMail = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");

                if (regImePrez.IsMatch(form_ime.Value) && regImePrez.IsMatch(form_prezime.Value) && regImePrez.IsMatch(form_grad.Value)
                    && regAdresa.IsMatch(form_adresa.Value) && int.TryParse(form_postanskibroj.Value, out posBr) && form_postanskibroj.Value.Length > 3
                    && regPhone.IsMatch(form_telefon.Value) && regMail.IsMatch(form_email.Value))
                {
                    string value = RadioButtonList1.SelectedItem.Value.ToString();

                    if (value == "Plaćanje prilikom preuzimanja")
                    {
                        Session["Pouzece"] = 1;
                    }
                    else
                    {
                        Session["Banka"] = 1;
                    }

                    SqlConnection con = new SqlConnection(conString);

                    SqlCommand insertCmd = new SqlCommand("insert into Narudzbe values(@Ime, @Prezime, @Adresa, @Grad, @PosBroj, @Telefon, @Email, @Nacin, @Datum)", con);
                    insertCmd.Parameters.AddWithValue("@Ime", form_ime.Value);
                    insertCmd.Parameters.AddWithValue("@Prezime", form_prezime.Value);
                    insertCmd.Parameters.AddWithValue("@Adresa", form_adresa.Value);
                    insertCmd.Parameters.AddWithValue("@Grad", form_grad.Value);
                    insertCmd.Parameters.AddWithValue("@PosBroj", form_postanskibroj.Value);
                    insertCmd.Parameters.AddWithValue("@Telefon", form_telefon.Value);
                    insertCmd.Parameters.AddWithValue("@Email", form_email.Value);
                    if (Session["Pouzece"] != null)
                    {
                        insertCmd.Parameters.AddWithValue("@Nacin", "Pouzece");
                    }
                    else
                    {
                        insertCmd.Parameters.AddWithValue("@Nacin", "Banka");
                    }
                    insertCmd.Parameters.AddWithValue("@Datum", DateTime.Today);

                    con.Open();

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    con.Close();

                    Session["naruceno"] = true;

                    Response.Redirect("Order-Received.aspx");
                }
                else
                {

                }
            }
            else
            {

            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((RadioButtonList)sender).SelectedIndex == 0)
            {
                lblBanka.Visible = false;
            }
            else
            {
                lblBanka.Visible = true;
            }
        }
    }
}