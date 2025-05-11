<%@ Page Title="Profile Page" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Profile Information</h2>
    <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
    <br />

    <hr />

    <h3>Change Password</h3>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <br />

    <asp:Label runat="server" Text="Old Password:" />
    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" OnTextChanged="txtOldPassword_TextChanged" />
    <br />

    <asp:Label runat="server" Text="New Password:" />
    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" OnTextChanged="txtNewPassword_TextChanged" />
    <br />

    <asp:Label runat="server" Text="Confirm Password:" />
    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" OnTextChanged="txtConfirmPassword_TextChanged" />
    <br />
    <br />

    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
</asp:Content>
