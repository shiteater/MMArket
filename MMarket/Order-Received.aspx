<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order-Received.aspx.cs" Inherits="MMarket.Order_Received" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Payment.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div class="row">
                    <div style="display: table; margin: auto;">
                        <span class="step step_complete"> <a href="Home.aspx" class="check-bc">Početna</a> <span class="step_line "> </span> <span class="step_line step_complete"> </span> </span>
                        <span class="step step_complete" style="color: #F1C13C">Hvala</span>
                    </div>
                </div>
    <form id="form1" runat="server">
            <asp:Panel ID="Panel1" runat="server">
            <div class="col-lg-12">
                <div><br />
           <div>Hvala. Vaša narudžba je zaprimljena.</div> 
           <div>Broj narudžbe: 1</div>
           <div>Datum: 1</div>
           <div>Ukupno: 65 kn</div>
           <div>Način plaćanja: <asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>


        </div>
                <asp:Label ID="Label2" runat="server" Text="Molimo uplatite direktno na naš račun u banci. Koristite indetifikacijski broj narudžbe kao poziv na broj. Vaša narudžba će biti isporučena kad sredstva budu vidljiva na našem računu."></asp:Label>
            </div>
            <div id="div" runat="server" class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <h2>Detalji o našoj banci</h2>
                <h2>HABIBI-ORIENT d.o.o.:</h2>

               <div> Banka: <br/>
               Zagrebačka banka d.o.o.
                   </div>
                
                <div>
                    IBAN:<br/>
                    <span id="cch_f2390152e058f4" class="_mh6 _wsc"><span class="_3oh- _58nk">HR8023600001102448841</span></span>
                </div>
                 <div>
                     Brothers HD D.O.O 
10020 Jaruščica 9a 
croatia zagreb 
Oib 11070517886
                 </div>
               
            </div>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    </div>

        </asp:Panel>

    </form>
    <div class="col-xs-12">
       <h1 id="DetaljiNarudbe">Detalji Narudžbe</h1>
        </div>
    <table class="table Narudba" style="width:100%;">
        <th>Proizvod</th>
    <th>Ukupno</th>
        
        <tr>
           
            <td>Brašno</td>
            <td>36,80</td>
        </tr>
        <tr>
           
            <td>Ukupno</td>
            <td>36,80</td>
        </tr>
        <tr>
           
            <td>dostava</td>
            <td><span class="woocommerce-Price-amount amount">29.00<span class="woocommerce-Price-currencySymbol">Kn</span></span></td>
        </tr>
        <tr>
           
            <td>Način plaćanja</td>
            <td>Pouzećem</td>
        </tr>
        <tr>
           
            <td>Ukupno</td>
            <td><span class="woocommerce-Price-amount amount">66kn</span></td>
        </tr>
    </table>
</body>
</html>
