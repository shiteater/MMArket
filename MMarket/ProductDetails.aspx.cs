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
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;
            DataTable dt = new DataTable();
            string id = (string)(Session["ProductId"]);

            SqlConnection con = new SqlConnection(conString);

            SqlCommand com = new SqlCommand("SELECT [idProizvod], [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [IdProizvod] LIKE @id", con);
            com.Parameters.AddWithValue("@id", id);

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter(com);

            ViewState["CurrentTable"] = dt;

            adptr.Fill(dt);

            con.Close();

            HtmlGenericControl mainDiv = new HtmlGenericControl("div");
            mainDiv.Attributes["class"] = "container";
            mainDiv.Style.Add("width", "100%");
            mainDiv.Style.Add("height", "100%");

            HtmlGenericControl jumboDiv = new HtmlGenericControl("div");
            jumboDiv.Attributes["class"] = "jumbotron";

            HtmlGenericControl rowDiv = new HtmlGenericControl("div");
            rowDiv.Attributes["class"] = "row";

            HtmlGenericControl imageDiv = new HtmlGenericControl("div");
            imageDiv.Attributes["class"] = "col-md-6 col-xs-12 col-sm-4 col-lg-6";

            HtmlImage itemImage = new HtmlImage();
            itemImage.Attributes.Add("class", "img-responsive thumbnail");
            itemImage.Src = "Images/" + dt.Rows[0].ItemArray[4];
            itemImage.Attributes.Add("alt", "stack photo");

            imageDiv.Controls.Add(itemImage);

            HtmlGenericControl infoDiv = new HtmlGenericControl("div");
            infoDiv.Attributes["class"] = "col-md-6 col-xs-12 col-sm-8 col-lg-6";

            HtmlGenericControl nazivDiv = new HtmlGenericControl("div");
            nazivDiv.Attributes["class"] = "container";
            nazivDiv.Style.Add("border-bottom", "1px solid black");

            HtmlGenericControl naziv = new HtmlGenericControl("h2");
            naziv.InnerText = dt.Rows[0].ItemArray[1].ToString();
            naziv.Style.Add("font-family", "Lobster");
            nazivDiv.Controls.Add(naziv);

            LiteralControl hr = new LiteralControl("<hr/>");

            HtmlGenericControl subInfoDiv = new HtmlGenericControl("div");
            subInfoDiv.Attributes["class"] = "container details";
            
            HtmlGenericControl para1 = new HtmlGenericControl("p");
            para1.InnerText = dt.Rows[0].ItemArray[3].ToString() + " Kn";
            para1.Style.Add("color", "blue");
            
            HtmlGenericControl para2 = new HtmlGenericControl("p");
            para2.InnerText = dt.Rows[0].ItemArray[2].ToString();
            para2.Style.Add("font-family", "Lobster Two");
            
            HtmlGenericControl commerce11 = new HtmlGenericControl("div");
            commerce11.Attributes["class"] = "commerce";

            HtmlGenericControl paraNew = new HtmlGenericControl("p");
            paraNew.Attributes["class"] = "return-to-shop";

            HtmlButton btnTbody = new HtmlButton();
            btnTbody.ID = "akcija_0";
            btnTbody.Attributes["class"] = "button glyphicon glyphicon-shopping-cart";
            btnTbody.Attributes.Add("runat", "server");
            btnTbody.Style.Add("color", "#AD1616");
            btnTbody.Style.Add("border-color", "#AD1616");
            btnTbody.CausesValidation = false;
            btnTbody.ServerClick += AddToCart_ServerClick;

            paraNew.Controls.Add(btnTbody);
            commerce11.Controls.Add(paraNew);

            subInfoDiv.Controls.Add(para1);
            subInfoDiv.Controls.Add(para2);
            subInfoDiv.Controls.Add(commerce11);

            infoDiv.Controls.Add(nazivDiv);
            infoDiv.Controls.Add(hr);
            infoDiv.Controls.Add(subInfoDiv);

            rowDiv.Controls.Add(imageDiv);
            rowDiv.Controls.Add(infoDiv);

            jumboDiv.Controls.Add(rowDiv);

            mainDiv.Controls.Add(jumboDiv);

            Panel1.Controls.Add(mainDiv);
        }

        private void AddToCart_ServerClick(object sender, EventArgs e)
        {
            if (Session["CartTable"] == null)
            {
                DataTable dt = new DataTable();

                dt = ((DataTable)ViewState["CurrentTable"]).Clone();

                string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
                int row = int.Parse(resultString);
                dt.ImportRow(((DataTable)ViewState["CurrentTable"]).Rows[row]);

                Session["CartTable"] = dt;
            }

            else
            {
                bool dodaj = true;

                string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
                int row = int.Parse(resultString);

                foreach (DataRow item in ((DataTable)Session["CartTable"]).Rows)
                {
                    if ((int)item.ItemArray[0] == (int)((DataTable)ViewState["CurrentTable"]).Rows[row].ItemArray[0])
                    {
                        dodaj = false;
                    }
                }

                if (dodaj)
                {
                    ((DataTable)Session["CartTable"]).ImportRow(((DataTable)ViewState["CurrentTable"]).Rows[row]);
                }
            }
        }
    }
}