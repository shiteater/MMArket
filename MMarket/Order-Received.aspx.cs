using iTextSharp.text;
using iTextSharp.text.html;
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
                Session["idNarudzba"] = idNarudzba;

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
                    string logoPath = Server.MapPath("~/Images/icones/habibi_shop_pdf.png");
                    logo.Src = logoPath;

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
                    th3.InnerText = "Ukupna cijena proizvoda";
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
                    th5.Style.Add("font-weight", "bold");
                    tr6.Controls.Add(th5);

                    float sum = float.Parse(Session["total"].ToString()) + float.Parse(Session["shipping"].ToString());

                    HtmlGenericControl th6 = new HtmlGenericControl("th");
                    th6.InnerText = String.Format("{0:0.00}", sum) + "kn";
                    th6.Style.Add("font-weight", "bold");
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

            StringWriter sw2 = new StringWriter();
            HtmlTextWriter hw2 = new HtmlTextWriter(sw2);
            Panel1.RenderControl(hw2);

            byte[] bytes = RenderPDF(sw2.ToString());
            FileStream fs = new FileStream(path, FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            SqlConnection con2 = new SqlConnection(conString);
            con2.Open();
            SqlCommand email = new SqlCommand("SELECT [Email] FROM Narudzbe WHERE [idNarudzba] = @myID2", con2);
            email.Parameters.AddWithValue("@myID2", idNarudzba);

            string email2 = Convert.ToString(email.ExecuteScalar());

            con2.Close();

            // Specify the from and to email address
            MailMessage mailMessage = new MailMessage("orders@habibi-orient.com", email2);
            // Specify the email body

            String path1 = Server.MapPath("~/Images/icones/habibi_shop.png");
            Attachment inlineLogo = new Attachment(path1);
            mailMessage.Attachments.Add(inlineLogo);
            string contentID = "Image";
            inlineLogo.ContentId = contentID;


            mailMessage.Body =
            //"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
            //"<html xmlns='http://www.w3.org/1999/xhtml' xmlns: v = 'urn:schemas-microsoft-com:vml' xmlns: o = 'urn:schemas-microsoft-com:office:office'>" +
            // "<head>"
            ////"<style type='text/css'>#img1{display: block;}#img2{display:none}@media all and(max-width:499px){#img1{display:none;}#img2{display:block;}}</style>" 
            //+ "<style type='text/css'>#visibledesktop{display: block;}#visiblephone{display:none;}@media(max-width:450px){#visibledesktop{display:none;}#visiblephone{display:block;}}</style>"
            //+ "</head>"
            //"<body>"
            //+ "<div id='visibledesktop'>"
            "<center><img id='img1' src=\"cid:" + contentID + "\" width=\"40%\" /></center>"
            //+ "<img id='img2' src=\"cid:" + contentID + "\" style=\"width: 100%; height: 50%;\" />"
            + "<hr style='border-top: 1px dashed #8c8b8b;'></hr>" + " <br/>"
            + "Poštovani, <br/>Vaša narudžba je zaprimljena <br/><br/>" +
            "<hr style='border-top: 1px dashed #8c8b8b;'></hr>" + " <br/>" +
            "<p style='font-size:16px!important;font-weight:bold;color:#333333;'>Broj narudžbe:" + idNarudzba
            + "<p style='font-size:16px!important;font-weight:bold;color:#333333;'>Datum: " + thisDay.ToString("d")
            + "<p style='font-size:16px!important;font-weight:bold;color:#333333;'>Dostava na Vašu adresu unutar 3 radna dana"
            + "<p style='font-size:16px!important;font-lightt:bold;color:#333333;'>Račun u prilogu maila," + " <br/><br/>"
            + "<span>Hvala na Vašoj kupnji :)</span></div>";
            // + "<div id='visiblephone'>"
            ////+ "<center><img id='img1' src=\"cid:" + contentID + "\" style=\"width: 100%; height: 50%;\" /></center>"
            //+ "<img id='img2' src=\"cid:" + contentID + "\" width=\"100%\" />"
            //+ "<hr style='border-top: 1px dashed #8c8b8b;'></hr>" + " <br/>"
            //+ "Poštovani, <br/>Vaša narudžba je zaprimljena <br/><br/>" +
            //"<hr style='border-top: 1px dashed #8c8b8b;'></hr>" + " <br/>" +
            //"<p style='font-size:16px!important;font-weight:bold;color:#333333;'>Broj narudžbe:" + idNarudzba
            //+ "<p style='font-size:16px!important;font-weight:bold;color:#333333;'>Datum: " + thisDay.ToString("d")
            //+ "<p style='font-size:16px!important;font-weight:bold;color:#333333;'>Dostava na Vašu adresu unutar 3 radna dana"
            //+ "<p style='font-size:16px!important;font-lightt:bold;color:#333333;'>Račun u prilogu maila," + " <br/><br/>"
            //+ "<span>Hvala na Vašoj kupnji :)</span></div>"
            //+ "</body></html>";


            mailMessage.IsBodyHtml = true;
            // Specify the email Subject
            mailMessage.Subject = "Narudžba " + idNarudzba;
            mailMessage.Attachments.Add(new Attachment(path));

            mailMessage.To.Add("orders@habibi-orient.com");
            // Specify the SMTP server name and post number
            SmtpClient smtpClient = new SmtpClient("mail.habibi-orient.com", 8889);
            // Specify your gmail address and password
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "orders@habibi-orient.com",
                Password = "Habibi123!"
            };
            // Gmail works on SSL, so set this property to true
            //smtpClient.EnableSsl = true;
            // Finall send the email message using Send() method
            smtpClient.Send(mailMessage);

            Response.Redirect("orderreceived.aspx", true);
        }

        public byte[] RenderPDF(string htmlText/*, string pageTitle*/)
        {
            byte[] renderedBuffer;

            using (var outputMemoryStream = new MemoryStream())
            {
                using (var pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f))
                {
                    //string arialuniTff = Server.MapPath("~/fonts/ARIALUNI.TTF");
                    //FontFactory.Register(arialuniTff);

                    string Roboto = Server.MapPath("~/fonts/Roboto-Regular.ttf");
                    FontFactory.Register(Roboto);

                    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, outputMemoryStream);

                    pdfWriter.CloseStream = false;
                    //pdfWriter.PageEvent = new PrintHeaderFooter { Title = pageTitle };
                    pdfDocument.Open();

                    using (var htmlViewReader = new StringReader(htmlText))
                    {
                        using (var htmlWorker = new HTMLWorker(pdfDocument))
                        {
                            var styleSheet = new StyleSheet();
                            styleSheet.LoadTagStyle(HtmlTags.BODY, HtmlTags.FACE, "Roboto-Regular");//Arial Unicode MS
                            styleSheet.LoadTagStyle(HtmlTags.BODY, HtmlTags.ENCODING, BaseFont.IDENTITY_H);
                            htmlWorker.SetStyleSheet(styleSheet);

                            htmlWorker.Parse(htmlViewReader);
                        }
                    }
                }

                renderedBuffer = new byte[outputMemoryStream.Position];
                outputMemoryStream.Position = 0;
                outputMemoryStream.Read(renderedBuffer, 0, renderedBuffer.Length);
            }

            return renderedBuffer;
        }
    }
}
