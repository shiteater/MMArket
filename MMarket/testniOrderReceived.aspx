<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testniOrderReceived.aspx.cs" Inherits="MMarket.testniOrderReceived" %>

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
                        <span class="step step_complete"> <a href="Home.aspx" class="check-bc">Početna</a> <span class="step_line "> </span> <span class="step_line step_complete"> </span> </span>
                        <span class="step step_complete" style="color: #F1C13C">Hvala</span>
                    </div>
                </div>
    <form id="form1" runat="server" style="margin-top: 1%">
        <asp:Panel ID="Panel5" runat="server" HorizontalAlign="Center">
            <div class="commerce">
                <p class="return-to-shop"><asp:Button ID="Button1" runat="server" Text="spremi narudžbu" class="button glyphicon" style="color: #764069; border-color: #764069" OnClick="Button1_Click"/></p>
            </div>
            <iframe id="pdfViewer" runat="server" style="margin-top: 2%"></iframe>   
        </asp:Panel>
    </form>
</body>
</html>
