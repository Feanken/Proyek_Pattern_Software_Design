<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register - Jewelry Store</title>
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
        .register-container {
            background: white;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 500px;
            margin: 20px;
        }
        .register-header {
            text-align: center;
            margin-bottom: 30px;
        }
        .register-header h1 {
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
            box-sizing: border-box;
        }
        .form-control:focus {
            border-color: #4B6CB7;
            outline: none;
        }
        .gender-group {
            margin-bottom: 20px;
        }
        .gender-group label {
            display: block;
            margin-bottom: 8px;
            color: #333;
            font-weight: 500;
        }
        .radio-list {
            display: flex;
            gap: 20px;
        }
        .radio-list label {
            display: flex;
            align-items: center;
            font-weight: normal;
            cursor: pointer;
        }
        .radio-list input[type="radio"] {
            margin-right: 8px;
        }
        .calendar-container {
            margin-bottom: 20px;
        }
        .calendar-container label {
            display: block;
            margin-bottom: 8px;
            color: #333;
            font-weight: 500;
        }
        .calendar {
            border: 1px solid #ddd;
            border-radius: 4px;
            padding: 10px;
            background: white;
        }
        .btn-register {
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
        .btn-register:hover {
            background-color: #3a5a9e;
        }
        .status-label {
            color: #dc3545;
            margin-bottom: 15px;
            display: block;
        }
        .login-link {
            text-align: center;
            margin-top: 20px;
        }
        .login-link a {
            color: #4B6CB7;
            text-decoration: none;
            font-weight: 500;
        }
        .login-link a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-container">
            <div class="register-header">
                <h1>Create Account</h1>
            </div>

            <div class="form-group">
                <asp:Label ID="LabelEmail" runat="server" Text="Email" AssociatedControlID="TextBoxEmail"></asp:Label>
                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter your email"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="LabelUsername" runat="server" Text="Username" AssociatedControlID="TextBoxUsername"></asp:Label>
                <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="form-control" placeholder="Choose a username"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="LabelPassword" runat="server" Text="Password" AssociatedControlID="TextBoxPassword"></asp:Label>
                <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Create a password"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="LabelConfirmPassword" runat="server" Text="Confirm Password" AssociatedControlID="TextBoxConfirmPassword"></asp:Label>
                <asp:TextBox ID="TextBoxConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirm your password"></asp:TextBox>
            </div>

            <div class="gender-group">
                <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
                <div class="radio-list">
                    <asp:RadioButtonList ID="RadioButtonGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="Male">Male</asp:ListItem>
                        <asp:ListItem Value="Female">Female</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>

            <div class="calendar-container">
                <asp:Label ID="LabelDateofBirth" runat="server" Text="Date of Birth"></asp:Label>
                <div class="calendar">
                    <asp:Calendar ID="CalendarDateofBirth" runat="server" 
                        BackColor="White" 
                        BorderColor="#ddd"
                        BorderWidth="1px"
                        CellPadding="1"
                        DayNameFormat="Shortest"
                        Font-Names="Verdana"
                        Font-Size="8pt"
                        ForeColor="#333333"
                        Height="200px"
                        Width="100%"
                        OnSelectionChanged="CalendarDateofBirth_SelectionChanged1">
                        <DayHeaderStyle BackColor="#4B6CB7" ForeColor="White" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#4B6CB7" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#f8f9fa" ForeColor="#333333" />
                    </asp:Calendar>
                </div>
            </div>

            <asp:Label ID="LabelStatus" runat="server" Text="" CssClass="status-label"></asp:Label>

            <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" CssClass="btn-register"/>

            <div class="login-link">
                <asp:LinkButton ID="LinkButtonLogin" runat="server" OnClick="LinkButtonLogin_Click">Already have an account? Login here</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
