<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HangMan.aspx.cs" Inherits="HangManAsp.HangMan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/HangMan.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="ButtonBack" runat="server" CssClass="btn" Text="חזרה" OnClick="ButtonBack_Click"/>
        <h1 class="title">נושא: <%=Session["Cat"] %></h1>
        <div class="hangmanImg">
            <img src="imgs/<%=Session["Mistakes"] %>.png" />
        </div>
        <div class="secretWordContainer">
            <%=Session["SecretWord"] %>
        </div>
        <div class="hintContainer">
            <div class="hint"><%=Session["Hint"] %></div>
            <asp:Button ID="ButtonHint" runat="server" CssClass="btn" Text="קבל רמז" OnClick="ButtonHint_Click" OnLoad="ButtonHint_Load"/>
        </div>
        <div>
        </div>
        <div class="buttonsContainer">
            <asp:Button ID="Button1" runat="server" Text="א" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button2" runat="server" Text="ב" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button4" runat="server" Text="ג" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button3" runat="server" Text="ד" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button5" runat="server" Text="ה" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button6" runat="server" Text="ו" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button7" runat="server" Text="ז" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button8" runat="server" Text="ח" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button9" runat="server" Text="ט" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button10" runat="server" Text="י" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button11" runat="server" Text="כ" OnClick="Button_Click" OnLoad="Button_Load"/>    
            <asp:Button ID="Button12" runat="server" Text="ל" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button13" runat="server" Text="מ" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button14" runat="server" Text="נ" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button15" runat="server" Text="ס" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button16" runat="server" Text="ע" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button17" runat="server" Text="פ" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button18" runat="server" Text="צ" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button19" runat="server" Text="ק" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button20" runat="server" Text="ר" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button21" runat="server" Text="ש" OnClick="Button_Click" OnLoad="Button_Load"/>
            <asp:Button ID="Button22" runat="server" Text="ת" OnClick="Button_Click" OnLoad="Button_Load"/>
        </div>
    </form>
</body>
</html>
