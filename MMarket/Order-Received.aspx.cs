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
    public partial class Order_Received : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            Datum.InnerText = thisDay.ToString("d");

            if (Session["Pouzece"] != null)
            {
                Label1.Text = "Plaćanje gotovinom prilikom dostave. \n Dostava unutar 3 dana.";
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
                    td.InnerText = item.ItemArray[1].ToString()+" "+ "x"+" "+ item.ItemArray[6].ToString(); 
                    tr2.Controls.Add(td);

                    HtmlGenericControl td2 = new HtmlGenericControl("td");
                    td2.InnerText = (float.Parse(item.ItemArray[3].ToString()) * float.Parse(item.ItemArray[6].ToString())).ToString() +"Kn";
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
                td4.InnerText = Session["shipping"].ToString() + "Kn";
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
                th6.InnerText = sum.ToString() +"Kn";
                tr6.Controls.Add(th6);
               
                Table.Controls.Add(tbl);
            }

        }


    }

}

//TableHeaderRow row = new TableHeaderRow();

//var cell1 = new TableCell();
//cell1.Text = "Proizvod";
//row.Cells.Add(cell1);


//var cell2 = new TableCell();
//cell2.Text = "Ukupno";
//row.Cells.Add(cell2);

////var cell3 = new TableCell();
////cell3.Text = "Footer";
////row.Cells.Add(cell3);
//TableRow row2 = new TableRow();

//var cell11 = new TableCell();
//cell11.Text = "Proizvod";
//row2.Cells.Add(cell11);

//var cell22 = new TableCell();
//cell22.Text = "Ukupno";
//row2.Cells.Add(cell22);

//TableRow row3 = new TableRow();

//var cell111 = new TableCell();
//cell111.Text = "Proizvod";
//row3.Cells.Add(cell111);

//var cell222 = new TableCell();
//cell222.Text = "Ukupno";
//row3.Cells.Add(cell222);


//Table1.Rows.Add(row);
//Table1.Rows.Add(row2);
//Table1.Rows.Add(row3);