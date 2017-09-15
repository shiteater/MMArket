using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MMarket
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DoMagicCart();
        }

        private void DoMagicCart()
        {
            if (Session["CartTable"] != null)
            {
                HtmlGenericControl DivContainer = new HtmlGenericControl();
                DivContainer.Attributes["class"] = "container";
                DivContainer.TagName = "div";

                HtmlTable table = new HtmlTable();
                table.ID = "cart";
                table.Attributes["class"] = "table table-hover table-condensed";

                HtmlTableRow trThead = new HtmlTableRow();

                HtmlTableCell th1 = new HtmlTableCell("th");
                th1.Style.Add("width", "50%");
                th1.InnerText = "Proizvod";

                HtmlTableCell th2 = new HtmlTableCell("th");
                th2.Style.Add("width", "10%");
                th2.InnerText = "Cijena";

                HtmlTableCell th3 = new HtmlTableCell("th");
                th3.Style.Add("width", "8%");
                th3.InnerText = "Količina";

                HtmlTableCell th4 = new HtmlTableCell("th");
                th4.Style.Add("width", "22%");
                th4.Attributes["class"] = "text-center";
                th4.InnerText = "Subtotal";

                HtmlTableCell th5 = new HtmlTableCell("th");
                th5.Style.Add("width", "10%");

                trThead.Cells.Add(th1);
                trThead.Cells.Add(th2);
                trThead.Cells.Add(th3);
                trThead.Cells.Add(th4);
                trThead.Cells.Add(th5);

                table.Rows.Add(trThead);
                
                foreach (DataRow item in ((DataTable)Session["CartTable"]).Rows)
                {
                    HtmlTableRow trTbody = new HtmlTableRow();

                    HtmlTableCell tdTbody1 = new HtmlTableCell("td");
                    tdTbody1.Attributes["data-th"] = "Proizvod";

                    HtmlGenericControl divTd = new HtmlGenericControl("div");
                    divTd.Attributes["class"] = "row";

                    HtmlGenericControl divTd1 = new HtmlGenericControl("div");
                    divTd1.Attributes["class"] = "col-lg-4 col-sm-2";

                    HtmlImage img = new HtmlImage();
                    img.Attributes["class"] = "img-responsive";
                    img.Src = "Images/" + item.ItemArray[4];

                    divTd1.Controls.Add(img);

                    HtmlGenericControl divTd2 = new HtmlGenericControl("div");
                    divTd2.Attributes["class"] = "col-sm-8";

                    HtmlGenericControl h4 = new HtmlGenericControl("h4");
                    h4.Attributes["class"] = "nomargin";
                    h4.InnerText = item.ItemArray[1].ToString();

                    HtmlGenericControl para = new HtmlGenericControl("p");
                    para.InnerText = item.ItemArray[2].ToString();

                    divTd2.Controls.Add(h4);
                    divTd2.Controls.Add(para);

                    divTd.Controls.Add(divTd1);
                    divTd.Controls.Add(divTd2);

                    tdTbody1.Controls.Add(divTd);
                    tdTbody1.Style.Add("vertical-align", "middle");

                    HtmlTableCell tdTbody2 = new HtmlTableCell("td");
                    tdTbody2.ID = "price_" + item.ItemArray[0];
                    tdTbody2.Attributes["data-th"] = "Cijena";
                    tdTbody2.InnerText = item.ItemArray[3].ToString();
                    tdTbody2.Style.Add("vertical-align", "middle");

                    HtmlTableCell tdTbody3 = new HtmlTableCell("td");
                    tdTbody3.Attributes["data-th"] = "Količina";

                    HtmlInputText inputNumber = new HtmlInputText("number");
                    inputNumber.ID = "myInput_" + item.ItemArray[0];
                    inputNumber.Attributes["class"] = "form-control text-center";
                    inputNumber.Value = "1";

                    tdTbody3.Controls.Add(inputNumber);
                    tdTbody3.Style.Add("vertical-align", "middle");

                    HtmlTableCell tdTbody4 = new HtmlTableCell("td");
                    tdTbody4.ID = "subTotalNum_" + item.ItemArray[0];
                    tdTbody4.Attributes["data-th"] = "Subtotal";
                    tdTbody4.Attributes["class"] = "text-center";
                    tdTbody4.InnerText = item.ItemArray[3].ToString();
                    tdTbody4.Style.Add("vertical-align", "middle");

                    HtmlTableCell tdTbody5 = new HtmlTableCell("td");
                    tdTbody5.Attributes["data-th"] = "";
                    tdTbody5.Attributes["class"] = "actions";

                    //HtmlButton btnTbody = new HtmlButton();
                    //btnTbody.ID = "btnRmv_" + ((DataTable)Session["CartTable"]).Rows.IndexOf(item);
                    //btnTbody.Attributes["class"] = "btn btn-danger btn-sm";
                    //btnTbody.Attributes.Add("runat", "server");
                    //btnTbody.Style.Add("float", "right");
                    //btnTbody.CausesValidation = false;
                    //btnTbody.ServerClick += BtnTbody_ServerClick;

                    //HtmlGenericControl htmlI = new HtmlGenericControl("i");
                    //htmlI.Attributes["class"] = "fa fa-trash-o";

                    //btnTbody.Controls.Add(htmlI);

                    HtmlGenericControl commerce11 = new HtmlGenericControl("div");
                    commerce11.Attributes["class"] = "commerce";

                    HtmlGenericControl para111 = new HtmlGenericControl("p");
                    para111.Attributes["class"] = "return-to-shop";

                    HtmlButton btnTbody = new HtmlButton();
                    btnTbody.ID = "btnRmv_" + ((DataTable)Session["CartTable"]).Rows.IndexOf(item);
                    btnTbody.Attributes["class"] = "button glyphicon glyphicon-trash";
                    btnTbody.Attributes.Add("runat", "server");
                    btnTbody.Style.Add("color", "#ea3a1a");
                    btnTbody.Style.Add("border-color", "#ea3a1a");
                    btnTbody.CausesValidation = false;
                    btnTbody.ServerClick += BtnTbody_ServerClick;

                    para111.Controls.Add(btnTbody);
                    commerce11.Controls.Add(para111);
                    commerce11.Style.Add("float", "right");

                    tdTbody5.Controls.Add(commerce11);
                    tdTbody5.Style.Add("vertical-align", "middle");

                    trTbody.Cells.Add(tdTbody1);
                    trTbody.Cells.Add(tdTbody2);
                    trTbody.Cells.Add(tdTbody3);
                    trTbody.Cells.Add(tdTbody4);
                    trTbody.Cells.Add(tdTbody5);

                    table.Rows.Add(trTbody);
                }

                HtmlTableRow rowCon = new HtmlTableRow();

                HtmlTableCell cellCon = new HtmlTableCell("td");

                HtmlTableRow trTfoot1 = new HtmlTableRow();
                trTfoot1.Attributes["class"] = "visible-xs";

                HtmlTableCell tdFoot = new HtmlTableCell("td");
                tdFoot.Attributes["class"] = "text-center";

                HtmlTable subTableFoot = new HtmlTable();

                HtmlTableRow tr1 = new HtmlTableRow();

                HtmlTableCell tdFoot1 = new HtmlTableCell("td");
                tdFoot1.InnerText = "Dostava => 50 kn";

                tr1.Cells.Add(tdFoot1);

                HtmlTableRow tr2 = new HtmlTableRow();

                HtmlTableCell tdFoot2 = new HtmlTableCell("td");

                Label total = new Label();
                total.ID = "totalPrice";
                total.Font.Bold = true;
                total.Text = "in progress";

                tdFoot2.Controls.Add(total);

                tr2.Cells.Add(tdFoot2);

                subTableFoot.Rows.Add(tr1);
                subTableFoot.Rows.Add(tr2);

                tdFoot.Controls.Add(subTableFoot);

                trTfoot1.Cells.Add(tdFoot);

                HtmlTableRow trTfoot2 = new HtmlTableRow();

                HtmlTableCell secTd1 = new HtmlTableCell("td");

                //HtmlAnchor anchor = new HtmlAnchor();
                //anchor.HRef = "Home.aspx";
                //anchor.Attributes["class"] = "btn btn-warning";
                ////anchor.InnerText = " Nastavite Shopping";

                //HtmlGenericControl htmlI1 = new HtmlGenericControl("i");
                //htmlI1.Attributes["class"] = "fa fa-angle-left";
                //htmlI1.InnerText = " Nastavite Shopping";

                //anchor.Controls.Add(htmlI1);
                HtmlGenericControl commerce = new HtmlGenericControl("div");
                commerce.Attributes["class"] = "commerce";

                HtmlGenericControl para1 = new HtmlGenericControl("p");
                para1.Attributes["class"] = "return-to-shop";

                HtmlAnchor anchor = new HtmlAnchor();
                anchor.Attributes["class"] = "button glyphicon glyphicon-arrow-left";
                anchor.HRef = "Home.aspx";
                anchor.InnerText = " Natrag u shoping";

                para1.Controls.Add(anchor);
                commerce.Controls.Add(para1);
                commerce.Style.Add("float", "left");

                secTd1.Controls.Add(commerce);

                HtmlTableCell secTd2 = new HtmlTableCell("td");
                secTd2.Attributes["colspan"] = "2";
                secTd2.Attributes["class"] = "hidden-xs";

                HtmlTableCell secTd3 = new HtmlTableCell("td");
                secTd3.Attributes["class"] = "hidden-xs text-center";

                HtmlTable subTableFoot1 = new HtmlTable();

                HtmlTableRow tr11 = new HtmlTableRow();

                HtmlTableCell tdFoot11 = new HtmlTableCell("td");
                tdFoot11.InnerText = "Dostava -> 50 kn";

                tr11.Cells.Add(tdFoot11);

                HtmlTableRow tr21 = new HtmlTableRow();

                HtmlTableCell tdFoot21 = new HtmlTableCell("td");

                Label total1 = new Label();
                total1.ID = "totalPrice1";
                total1.Font.Bold = true;
                total1.Text = "in progress";

                tdFoot21.Controls.Add(total1);

                tr21.Cells.Add(tdFoot21);

                subTableFoot1.Rows.Add(tr11);
                subTableFoot1.Rows.Add(tr21);

                secTd3.Controls.Add(subTableFoot1);

                HtmlTableCell secTd4 = new HtmlTableCell("td");

                //HtmlAnchor anchor1 = new HtmlAnchor();
                //anchor1.HRef = "#Payment";
                //anchor1.Attributes["class"] = "btn btn-success btn-block";
                //anchor1.InnerText = "Plačanje ";

                //HtmlGenericControl htmlI2 = new HtmlGenericControl("i");
                //htmlI2.Attributes["class"] = "fa fa-angle-right";

                //anchor1.Controls.Add(htmlI2);
                HtmlGenericControl commerce1 = new HtmlGenericControl("div");
                commerce1.Attributes["class"] = "commerce";

                HtmlGenericControl para11 = new HtmlGenericControl("p");
                para11.Attributes["class"] = "return-to-shop";

                HtmlAnchor anchor1 = new HtmlAnchor();
                anchor1.Attributes["class"] = "button";
                anchor1.InnerText = "Plačanje ";
                anchor1.CausesValidation = false;
                anchor1.ServerClick += Payment_ServerClick;

                HtmlGenericControl span = new HtmlGenericControl("span");
                span.Attributes["class"] = "glyphicon glyphicon-arrow-right";

                anchor1.Controls.Add(span);

                para11.Controls.Add(anchor1);
                commerce1.Controls.Add(para11);
                commerce1.Style.Add("float", "right");

                secTd4.Controls.Add(commerce1);

                trTfoot2.Cells.Add(secTd1);
                trTfoot2.Cells.Add(secTd2);
                trTfoot2.Cells.Add(secTd3);
                trTfoot2.Cells.Add(secTd4);

                cellCon.Controls.Add(trTfoot1);
                cellCon.Controls.Add(trTfoot2);

                rowCon.Cells.Add(cellCon);

                table.Rows.Add(rowCon);

                DivContainer.Controls.Add(table);

                Panel1.Controls.Add(DivContainer);

                string myScript = "\n<script type=\"text/javascript\" language=\"Javascript\" id=\"EventScriptBlock\">\n";
                myScript += "$('#ContentPlaceHolder2_myInput').on('change', function (e) {" +
                "if ($(this).data(\"lastval\") != $(this).val()) {" +
                    "if ($(this).val() < 1 || !$.isNumeric($(this).val())) {" +
                        "$(this).val(1);" +
                    "}" +
                    "$(this).data(\"lastval\", $(this).val());" +

                    "$('#ContentPlaceHolder2_subTotalNum').val($(this).val() * $('#ContentPlaceHolder2_price').text());" +
                    "$('#ContentPlaceHolder2_subTotalNum').text($('#ContentPlaceHolder2_subTotalNum').val() + ' kn');" +

                //"$('#total').text(+$('#subTotalNum').val()); "+
                //"$('#total1').text(+$('#subTotalNum').val()); "+
                //"$('#total').val(+$('#subTotalNum').val()); "+
                //"$('#total1').val(+$('#subTotalNum').val()); "+
                "};" +
            "});";
                myScript += "\n\n </script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", myScript, false);
            }
            else
            {
                HtmlGenericControl DivContainer = new HtmlGenericControl();
                DivContainer.Attributes["class"] = "container";
                DivContainer.TagName = "div";

                HtmlGenericControl row = new HtmlGenericControl("div");
                row.Attributes["class"] = "row";

                HtmlGenericControl col = new HtmlGenericControl("div");
                col.Attributes["class"] = "col-md-12 main-wrap";

                HtmlGenericControl con = new HtmlGenericControl("div");
                con.Attributes["class"] = "main-content";

                HtmlGenericControl commerce = new HtmlGenericControl("div");
                commerce.Attributes["class"] = "commerce";

                HtmlGenericControl para = new HtmlGenericControl("p");
                para.Attributes["class"] = "cart-empty";
                para.InnerText = "Nema trenutno niti jednog proizvoda u vašoj košarici.";

                HtmlGenericControl para1 = new HtmlGenericControl("p");
                para1.Attributes["class"] = "return-to-shop";

                HtmlAnchor anchor = new HtmlAnchor();
                anchor.Attributes["class"] = "button glyphicon glyphicon-arrow-left";
                anchor.HRef = "Home.aspx";
                anchor.InnerText = " Natrag u shoping";

                para1.Controls.Add(anchor);

                commerce.Controls.Add(para);
                commerce.Controls.Add(para1);

                con.Controls.Add(commerce);

                col.Controls.Add(con);

                row.Controls.Add(col);

                DivContainer.Controls.Add(row);

                Panel1.Controls.Add(DivContainer);
            }
        }

        private void Payment_ServerClick(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Opcija plačanje trenutno nije dostupna!');</script>");
        }

        private void BtnTbody_ServerClick(object sender, EventArgs e)
        {
            if (((DataTable)Session["CartTable"]).Rows.Count == 1)
            {
                Session["CartTable"] = null;
            }
            else
            {
                string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
                int row = int.Parse(resultString);
                ((DataTable)Session["CartTable"]).Rows.RemoveAt(row);
            }

            Response.Redirect("Cart.aspx");
        }
    }
}