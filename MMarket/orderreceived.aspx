<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderreceived.aspx.cs" Inherits="MMarket.orderreceived" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
  <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Payment.css" rel="stylesheet" />
    <title>Narudžba</title>
    <script type = "text/javascript" >
    history.pushState(null, null, document.URL);
    window.addEventListener('popstate', function () {
        history.pushState(null, null, document.URL);
    });
</script>
    <style type="text/css">
        .auto-style4 {
            width: 3%;
            font-size:17px;
        }
        .auto-style5 {
            width: 100%;
            display: inline-block;
            background-color: #764069;
            height: 76px;
            color: white;
            text-align: center;
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            font-weight: bold;
            padding-top: -1px;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <div class="row">
            <div style="display: table; margin: auto;">
                        <span class="step step_complete"> <a href="Home.aspx" runat="server" onserverclick="Home_Click" class="check-bc">Početna</a> <span class="step_line "> </span> <span class="step_line step_complete"> </span> </span>
                        <span class="step step_complete" style="color: #F1C13C">Hvala</span>
                    </div>
            <br />
            <asp:Panel ID="Panel7" runat="server" HorizontalAlign="Center">
                <a href="Home.aspx" runat="server" onserverclick="Home_Click"><img src="Images/icones/habibi_shop.png" style="width: 30%" /></a>
                <br />
                <br />
                <div class="commerce">
                    <br />
            <p class="return-to-shop"><asp:Button ID="Button1" runat="server" Text="spremi u pdf formatu" class="button glyphicon" style="color: white;background-color:#764069; border-color: #764069;font-weight:bold;" OnClick="Button1_Click"/></p>
        </div>
                <br />
                 <br />
            </asp:Panel>
                </div>
        <div class="container wrapper">
            <asp:Panel ID="Panel1" runat="server">
            <div class="col-lg-12">
                <div>
                    <asp:Panel ID="Panel5" runat="server" HorizontalAlign="Center">
                        <div class="auto-style5">
           <h1>Hvala, Vaša narudžba je zaprimljena</h1> 
        </div>
                    </asp:Panel>
                    <br />
                  
           <div id="Narudzba" runat="server" style="font-size:20px;font-weight:bold;"></div>
                    <br />
           <div id="myDatum" runat="server" style="font-size:18px;"></div>
           <div style="font-weight: bold">Način plaćanja: <asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>
<asp:Label ID="Label2" runat="server" Text="Molimo uplatite direktno na naš račun u banci. Koristite indetifikacijski broj narudžbe kao poziv na broj. Vaša narudžba će biti isporučena kad sredstva budu vidljiva na našem računu."></asp:Label>
<br />
        </div>
            </div>
                <br />               
                <br />
            <div id="div" runat="server" class="col-lg-12 col-md-6 col-sm-4 col-xs-12">
                                
                <asp:Panel ID="Panel4" runat="server" HorizontalAlign="Center">
                    <h1 style="margin-top: 1%;color:#764069;font-weight:bold;">Detalji o našoj banci</h1>
                </asp:Panel>
                
                <h2 style="font-size:23px;font-weight:bold;">Brothers HD d.o.o</h2>

               <div style="margin-bottom: 1%">
                   <h5 style="font-weight: bold">Banka</h5> Zagrebačka banka d.o.o.
                   </div>
                
                <div style="margin-bottom: 1%">
                    <h5 style="font-weight: bold">IBAN:</h5> HR8023600001102448841
                </div>
                 <div style="margin-bottom: 1%">
                     <h5 style="font-weight: bold">Adresa:</h5> Jaruščica 9a, 10020, Zagreb, Hrvatska
                 </div>
                <div style="margin-bottom: 1%">
                    <h5 style="font-weight: bold">OIB:</h5> 11070517886
                </div>
               
            </div>
      <br />
                  <br />
        <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
<br />
            <h1 id="DetaljiNarudbe" style="margin-bottom: 1%;color:#764069; font-weight:bold;">Detalji Narudžbe</h1>
            </asp:Panel>
                
        <asp:Panel ID="Panel6" runat="server" HorizontalAlign="Center">
            <table style="margin-bottom: 1%; width: 60%;">
    				<tr>
							<td style="font-weight: bold;" class="auto-style4">Naručitelj:</td>
                               <td id="naziv" runat="server" style="width:30%; float:left;font-size:17px;">&nbsp;</td>
                    </tr>
						<tr>
                        <td style="font-weight: bold;" class="auto-style4">Adresa:</td>
                        <td id="adresa" runat="server" style="width:30%;float:left;font-size:17px;">&nbsp;</td>
                        </tr>
                        <tr>
							<td style="font-weight: bold;" class="auto-style4">Telefon:</td>
                            <td id="tel" runat="server" style="width:30%;float:left;font-size:17px;"></td>
                        </tr>
				
                    </table>
        </asp:Panel>
                <br />
                <asp:Panel ID="Panel3" runat="server" HorizontalAlign="Center">
                    <div id="myTable" runat="server" style="margin-top: 1%"></div> 
                </asp:Panel>
            </asp:Panel>
        </div>
    </form>
</body>
</html>