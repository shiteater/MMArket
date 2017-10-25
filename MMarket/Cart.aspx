<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="MMarket.TestCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="css/Cart.css" rel="stylesheet" />
    <link href="css/Payment.css" rel="stylesheet" />
    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
        <div>
                    <div style="display: table; margin: auto auto 10px auto; font-size:17px;">
                        <span class="step step_complete check-bc" style="color: #F1C13C; background-color:white;">Košarica<span class="step_line step_complete"> </span></span>
                        <span class="step step_complete">Naplata<span class="step_line "> </span> <span class="step_line step_complete"> </span> </span>
                        <span class="step_thankyou check-bc step_complete">Hvala</span>
                    </div>
                </div>
    <br />
        <div class="container">
	<table id="cart" class="table table-hover table-condensed">
    				<thead>
						<tr>
							<th style="width:50%">Proizvod</th>
							<th style="width:10%">Cijena</th>
							<th style="width:8%">Količina</th>
							<th style="width:22%" class="text-center">Subtotal</th>
							<th style="width:10%"></th>
						</tr>
					</thead>
					<tbody id="trProducts" runat="server">
					</tbody>
					<tfoot>
						<tr class="visible-xs">
							<td class="text-center" id="tdHidden" runat="server"></td>
						</tr>
						<tr id="trFooter" runat="server">
						</tr>
					</tfoot>
				</table>
</div>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
