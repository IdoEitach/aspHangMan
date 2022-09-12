<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HangMan.aspx.cs" Inherits="HangManAsp.HangMan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/HangMan.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="buttonsContainer">
            <asp:Button ID="Button1" runat="server" Text="א" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button2" runat="server" Text="ב" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button4" runat="server" Text="ג" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button3" runat="server" Text="ד" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button5" runat="server" Text="ה" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button6" runat="server" Text="ו" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button7" runat="server" Text="ז" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button8" runat="server" Text="ח" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button9" runat="server" Text="ט" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button10" runat="server" Text="י" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button11" runat="server" Text="כ" OnClick="ButtonLetter_Click" />    
            <asp:Button ID="Button12" runat="server" Text="ל" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button13" runat="server" Text="מ" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button14" runat="server" Text="נ" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button15" runat="server" Text="ס" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button16" runat="server" Text="ע" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button17" runat="server" Text="פ" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button18" runat="server" Text="צ" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button19" runat="server" Text="ק" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button20" runat="server" Text="ר" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button21" runat="server" Text="ש" OnClick="ButtonLetter_Click" />
            <asp:Button ID="Button22" runat="server" Text="ת" OnClick="ButtonLetter_Click" />
        </div>
    </form>
</body>
</html>
