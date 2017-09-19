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
        string conString = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //DoMagicProdPic();

            DataTable dt = new DataTable();
            string id = (string)(Session["ProductId"]);

            SqlConnection con = new SqlConnection(conString);

            SqlCommand categoryCom = new SqlCommand("SELECT [Kategorija] FROM [Proizvodi] WHERE [IdProizvod] LIKE @id", con);
            categoryCom.Parameters.AddWithValue("@id", id);

            con.Open();

            SqlDataReader reader = categoryCom.ExecuteReader();

            if (reader.Read())
            {
                ViewState["kategorija"] = (string)reader["Kategorija"];
            }

            con.Close();

            

            SqlCommand com = new SqlCommand("SELECT [idProizvod], [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [IdProizvod] LIKE @id", con);
            com.Parameters.AddWithValue("@id", id);

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter(com);

            ViewState["CurrentTable"] = dt;

            adptr.Fill(dt);

            con.Close();

            DataTable dt1 = new DataTable();

            SqlCommand com1 = new SqlCommand("SELECT [NazFile] FROM [Proizvod] WHERE [idProizvod] = @id", con);
            com1.Parameters.AddWithValue("@id", int.Parse((string)(Session["ProductId"])));

            con.Open();

            SqlDataAdapter adptr1 = new SqlDataAdapter(com1);

            adptr1.Fill(dt1);

            con.Close();

            HtmlGenericControl mainDiv = new HtmlGenericControl("div");
            mainDiv.Attributes["class"] = "container";
            mainDiv.Style.Add("margin-left", "1%");
            mainDiv.Style.Add("margin-right", "1%");

            HtmlGenericControl mainArea = new HtmlGenericControl("div");
            mainArea.Attributes["id"] = "main_area";

            HtmlGenericControl row = new HtmlGenericControl("div");
            mainDiv.Attributes["class"] = "row";

            HtmlGenericControl slider = new HtmlGenericControl("div");
            slider.Attributes["id"] = "slider";

            HtmlGenericControl row1 = new HtmlGenericControl("div");
            row1.Attributes["class"] = "row";

            HtmlGenericControl carousel = new HtmlGenericControl("div");
            carousel.Attributes["id"] = "carousel-bounding-box";
            carousel.Attributes["class"] = "col-md-4 col-xs-12 col-sm-6 col-lg-6";

            HtmlGenericControl myCarousel = new HtmlGenericControl("div");
            myCarousel.Attributes["id"] = "myCarousel";
            myCarousel.Attributes["class"] = "carousel slide";

            HtmlGenericControl carousel1 = new HtmlGenericControl("div");
            carousel1.Attributes["class"] = "carousel-inner";

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                HtmlGenericControl carouselItem = new HtmlGenericControl("div");

                if (i == 0)
                {
                    carouselItem.Attributes["class"] = "active item";
                }
                else
                {
                    carouselItem.Attributes["class"] = "item";
                }

                carouselItem.Attributes.Add("data-slide-number", i.ToString());

                HtmlImage img = new HtmlImage();
                img.Src = "Images/" + dt1.Rows[i].ItemArray[0];

                carouselItem.Controls.Add(img);
                carousel1.Controls.Add(carouselItem);
            }

            HtmlAnchor anchor1 = new HtmlAnchor();
            anchor1.Attributes["class"] = "left carousel-control";
            anchor1.HRef = "#myCarousel";
            anchor1.Attributes["role"] = "button";
            anchor1.Attributes["data-slide"] = "prev";

            HtmlGenericControl span1 = new HtmlGenericControl("span");
            span1.Attributes["class"] = "glyphicon glyphicon-chevron-left";

            anchor1.Controls.Add(span1);

            HtmlAnchor anchor2 = new HtmlAnchor();
            anchor2.Attributes["class"] = "right carousel-control";
            anchor2.HRef = "#myCarousel";
            anchor2.Attributes["role"] = "button";
            anchor2.Attributes["data-slide"] = "next";

            HtmlGenericControl span2 = new HtmlGenericControl("span");
            span2.Attributes["class"] = "glyphicon glyphicon-chevron-right";

            anchor2.Controls.Add(span2);

            myCarousel.Controls.Add(carousel1);
            myCarousel.Controls.Add(anchor1);
            myCarousel.Controls.Add(anchor2);

            carousel.Controls.Add(myCarousel);

            HtmlGenericControl infoDiv = new HtmlGenericControl("div");
            infoDiv.Attributes["id"] = "carousel-text";
            infoDiv.Attributes["class"] = "col-md-8 col-xs-12 col-sm-6 col-lg-6";

            HtmlGenericControl nazivDiv = new HtmlGenericControl("div");
            nazivDiv.Style.Add("border-bottom", "1px solid black");
            nazivDiv.Style.Add("text-align", "center");

            HtmlGenericControl naziv = new HtmlGenericControl("h2");
            naziv.InnerText = dt.Rows[0].ItemArray[1].ToString();
            naziv.Style.Add("font-family", "Lobster");
            nazivDiv.Controls.Add(naziv);

            HtmlGenericControl subInfoDiv = new HtmlGenericControl("div");
            subInfoDiv.Attributes["class"] = "details";

            HtmlGenericControl divPrice = new HtmlGenericControl("div");
            HtmlGenericControl price = new HtmlGenericControl("h2");
            price.InnerText = dt.Rows[0].ItemArray[3].ToString() + " Kn";
            price.Style.Add("color", "blue");
            divPrice.Controls.Add(price);

            HtmlGenericControl divDetails = new HtmlGenericControl("div");
            HtmlGenericControl details = new HtmlGenericControl("para");
            details.Style.Add("font-size", "x-large");
            details.Style.Add("word-break", "break-all");
            details.InnerText = dt.Rows[0].ItemArray[2].ToString();
            details.Style.Add("font-family", "Lobster Two");
            divDetails.Controls.Add(details);

            HtmlGenericControl commerce11 = new HtmlGenericControl("div");
            commerce11.Attributes["class"] = "commerce";

            HtmlGenericControl paraNew = new HtmlGenericControl("p");
            paraNew.Attributes["class"] = "return-to-shop";

            HtmlButton btnTbody = new HtmlButton();
            btnTbody.ID = "details_0";
            btnTbody.Attributes["class"] = "button glyphicon glyphicon-shopping-cart";
            btnTbody.Attributes.Add("runat", "server");
            btnTbody.Style.Add("color", "#AD1616");
            btnTbody.Style.Add("border-color", "#AD1616");
            btnTbody.CausesValidation = false;
            btnTbody.ServerClick += AddToCart_ServerClick;

            paraNew.Controls.Add(btnTbody);
            commerce11.Controls.Add(paraNew);

            subInfoDiv.Controls.Add(divPrice);
            subInfoDiv.Controls.Add(divDetails);
            subInfoDiv.Controls.Add(commerce11);

            infoDiv.Controls.Add(nazivDiv);
            infoDiv.Controls.Add(subInfoDiv);

            row1.Controls.Add(carousel);
            row1.Controls.Add(infoDiv);

            slider.Controls.Add(row1);

            row.Controls.Add(slider);

            HtmlGenericControl rowHidden = new HtmlGenericControl("div");
            rowHidden.Attributes["id"] = "slider-thumbs";
            rowHidden.Attributes["class"] = "row hidden-xs";

            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Attributes["class"] = "hide-bullets";

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Attributes["class"] = "col-sm-2";

                HtmlAnchor anchor = new HtmlAnchor();
                anchor.Attributes["class"] = "thumbnail";
                anchor.Attributes["id"] = "carousel-selector-" + i.ToString();

                HtmlImage img = new HtmlImage();
                img.Src = "Images/" + dt1.Rows[i].ItemArray[0];

                anchor.Controls.Add(img);

                li.Controls.Add(anchor);

                ul.Controls.Add(li);
            }

            rowHidden.Controls.Add(ul);

            mainArea.Controls.Add(row);
            mainArea.Controls.Add(rowHidden);

            mainDiv.Controls.Add(mainArea);

            Panel1.Controls.Add(mainDiv);
            
            DoMagicKategorija();
        }

        private void AddToCart_ServerClick(object sender, EventArgs e)
        {
            if (((HtmlButton)sender).ID.First() == 'd')
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
            else
            {
                if (Session["CartTable"] == null)
                {
                    DataTable dt = new DataTable();

                    dt = ((DataTable)ViewState["currentCategory"]).Clone();

                    string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
                    int row = int.Parse(resultString);
                    dt.ImportRow(((DataTable)ViewState["currentCategory"]).Rows[row]);

                    Session["CartTable"] = dt;
                }
                else
                {
                    bool dodaj = true;

                    string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
                    int row = int.Parse(resultString);

                    foreach (DataRow item in ((DataTable)Session["CartTable"]).Rows)
                    {
                        if ((int)item.ItemArray[0] == (int)((DataTable)ViewState["currentCategory"]).Rows[row].ItemArray[0])
                        {
                            dodaj = false;
                        }
                    }

                    if (dodaj)
                    {
                        ((DataTable)Session["CartTable"]).ImportRow(((DataTable)ViewState["currentCategory"]).Rows[row]);
                    }
                }
            }
        }

        private void DoMagicKategorija()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(conString);
            
            SqlCommand com = new SqlCommand("SELECT TOP 8 [idProizvod], [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [Kategorija] LIKE @kategorija AND [idProizvod] NOT LIKE @id", con);
            com.Parameters.AddWithValue("@kategorija", (string)ViewState["kategorija"]);
            com.Parameters.AddWithValue("@id", int.Parse((string)(Session["ProductId"])));

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter(com);

            ViewState["currentCategory"] = dt;

            adptr.Fill(dt);

            con.Close();

            if (dt.Rows.Count > 0)
            {
                HtmlGenericControl mainDiv = new HtmlGenericControl();
                mainDiv.Attributes["class"] = "row";
                mainDiv.Style.Add("margin-left", "1%");
                mainDiv.Style.Add("margin-right", "1%");
                mainDiv.TagName = "div";

                HtmlGenericControl commerce = new HtmlGenericControl("div");
                commerce.Attributes["class"] = "commerce";

                HtmlGenericControl naAkciji = new HtmlGenericControl("div");
                naAkciji.Attributes["class"] = "col-lg-12";

                HtmlGenericControl paraNaAkc = new HtmlGenericControl("p");
                paraNaAkc.Attributes["class"] = "cart-empty";
                paraNaAkc.InnerText = "SLIČNI PROIZVODI";

                naAkciji.Controls.Add(paraNaAkc);
                commerce.Controls.Add(naAkciji);
                mainDiv.Controls.Add(commerce);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HtmlGenericControl itemDiv = new HtmlGenericControl();
                    itemDiv.Attributes["class"] = "col-lg-3 col-md-4 col-sm-6";
                    itemDiv.TagName = "div";

                    HtmlAnchor itemAnchor = new HtmlAnchor();
                    itemAnchor.ID = "anchorAkcija_" + dt.Rows[i].ItemArray[0];
                    itemAnchor.Attributes["class"] = "thumbnail";
                    itemAnchor.CausesValidation = false;
                    itemAnchor.ServerClick += ItemAnchor_ServerClick;


                    HtmlImage itemImage = new HtmlImage();
                    itemImage.Src = "Images/" + dt.Rows[i].ItemArray[4];

                    HtmlContainerControl para = new HtmlGenericControl("h4");
                    para.InnerText = dt.Rows[i].ItemArray[1].ToString().ToUpper();

                    HtmlGenericControl Div = new HtmlGenericControl();
                    Div.TagName = "div";

                    HtmlGenericControl commerce11 = new HtmlGenericControl("div");
                    commerce11.Attributes["class"] = "commerce";

                    HtmlGenericControl paraNew = new HtmlGenericControl("p");
                    paraNew.Attributes["class"] = "return-to-shop";

                    HtmlButton btnTbody = new HtmlButton();
                    btnTbody.ID = "category_" + i;
                    btnTbody.Attributes["class"] = "button glyphicon glyphicon-shopping-cart";
                    btnTbody.Attributes.Add("runat", "server");
                    btnTbody.Style.Add("color", "#AD1616");
                    btnTbody.Style.Add("border-color", "#AD1616");
                    btnTbody.CausesValidation = false;
                    btnTbody.ServerClick += AddToCart_ServerClick;

                    paraNew.Controls.Add(btnTbody);
                    commerce11.Controls.Add(paraNew);
                    commerce11.Style.Add("float", "left");

                    HtmlContainerControl para1 = new HtmlGenericControl("h4");
                    para1.Style.Add("float", "right");
                    para1.InnerText = dt.Rows[i].ItemArray[3] + " kn";

                    Div.Controls.Add(commerce11);
                    Div.Controls.Add(para1);

                    itemAnchor.Controls.Add(Div);
                    itemAnchor.Controls.Add(itemImage);
                    itemAnchor.Controls.Add(para);
                    itemDiv.Controls.Add(itemAnchor);
                    mainDiv.Controls.Add(itemDiv);
                }

                Panel2.Controls.Add(mainDiv);
            }
        }

        private void ItemAnchor_ServerClick(object sender, EventArgs e)
        {
            string resultString = Regex.Match(((HtmlAnchor)sender).ID, @"\d+").Value;
            Session["ProductId"] = resultString;
            Response.Redirect("ProductDetails.aspx");
        }
    }
}