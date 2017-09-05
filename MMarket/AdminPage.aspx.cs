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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string ProcessImage(byte[] avatarBytes)
        {
            ISupportedImageFormat format = new JpegFormat() { Quality = 100 };
            //Size size = new Size(150, 150);
            using (MemoryStream inStream = new MemoryStream(avatarBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory ifac = new ImageFactory(true))
                    {
                        //ifac.Load(inStream).Resize(size).Format(format).Save(outStream);
                        ifac.Load(inStream)
                            .Format(format)
                            .Save(outStream);

                        var filename = Guid.NewGuid().ToString();
                        var ext = "jpeg";

                        var fullFilename = String.Format("{0}.{1}", filename, ext);

                        var img = System.Drawing.Image.FromStream(outStream);

                        var savePath =
                            Path.Combine(Server.MapPath("~/Images/"), fullFilename);

                        img.Save(savePath);

                        return fullFilename;
                    }
                }
            }



            throw new NotImplementedException();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var ImageFilename = ImageUpload.FileName;
            var ImageBytes = ImageUpload.FileBytes;

            if (ImageFilename != string.Empty)
            {
                ImageFilename = ProcessImage(ImageBytes);
                Image1.ImageUrl = "~/Images/" + ImageFilename;
            }
        }
    }
}