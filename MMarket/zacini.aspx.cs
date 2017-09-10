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
    public partial class zacini : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DoMagic();
            }
        }

        private void DoMagic()
        {
            SqlConnection con = new SqlConnection(conString);

            string zacini = "zacini";
            SqlCommand com = new SqlCommand("SELECT [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [Kategorija] LIKE @zacini", con);
            com.Parameters.AddWithValue("@zacini", zacini);

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adptr.Fill(dt);

            con.Close();

            ViewState["CurrentTable"] = dt;

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
                Label lbl = new Label();
                lbl.Text = dt.Rows[i].ItemArray[0].ToString();
                para.Controls.Add(lbl);

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
    }
}