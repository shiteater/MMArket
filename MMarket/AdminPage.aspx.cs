using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System;
using System.Collections.Generic;
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
        string finalFilename = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (Session["Admin"] == null)
            {
                Response.Redirect("Home.aspx");
            }

            if (IsPostBack && ((FileUpload)DetailsView1.Rows[5].Cells[1].FindControl("FileUpload1")) != null)
            {
                if (((FileUpload)DetailsView1.Rows[5].Cells[1].FindControl("FileUpload1")).FileName != string.Empty)
                {
                    finalFilename = String.Format("{0}.jpeg", Guid.NewGuid().ToString());
                    ((TextBox)DetailsView1.Rows[5].Cells[1].FindControl("TextBox4")).Text = finalFilename;
                }
            }
        }

        protected bool ProcessImage(byte[] imageBytes, string filename)
        {
            try
            {
                ISupportedImageFormat format = new JpegFormat() { Quality = 100 };
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

                            var savePath =
                                Path.Combine(Server.MapPath("~/Images/"), filename);

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
    }
}