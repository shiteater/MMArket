<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="MMarket.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/Payment.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>Plaćanje</title>
</head>
<body>
<%--    <form id="form1" runat="server">--%>
        <div class="container wrapper">
            <div class="row cart-head">
                <div class="container">
                <div class="row">
                    <p></p>
                </div>
                <div class="row">
                    <div style="display: table; margin: auto;">
                        <span class="step step_complete"> <a href="Cart.aspx" class="check-bc" style="color:black;">Košarica</a> <span class="step_line step_complete"> </span> <span class="step_line backline"> </span> </span>
                        <span class="step step_complete" style="color: #F1C13C">Naplata<span class="step_line "> </span> <span class="step_line step_complete"> </span> </span>
                        <span class="step_thankyou check-bc step_complete"  style="color:black;">Hvala</span>
                    </div>
                </div>
                <div class="row">
                    <p></p>
                </div>
                </div>
            </div>    
            <div class="row cart-body">
                <form id="form1" class="form-horizontal" method="post" runat="server">
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 col-md-push-6 col-sm-push-6">
                    <!--REVIEW ORDER-->
                    <div class="panel panel-info" style="border-color: #EDC15E;">
                        <div class="panel-heading" style="background-color: #633658; color:palegoldenrod; border-color:#EDC15E;">
                            Vaša narudžba
                        </div>
                        <div class="panel-body">
                        <asp:Panel Id="Panel1" runat="server" >
                            
                            </asp:Panel>
                            
                            </div>
                    </div>
                  
                    
                    
                    <!--REVIEW ORDER END-->
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 col-md-pull-6 col-sm-pull-6">
                    <!--SHIPPING METHOD-->
                    <div class="panel panel-info" border-color: #EDC15E;>
                        <div class="panel-heading" style="background-color: #633658; color:palegoldenrod; border-color:#EDC15E;">Podaci za plaćanje</div>
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <h4>&nbsp;</h4>
                                </div>
                            </div>
                            <%--<div class="form-group">
                                <div class="col-md-12"><strong>Country:</strong></div>
                                <div class="col-md-12">
                                    <input type="text" class="form-control" name="country" value="" />
                                </div>
                            </div>--%>
                            <div class="form-group">
                                <div class="col-md-6 col-xs-12">
                                    <strong>Ime:</strong>
                                    <input id="form_ime" runat="server" type="text" name="Ime" title="Samo slova do 30 karaktera" class="form-control" placeholder="Molimo unesite svoje ime *" pattern="[A-Za-zÀ-ž]{3,30}" required="required"/>
                                    <%--<asp:TextBox ID="form_ime" runat="server" Class="form-control" placeholder="Molimo unesite svoje ime *" ValidationGroup="2"></asp:TextBox>--%>
                                </div>
                                <div class="span1"></div>
                                <div class="col-md-6 col-xs-12">
                                    <strong>Prezime:</strong>
                                    <input id="form_prezime" runat="server" type="text" name="Prezime" title="Samo slova do 30 karaktera" class="form-control" placeholder="Molimo unesite svoje prezime *" pattern="[A-Za-zÀ-ž]{3,30}" required="required"/></div>
                                    <%--<asp:TextBox ID="form_prezime" runat="server" Class="form-control" placeholder="Molimo unesite svoje prezime *" ValidationGroup="2"></asp:TextBox>--%>
                            
                                </div>
                            <div class="form-group">
                                <div class="col-md-12"><strong>Adresa:</strong></div>
                                <div class="col-md-12"> 
                              <input id="form_adresa" runat="server" type="text" name="Adresa" title="npr. ulica 20a, ulica20/a" class="form-control" placeholder="Molimo unesite svoju adresu *" pattern="[A-z0-9À-ž\s\/\-]{5,200}" required="required"/></div>
                                    <%--<asp:TextBox ID="form_adresa" runat="server" Class="form-control" placeholder="Molimo unesite svoju adresu *" ValidationGroup="2"></asp:TextBox>--%>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12"><strong>Grad:</strong></div>
                                <div class="col-md-12">
                                    <input id="form_grad" runat="server" type="text" name="Grad" title="Samo slova do 30 karaktera" class="form-control" placeholder="Molimo unesite grad *" pattern="[A-Za-zÀ-ž]{3,30}" required="required"/></div>
                                    <%--<asp:TextBox ID="form_grad" runat="server" Class="form-control" placeholder="Molimo unesite grad *" ValidationGroup="2"></asp:TextBox>--%>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12"><strong>Poštanski broj:</strong></div>
                                <div class="col-md-12">
                                    <input id="form_postanskibroj" runat="server" type="text" name="Poštanski broj" title="Samo brojevi do 20 karaktera" class="form-control" placeholder="Molimo unesite poštanski broj *" pattern="[0-9]{3,20}" required="required"/></div>
                                    <%--<asp:TextBox ID="form_postanskibroj" runat="server" Class="form-control" placeholder="Molimo unesite poštanski broj *" TextMode="Number" ValidationGroup="2"></asp:TextBox>--%>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12"><strong>Telefon:</strong></div>
                                <div class="col-md-12">
                                    <input id="form_telefon" runat="server" type="text" name="Telefon" title="npr. +385/991111111, 0991111111" class="form-control" placeholder="Molimo unesite broj telefona *" pattern="[0-9\s\/\+]{8,20}" required="required"/></div>
                                    <%--<asp:TextBox ID="form_telefon" runat="server" Class="form-control" placeholder="Molimo unesite broj telefona *" TextMode="Phone" ValidationGroup="2"></asp:TextBox>--%>
                                </div>
                            <div class="form-group">
                                <div class="col-md-12"><strong>Email Adresa:</strong></div>
                                <div class="col-md-12">
                                    <input id="form_email" runat="server" type="text" name="Email" title="Uneseni email je u krivom formatu!" class="form-control" placeholder="Molimo unesite svoj Email *" pattern="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" required="required"/>
                                    <%--<asp:TextBox ID="form_email" runat="server" Class="form-control" placeholder="Molimo unesite svoj Email *" TextMode="Email" ValidationGroup="2"></asp:TextBox>--%>
                                </div>
                        </div>
                    </div>
                        </div>
                    
                    <!--SHIPPING METHOD END-->
                    <!--CREDIT CART PAYMENT-->
                 <div class="panel panel-info" border-color: #EDC15E;>
                        <div class="panel-heading" style="background-color: #633658; color:palegoldenrod; border-color:#EDC15E;"><span><i class="glyphicon glyphicon-lock"></i></span>Odabir plaćanja</div>
                        <div class="panel-body">
                      <div class="form-group"></div>
                                <div class="col-md-12">
                               <asp:RadioButtonList id="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                   <asp:ListItem>Plaćanje prilikom preuzimanja</asp:ListItem>
                                 <asp:ListItem Selected="True">Direktna bankovna transakcija *</asp:ListItem>
                                 
                               </asp:RadioButtonList>
                                    <asp:Label ID="lblBanka" runat="server" Text="* Molimo uplatite direktno na naš račun u banci. Koristite identifikacijski broj narudžbe kao poziv na broj. Vaša narudžba će biti isporučena kad sredstva budu vidljiva na našem računu."></asp:Label>

                                    </div>
                            <div class="commerce">
                                
                                <p class="return-to-shop"><asp:Button ID="Button1" runat="server" Text="Naručite" ValidationGroup="2" class="button glyphicon" style="color: white;background-color:#764069; border-color: #764069;font-weight:bold;" OnClick="Button1_Click" /></p>
                            </div>
                            </div>
                        <%--  
                            <div class="form-group">
                                <div class="col-md-12"><strong>Card Type:</strong></div>
                                <div class="col-md-12">
                                    <select id="CreditCardType" name="CreditCardType" class="form-control">
                                        <option value="5">Visa</option>
                                        <option value="6">MasterCard</option>
                                        <option value="7">American Express</option>
                                        <option value="8">Discover</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12"><strong>Credit Card Number:</strong></div>
                                <div class="col-md-12"><input type="text" class="form-control" name="car_number" value="" /></div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12"><strong>Card CVV:</strong></div>
                                <div class="col-md-12"><input type="text" class="form-control" name="car_code" value="" /></div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <strong>Expiration Date</strong>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                    <select class="form-control" name="">
                                        <option value="">Month</option>
                                        <option value="01">01</option>
                                        <option value="02">02</option>
                                        <option value="03">03</option>
                                        <option value="04">04</option>
                                        <option value="05">05</option>
                                        <option value="06">06</option>
                                        <option value="07">07</option>
                                        <option value="08">08</option>
                                        <option value="09">09</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                </select>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                    <select class="form-control" name="">
                                        <option value="">Year</option>
                                        <option value="2015">2015</option>
                                        <option value="2016">2016</option>
                                        <option value="2017">2017</option>
                                        <option value="2018">2018</option>
                                        <option value="2019">2019</option>
                                        <option value="2020">2020</option>
                                        <option value="2021">2021</option>
                                        <option value="2022">2022</option>
                                        <option value="2023">2023</option>
                                        <option value="2024">2024</option>
                                        <option value="2025">2025</option>
                                </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <span>Pay secure using your credit card.</span>
                                </div>
                                <div class="col-md-12">
                                    <ul class="cards">
                                        <li class="visa hand">Visa</li>
                                        <li class="mastercard hand">MasterCard</li>
                                        <li class="amex hand">Amex</li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <button type="submit" class="btn btn-primary btn-submit-fix">Place Order</button>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <!--CREDIT CART PAYMENT END-->
               <%-- </div>--%>
                
                </div>
                    </div>
            </form>
            <div class="row cart-footer">
        
            </div>
            </div>
    </div>
   <%-- </form>--%>
</body>
</html>