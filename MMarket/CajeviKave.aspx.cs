using System;
using System.Collections.Generic;
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
            newDiv.Attributes.Add("class", "col-lg-3");//<---Add some style as example
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

            HtmlGenericControl newDiv2 = new HtmlGenericControl("DIV");
            newDiv2.ID = "newSuperDIV"; //<---Give and ID to the div, very important!
            newDiv2.Attributes.Add("class", "col-lg-7");//<---Add some style as example
            HtmlGenericControl anchor2 = new HtmlGenericControl("a");
            anchor2.Attributes.Add("href", "Images/1.jpg");
            anchor2.Attributes.Add("class", "thumbnail");
            HtmlGenericControl p2 = new HtmlGenericControl("p");
            p2.InnerHtml = "ovo je slika majke ti";
            Image img2 = new Image();
            img2.ImageUrl = "~/Images/1.jpg";
            anchor2.Controls.Add(p2);
            anchor2.Controls.Add(img2);
            newDiv2.Controls.Add(anchor2);
            superDIV.Controls.Add(newDiv2);

        }
    }
}