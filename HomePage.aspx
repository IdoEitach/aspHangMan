<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="HangManAsp.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/HomePage.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>איש תלוי</h1>
            <img src="imgs/icon.png" width="100px"/>
            <br />
            <asp:TextBox ID="TextBoxName" AutoPostBack="true" runat="server" onLoad="TextBoxName_Load" OnTextChanged="TextBoxName_TextChanged"></asp:TextBox><label>:שם</label>
            <h1>קטגוריות לבחירה</h1>
            <div class="categoriesContainer">
                <a href="HangMan.aspx?cat=General&title=ידע כללי">ידע כללי</a>
                <a href="HangMan.aspx?cat=Cats&title=חתולים">חתולים</a>
                <a href="HangMan.aspx?cat=Dogs&title=כלבים">כלבים</a>
            </div>
        </div>
    </form>
</body>
</html>
