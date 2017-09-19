<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="MMarket.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:Panel ID="Panel3" runat="server" HorizontalAlign="Center"></asp:Panel>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="css/DetailsStyle.css" rel="stylesheet" />
    <script src="js/mod.3.2.0.bootstrap.min.js"></script>
    <script src="js/DetailsScript.js"></script>
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Panel ID="Panel2" runat="server"></asp:Panel>
</asp:Content>
