<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Pica.aspx.cs" Inherits="MMarket.Pica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="None" ShowHeader="False" DataSourceID="SqlDataSource1" EmptyDataText="Nema niti jednog proizvoda u ovoj kategoriji" GridLines="None" HorizontalAlign="Center">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="Image1" CssClass="img-responsive" runat="server" ImageUrl='<%# Eval("NazFile", "~/Images/{0}") %>' />
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
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MaritaMarketConnectionString %>" SelectCommand="SELECT [Naziv], [Opis], [Cijena], [NazFile] FROM [Proizvodi] WHERE [Kategorija] LIKE 'pica'"></asp:SqlDataSource>
</asp:Content>
