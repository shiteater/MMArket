using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MMarket
{
    public partial class orderreceived : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;
        int idNarudzba = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["naruceno"] == null || Session["DajSeMakni"] != null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("Home.aspx");
            }

            SqlConnection con = new SqlConnection(conString);

            //SqlCommand idCom = new SqlCommand("SELECT IDENT_CURRENT('Narudzbe') AS Current_Identity", con);

            //con.Open();

            //SqlDataReader reader = idCom.ExecuteReader();

            //if (reader.Read())
            //{
            //    idNarudzba = int.Parse(reader["Current_Identity"].ToString());
            //}

            //con.Close();

            if (Session["idNarudzba"] != null || ViewState["idNarudzba"] != null)
            {
                if (Session["idNarudzba"] != null)
                {
                    ViewState["idNarudzba"] = (int)Session["idNarudzba"];
                }

                idNarudzba = (int)ViewState["idNarudzba"];

                Narudzba.InnerText = "Broj narudžbe: " + idNarudzba;
                Narudzba.Style.Add("font-weight", "bold");
                DateTime thisDay = DateTime.Today;
                myDatum.InnerText = thisDay.ToString("d");
                myDatum.Style.Add("font-weight", "bold");

                if (Session["Pouzece"] != null)
                {
                    Label1.Text = "Plaćanje gotovinom prilikom dostave.\n Dostava unutar 3 dana.";
                    Label2.Visible = false;
                    Control div = FindControl("div");
                    div.Visible = false;
                }
                if (Session["Banka"] != null)
                {
                    Label1.Text = "Direktna bankovna transakcija";
                }

                if (Session["CartTable"] != null)
                {
                    HtmlGenericControl tbl = new HtmlGenericControl("table");
                    tbl.Attributes["class"] = "table table-bordered";

                    HtmlGenericControl tbody = new HtmlGenericControl("tbody");
                    tbl.Controls.Add(tbody);

                    HtmlGenericControl tr = new HtmlGenericControl("tr");
                    tbody.Controls.Add(tr);

                    HtmlGenericControl th = new HtmlGenericControl("td");
                    th.Style.Add("font-weight", "bold");
                    th.InnerText = "Proizvod";
                    tr.Controls.Add(th);

                    HtmlGenericControl th2 = new HtmlGenericControl("td");
                    th2.Style.Add("font-weight", "bold");
                    th2.InnerText = "Ukupno";
                    tr.Controls.Add(th2);



                    foreach (DataRow item in ((DataTable)Session["CartTable"]).Rows)
                    {
                        HtmlGenericControl tr2 = new HtmlGenericControl("tr");
                        tbody.Controls.Add(tr2);

                        HtmlGenericControl td = new HtmlGenericControl("td");
                        td.InnerText = item.ItemArray[1].ToString() + " " + "x" + " " + item.ItemArray[6].ToString();
                        tr2.Controls.Add(td);

                        HtmlGenericControl td2 = new HtmlGenericControl("td");
                        td2.InnerText = (float.Parse(item.ItemArray[3].ToString()) * float.Parse(item.ItemArray[6].ToString())).ToString() + "Kn";
                        tr2.Controls.Add(td2);

                    }

                    HtmlGenericControl tr3 = new HtmlGenericControl("tr");
                    tbody.Controls.Add(tr3);

                    HtmlGenericControl th3 = new HtmlGenericControl("th");
                    th3.InnerText = "Ukupno Proizvodi";
                    tr3.Controls.Add(th3);

                    HtmlGenericControl th4 = new HtmlGenericControl("th");
                    th4.InnerText = Session["total"].ToString();
                    tr3.Controls.Add(th4);


                    HtmlGenericControl tr4 = new HtmlGenericControl("tr");
                    tbody.Controls.Add(tr4);

                    HtmlGenericControl td3 = new HtmlGenericControl("td");
                    td3.InnerText = "Dostava";
                    tr4.Controls.Add(td3);

                    HtmlGenericControl td4 = new HtmlGenericControl("td");
                    td4.InnerText = String.Format("{0:0.00}", ((float)Session["shipping"])) + "Kn";
                    tr4.Controls.Add(td4);


                    HtmlGenericControl tr5 = new HtmlGenericControl("tr");
                    tbody.Controls.Add(tr5);

                    HtmlGenericControl td5 = new HtmlGenericControl("td");
                    td5.InnerText = "Način plaćanja";
                    tr5.Controls.Add(td5);

                    HtmlGenericControl td6 = new HtmlGenericControl("td");
                    td6.InnerText = Label1.Text;
                    tr5.Controls.Add(td6);


                    HtmlGenericControl tr6 = new HtmlGenericControl("tr");
                    tbody.Controls.Add(tr6);

                    HtmlGenericControl th5 = new HtmlGenericControl("th");
                    th5.InnerText = "Ukupno";
                    tr6.Controls.Add(th5);

                    float sum = float.Parse(Session["total"].ToString()) + float.Parse(Session["shipping"].ToString());

                    HtmlGenericControl th6 = new HtmlGenericControl("th");
                    th6.InnerText = String.Format("{0:0.00}", sum) + "kn";
                    tr6.Controls.Add(th6);

                    myTable.Controls.Add(tbl);

                    SqlCommand podaciCom = new SqlCommand("SELECT [Ime], [Prezime], [Adresa], [Grad], [Telefon] FROM Narudzbe WHERE [idNarudzba] = @myID", con);
                    podaciCom.Parameters.AddWithValue("@myID", idNarudzba);

                    con.Open();

                    SqlDataReader reader1 = podaciCom.ExecuteReader();

                    if (reader1.Read())
                    {
                        naziv.InnerText = (string)reader1["Ime"] + " " + (string)reader1["Prezime"];
                        adresa.InnerText = (string)reader1["Adresa"] + ", " + (string)reader1["Grad"];
                        tel.InnerText = (string)reader1["Telefon"];
                    }

                    con.Close();
                }
            }
            else
            {
                Panel1.Controls.Clear();
                Button1.Visible = false;

                HtmlGenericControl DivContainer = new HtmlGenericControl();
                DivContainer.Attributes["class"] = "container";
                DivContainer.TagName = "div";

                HtmlGenericControl row = new HtmlGenericControl("div");
                row.Attributes["class"] = "row";

                HtmlGenericControl col = new HtmlGenericControl("div");
                col.Attributes["class"] = "col-md-12 main-wrap";

                HtmlGenericControl con1 = new HtmlGenericControl("div");
                con1.Attributes["class"] = "main-content";

                HtmlGenericControl commerce = new HtmlGenericControl("div");
                commerce.Attributes["class"] = "commerce";

                HtmlGenericControl para = new HtmlGenericControl("p");
                para.Attributes["class"] = "cart-empty";
                para.InnerText = "Došlo je do problema s vašem narudžbom, molimo ponovno naručite.";
                para.Style.Add("color", "#ea3a1a");

                commerce.Controls.Add(para);

                con1.Controls.Add(commerce);

                col.Controls.Add(con1);

                row.Controls.Add(col);

                DivContainer.Controls.Add(row);

                Panel1.Controls.Add(DivContainer);
            }

            Session.Clear();

            Session["naruceno"] = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["DajSeMakni"] = 1;

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Narudzbe" + idNarudzba + ".pdf");
            Response.TransmitFile(Server.MapPath("~/Narudzbe/Narudzba" + idNarudzba + ".pdf"));
            Response.End();
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }
    }
}