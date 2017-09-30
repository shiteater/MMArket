<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order-Received.aspx.cs" Inherits="MMarket.Order_Received" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Payment.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 37px;
        }
    </style>
    </head>
<body>
    <div class="row">
                    <div style="display: table; margin: auto;">
                        <span class="step step_complete"> <a href="Home.aspx" class="check-bc">Početna</a> <span class="step_line "> </span> <span class="step_line step_complete"> </span> </span>
                        <span class="step step_complete" style="color: #F1C13C">Hvala</span>
                    </div>
                </div>
    <form id="form1" runat="server">
            <asp:Panel ID="Panel1" runat="server">
                <img runat="server" id="logo" width="120" />
                <br />
                <br />
            <div class="col-lg-12">
                <div>
                    <asp:Panel ID="Panel5" runat="server" HorizontalAlign="Center">
                        <div class="zaprimljeno">
           <h1>Hvala, Vaša narudžba je zaprimljena</h1> 
        </div>
                    </asp:Panel>
           
           <div id="Narudzba" runat="server"></div>
           <div id="myDatum" runat="server"></div>
           <div style="font-weight: bold">Način plaćanja: <asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>
<asp:Label ID="Label2" runat="server" Text="Molimo uplatite direktno na naš račun u banci. Koristite indetifikacijski broj narudžbe kao poziv na broj. Vaša narudžba će biti isporučena kad sredstva budu vidljiva na našem računu."></asp:Label>

        </div>
            </div>
                <br />
            <div id="div" runat="server" class="col-lg-12 col-md-6 col-sm-4 col-xs-12">
                                
                <asp:Panel ID="Panel4" runat="server" HorizontalAlign="Center">
                    <h1 style="margin-top: 1%">Detalji o našoj banci</h1>
                </asp:Panel>
                
                <h2>Brothers HD d.o.o</h2>

               <div style="margin-bottom: 1%">
                   <h5 style="font-weight: bold">Banka:</h5> Zagrebačka banka d.o.o.
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
        <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
            <h1 id="DetaljiNarudbe" style="margin-bottom: 1%">Detalji Narudžbe</h1>
            </asp:Panel>
        <asp:Panel ID="Panel6" runat="server" HorizontalAlign="Center">
            <table style="margin-bottom: 1%; width: 100%;">
    				<tr>
							<td style="width:30%; font-weight: bold;">Naručitelj</td>
							<td style="width:40%; font-weight: bold;">Adresa</td>
							<td style="width:30%; font-weight: bold;">Telefon</td>
						</tr>
					<tr>
							<td id="naziv" runat="server" style="width:20%"></td>
							<td id="adresa" runat="server" style="width:30%"></td>
							<td id="tel" runat="server" style="width:20%"></td>
						</tr>
                    </table>
        </asp:Panel>

                <asp:Panel ID="Panel3" runat="server" HorizontalAlign="Center">
                    <div id="myTable" runat="server" style="margin-top: 1%"></div> 
                </asp:Panel>
            </asp:Panel>
    </form>
</body>
</html>