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

            HtmlGenericControl mainDiv2 = new HtmlGenericControl("div");
            mainDiv2.Attributes["class"] = "container";


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HtmlGenericControl mainDiv = new HtmlGenericControl("div");
                mainDiv.Attributes["class"] = "row";

                // slika na productDetails

                HtmlGenericControl itemDiv = new HtmlGenericControl("div");
                itemDiv.Attributes["class"] = "col-xs-12 col-sm-4";
                itemDiv.Style.Add("border-color", "blue");

                HtmlImage itemImage = new HtmlImage();
                itemImage.Attributes.Add("class", "img-responsive");
                itemImage.Src = "Images/" + dt.Rows[i].ItemArray[4];

                // desna polovica


                HtmlGenericControl itemDiv2 = new HtmlGenericControl("div");
                itemDiv2.Attributes["class"] = "col-xs-12 col-sm-8";

                HtmlGenericControl Divh1 = new HtmlGenericControl("div");

                HtmlGenericControl clearfix = new HtmlGenericControl("div");
                clearfix.Attributes.Add("class","clearfix");


                HtmlContainerControl naziv = new HtmlGenericControl("h1");
                Label lbl = new Label();
                lbl.Text = dt.Rows[i].ItemArray[1].ToString();
                naziv.Controls.Add(lbl);
                naziv.Attributes.Add("class", "pull-left");
                naziv.Style.Add("margin-top", "30px");

                HtmlGenericControl DivCijena = new HtmlGenericControl("div");

                HtmlContainerControl Cijena = new HtmlGenericControl("h2");
                Label cijena = new Label();
                cijena.Text = dt.Rows[i].ItemArray[3].ToString() + "Kn";
                Cijena.Controls.Add(cijena);
                Cijena.Style.Add("color", "blue");
                DivCijena.Controls.Add(Cijena);

                HtmlGenericControl DivOpis = new HtmlGenericControl("div");

                HtmlContainerControl podaci = new HtmlGenericControl("h3");
                Label opis = new Label();
                opis.Text = dt.Rows[i].ItemArray[2].ToString();
                podaci.Attributes.Add("class", "Ivana Sredi Ovo");
                podaci.Controls.Add(opis);

                HtmlButton btnTbody = new HtmlButton();
                btnTbody.ID = "akcija_" + i;
                btnTbody.Attributes["class"] = "button glyphicon glyphicon-shopping-cart";
                btnTbody.Attributes.Add("runat", "server");
                btnTbody.Style.Add("color", "#6B32C7");
                btnTbody.Style.Add("border-color", "#6B32C7");
                btnTbody.Style.Add("height", "70px");
                btnTbody.Style.Add("width", "70px");
                btnTbody.CausesValidation = false;
                btnTbody.ServerClick += AddToCart_ServerClick;

                // dodavanje slike lijevo

                itemDiv.Controls.Add(itemImage);

                // desne kontrole

                Divh1.Controls.Add(naziv);

                DivOpis.Controls.Add(podaci);

                itemDiv2.Controls.Add(Divh1);
                itemDiv2.Controls.Add(clearfix);
                itemDiv2.Controls.Add(DivCijena);
                itemDiv2.Controls.Add(DivOpis);
                itemDiv2.Controls.Add(btnTbody);

                mainDiv.Controls.Add(itemDiv);
                mainDiv.Controls.Add(itemDiv2);

                mainDiv2.Controls.Add(mainDiv);
            }
            Panel1.Controls.Add(mainDiv2);
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