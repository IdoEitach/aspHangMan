﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="HangManAsp.HomePage" %>

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
            <h1>קטגוריות לבחירה</h1>
            <div class="categories">
                <a href="HangMan.aspx?cat=general">ידע כללי</a>
                <a href="HangMan.aspx?cat=cats">חתולים</a>
                <a href="HangMan.aspx?cat=dogs">כלבים</a>
            </div>
        </div>
    </form>
</body>
</html>