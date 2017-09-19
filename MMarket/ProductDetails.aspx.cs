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
            DoMagicProdPic();

            DataTable dt = new DataTable();
            string id = (string)(Session["ProductId"]);

            SqlConnection con = new SqlConnection(conString);

            SqlCommand com = new SqlCommand("SELECT [idProizvod], [Naziv], [Opis], [Cijena], [Kategorija], [NazFile] FROM [Proizvodi] WHERE [IdProizvod] LIKE @id", con);
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
            itemImage.Src = "Images/" + dt.Rows[0].ItemArray[5];
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
            btnTbody.ID = "details_0";
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

        private void DoMagicProdPic()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(conString);
            
            SqlCommand com = new SqlCommand("SELECT [NazFile] FROM [Proizvod] WHERE [idProizvod] = @id", con);
            com.Parameters.AddWithValue("@id", int.Parse((string)(Session["ProductId"])));
            
            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter(com);

            adptr.Fill(dt);

            con.Close();

            HtmlGenericControl mainDiv = new HtmlGenericControl();
            mainDiv.Attributes["class"] = "row";
            mainDiv.Style.Add("margin-left", "1%");
            mainDiv.Style.Add("margin-right", "1%");
            mainDiv.TagName = "div";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HtmlGenericControl itemDiv = new HtmlGenericControl();
                itemDiv.Attributes["class"] = "col-lg-4 col-md-4 col-sm-6";
                itemDiv.TagName = "div";

                HtmlAnchor itemAnchor = new HtmlAnchor();
                itemAnchor.Attributes["class"] = "thumbnail";

                HtmlImage itemImage = new HtmlImage();
                itemImage.Src = "Images/" + dt.Rows[i].ItemArray[0];
                
                itemAnchor.Controls.Add(itemImage);
                itemDiv.Controls.Add(itemAnchor);
                mainDiv.Controls.Add(itemDiv);
            }

            Panel3.Controls.Add(mainDiv);
        }

        private void DoMagicKategorija()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(conString);

            string kategorija = ((DataTable)ViewState["CurrentTable"]).Rows[0].ItemArray[4].ToString();
            SqlCommand com = new SqlCommand("SELECT TOP 8 [idProizvod], [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [Kategorija] LIKE @kategorija AND [idProizvod] NOT LIKE @id", con);
            com.Parameters.AddWithValue("@kategorija", kategorija);
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