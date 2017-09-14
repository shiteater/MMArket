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
            string id = (string)(Session["ProductId"]);

            SqlConnection con = new SqlConnection(conString);

            SqlCommand com = new SqlCommand("SELECT [Naziv], [Opis], [Cijena], [NazFile], [IdProizvod] FROM [Proizvodi] WHERE [IdProizvod] LIKE @id", con);
            com.Parameters.AddWithValue("@id", id);

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adptr.Fill(dt);

            con.Close();

            ViewState["CurrentTable"] = dt;

            HtmlGenericControl mainDiv2 = new HtmlGenericControl("div");
            mainDiv2.Attributes["class"] = "container";


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HtmlGenericControl mainDiv = new HtmlGenericControl("div");
                mainDiv.Attributes["class"] = "row";

                // slika na productDetails

                HtmlGenericControl itemDiv = new HtmlGenericControl("div");
                itemDiv.Attributes["class"] = "col-lg-6 col-md-6 col-sm-6";
                itemDiv.Style.Add("background-color", "greenyellow");
                itemDiv.Style.Add("border-color", "blue");

                HtmlImage itemImage = new HtmlImage();
                itemImage.Attributes.Add("class", "img-responsive");
                itemImage.Src = "Images/" + dt.Rows[i].ItemArray[3];

                // desna polovica


                HtmlGenericControl itemDiv2 = new HtmlGenericControl("div");
                itemDiv2.Attributes["class"] = "col-lg-6 col-md-6 col-sm-6";


                HtmlGenericControl container = new HtmlGenericControl("div");
                container.Attributes["class"] = "container";

                HtmlContainerControl naziv = new HtmlGenericControl("h2");
                Label lbl = new Label();
                lbl.Text = dt.Rows[i].ItemArray[0].ToString();
                naziv.Controls.Add(lbl);

                HtmlContainerControl podaci = new HtmlGenericControl("h3");
                Label opis = new Label();
                opis.Text = "Opis: " + dt.Rows[i].ItemArray[1].ToString();
                podaci.Controls.Add(opis);

                Label lbl3 = new Label();
                lbl3.Text = "<br />";
                podaci.Controls.Add(lbl3);

                Label proizvodID = new Label();
                proizvodID.Text = "Šifra proizvoda: " + dt.Rows[i].ItemArray[4].ToString();
                podaci.Controls.Add(proizvodID);

                Label lbl2 = new Label();
                lbl2.Text = "<br />";
                podaci.Controls.Add(lbl2);

                Label cijena = new Label();
                cijena.Text = "Cijena: " + dt.Rows[i].ItemArray[2].ToString() + "kn";
                podaci.Controls.Add(cijena);




                itemDiv.Controls.Add(itemImage);

                itemDiv2.Controls.Add(container);
                itemDiv2.Controls.Add(naziv);
                itemDiv2.Controls.Add(podaci);


                mainDiv.Controls.Add(itemDiv);
                mainDiv.Controls.Add(itemDiv2);

                mainDiv2.Controls.Add(mainDiv);
            }
            Panel1.Controls.Add(mainDiv2);
        }

    }
}