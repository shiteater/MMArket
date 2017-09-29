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
    public partial class Order_Received : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;
        int idNarudzba = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["total"] == null || Session["shipping"] == null || Session["naruceno"] == null || Session["CartTable"] == null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("Cart.aspx");
            }

            DateTime thisDay = DateTime.Today;
            myDatum.InnerText = thisDay.ToString("d");
            
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

            String path = Server.MapPath("~/Narudzbe/Narudzba" + idNarudzba + ".pdf");

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Narudzbe" + idNarudzba + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw2 = new StringWriter();
            HtmlTextWriter hw2 = new HtmlTextWriter(sw2);
            Panel1.RenderControl(hw2);
            StringReader sr2 = new StringReader(sw2.ToString());
            Document pdfDoc2 = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser2 = new HTMLWorker(pdfDoc2);
            FileStream fs = new FileStream(path, FileMode.Create);
            PdfWriter.GetInstance(pdfDoc2, fs);
            pdfDoc2.Open();
            htmlparser2.Parse(sr2);
            pdfDoc2.Close();
            Response.Write(pdfDoc2);
            fs.Close();

            // Specify the from and to email address
            MailMessage mailMessage = new MailMessage("timraketa666@gmail.com", "adel1othman@gmail.com");
            // Specify the email body

            String path1 = Server.MapPath("~/Images/icones/habibi_shop.png");
            Attachment inlineLogo = new Attachment(path1);
            mailMessage.Attachments.Add(inlineLogo);
            string contentID = "Image";
            inlineLogo.ContentId = contentID;

            mailMessage.Body =
            "<img style='width: 120px;' src=\"cid:" + contentID+"\">"
           + "<hr style='border-top: 1px dashed #8c8b8b;'></hr>" + " <br/>"     
           + "Poštovani, <br/>Vaša narudžba je zaprimljena <br/><br/>" +
           "<hr style='border-top: 1px dashed #8c8b8b;'></hr>" + " <br/>" +
           "<p style='font-size:16px!important;font-weight:bold;color:#333333;'>Broj narudžbe:" + idNarudzba
           + "<p style='font-size:16px!important;font-weight:bold;color:#333333;'>Datum: " + thisDay.ToString("d")
           + "<p style='font-size:16px!important;font-weight:bold;color:#333333;'>Dostava na Vašu adresu unutar 3 radna dana"
           + "<p style='font-size:16px!important;font-lightt:bold;color:#333333;'>Račun u prilogu maila,"+ " <br/><br/>"
           + "<span>Hvala na Vašoj kupnji :)</span>";
            mailMessage.IsBodyHtml = true;
            // Specify the email Subject
            mailMessage.Subject = "Narudžba " + idNarudzba;
            mailMessage.Attachments.Add(new Attachment(path));
            
            mailMessage.To.Add("ivaana.perko@gmail.com");
            // Specify the SMTP server name and post number
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            // Specify your gmail address and password
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "timraketa666@gmail.com",
                Password = "vabafet666"
            };
            // Gmail works on SSL, so set this property to true
            smtpClient.EnableSsl = true;
            // Finall send the email message using Send() method
            smtpClient.Send(mailMessage);

            Response.Redirect("orderreceived.aspx", true);
        }
    }
}
