using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace MMarket
{
    public partial class KavaCaj : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           

            //HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
            //createDiv.ID = "createDiv";
            //createDiv.Style.Add(HtmlTextWriterStyle.
            //createDiv.Style.Add(HtmlTextWriterStyle.Height, "100px");
            //createDiv.Style.Add(HtmlTextWriterStyle.Width, "400px");
            //createDiv.InnerHtml = " I'm a div, from code behind ";
            //this.Controls.Add(createDiv);



         
            //HtmlGenericControl divItem = new HtmlGenericControl("div");
            //divItem.Attributes["class"] = "item active";

            //HtmlGenericControl divItem2 = new HtmlGenericControl("div");
            //divItem2.Attributes["class"] = "item";

            //HtmlGenericControl dv1= new HtmlGenericControl("div");




            //dv1.InnerHtml = "<htmltag>fdgfdgfdgfd</htmltag>";

            //HtmlImage img = new HtmlImage();
            //img.ID = "myImage";
            //img.Src = "~/Images/1.jpg";
            //img.Alt = "An image";
            //img.Attributes.Add("class", "cssimage");

            //dv1.Controls.Add(img);
            //this.Controls.Add(dv1);

            //HtmlGenericControl div2 = new HtmlGenericControl("div");
            //div2.Attributes["class"] = "col-lg-4";
            //div2.InnerHtml = "<htmltag>something within html tags</htmltag>";
            //HtmlImage img2 = new HtmlImage();
            //img2.ID = "myImage";
            //img2.Src = "~/Images/2.jpg";
            //img2.Alt = "An image";
            //img2.Attributes.Add("class", "cssimage");

            //div2.Controls.Add(img2);
            //this.Controls.Add(div2);


            //HtmlGenericControl div3 = new HtmlGenericControl("div");

            //div3.Attributes["class"] = "col-lg-4";


            //div3.InnerHtml = "<htmltag>something within html tags</htmltag>";

            //HtmlImage img3 = new HtmlImage();
            //img3.ID = "myImage";
            //img3.Src = "~/Images/3.jpg";
            //img3.Alt = "An image";
            //img3.Attributes.Add("class", "cssimage");

            //div3.Controls.Add(img3);
            //this.Controls.Add(div3);


            ////HtmlGenericControl a = new HtmlGenericControl("a");
            ////Image img = new Image();
            ////img.ImageUrl = "~/Images/1.jpg";
            //a.Controls.Add(img);



            //    < div class="col-lg-3 col-md-4 col-sm-6">
            //    <a href = "Images/1.jpg" class="thumbnail">
            //        <p>Chrysanthemum</p>
            //        <img src = "Images/1.jpg" />
            //    </ a >
            //</ div >

            //string CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(CS))

            //    MySqlDataReader dr = runQuery("SELECT * FROM category");

            //while (dr.Read())
            //{
            //    HtmlGenericControl divColumnD1 = new HtmlGenericControl("div");
            //    divColumnD1.Attributes["class"] = "col-sm-3";

            //    Image img = new Image();
            //    img.ImageUrl = dr["logoURL"].ToString();

            //    Label lbl1 = new Label();
            //    lbl1.Text = "<br>" + dr["name"].ToString();

            //    divCategory.Controls.Add(divItem);
            //    divItem.Controls.Add(divColumnH);
            //    divColumnD1.Controls.Add(img);
            //    divColumnD1.Controls.Add(lbl1);
            //}
            //ConnectionClose();
        }
    }
}
