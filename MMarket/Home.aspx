<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MMarket.Home" %>

<%--Content2 je za SAMO ZA Slide Show --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div class="col-xs-12">

                <div id="imageCarousel" class="carousel slide" data-interval="3000"
                     data-ride="carousel" data-pause="hover" data-wrap="true">

                    <asp:Panel ID="Panel2" runat="server"></asp:Panel>

                    <a href="#imageCarousel" class="carousel-control left" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                    </a>
                    <a href="#imageCarousel" class="carousel-control right" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                    </a>
                </div>

            </div>
        </div>
</asp:Content>

<%--Content3 je za sve ostalo--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
</asp:Content>