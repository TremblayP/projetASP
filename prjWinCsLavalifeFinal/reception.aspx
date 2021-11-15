<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reception.aspx.cs" Inherits="prjWinCsLavalifeFinal.reception" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 592px;
        }
        </style>
</head>
<body style="background-color:silver">
    <form id="form1" runat="server">
        <div class="auto-style1">

            <h1>Lavalife - My messages</h1>
            <hr class="auto-style2" />
            <br />
            <asp:Table ID="tabMessages" runat="server" Height="16px" HorizontalAlign="Center" Width="710px"></asp:Table>

        </div>
        <asp:Label ID="lbltest" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
