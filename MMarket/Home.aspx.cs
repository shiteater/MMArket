using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            if (!IsPostBack)
            {
                DoMagicNajprodavaniji();
                DoMagicNaAkciji();
            }
        }
        
        private void DoMagicNaAkciji()
        {
            SqlConnection con = new SqlConnection(conString);

            string jeilinije = "je";
            SqlCommand com = new SqlCommand("SELECT [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [Akcija] LIKE @je", con);
            com.Parameters.AddWithValue("@je", jeilinije);

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adptr.Fill(dt);

            con.Close();

            HtmlGenericControl mainDiv = new HtmlGenericControl();
            mainDiv.Attributes["class"] = "row";
            mainDiv.TagName = "div";

            HtmlGenericControl subMainAkcija = new HtmlGenericControl();
            subMainAkcija.Attributes["class"] = "col-lg-6 col-md-8 col-sm-12";
            subMainAkcija.TagName = "div";

            HtmlGenericControl subAkcija = new HtmlGenericControl();
            subAkcija.Attributes["class"] = "row";
            subAkcija.Style.Add("width", "100%");
            subAkcija.TagName = "div";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HtmlGenericControl itemDiv = new HtmlGenericControl();
                itemDiv.Attributes["class"] = "col-lg-4 col-md-4 col-sm-6";
                itemDiv.TagName = "div";

                HtmlAnchor itemAnchor = new HtmlAnchor();
                itemAnchor.Attributes["class"] = "thumbnail";

                HtmlImage itemImage = new HtmlImage();
                itemImage.Src = "Images/" + dt.Rows[i].ItemArray[3];

                HtmlContainerControl para = new HtmlGenericControl("p");
                para.InnerText = dt.Rows[i].ItemArray[0].ToString();

                itemAnchor.Controls.Add(para);
                itemAnchor.Controls.Add(itemImage);
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
            mapIFrame.Style.Add("height", "400px");

            subMap.Controls.Add(mapIFrame);
            subMainMap.Controls.Add(subMap);
            mainDiv.Controls.Add(subMainMap);

            Panel1.Controls.Add(mainDiv);
        }

        private void DoMagicNajprodavaniji()
        {
            SqlConnection con = new SqlConnection(conString);

            string jeilinije = "je";
            SqlCommand com = new SqlCommand("SELECT [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [Najprodavaniji] LIKE @je", con);
            com.Parameters.AddWithValue("@je", jeilinije);

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adptr.Fill(dt);

            con.Close();

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
                    HtmlImage img = new HtmlImage();
                    img.Src = "Images/" + dt.Rows[counter].ItemArray[3];
                    img.Attributes["class"] = "img-responsive";
                    anchor.Controls.Add(img);

                    HtmlGenericControl Div = new HtmlGenericControl();
                    Div.Attributes["class"] = "carousel-caption";
                    Div.TagName = "div";

                    HtmlGenericControl h3 = new HtmlGenericControl();
                    h3.InnerText = dt.Rows[counter].ItemArray[0].ToString();
                    h3.TagName = "h3";

                    HtmlContainerControl para = new HtmlGenericControl("p");
                    para.InnerText = dt.Rows[counter].ItemArray[1].ToString();

                    Div.Controls.Add(h3);
                    Div.Controls.Add(para);

                    anchor.Controls.Add(Div);

                    SubItem1.Controls.Add(anchor);
                    subItem.Controls.Add(SubItem1);

                    ++counter;
                }

                DivItem.Controls.Add(subItem);
                DivContainer.Controls.Add(DivItem);
            }

            if (ostalo != 0)
            {
                HtmlGenericControl DivItem1 = new HtmlGenericControl();
                DivItem1.Attributes["class"] = "item";
                DivItem1.TagName = "div";

                HtmlGenericControl subItem1 = new HtmlGenericControl();
                subItem1.Attributes["class"] = "row";
                subItem1.TagName = "div";
                for (int i = 0; i < ostalo; i++)
                {
                    HtmlGenericControl SubItem_1 = new HtmlGenericControl();
                    SubItem_1.Attributes["class"] = "col-xs-4";
                    SubItem_1.TagName = "div";

                    HtmlAnchor anchor = new HtmlAnchor();
                    HtmlImage img = new HtmlImage();
                    img.Src = "Images/" + dt.Rows[counter].ItemArray[3];
                    img.Attributes["class"] = "img-responsive";
                    anchor.Controls.Add(img);

                    HtmlGenericControl Div = new HtmlGenericControl();
                    Div.Attributes["class"] = "carousel-caption";
                    Div.TagName = "div";

                    HtmlGenericControl h3 = new HtmlGenericControl();
                    h3.InnerText = dt.Rows[counter].ItemArray[0].ToString();
                    h3.TagName = "h3";

                    HtmlContainerControl para = new HtmlGenericControl("p");
                    para.InnerText = dt.Rows[counter].ItemArray[1].ToString();

                    Div.Controls.Add(h3);
                    Div.Controls.Add(para);

                    anchor.Controls.Add(Div);

                    SubItem_1.Controls.Add(anchor);
                    subItem1.Controls.Add(SubItem_1);

                    ++counter;
                }
                DivItem1.Controls.Add(subItem1);
                DivContainer.Controls.Add(DivItem1);
            }

            HtmlContainerControl ol = new HtmlGenericControl("ol");
            ol.Attributes["class"] = "carousel-indicators";

            if (ostalo == 0)
            {
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
            }
            else
            {
                for (int i = 0; i <= trazeni; i++)
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
            }
            

            Panel2.Controls.Add(ol);
            Panel2.Controls.Add(DivContainer);
        }
    }
}