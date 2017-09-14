<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="MMarket.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/AdminStyle.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Home.aspx" class="home" >Home</a>
            <asp:Button ID="Button1" class="logout" runat="server" Text="Logout" OnClick="Button1_Click" />
            <br />
             <br />
            <hr />

            <asp:DetailsView ID="DetailsView1" class="dodajNovi" runat="server" AutoGenerateRows="False" DataKeyNames="idProizvod" DataSourceID="SqlDataSource1" Height="50px" Width="398px" OnItemInserting="DetailsView1_ItemInserting" CellPadding="4" Font-Names="Times New Roman" ForeColor="Black" GridLines="None" OnPageIndexChanging="DetailsView1_PageIndexChanging">
                <AlternatingRowStyle BackColor="#EAEAFF" Font-Size="Medium" Width="300px" />
                <CommandRowStyle BackColor="#001A33" Font-Bold="True" ForeColor="#99CCFF" />
                <EditRowStyle BackColor="#F7F6F3" Width="400px" />
                <FieldHeaderStyle BackColor="#003366" Font-Bold="True" ForeColor="White" Width="100px" />
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
                                <asp:ListItem>ostalo</asp:ListItem>
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

                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#404040" BorderColor="#00EFFF" BorderStyle="Outset" Font-Names="Franklin Gothic Book" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Width="300px" />

            </asp:DetailsView>
            <hr />
            <asp:GridView ID="GridView1" runat="server" class="grid" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idProizvod" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting" CellPadding="4" CellSpacing="3" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="#ECECFF" ForeColor="#000048" />
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
                                <asp:ListItem>ostalo</asp:ListItem>
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

                <EditRowStyle BackColor="#999999" />

                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#002346" BorderStyle="Outset" Font-Bold="True" Font-Names="Franklin Gothic Demi Cond" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F4F4F4" ForeColor="Black" Font-Bold="False" />
                <SelectedRowStyle BackColor="#E2DED6" BorderColor="#00EFFF" BorderStyle="Solid" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

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
