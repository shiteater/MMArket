using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MMarket
{
    public partial class AdminPage : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["MaritaMarketConnectionString"].ConnectionString;

        string finalFilename = string.Empty;
        string finalFilename2 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            
            lblError.Visible = false;

            if (IsPostBack && ((FileUpload)DetailsView1.Rows[5].Cells[1].FindControl("FileUpload1")) != null)
            {
                if (((FileUpload)DetailsView1.Rows[5].Cells[1].FindControl("FileUpload1")).FileName != string.Empty)
                {
                    finalFilename = String.Format("{0}.jpeg", Guid.NewGuid().ToString());
                    ((TextBox)DetailsView1.Rows[5].Cells[1].FindControl("TextBox4")).Text = finalFilename;
                }
            }
            else if (IsPostBack && ((FileUpload)DetailsView2.Rows[2].Cells[1].FindControl("FileUpload2")) != null)
            {
                if (((FileUpload)DetailsView2.Rows[2].Cells[1].FindControl("FileUpload2")).FileName != string.Empty)
                {
                    finalFilename2 = String.Format("{0}.jpeg", Guid.NewGuid().ToString());
                    ((TextBox)DetailsView2.Rows[2].Cells[1].FindControl("tbxNaz")).Text = finalFilename2;
                }
            }
        }

        protected bool ProcessImage(byte[] imageBytes, string filename)
        {
            try
            {
                ISupportedImageFormat format = new JpegFormat() { Quality = 40 };
                //Size size = new Size(150, 150);
                using (MemoryStream inStream = new MemoryStream(imageBytes))
                {
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        using (ImageFactory ifac = new ImageFactory(true))
                        {
                            //ifac.Load(inStream).Resize(size).Format(format).Save(outStream);
                            ifac.Load(inStream)
                                .Format(format)
                                .Save(outStream);

                            var img = System.Drawing.Image.FromStream(outStream);

                            var savePath = Path.Combine(Server.MapPath("~/Images/"), filename);

                            img.Save(savePath);

                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            var ImageFilename = ((FileUpload)DetailsView1.Rows[5].Cells[1].FindControl("FileUpload1")).FileName;
            var ImageBytes = ((FileUpload)DetailsView1.Rows[5].Cells[1].FindControl("FileUpload1")).FileBytes;

            float cijenaTest;
            if (ImageFilename == string.Empty || string.IsNullOrWhiteSpace(((TextBox)DetailsView1.Rows[1].Cells[1].FindControl("TextBox1")).Text)
                || string.IsNullOrWhiteSpace(((TextBox)DetailsView1.Rows[2].Cells[1].FindControl("TextBox2")).Text)
                || !float.TryParse(((TextBox)DetailsView1.Rows[3].Cells[1].FindControl("TextBox3")).Text, out cijenaTest))
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Proizvod nije dodan! Provjerite da li ste popunili sva potrebna polja";
                lblError.Visible = true;
                e.Cancel = true;
            }
            else
            {
                if (ProcessImage(ImageBytes, finalFilename))
                {
                    lblError.ForeColor = Color.Green;
                    lblError.Text = "Proizvod je uspješno dodan";
                    lblError.Visible = true;
                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Proizvod nije dodan! Provjerite da li ste popunili sva potrebna polja";
                    lblError.Visible = true;
                    e.Cancel = true;
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);

            SqlCommand picCom = new SqlCommand("SELECT [NazFile] FROM [Proizvod] WHERE [IdProizvod] = @id", con);
            picCom.Parameters.AddWithValue("@id", GridView1.Rows[e.RowIndex].Cells[1].Text);

            con.Open();

            SqlDataReader reader = picCom.ExecuteReader();

            while (reader.Read())
            {
                var myPath = Server.MapPath("~/Images/" + (string)reader["NazFile"]);
                if (File.Exists(myPath))
                {
                    File.Delete(myPath);
                }
            }

            con.Close();

            SqlCommand deleteCmd = new SqlCommand("DELETE FROM Proizvod WHERE idProizvod = @ID", con);
            deleteCmd.Parameters.AddWithValue("@ID", e.Keys[0]);

            con.Open();
            int rowsAffected = deleteCmd.ExecuteNonQuery();
            con.Close();

            var filePath = Server.MapPath("~/Images/" + ((Label)GridView1.Rows[e.RowIndex].Cells[6].FindControl("Label3")).Text);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }

        protected void DetailsView2_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            var ImageFilename = ((FileUpload)DetailsView2.Rows[2].Cells[1].FindControl("FileUpload2")).FileName;
            var ImageBytes = ((FileUpload)DetailsView2.Rows[2].Cells[1].FindControl("FileUpload2")).FileBytes;
            
            if (ImageFilename == string.Empty)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Nije dodana slika za birani proizvod";
                lblError.Visible = true;
                e.Cancel = true;
            }
            else
            {
                if (ProcessImage(ImageBytes, finalFilename2))
                {
                    e.Values.Add("idProizvod", GridView1.SelectedValue);

                    lblError.ForeColor = Color.Green;
                    lblError.Text = "Slika je uspješno dodana";
                    lblError.Visible = true;
                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Nije dodana slika za birani proizvod";
                    lblError.Visible = true;
                    e.Cancel = true;
                }
            }
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand("SELECT IDENT_CURRENT(@table) AS Current_Identity;", con);
            cmd.Parameters.AddWithValue("@table", "Proizvodi");
            
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int myID = 0;
            if (reader.Read())
            {
                myID = int.Parse(reader["Current_Identity"].ToString());
            }
            con.Close();

            SqlCommand insertCmd = new SqlCommand("insert into Proizvod values(@idProizvod, @NazFile)", con);
            insertCmd.Parameters.AddWithValue("@idProizvod", myID);
            insertCmd.Parameters.AddWithValue("@NazFile", finalFilename);

            con.Open();
            int rowsAffected = insertCmd.ExecuteNonQuery();
            con.Close();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image1.ImageUrl = "Images/" + GridView2.SelectedRow.Cells[3].Text;
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var filePath = Server.MapPath("~/Images/" + GridView2.Rows[e.RowIndex].Cells[3].Text);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows[0].Cells[1].Text == "1")
            {
                GridView1.Rows[0].Visible = false;
            }
            else
            {
                GridView1.Rows[0].Visible = true;
            }
        }
    }
}