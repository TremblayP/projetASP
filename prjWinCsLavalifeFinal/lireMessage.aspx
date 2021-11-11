<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lireMessage.aspx.cs" Inherits="prjWinCsLavalifeFinal.lireMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style2 {
            width: 592px;
        }
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body style="background-color:silver">
    <form id="form1" runat="server">
        <div class="auto-style3">
            
            <h1>Lecture du message</h1>
            <hr class="auto-style2" />
            <div class="auto-style3">
                <br />
                <asp:Label ID="lblInfos" runat="server"></asp:Label>
            </div>
            <p>
                <asp:Table ID="tabMessa" runat="server" BackColor="#FF3300" BorderColor="White" BorderStyle="Groove" ForeColor="White" Height="148px" HorizontalAlign="Center" Width="633px">
                    <asp:TableRow runat="server">
                        <asp:TableCell ID="cellTitre" runat="server" Width="10%">Title</asp:TableCell>
                        <asp:TableCell ID="cellContenuTitre" runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell ID="cellDate" runat="server">Date</asp:TableCell>
                        <asp:TableCell ID="cellContenuDate" runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell ID="cellEnvoyeur" runat="server">From</asp:TableCell>
                        <asp:TableCell ID="cellContenuEnvoyeur" runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell ID="cellMessage" runat="server">Message</asp:TableCell>
                        <asp:TableCell ID="cellContenuMessage" runat="server"></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </p>
            <p>
                <asp:HyperLink ID="HyperLink1" runat="server">Back to messages</asp:HyperLink>
            </p>
            
        </div>
    </form>
</body>
</html>
