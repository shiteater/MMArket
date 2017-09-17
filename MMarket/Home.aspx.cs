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
    public partial class Home : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            DoMagicNajprodavaniji();
            DoMagicNaAkciji();
        }
        
        private void DoMagicNaAkciji()
        {
            DataTable dt = new DataTable();
            if (ViewState["AkcijaTable"] == null)
            {
                SqlConnection con = new SqlConnection(conString);

                string jeilinije = "je";
                SqlCommand com = new SqlCommand("SELECT [idProizvod], [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [Akcija] LIKE @je", con);
                com.Parameters.AddWithValue("@je", jeilinije);

                con.Open();

                SqlDataAdapter adptr = new SqlDataAdapter(com);

                adptr.Fill(dt);

                con.Close();

                ViewState["AkcijaTable"] = dt;
            }
            else
            {
                dt = (DataTable)ViewState["AkcijaTable"];
            }

            HtmlGenericControl mainDiv = new HtmlGenericControl();
            mainDiv.Attributes["class"] = "row";
            mainDiv.Style.Add("margin-left", "1%");
            mainDiv.Style.Add("margin-right", "1%");
            mainDiv.TagName = "div";

            HtmlGenericControl subMainAkcija = new HtmlGenericControl();
            subMainAkcija.Attributes["class"] = "col-lg-6 col-md-8 col-sm-12";
            subMainAkcija.TagName = "div";

            HtmlGenericControl subAkcija = new HtmlGenericControl();
            subAkcija.Attributes["class"] = "row";
            subAkcija.Style.Add("width", "100%");
            subAkcija.TagName = "div";

            HtmlGenericControl commerce = new HtmlGenericControl("div");
            commerce.Attributes["class"] = "commerce";

            HtmlGenericControl naAkciji = new HtmlGenericControl("div");
            naAkciji.Attributes["class"] = "col-lg-12";

            HtmlGenericControl paraNaAkc = new HtmlGenericControl("p");
            paraNaAkc.Attributes["class"] = "cart-empty";
            paraNaAkc.InnerText = "PROIZVODI NA AKCIJI";

            naAkciji.Controls.Add(paraNaAkc);
            commerce.Controls.Add(naAkciji);
            subAkcija.Controls.Add(commerce);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HtmlGenericControl itemDiv = new HtmlGenericControl();
                itemDiv.Attributes["class"] = "col-lg-4 col-md-4 col-sm-6";
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

                //ImageButton imgBtn = new ImageButton();
                //imgBtn.ID = "akcija_" + i;
                //imgBtn.ImageUrl = "~/Images/icones/add_to_cart_purple.png";
                //imgBtn.Width = 20;
                //imgBtn.Click += AddToCart_ServerClick;
                //imgBtn.CausesValidation = false;

                HtmlGenericControl commerce11 = new HtmlGenericControl("div");
                commerce11.Attributes["class"] = "commerce";

                HtmlGenericControl paraNew = new HtmlGenericControl("p");
                paraNew.Attributes["class"] = "return-to-shop";

                HtmlButton btnTbody = new HtmlButton();
                btnTbody.ID = "akcija_" + i;
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
                subAkcija.Controls.Add(itemDiv);
            }

            subMainAkcija.Controls.Add(subAkcija);
            mainDiv.Controls.Add(subMainAkcija);

            HtmlGenericControl subMainMap = new HtmlGenericControl();
            subMainMap.Attributes["class"] = "col-lg-6 col-md-8 col-sm-12";
            subMainMap.TagName = "div";

            HtmlGenericControl subMap = new HtmlGenericControl();
            subMap.Attributes["class"] = "row col-lg-12";
            subMap.TagName = "div";

            HtmlIframe mapIFrame = new HtmlIframe();
            mapIFrame.Src = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2783.15947314275!2d15.93905251556764!3d45.76799417910569!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4765d43ba34f8727%3A0xe97ed758c57f65b!2sMarita+Market!5e0!3m2!1shr!2shr!4v1504394070429";
            mapIFrame.Style.Add("border-style", "none");
            mapIFrame.Style.Add("width", "100%");
            mapIFrame.Style.Add("height", "500px");

            subMap.Controls.Add(mapIFrame);
            subMainMap.Controls.Add(subMap);
            mainDiv.Controls.Add(subMainMap);

            Panel1.Controls.Add(mainDiv);
        }

        private void ItemAnchor_ServerClick(object sender, EventArgs e)
        {
            string resultString = Regex.Match(((HtmlAnchor)sender).ID, @"\d+").Value;
            Session["ProductId"] = resultString;
            Response.Redirect("ProductDetails.aspx");
        }

        private void DoMagicNajprodavaniji()
        {
            DataTable dt = new DataTable();
            if (ViewState["NajprodavanijiTable"] == null)
            {
                SqlConnection con = new SqlConnection(conString);

                string jeilinije = "je";
                SqlCommand com = new SqlCommand("SELECT [idProizvod], [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [Najprodavaniji] LIKE @je", con);
                com.Parameters.AddWithValue("@je", jeilinije);

                con.Open();

                SqlDataAdapter adptr = new SqlDataAdapter(com);
                adptr.Fill(dt);

                con.Close();

                ViewState["NajprodavanijiTable"] = dt;
            }
            else
            {
                dt = (DataTable)ViewState["NajprodavanijiTable"];
            }   

            int counter = dt.Rows.Count;
            while (counter % 3 != 0)
            {
                counter--;
            }
            int trazeni = counter / 3;
            int ostalo = dt.Rows.Count - (trazeni * 3);

            HtmlGenericControl DivContainer = new HtmlGenericControl();
            DivContainer.Attributes["class"] = "carousel-inner";
            DivContainer.TagName = "div";

            if (ostalo != 0)
            {
                if (Session["change"] == null)
                {
                    counter = 0;
                    for (int i = 0; i < trazeni; i++)
                    {
                        HtmlGenericControl DivItem = new HtmlGenericControl();
                        DivItem.TagName = "div";

                        HtmlGenericControl subItem = new HtmlGenericControl();
                        subItem.Attributes["class"] = "row";
                        subItem.TagName = "div";

                        if (i == 0)
                        {
                            DivItem.Attributes["class"] = "item active";
                        }
                        else
                        {
                            DivItem.Attributes["class"] = "item";
                        }

                        for (int j = 0; j < 3; j++)
                        {
                            HtmlGenericControl SubItem1 = new HtmlGenericControl();
                            SubItem1.Attributes["class"] = "col-xs-4";
                            SubItem1.TagName = "div";

                            HtmlAnchor anchor = new HtmlAnchor();
                            anchor.ID = "anchorNaj_" + dt.Rows[counter].ItemArray[0];
                            anchor.CausesValidation = false;
                            anchor.ServerClick += ItemAnchor_ServerClick;

                            HtmlImage img = new HtmlImage();
                            img.Src = "Images/" + dt.Rows[counter].ItemArray[4];
                            img.Attributes["class"] = "img-responsive";
                            anchor.Controls.Add(img);

                            HtmlGenericControl Div = new HtmlGenericControl();
                            Div.Attributes["class"] = "carousel-caption";
                            Div.TagName = "div";

                            HtmlGenericControl h3 = new HtmlGenericControl();
                            h3.InnerText = dt.Rows[counter].ItemArray[1].ToString();
                            h3.TagName = "h3";

                            HtmlContainerControl para = new HtmlGenericControl("p");
                            para.InnerText = dt.Rows[counter].ItemArray[2].ToString();

                            HtmlGenericControl commerce11 = new HtmlGenericControl("div");
                            commerce11.Attributes["class"] = "commerce";

                            HtmlGenericControl paraNew = new HtmlGenericControl("p");
                            paraNew.Attributes["class"] = "return-to-shop";

                            HtmlButton btnTbody = new HtmlButton();
                            btnTbody.ID = "naj_" + counter;
                            btnTbody.Attributes["class"] = "button glyphicon glyphicon-shopping-cart";
                            btnTbody.Attributes.Add("runat", "server");
                            btnTbody.Style.Add("color", "#ffffff");
                            btnTbody.Style.Add("border-color", "#ffffff");
                            btnTbody.CausesValidation = false;
                            btnTbody.ServerClick += AddToCart_ServerClick;

                            paraNew.Controls.Add(btnTbody);
                            commerce11.Controls.Add(paraNew);

                            Div.Controls.Add(h3);
                            Div.Controls.Add(para);
                            Div.Controls.Add(commerce11);

                            anchor.Controls.Add(Div);

                            SubItem1.Controls.Add(anchor);
                            subItem.Controls.Add(SubItem1);

                            ++counter;
                        }

                        DivItem.Controls.Add(subItem);
                        DivContainer.Controls.Add(DivItem);
                    }

                    HtmlContainerControl ol = new HtmlGenericControl("ol");
                    ol.Attributes["class"] = "carousel-indicators";

                    for (int i = 0; i < trazeni; i++)
                    {
                        HtmlGenericControl li = new HtmlGenericControl();
                        li.Attributes["data-target"] = "#imageCarousel";
                        li.Attributes["data-slide-to"] = i.ToString();
                        if (i == 0)
                        {
                            li.Attributes["class"] = "active";
                        }
                        li.TagName = "li";
                        ol.Controls.Add(li);
                    }


                    Panel2.Controls.Add(ol);
                    Panel2.Controls.Add(DivContainer);

                    Session["change"] = 0;
                }
                else
                {
                    counter = dt.Rows.Count - 1;
                    for (int i = trazeni; i > 0; i--)
                    {
                        HtmlGenericControl DivItem = new HtmlGenericControl();
                        DivItem.TagName = "div";

                        HtmlGenericControl subItem = new HtmlGenericControl();
                        subItem.Attributes["class"] = "row";
                        subItem.TagName = "div";

                        if (i == trazeni)
                        {
                            DivItem.Attributes["class"] = "item active";
                        }
                        else
                        {
                            DivItem.Attributes["class"] = "item";
                        }

                        for (int j = 0; j < 3; j++)
                        {
                            HtmlGenericControl SubItem1 = new HtmlGenericControl();
                            SubItem1.Attributes["class"] = "col-xs-4";
                            SubItem1.TagName = "div";

                            HtmlAnchor anchor = new HtmlAnchor();
                            anchor.ID = "anchorNaj_" + dt.Rows[counter].ItemArray[0];
                            anchor.CausesValidation = false;
                            anchor.ServerClick += ItemAnchor_ServerClick;

                            HtmlImage img = new HtmlImage();
                            img.Src = "Images/" + dt.Rows[counter].ItemArray[4];
                            img.Attributes["class"] = "img-responsive";
                            anchor.Controls.Add(img);

                            HtmlGenericControl Div = new HtmlGenericControl();
                            Div.Attributes["class"] = "carousel-caption";
                            Div.TagName = "div";

                            HtmlGenericControl h3 = new HtmlGenericControl();
                            h3.InnerText = dt.Rows[counter].ItemArray[1].ToString();
                            h3.TagName = "h3";

                            HtmlContainerControl para = new HtmlGenericControl("p");
                            para.InnerText = dt.Rows[counter].ItemArray[2].ToString();

                            HtmlGenericControl commerce11 = new HtmlGenericControl("div");
                            commerce11.Attributes["class"] = "commerce";

                            HtmlGenericControl paraNew = new HtmlGenericControl("p");
                            paraNew.Attributes["class"] = "return-to-shop";

                            HtmlButton btnTbody = new HtmlButton();
                            btnTbody.ID = "naj_" + counter;
                            btnTbody.Attributes["class"] = "button glyphicon glyphicon-shopping-cart";
                            btnTbody.Attributes.Add("runat", "server");
                            btnTbody.Style.Add("color", "#ffffff");
                            btnTbody.Style.Add("border-color", "#ffffff");
                            btnTbody.CausesValidation = false;
                            btnTbody.ServerClick += AddToCart_ServerClick;

                            paraNew.Controls.Add(btnTbody);
                            commerce11.Controls.Add(paraNew);

                            Div.Controls.Add(h3);
                            Div.Controls.Add(para);
                            Div.Controls.Add(commerce11);

                            anchor.Controls.Add(Div);

                            SubItem1.Controls.Add(anchor);
                            subItem.Controls.Add(SubItem1);

                            --counter;
                        }

                        DivItem.Controls.Add(subItem);
                        DivContainer.Controls.Add(DivItem);
                    }

                    HtmlContainerControl ol = new HtmlGenericControl("ol");
                    ol.Attributes["class"] = "carousel-indicators";

                    for (int i = 0; i < trazeni; i++)
                    {
                        HtmlGenericControl li = new HtmlGenericControl();
                        li.Attributes["data-target"] = "#imageCarousel";
                        li.Attributes["data-slide-to"] = i.ToString();
                        if (i == 0)
                        {
                            li.Attributes["class"] = "active";
                        }
                        li.TagName = "li";
                        ol.Controls.Add(li);
                    }


                    Panel2.Controls.Add(ol);
                    Panel2.Controls.Add(DivContainer);

                    Session["change"] = null;
                }
            }
            else
            {
                counter = 0;
                for (int i = 0; i < trazeni; i++)
                {
                    HtmlGenericControl DivItem = new HtmlGenericControl();
                    DivItem.TagName = "div";

                    HtmlGenericControl subItem = new HtmlGenericControl();
                    subItem.Attributes["class"] = "row";
                    subItem.TagName = "div";

                    if (i == 0)
                    {
                        DivItem.Attributes["class"] = "item active";
                    }
                    else
                    {
                        DivItem.Attributes["class"] = "item";
                    }

                    for (int j = 0; j < 3; j++)
                    {
                        HtmlGenericControl SubItem1 = new HtmlGenericControl();
                        SubItem1.Attributes["class"] = "col-xs-4";
                        SubItem1.TagName = "div";

                        HtmlAnchor anchor = new HtmlAnchor();
                        anchor.ID = "anchorNaj_" + dt.Rows[counter].ItemArray[0];
                        anchor.CausesValidation = false;
                        anchor.ServerClick += ItemAnchor_ServerClick;

                        HtmlImage img = new HtmlImage();
                        img.Src = "Images/" + dt.Rows[counter].ItemArray[4];
                        img.Attributes["class"] = "img-responsive";
                        anchor.Controls.Add(img);

                        HtmlGenericControl Div = new HtmlGenericControl();
                        Div.Attributes["class"] = "carousel-caption";
                        Div.TagName = "div";

                        HtmlGenericControl h3 = new HtmlGenericControl();
                        h3.InnerText = dt.Rows[counter].ItemArray[1].ToString();
                        h3.TagName = "h3";

                        HtmlContainerControl para = new HtmlGenericControl("p");
                        para.InnerText = dt.Rows[counter].ItemArray[2].ToString();

                        HtmlGenericControl commerce11 = new HtmlGenericControl("div");
                        commerce11.Attributes["class"] = "commerce";

                        HtmlGenericControl paraNew = new HtmlGenericControl("p");
                        paraNew.Attributes["class"] = "return-to-shop";

                        HtmlButton btnTbody = new HtmlButton();
                        btnTbody.ID = "naj_" + counter;
                        btnTbody.Attributes["class"] = "button glyphicon glyphicon-shopping-cart";
                        btnTbody.Attributes.Add("runat", "server");
                        btnTbody.Style.Add("color", "#ffffff");
                        btnTbody.Style.Add("border-color", "#ffffff");
                        btnTbody.CausesValidation = false;
                        btnTbody.ServerClick += AddToCart_ServerClick;

                        paraNew.Controls.Add(btnTbody);
                        commerce11.Controls.Add(paraNew);

                        Div.Controls.Add(h3);
                        Div.Controls.Add(para);
                        Div.Controls.Add(commerce11);

                        anchor.Controls.Add(Div);

                        SubItem1.Controls.Add(anchor);
                        subItem.Controls.Add(SubItem1);

                        ++counter;
                    }

                    DivItem.Controls.Add(subItem);
                    DivContainer.Controls.Add(DivItem);
                }

                HtmlContainerControl ol = new HtmlGenericControl("ol");
                ol.Attributes["class"] = "carousel-indicators";

                for (int i = 0; i < trazeni; i++)
                {
                    HtmlGenericControl li = new HtmlGenericControl();
                    li.Attributes["data-target"] = "#imageCarousel";
                    li.Attributes["data-slide-to"] = i.ToString();
                    if (i == 0)
                    {
                        li.Attributes["class"] = "active";
                    }
                    li.TagName = "li";
                    ol.Controls.Add(li);
                }


                Panel2.Controls.Add(ol);
                Panel2.Controls.Add(DivContainer);
            }
        }

        private void AddToCart_ServerClick(object sender, EventArgs e)
        {
            if (Session["CartTable"] == null)
            {
                DataTable dt = new DataTable();

                if (((HtmlButton)sender).ID.First() == 'n')
                {
                    dt = ((DataTable)ViewState["NajprodavanijiTable"]).Clone();

                    string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
                    int row = int.Parse(resultString);
                    dt.ImportRow(((DataTable)ViewState["NajprodavanijiTable"]).Rows[row]);
                }
                else if (((HtmlButton)sender).ID.First() == 'a')
                {
                    dt = ((DataTable)ViewState["AkcijaTable"]).Clone();

                    string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
                    int row = int.Parse(resultString);
                    dt.ImportRow(((DataTable)ViewState["AkcijaTable"]).Rows[row]);
                }

                Session["CartTable"] = dt;
            }
            else
            {
                bool dodaj = true;

                if (((HtmlButton)sender).ID.First() == 'n')
                {
                    string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
                    int row = int.Parse(resultString);

                    foreach (DataRow item in ((DataTable)Session["CartTable"]).Rows)
                    {
                        if ((int)item.ItemArray[0] == (int)((DataTable)ViewState["NajprodavanijiTable"]).Rows[row].ItemArray[0])
                        {
                            dodaj = false;
                        }
                    }

                    if (dodaj)
                    {
                        ((DataTable)Session["CartTable"]).ImportRow(((DataTable)ViewState["NajprodavanijiTable"]).Rows[row]);
                    }
                }
                else if (((HtmlButton)sender).ID.First() == 'a')
                {
                    string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
                    int row = int.Parse(resultString);

                    foreach (DataRow item in ((DataTable)Session["CartTable"]).Rows)
                    {
                        if ((int)item.ItemArray[0] == (int)((DataTable)ViewState["AkcijaTable"]).Rows[row].ItemArray[0])
                        {
                            dodaj = false;
                        }
                    }

                    if (dodaj)
                    {
                        ((DataTable)Session["CartTable"]).ImportRow(((DataTable)ViewState["AkcijaTable"]).Rows[row]);
                    }
                }
            }
        }
    }
}