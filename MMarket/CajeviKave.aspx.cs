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
    public partial class CajeviKave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            HtmlGenericControl newDiv =new HtmlGenericControl("DIV");
            newDiv.ID = "newSuperDIV"; //<---Give and ID to the div, very important!
            newDiv.Attributes.Add("class", "col-lg-4 col-md-6");//<---Add some style as example
            HtmlGenericControl anchor = new HtmlGenericControl("a");
            anchor.Attributes.Add("href", "Images/1.jpg");
            anchor.Attributes.Add("class", "thumbnail");
            HtmlGenericControl p = new HtmlGenericControl("p");
            p.InnerHtml = "ovo je slika majke ti";
            Image img = new Image();
            img.ImageUrl = "~/Images/1.jpg";
            anchor.Controls.Add(p);
            anchor.Controls.Add(img);
            newDiv.Controls.Add(anchor);
            superDIV.Controls.Add(newDiv);

            string CS = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
              

                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM proizvodi", con);
                    //cmd.Parameters.AddWithValue("@id", (int)Session["idKor"]);
                    cmd.CommandType = CommandType.Text;

                    // Execute DataReader
                    SqlDataReader reader = cmd.ExecuteReader();
                    // Read DataReader till it reaches the end
                    while (reader.Read())
                    {
                        HtmlGenericControl newDiv3 = new HtmlGenericControl("DIV");
                        newDiv3.ID = "newSuperDIV"; //<---Give and ID to the div, very important!
                        newDiv3.Attributes.Add("class", "col-lg-4 col-md-6");//<---Add some style as example
                        HtmlGenericControl anchor3 = new HtmlGenericControl("a");
                        anchor3.Attributes.Add("href", reader["lokacija"].ToString());
                        anchor3.Attributes.Add("class", "thumbnail");
                        HtmlGenericControl p3 = new HtmlGenericControl("p");
                        p3.InnerHtml =reader["opis"].ToString();
                        Image img3 = new Image();
                        img3.ImageUrl = "~/images/"+reader["lokacija"];
                        anchor3.Controls.Add(p3);
                        anchor3.Controls.Add(img3);
                        newDiv3.Controls.Add(anchor3);
                        superDIV.Controls.Add(newDiv3);
                    }


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('There was an error:" + ex.Message + "');</script>");
                }
                con.Close();
            }

            //MySqlDataReader dr = runQuery("SELECT * FROM category");

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

            //HtmlGenericControl newDiv2 = new HtmlGenericControl("DIV");
            //newDiv2.ID = "newSuperDIV"; //<---Give and ID to the div, very important!
            //newDiv2.Attributes.Add("class", "col-lg-7");//<---Add some style as example
            //HtmlGenericControl anchor2 = new HtmlGenericControl("a");
            //anchor2.Attributes.Add("href", "Images/1.jpg");
            //anchor2.Attributes.Add("class", "thumbnail");
            //HtmlGenericControl p2 = new HtmlGenericControl("p");
            //p2.InnerHtml = "ovo je slika majke ti";
            //Image img2 = new Image();
            //img2.ImageUrl = "~/Images/1.jpg";
            //anchor2.Controls.Add(p2);
            //anchor2.Controls.Add(img2);
            //newDiv2.Controls.Add(anchor2);
            //superDIV.Controls.Add(newDiv2);

        }
    }
}