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
    public partial class Kozmetika : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(conString);

            string kozmetika = "kozmetika";
            SqlCommand com = new SqlCommand("SELECT [idProizvod], [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [Kategorija] LIKE @kozmetika", con);
            com.Parameters.AddWithValue("@kozmetika", kozmetika);

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter(com);

            ViewState["kozmetika"] = dt;

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
                itemDiv.Attributes["class"] = "col-lg-3 col-md-4 col-sm-6";
                itemDiv.TagName = "div";

                HtmlAnchor itemAnchor = new HtmlAnchor();
                itemAnchor.ID = "anchorAkcija_" + dt.Rows[i].ItemArray[0];
                itemAnchor.Attributes["class"] = "thumbnail";
                itemAnchor.Style.Add("background", "#F2F2F2");
                itemAnchor.Style.Add("border-color", "#F2F2F2");
                itemAnchor.Style.Add("color", "#5E3354");
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
                btnTbody.ID = "akcija_" + i;
                btnTbody.Attributes["class"] = "button glyphicon glyphicon-shopping-cart";
                btnTbody.Attributes.Add("runat", "server");
                btnTbody.Style.Add("color", "#F1C13C");
                btnTbody.Style.Add("border-color", "#F1C13C");
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
            Panel1.Controls.Add(mainDiv);

            DoMagicKategorija();
        }

        private void AddToCart_ServerClick(object sender, EventArgs e)
        {
            if (((HtmlButton)sender).ID.First() == 'k')
            {
                if (Session["CartTable"] == null)
                {
                    DataTable dt = new DataTable();

                    dt = ((DataTable)ViewState["kozmetika"]).Clone();

                    string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
                    int row = int.Parse(resultString);
                    dt.ImportRow(((DataTable)ViewState["kozmetika"]).Rows[row]);

                    Session["CartTable"] = dt;
                }
                else
                {
                    bool dodaj = true;

                    string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
                    int row = int.Parse(resultString);

                    foreach (DataRow item in ((DataTable)Session["CartTable"]).Rows)
                    {
                        if ((int)item.ItemArray[0] == (int)((DataTable)ViewState["kozmetika"]).Rows[row].ItemArray[0])
                        {
                            dodaj = false;
                        }
                    }

                    if (dodaj)
                    {
                        ((DataTable)Session["CartTable"]).ImportRow(((DataTable)ViewState["kozmetika"]).Rows[row]);
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

            string jeilinije = "je";
            SqlCommand com = new SqlCommand("SELECT [idProizvod], [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [Najprodavaniji] LIKE @je", con);
            com.Parameters.AddWithValue("@je", jeilinije);

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter(com);

            ViewState["currentCategory"] = dt;

            adptr.Fill(dt);

            con.Close();

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
            paraNaAkc.InnerText = "IZ PONUDE";

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

        private void ItemAnchor_ServerClick(object sender, EventArgs e)
        {
            string resultString = Regex.Match(((HtmlAnchor)sender).ID, @"\d+").Value;
            Session["ProductId"] = resultString;
            Response.Redirect("ProductDetails.aspx");
        }
    }
}