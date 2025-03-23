<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login Page</h1>
        </div>
        <div>
            <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:CheckBox ID="CheckBoxCookie" runat="server" />
            <asp:Label ID="LabelCookie" runat="server" Text="Remember Me"></asp:Label>
        </div>
        <div>
            <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
            <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click"/>
        </div>
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Didn't have a Account? Register</asp:LinkButton>
        </div>

    </form>
</body>
</html>
