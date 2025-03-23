<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Register Page</h1>
        </div>
        <div>
            <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="TextBoxConfirmPassword" runat="server"></asp:TextBox>
            <br />  
            <asp:RadioButtonList ID="RadioButtonGender" runat="server">
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
            </asp:RadioButtonList>

            <br />
            <asp:Label ID="LabelDateofBirth" runat="server" Text="Date of Birth"></asp:Label>
            <asp:Calendar ID="CalendarDateofBirth" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" OnSelectionChanged="CalendarDateofBirth_SelectionChanged1" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px" >
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
        </div>
        <div>
            <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click"/>
        </div>
        <div>
            <asp:LinkButton ID="LinkButtonLogin" runat="server" OnClick="LinkButtonLogin_Click">Have Account? Login</asp:LinkButton>
        </div>
    </form>
</body>
</html>
