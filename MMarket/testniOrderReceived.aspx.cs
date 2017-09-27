using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MMarket
{
    public partial class testniOrderReceived : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;
        int idNarudzba = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["clicked"] != null)
            {
                Session.Clear();
                Session.Abandon();
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

            pdfViewer.Style.Add("width", PageSize.A4.Width + (PageSize.A4.Width * 0.1) + "px");
            pdfViewer.Style.Add("height", PageSize.A4.Height + (PageSize.A4.Width * 0.2) + "px");
            pdfViewer.Style.Add("border-color", "#F1C13C");

            pdfViewer.Src = "/Narudzbe/Narudzba" + idNarudzba + ".pdf";
            Panel5.Visible = true;

            Session.Clear();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String path = Server.MapPath("~/Narudzbe/Narudzba" + idNarudzba + ".pdf");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Narudzba" + idNarudzba + ".pdf");
            Response.TransmitFile(path);
            Response.Flush();
            Session["clicked"] = 1;
            Response.End();
        }
    }
}