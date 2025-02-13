<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATS_friendly_Resume_Maker.HomePage" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Home - Resume Maker</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <div class="title">ATS Friendly Resume Maker</div>
        <a href="Login.aspx" class="login-btn">Login</a>
    </div>
    <div class="container">
        <p class="hero-text">Create a Resume That Stands Out</p>
        <p class="sub-text">Start building your professional resume with our easy-to-use tool.</p>
        <a href="ResumeBuilder.aspx" class="btn">Get Started</a>
        <asp:Label ID="lblWelcome" runat="server" Text="Label"></asp:Label>
    </div>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    </form>
</body>
</html>
