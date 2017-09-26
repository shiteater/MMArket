<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="MMarket.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="css/Payment.css" rel="stylesheet" />
    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
        <div class="row">
                    <div style="display: table; margin: auto auto 10px auto; font-size:17px;">
                        <span class="step step_complete check-bc" style="color: #F1C13C;">Košarica<span class="step_line step_complete"> </span></span>
                        <span class="step step_complete">Naplata<span class="step_line "> </span> <span class="step_line step_complete"> </span> </span>
                        <span class="step_thankyou check-bc step_complete">Hvala</span>
                    </div>
                </div>

    <br />
    <br />
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>

</asp:Content>
