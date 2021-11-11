<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="envoyerMessage.aspx.cs" Inherits="prjWinCsLavalifeFinal.envoyerMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <table align="center" style="background-color:#FF3300; color: #FFFFFF;">
        <tr>
            <td class="auto-style4"><strong>Destinataire :</strong></td>
            <td class="auto-style4">
                <asp:Label ID="lblClient" runat="server" ></asp:Label>
                <asp:DropDownList ID="cboClients" runat="server" Height="32px" Visible="False" Width="266px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><strong>Titre Message :</strong></td>
            <td>
                <asp:TextBox ID="txtTitre" runat="server" Width="340px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top"><strong>Contenu Message :</strong></td>
            <td>
                <asp:TextBox ID="txtMessage" runat="server" Height="189px" TextMode="MultiLine" Width="342px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnEnvoyer" runat="server" Text="Envoyer" BackColor="White" ForeColor="#33CC33" OnClick="btnEnvoyer_Click" />
            </td>
            <td>
                <asp:Button ID="btnEffacer" runat="server" OnClick="btnEffacer_Click" Text="Effacer" BackColor="White" ForeColor="#FF3300" />
            </td>
        </tr>
    </table>
        </div>
    </form>
</body>
</html>
