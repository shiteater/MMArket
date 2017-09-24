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
        HtmlTable table = new HtmlTable();
        Label total1 = new Label();
        Label lblDelivery1 = new Label();
        Label total = new Label();
        Label lblDelivery = new Label();

        protected void Page_Load(object sender, EventArgs e)
        {
            DoMagicCart();
        }

        private void DoMagicCart()
        {
            if (Session["CartTable"] != null)
            {
                Panel2.Visible = true;

                HtmlGenericControl DivContainer = new HtmlGenericControl();
                DivContainer.Attributes["class"] = "container";
                DivContainer.TagName = "div";
                
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
                    h4.Style.Add("color", "#764069");

                    HtmlGenericControl para = new HtmlGenericControl("p");
                    para.InnerText = item.ItemArray[2].ToString();
                    para.Style.Add("color", "#764069");

                    divTd2.Controls.Add(h4);
                    divTd2.Controls.Add(para);

                    divTd.Controls.Add(divTd1);
                    divTd.Controls.Add(divTd2);

                    tdTbody1.Controls.Add(divTd);
                    tdTbody1.Style.Add("vertical-align", "middle");

                    HtmlTableCell tdTbody2 = new HtmlTableCell("td");
                    //tdTbody2.ID = "price_" + item.ItemArray[0];
                    tdTbody2.Attributes["data-th"] = "Cijena";
                    //tdTbody2.InnerText = item.ItemArray[3].ToString();
                    tdTbody2.Style.Add("vertical-align", "middle");
                    Label lblPrice = new Label();
                    lblPrice.ID = "price_" + ((DataTable)Session["CartTable"]).Rows.IndexOf(item);
                    lblPrice.Text = item.ItemArray[3].ToString();
                    lblPrice.ForeColor = System.Drawing.ColorTranslator.FromHtml("#764069");
                    tdTbody2.Controls.Add(lblPrice);

                    HtmlTableCell tdTbody3 = new HtmlTableCell("td");
                    tdTbody3.Attributes["data-th"] = "Količina";

                    //HtmlInputText inputNumber = new HtmlInputText("number");
                    //inputNumber.ID = "myInput_" + item.ItemArray[0];
                    //inputNumber.Attributes["class"] = "form-control text-center";
                    //inputNumber.Value = "1";

                    HtmlTable myTable1 = new HtmlTable();
                    HtmlTableRow myRow1 = new HtmlTableRow();
                    HtmlTableCell myCell1 = new HtmlTableCell();
                    HtmlTableCell myCell2 = new HtmlTableCell();
                    HtmlTable myTable2 = new HtmlTable();
                    HtmlTableRow myRow2 = new HtmlTableRow();
                    HtmlTableRow myRow3 = new HtmlTableRow();
                    HtmlTableCell myCell3 = new HtmlTableCell();
                    HtmlTableCell myCell4 = new HtmlTableCell();
                    myTable1.Rows.Add(myRow1);
                    myRow1.Cells.Add(myCell1);
                    myRow1.Cells.Add(myCell2);
                    myTable2.Rows.Add(myRow2);
                    myTable2.Rows.Add(myRow3);
                    myRow2.Cells.Add(myCell3);
                    myRow3.Cells.Add(myCell4);
                    myCell2.Controls.Add(myTable2);

                    TextBox tbxCountity = new TextBox();
                    tbxCountity.ID = "countity_" + ((DataTable)Session["CartTable"]).Rows.IndexOf(item);
                    tbxCountity.Text = item.ItemArray[6].ToString();
                    tbxCountity.BorderStyle = BorderStyle.Groove;
                    tbxCountity.BorderColor = System.Drawing.ColorTranslator.FromHtml("#F1C13C");
                    tbxCountity.Width = 50;
                    tbxCountity.Style.Add("text-align", "center");
                    tbxCountity.Style.Add("margin-right", "5px");
                    tbxCountity.AutoPostBack = true;
                    tbxCountity.TextChanged += TbxCountity_TextChanged;

                    myCell1.Controls.Add(tbxCountity);

                    HtmlGenericControl myCom1 = new HtmlGenericControl("div");
                    myCom1.Attributes["class"] = "commerce";

                    HtmlGenericControl myPara1 = new HtmlGenericControl("p");
                    myPara1.Attributes["class"] = "return-to-shop";

                    HtmlButton btnInc = new HtmlButton();
                    btnInc.ID = "btnInc_" + ((DataTable)Session["CartTable"]).Rows.IndexOf(item);
                    btnInc.Attributes["class"] = "button glyphicon glyphicon-arrow-up";
                    btnInc.Attributes.Add("runat", "server");
                    btnInc.Style.Add("color", "#F1C13C");
                    btnInc.Style.Add("border-color", "#F1C13C");
                    btnInc.CausesValidation = false;
                    btnInc.ServerClick += CountityInc_Click;

                    myPara1.Controls.Add(btnInc);
                    myCom1.Controls.Add(myPara1);

                    myCell3.Controls.Add(myCom1);

                    HtmlGenericControl myCom2 = new HtmlGenericControl("div");
                    myCom2.Attributes["class"] = "commerce";

                    HtmlGenericControl myPara2 = new HtmlGenericControl("p");
                    myPara2.Attributes["class"] = "return-to-shop";

                    HtmlButton btnDec = new HtmlButton();
                    btnDec.ID = "btnDec_" + ((DataTable)Session["CartTable"]).Rows.IndexOf(item);
                    btnDec.Attributes["class"] = "button glyphicon glyphicon-arrow-down";
                    btnDec.Attributes.Add("runat", "server");
                    btnDec.Style.Add("color", "#F1C13C");
                    btnDec.Style.Add("border-color", "#F1C13C");
                    btnDec.CausesValidation = false;
                    btnDec.ServerClick += CountityDec_Click;

                    myPara2.Controls.Add(btnDec);
                    myCom2.Controls.Add(myPara2);

                    myCell4.Controls.Add(myCom2);

                    tdTbody3.Controls.Add(myTable1);
                    tdTbody3.Style.Add("vertical-align", "middle");

                    HtmlTableCell tdTbody4 = new HtmlTableCell("td");
                    //tdTbody4.ID = "subTotalNum_" + item.ItemArray[0];
                    tdTbody4.Attributes["data-th"] = "Subtotal";
                    tdTbody4.Attributes["class"] = "text-center";

                    Label lblPriceSub = new Label();
                    lblPriceSub.ID = "subTotalNum_" + ((DataTable)Session["CartTable"]).Rows.IndexOf(item);
                    lblPriceSub.Text = (float.Parse(item.ItemArray[3].ToString()) * float.Parse(item.ItemArray[6].ToString())).ToString();
                    lblPriceSub.ForeColor = System.Drawing.ColorTranslator.FromHtml("#764069");
                    tdTbody4.Controls.Add(lblPriceSub);

                    //tdTbody4.InnerText = item.ItemArray[3].ToString();
                    tdTbody4.Style.Add("vertical-align", "middle");

                    HtmlTableCell tdTbody5 = new HtmlTableCell("td");
                    tdTbody5.Attributes["data-th"] = "";
                    tdTbody5.Attributes["class"] = "actions";

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
                lblDelivery.ID = "delivery";
                lblDelivery.Font.Bold = true;
                lblDelivery.ForeColor = System.Drawing.ColorTranslator.FromHtml("#764069");
                tdFoot1.Controls.Add(lblDelivery);
                tr1.Cells.Add(tdFoot1);

                HtmlTableRow tr2 = new HtmlTableRow();

                HtmlTableCell tdFoot2 = new HtmlTableCell("td");
                
                total.ID = "totalPrice";
                total.Font.Bold = true;
                total.ForeColor = System.Drawing.ColorTranslator.FromHtml("#764069");

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
                anchor.Style.Add("color", "#F1C13C");
                anchor.Style.Add("border-color", "#F1C13C");
                anchor.InnerText = " Povratak na proizvode";
                anchor.Style.Add("color", "#F1C13C");
                anchor.Style.Add("border-color", "#F1C13C");


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
                lblDelivery1.ID = "delivery1";
                lblDelivery1.Font.Bold = true;
                lblDelivery1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#764069");
                tdFoot11.Controls.Add(lblDelivery1);
                tr11.Cells.Add(tdFoot11);

                HtmlTableRow tr21 = new HtmlTableRow();

                HtmlTableCell tdFoot21 = new HtmlTableCell("td");
                
                total1.ID = "totalPrice1";
                total1.Font.Bold = true;
                total1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#764069");

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
                anchor1.InnerText = "Plaćanje ";
                anchor1.Style.Add("color", "#F1C13C");
                anchor1.Style.Add("border-color", "#F1C13C");
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

                Panel2.Controls.Add(DivContainer);

                if (!IsPostBack)
                {
                    TotalCalculator();
                    DeliveryCalculator();
                }

            //    string myScript = "\n<script type=\"text/javascript\" language=\"Javascript\" id=\"EventScriptBlock\">\n";
            //    myScript += "$('#ContentPlaceHolder2_myInput').on('change', function (e) {" +
            //    "if ($(this).data(\"lastval\") != $(this).val()) {" +
            //        "if ($(this).val() < 1 || !$.isNumeric($(this).val())) {" +
            //            "$(this).val(1);" +
            //        "}" +
            //        "$(this).data(\"lastval\", $(this).val());" +

            //        "$('#ContentPlaceHolder2_subTotalNum').val($(this).val() * $('#ContentPlaceHolder2_price').text());" +
            //        "$('#ContentPlaceHolder2_subTotalNum').text($('#ContentPlaceHolder2_subTotalNum').val() + ' kn');" +

            //    //"$('#total').text(+$('#subTotalNum').val()); "+
            //    //"$('#total1').text(+$('#subTotalNum').val()); "+
            //    //"$('#total').val(+$('#subTotalNum').val()); "+
            //    //"$('#total1').val(+$('#subTotalNum').val()); "+
            //    "};" +
            //"});";
            //    myScript += "\n\n </script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", myScript, false);
            }
            else
            {
                Panel2.Visible = false;

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
                para.InnerText = "Vaša košarica je prazna.";
                para.Style.Add("color", "#764069");

                HtmlGenericControl para1 = new HtmlGenericControl("p");
                para1.Attributes["class"] = "return-to-shop";

                HtmlAnchor anchor = new HtmlAnchor();
                anchor.Attributes["class"] = "button glyphicon glyphicon-arrow-left";
                anchor.HRef = "Home.aspx";
                anchor.InnerText = " Povratak na proizvode";
                anchor.Style.Add("color", "#F1C13C");
                anchor.Style.Add("border-color", "#F1C13C");

                para1.Controls.Add(anchor);

                commerce.Controls.Add(para);
                commerce.Controls.Add(para1);

                con.Controls.Add(commerce);

                col.Controls.Add(con);

                row.Controls.Add(col);

                DivContainer.Controls.Add(row);

                Panel1.Controls.Add(DivContainer);

                Session["total"] = null;
            }
        }

        private void TbxCountity_TextChanged(object sender, EventArgs e)
        {
            string resultString = Regex.Match(((TextBox)sender).ID, @"\d+").Value;
            int row = int.Parse(resultString);

            int testBroj;
            if (!int.TryParse(((TextBox)((HtmlTable)table.Rows[row + 1].Cells[2].Controls[0]).Rows[0].Cells[0].Controls[0]).Text, out testBroj)
                || string.IsNullOrWhiteSpace(((TextBox)((HtmlTable)table.Rows[row + 1].Cells[2].Controls[0]).Rows[0].Cells[0].Controls[0]).Text)
                || testBroj < 1)
            {
                ((TextBox)((HtmlTable)table.Rows[row + 1].Cells[2].Controls[0]).Rows[0].Cells[0].Controls[0]).Text = ((DataTable)Session["CartTable"]).Rows[row].ItemArray[6].ToString();
                ((Label)table.Rows[row + 1].Cells[3].Controls[0]).Text = (float.Parse(((DataTable)Session["CartTable"]).Rows[row].ItemArray[6].ToString()) * float.Parse(((DataTable)Session["CartTable"]).Rows[row].ItemArray[3].ToString())).ToString();
            }
            else
            {
                ((Label)table.Rows[row + 1].Cells[3].Controls[0]).Text = (testBroj * float.Parse(((DataTable)Session["CartTable"]).Rows[row].ItemArray[3].ToString())).ToString();
                ((DataTable)Session["CartTable"]).Rows[row].SetField(6, ((TextBox)sender).Text);
            }

            TotalCalculator();
            DeliveryCalculator();
        }

        private void CountityInc_Click(object sender, EventArgs e)
        {
            string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
            int row = int.Parse(resultString);
            int broj = int.Parse(((TextBox)((HtmlTable)table.Rows[row + 1].Cells[2].Controls[0]).Rows[0].Cells[0].Controls[0]).Text);
            ++broj;
            ((TextBox)((HtmlTable)table.Rows[row + 1].Cells[2].Controls[0]).Rows[0].Cells[0].Controls[0]).Text = broj.ToString();
            ((DataTable)Session["CartTable"]).Rows[row].SetField(6, broj.ToString());
            ((Label)table.Rows[row + 1].Cells[3].Controls[0]).Text = (broj * float.Parse(((DataTable)Session["CartTable"]).Rows[row].ItemArray[3].ToString())).ToString();

            TotalCalculator();
            DeliveryCalculator();
        }

        private void CountityDec_Click(object sender, EventArgs e)
        {
            string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
            int row = int.Parse(resultString);
            int broj = int.Parse(((TextBox)((HtmlTable)table.Rows[row + 1].Cells[2].Controls[0]).Rows[0].Cells[0].Controls[0]).Text);
            --broj;
            if (broj < 1)
            {
                broj = 1;
            }
            ((TextBox)((HtmlTable)table.Rows[row + 1].Cells[2].Controls[0]).Rows[0].Cells[0].Controls[0]).Text = broj.ToString();
            ((DataTable)Session["CartTable"]).Rows[row].SetField(6, broj.ToString());
            ((Label)table.Rows[row + 1].Cells[3].Controls[0]).Text = (broj * float.Parse(((DataTable)Session["CartTable"]).Rows[row].ItemArray[3].ToString())).ToString();

            TotalCalculator();
            DeliveryCalculator();
        }

        private void Payment_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx");
        }

        private void BtnTbody_ServerClick(object sender, EventArgs e)
        {
            if (((DataTable)Session["CartTable"]).Rows.Count == 1)
            {
                Session["CartTable"] = null;
                Session["total"] = null;
                Session["shipping"] = null;
                Panel2.Visible = false;
            }
            else
            {
                string resultString = Regex.Match(((HtmlButton)sender).ID, @"\d+").Value;
                int row = int.Parse(resultString);
                ((DataTable)Session["CartTable"]).Rows.RemoveAt(row);

                TotalCalculator();
                DeliveryCalculator();

                Panel2.Visible = true;
            }

            Response.Redirect("Cart.aspx");
        }

        private void TotalCalculator()
        {
            if (Session["CartTable"] != null)
            {
                float totalNum = 0;
                //for (int i = 1; i < table.Rows.Count - 1; i++)
                //{
                //    totalNum += float.Parse(((Label)table.Rows[i].Cells[3].Controls[0]).Text);
                //}
                //Session["total"] = totalNum;

                //total.Text = "Ukupno: " + String.Format("{0:0.00}", totalNum) + " kn";
                //total1.Text = "Ukupno: " + String.Format("{0:0.00}", totalNum) + " kn";
                foreach (DataRow item in ((DataTable)Session["CartTable"]).Rows)
                {
                    totalNum += (float.Parse(item.ItemArray[3].ToString()) * float.Parse(item.ItemArray[6].ToString()));
                }
                Session["total"] = totalNum;

                total.Text = "Ukupno: " + String.Format("{0:0.00}", totalNum) + " kn";
                total1.Text = "Ukupno: " + String.Format("{0:0.00}", totalNum) + " kn";
            }
            else
            {
                Session["total"] = null;
            }
        }

        private void DeliveryCalculator()
        {
            if (Session["CartTable"] != null)
            {
                if (Session["total"] != null)
                {
                    float tezina = 0;
                    foreach (DataRow item in ((DataTable)Session["CartTable"]).Rows)
                    {
                        tezina += float.Parse(item.ItemArray[5].ToString()) * float.Parse(item.ItemArray[6].ToString());
                    }

                    float delivery = 0;
                    if (tezina <= 2000)
                    {
                        delivery = 20;
                    }
                    else if (tezina > 2000 && tezina <= 5000)
                    {
                        delivery = 25;
                    }
                    else if (tezina > 5000 && tezina <= 10000)
                    {
                        delivery = 28;
                    }
                    else if (tezina > 10000 && tezina <= 15000)
                    {
                        delivery = 35;
                    }
                    else if (tezina > 15000 && tezina <= 20000)
                    {
                        delivery = 38;
                    }

                    if ((float)Session["total"] <= 100)
                    {
                        Session["shipping"] = delivery;
                    }
                    else
                    {
                        string osnovno = "";
                        string ostatak = "";
                        for (int i = 0; i < ((float)Session["total"]).ToString().Count(); i++)
                        {
                            if ((float)Session["total"] >= 1000)
                            {
                                if (i < 2)
                                {
                                    osnovno += ((float)Session["total"]).ToString().ElementAt(i).ToString();
                                }
                                else
                                {
                                    ostatak += ((float)Session["total"]).ToString().ElementAt(i).ToString();
                                }
                            }
                            else
                            {
                                if (i == 0)
                                {
                                    osnovno += ((float)Session["total"]).ToString().ElementAt(i).ToString();
                                }
                                else
                                {
                                    ostatak += ((float)Session["total"]).ToString().ElementAt(i).ToString();
                                }
                            }
                        }

                        delivery += int.Parse(osnovno) * 3;
                        delivery += float.Parse(ostatak) * (float)0.03;

                        Session["shipping"] = delivery;
                    }

                    lblDelivery.Text = "Dostava: " + String.Format("{0:0.00}", (float)Session["shipping"]) + " kn";
                    lblDelivery1.Text = "Dostava: " + String.Format("{0:0.00}", (float)Session["shipping"]) + " kn";
                }
                else
                {
                    Session["shipping"] = null;
                }
            }
        }
    }
}