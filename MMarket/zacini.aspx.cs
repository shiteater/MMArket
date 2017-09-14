﻿using System;
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
    public partial class zacini : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(conString);

            string zacini = "zacini";
            SqlCommand com = new SqlCommand("SELECT [idProizvod], [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [Kategorija] LIKE @zacini", con);
            com.Parameters.AddWithValue("@zacini", zacini);

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter(com);

            ViewState["zacini"] = dt;

            adptr.Fill(dt);

            con.Close();

            HtmlGenericControl mainDiv = new HtmlGenericControl();
            mainDiv.Attributes["class"] = "row";
            mainDiv.TagName = "div";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HtmlGenericControl itemDiv = new HtmlGenericControl();
                itemDiv.Attributes["class"] = "col-lg-3 col-md-4 col-sm-6";
                itemDiv.TagName = "div";

                HtmlAnchor itemAnchor = new HtmlAnchor();
                itemAnchor.Attributes["class"] = "thumbnail";

                ImageButton itemImage = new ImageButton();
                itemImage.ID = "itemimage" + dt.Rows[i].ItemArray[0];
                itemImage.ImageUrl = "~/Images/" + dt.Rows[i].ItemArray[4];
                itemImage.Attributes.Add("class", "img-responsive");
                itemImage.Click += ItemImage_Click;
                itemImage.CausesValidation = false;


                HtmlContainerControl para = new HtmlGenericControl("p");
                para.InnerText = dt.Rows[i].ItemArray[1].ToString();


                HtmlGenericControl Div = new HtmlGenericControl();
                Div.TagName = "div";

                ImageButton imgBtn = new ImageButton();
                imgBtn.ID = "akcija_" + i;
                imgBtn.ImageUrl = "~/Images/icones/add_to_cart_purple.png";
                imgBtn.Width = 20;
                imgBtn.Click += AddToCart_ServerClick;
                imgBtn.CausesValidation = false;

                HtmlContainerControl para1 = new HtmlGenericControl("p");
                para1.Style.Add("float", "right");
                para1.InnerText = dt.Rows[i].ItemArray[3] + " kn";

                Div.Controls.Add(imgBtn);
                Div.Controls.Add(para1);

                itemAnchor.Controls.Add(para);
                itemAnchor.Controls.Add(itemImage);
                itemAnchor.Controls.Add(Div);
                itemDiv.Controls.Add(itemAnchor);
                mainDiv.Controls.Add(itemDiv);
            }
            Panel1.Controls.Add(mainDiv);


        }

        private void ItemImage_Click(object sender, ImageClickEventArgs e)
        {
            string resultString = Regex.Match(((ImageButton)sender).ID, @"\d+").Value;
            Session["ProductId"] = resultString;
            Response.Redirect("ProductDetails.aspx");
        }

        private void AddToCart_ServerClick(object sender, EventArgs e)
        {
            if (Session["CartTable"] == null)
            {
                DataTable dt = new DataTable();



                dt = ((DataTable)ViewState["zacini"]).Clone();

                string resultString = Regex.Match(((ImageButton)sender).ID, @"\d+").Value;
                int row = int.Parse(resultString);
                dt.ImportRow(((DataTable)ViewState["zacini"]).Rows[row]);

                Session["CartTable"] = dt;
            }

            else
            {
                bool dodaj = true;

                string resultString = Regex.Match(((ImageButton)sender).ID, @"\d+").Value;
                int row = int.Parse(resultString);

                foreach (DataRow item in ((DataTable)Session["CartTable"]).Rows)
                {
                    if ((int)item.ItemArray[0] == (int)((DataTable)ViewState["zacini"]).Rows[row].ItemArray[0])
                    {
                        dodaj = false;
                    }
                }

                if (dodaj)
                {
                    ((DataTable)Session["CartTable"]).ImportRow(((DataTable)ViewState["zacini"]).Rows[row]);
                }
            }
        }
    }
}