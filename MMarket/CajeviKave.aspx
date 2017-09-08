<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="CajeviKave.aspx.cs" Inherits="MMarket.CajeviKave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 
    <div class="row" style="width:100%">
        <div class="col-lg-12">
            <h2>Proizvodi na AKCIJI</h2>
        </div>
    <div id="superDIV" runat="server">
        <div id="ContentPlaceHolder2_newSuperDIV2" class="col-lg-3 col-md-4 col-sm-6">
            <a href="Images/1.jpg" class="thumbnail">
                <p>Chrysanthemum</p>
                <img src="Images/1.jpg" />
            </a></div>
        </div>
        </div>
  
    <%--   <<%--asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="None" ShowHeader="False" DataSourceID="SqlDataSource1" EmptyDataText="Nema niti jednog proizvoda u ovoj kategoriji" GridLines="None" HorizontalAlign="Center">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="Image1" CssClass="img-responsive" runat="server" ImageUrl='<%# Eval("Lokacija", "~/Images/{0}") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Naziv") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Opis") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Cijena") %>'></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text="kn"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MaritaMarketConnectionString %>" SelectCommand="SELECT [Naziv], [Opis], [Cijena], [Lokacija] FROM [Proizvodi] WHERE [Kategorija] LIKE 'cajevi i kave'"></asp:SqlDataSource>
</asp:Content>
