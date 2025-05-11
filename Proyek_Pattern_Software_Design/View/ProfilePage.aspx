<%@ Page Title="Profile Page" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .profile-container {
            padding: 40px 20px;
            max-width: 800px;
            margin: 0 auto;
        }
        .profile-header {
            text-align: center;
            margin-bottom: 40px;
        }
        .profile-header h2 {
            color: #4B6CB7;
            font-size: 2em;
            margin: 0;
            font-weight: 600;
        }
        .profile-card {
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            padding: 30px;
            margin-bottom: 30px;
        }
        .profile-info {
            margin-bottom: 20px;
        }
        .profile-info p {
            margin: 10px 0;
            font-size: 1.1em;
            color: #333;
        }
        .profile-info strong {
            color: #4B6CB7;
            font-weight: 500;
            display: inline-block;
            width: 120px;
        }
        .divider {
            height: 1px;
            background: #eee;
            margin: 30px 0;
        }
        .password-section h3 {
            color: #4B6CB7;
            font-size: 1.5em;
            margin-bottom: 20px;
            font-weight: 500;
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
        .btn-change-password {
            background-color: #4B6CB7;
            color: white;
            border: none;
            padding: 12px 24px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            font-weight: 500;
            transition: background-color 0.3s;
        }
        .btn-change-password:hover {
            background-color: #3a5a9e;
        }
        .error-message {
            color: #dc3545;
            margin-bottom: 15px;
            display: block;
            font-weight: 500;
        }
    </style>

    <div class="profile-container">
        <div class="profile-header">
            <h2>Profile Information</h2>
        </div>

        <div class="profile-card">
            <div class="profile-info">
                <p><strong>Username:</strong> <asp:Label ID="lblUsername" runat="server" /></p>
                <p><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" /></p>
            </div>

            <div class="divider"></div>

            <div class="password-section">
                <h3>Change Password</h3>
                <asp:Label ID="lblMessage" runat="server" CssClass="error-message" />

                <div class="form-group">
                    <asp:Label runat="server" Text="Old Password" AssociatedControlID="txtOldPassword" />
                    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" 
                        OnTextChanged="txtOldPassword_TextChanged" CssClass="form-control" />
                </div>

                <div class="form-group">
                    <asp:Label runat="server" Text="New Password" AssociatedControlID="txtNewPassword" />
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" 
                        OnTextChanged="txtNewPassword_TextChanged" CssClass="form-control" />
                </div>

                <div class="form-group">
                    <asp:Label runat="server" Text="Confirm Password" AssociatedControlID="txtConfirmPassword" />
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" 
                        OnTextChanged="txtConfirmPassword_TextChanged" CssClass="form-control" />
                </div>

                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" 
                    OnClick="btnChangePassword_Click" CssClass="btn-change-password" />
            </div>
        </div>
    </div>
</asp:Content>
