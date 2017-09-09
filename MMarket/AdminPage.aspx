<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="MMarket.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Home.aspx">Home</a>
            <asp:Button ID="Button1" runat="server" Text="Logout" OnClick="Button1_Click" />
            <hr />
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="idProizvod" DataSourceID="SqlDataSource1" Height="50px" Width="125px" OnItemInserting="DetailsView1_ItemInserting">
                <Fields>
                    <asp:BoundField DataField="idProizvod" HeaderText="idProizvod" InsertVisible="False" ReadOnly="True" SortExpression="idProizvod" />
                    <asp:TemplateField HeaderText="Naziv" SortExpression="Naziv">
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Naziv") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Naziv") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Opis" SortExpression="Opis">
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Opis") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Opis") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cijena" SortExpression="Cijena">
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Cijena") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Cijena") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Kategorija" SortExpression="Kategorija">
                        <InsertItemTemplate>
                            <asp:DropDownList ID="DropDownList4" runat="server" Text='<%# Bind("Kategorija") %>'>
                                <asp:ListItem>smrznuto</asp:ListItem>
                                <asp:ListItem>sirevi</asp:ListItem>
                                <asp:ListItem>konzerve</asp:ListItem>
                                <asp:ListItem>zitarice</asp:ListItem>
                                <asp:ListItem>zacini</asp:ListItem>
                                <asp:ListItem>slatkisi i grickalice</asp:ListItem>
                                <asp:ListItem>datulje</asp:ListItem>
                                <asp:ListItem>cajevi i kave</asp:ListItem>
                                <asp:ListItem>pica</asp:ListItem>
                                <asp:ListItem>kozmetika</asp:ListItem>
                            </asp:DropDownList>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Kategorija") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NazFile" SortExpression="NazFile">
                        <InsertItemTemplate>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True" Text='<%# Bind("NazFile") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("NazFile") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Akcija" SortExpression="Akcija">
                        <InsertItemTemplate>
                            <asp:DropDownList ID="DropDownList5" runat="server" Text='<%# Bind("Akcija") %>'>
                                <asp:ListItem>nije</asp:ListItem>
                                <asp:ListItem>je</asp:ListItem>
                            </asp:DropDownList>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Akcija") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Najprodavaniji" SortExpression="Najprodavaniji">
                        <InsertItemTemplate>
                            <asp:DropDownList ID="DropDownList6" runat="server" Text='<%# Bind("Najprodavaniji") %>'>
                                <asp:ListItem>nije</asp:ListItem>
                                <asp:ListItem>je</asp:ListItem>
                            </asp:DropDownList>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("Najprodavaniji") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowInsertButton="True" />
                </Fields>
            </asp:DetailsView>
            <hr />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idProizvod" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="idProizvod" HeaderText="idProizvod" InsertVisible="False" ReadOnly="True" SortExpression="idProizvod" />
                    <asp:BoundField DataField="Naziv" HeaderText="Naziv" SortExpression="Naziv" />
                    <asp:BoundField DataField="Opis" HeaderText="Opis" SortExpression="Opis" />
                    <asp:BoundField DataField="Cijena" HeaderText="Cijena" SortExpression="Cijena" />
                    <asp:TemplateField HeaderText="Kategorija" SortExpression="Kategorija">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" Text='<%# Bind("Kategorija") %>'>
                                <asp:ListItem>smrznuto</asp:ListItem>
                                <asp:ListItem>sirevi</asp:ListItem>
                                <asp:ListItem>konzerve</asp:ListItem>
                                <asp:ListItem>zitarice</asp:ListItem>
                                <asp:ListItem>zacini</asp:ListItem>
                                <asp:ListItem>slatkisi i grickalice</asp:ListItem>
                                <asp:ListItem>datulje</asp:ListItem>
                                <asp:ListItem>cajevi i kave</asp:ListItem>
                                <asp:ListItem>pica</asp:ListItem>
                                <asp:ListItem>kozmetika</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Kategorija") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NazFile" SortExpression="NazFile">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NazFile") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("NazFile") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Akcija" SortExpression="Akcija">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" Text='<%# Bind("Akcija") %>'>
                                <asp:ListItem>nije</asp:ListItem>
                                <asp:ListItem>je</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Akcija") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Najprodavaniji" SortExpression="Najprodavaniji">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList3" runat="server" Text='<%# Bind("Najprodavaniji") %>'>
                                <asp:ListItem>nije</asp:ListItem>
                                <asp:ListItem>je</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Najprodavaniji") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MaritaMarketConnectionString %>" DeleteCommand="DELETE FROM [Proizvodi] WHERE [idProizvod] = @idProizvod" InsertCommand="INSERT INTO [Proizvodi] ([Naziv], [Opis], [Cijena], [Kategorija], [NazFile], [Akcija], [Najprodavaniji]) VALUES (@Naziv, @Opis, @Cijena, @Kategorija, @NazFile, @Akcija, @Najprodavaniji)" SelectCommand="SELECT * FROM [Proizvodi]" UpdateCommand="UPDATE [Proizvodi] SET [Naziv] = @Naziv, [Opis] = @Opis, [Cijena] = @Cijena, [Kategorija] = @Kategorija, [NazFile] = @NazFile, [Akcija] = @Akcija, [Najprodavaniji] = @Najprodavaniji WHERE [idProizvod] = @idProizvod">
                <DeleteParameters>
                    <asp:Parameter Name="idProizvod" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Naziv" Type="String" />
                    <asp:Parameter Name="Opis" Type="String" />
                    <asp:Parameter Name="Cijena" Type="Double" />
                    <asp:Parameter Name="Kategorija" Type="String" />
                    <asp:Parameter Name="NazFile" Type="String" />
                    <asp:Parameter Name="Akcija" Type="String" />
                    <asp:Parameter Name="Najprodavaniji" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Naziv" Type="String" />
                    <asp:Parameter Name="Opis" Type="String" />
                    <asp:Parameter Name="Cijena" Type="Double" />
                    <asp:Parameter Name="Kategorija" Type="String" />
                    <asp:Parameter Name="NazFile" Type="String" />
                    <asp:Parameter Name="Akcija" Type="String" />
                    <asp:Parameter Name="Najprodavaniji" Type="String" />
                    <asp:Parameter Name="idProizvod" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
        </div>
    </form>
</body>
</html>
