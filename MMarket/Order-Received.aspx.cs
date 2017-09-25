﻿using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MMarket
{
    public partial class Order_Received : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;
        int idNarudzba = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CartTable"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            
            SqlConnection con = new SqlConnection(conString);

            SqlCommand idCom = new SqlCommand("SELECT IDENT_CURRENT('Narudzbe') AS Current_Identity", con);

            con.Open();

            SqlDataReader reader = idCom.ExecuteReader();

            if (reader.Read())
            {
                idNarudzba = int.Parse(reader["Current_Identity"].ToString());
            }

            con.Close();

            if (idNarudzba != 0)
            {
                Narudzba.InnerText = "Broj narudžbe: " + idNarudzba;
                DateTime thisDay = DateTime.Today;
                myDatum.InnerText = thisDay.ToString("d");

                if (Session["Pouzece"] != null)
                {
                    Label1.Text = "Plaćanje gotovinom prilikom dostave.\nDostava unutar 3 dana.";
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

                    HtmlGenericControl th = new HtmlGenericControl("th");
                    th.InnerText = "Proizvod";
                    tr.Controls.Add(th);

                    HtmlGenericControl th2 = new HtmlGenericControl("th");
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
                }

                Session["naruceno"] = true;
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Narudzba" + idNarudzba + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Panel1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}
