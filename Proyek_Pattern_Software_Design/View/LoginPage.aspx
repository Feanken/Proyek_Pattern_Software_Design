<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Jewelry Store</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #f5f7fa 0%, #c3cfe2 100%);
            margin: 0;
            padding: 0;
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
        }
        .login-container {
            background: white;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 400px;
            margin: 20px;
        }
        .login-header {
            text-align: center;
            margin-bottom: 30px;
        }
        .login-header h1 {
            color: #4B6CB7;
            font-size: 2em;
            margin: 0;
            font-weight: 600;
        }
        .form-group {
            margin-bottom: 20px;
        }
        .form-group label {
            display: block;
            margin-bottom: 8px;
            color: #333;
            font-weight: 500;
        }
        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 16px;
            transition: border-color 0.3s;
        }
        .form-control:focus {
            border-color: #4B6CB7;
            outline: none;
        }
        .remember-me {
            display: flex;
            align-items: center;
            margin-bottom: 20px;
        }
        .remember-me input[type="checkbox"] {
            margin-right: 8px;
        }
        .btn-login {
            background-color: #4B6CB7;
            color: white;
            border: none;
            padding: 12px 20px;
            border-radius: 4px;
            cursor: pointer;
            width: 100%;
            font-size: 16px;
            font-weight: 500;
            transition: background-color 0.3s;
        }
        .btn-login:hover {
            background-color: #3a5a9e;
        }
        .status-label {
            color: #dc3545;
            margin-bottom: 15px;
            display: block;
        }
        .register-link {
            text-align: center;
            margin-top: 20px;
        }
        .register-link a {
            color: #4B6CB7;
            text-decoration: none;
            font-weight: 500;
        }
        .register-link a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-header">
                <h1>Welcome Back</h1>
            </div>
            
            <div class="form-group">
                <asp:Label ID="LabelEmail" runat="server" Text="Email" AssociatedControlID="TextBoxEmail"></asp:Label>
                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter your email"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="LabelPassword" runat="server" Text="Password" AssociatedControlID="TextBoxPassword"></asp:Label>
                <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
            </div>

            <div class="remember-me">
                <asp:CheckBox ID="CheckBoxCookie" runat="server" />
                <asp:Label ID="LabelCookie" runat="server" Text="Remember Me"></asp:Label>
            </div>

            <asp:Label ID="LabelStatus" runat="server" Text="" CssClass="status-label"></asp:Label>

            <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" CssClass="btn-login"/>

            <div class="register-link">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Don't have an account? Register here</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
