<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditJewel.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.EditJewel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .edit-jewel-container {
            padding: 40px 20px;
            max-width: 800px;
            margin: 0 auto;
        }
        .edit-jewel-header {
            text-align: center;
            margin-bottom: 40px;
        }
        .edit-jewel-header h2 {
            color: #4B6CB7;
            font-size: 2em;
            margin: 0;
            font-weight: 600;
        }
        .edit-jewel-form {
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            padding: 30px;
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
        .form-select {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 16px;
            background-color: white;
            transition: border-color 0.3s;
        }
        .form-select:focus {
            border-color: #4B6CB7;
            outline: none;
        }
        .error-message {
            color: #dc3545;
            margin-bottom: 20px;
            display: block;
            font-weight: 500;
        }
        .form-actions {
            display: flex;
            gap: 15px;
            margin-top: 30px;
        }
        .btn-save {
            background-color: #28a745;
            color: white;
            border: none;
            padding: 12px 24px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            font-weight: 500;
            transition: background-color 0.3s;
        }
        .btn-save:hover {
            background-color: #218838;
        }
    </style>

    <div class="edit-jewel-container">
        <div class="edit-jewel-header">
            <h2>Edit Jewel</h2>
        </div>

        <asp:Panel ID="PanelEdit" runat="server" CssClass="edit-jewel-form">
            <div class="form-group">
                <asp:Label runat="server" Text="Name" AssociatedControlID="TxtName" />
                <asp:TextBox ID="TxtName" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="Category" AssociatedControlID="DDLCategory" />
                <asp:DropDownList ID="DDLCategory" runat="server" CssClass="form-select" />
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="Brand" AssociatedControlID="DDLBrand" />
                <asp:DropDownList ID="DDLBrand" runat="server" CssClass="form-select" />
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="Price" AssociatedControlID="TxtPrice" />
                <asp:TextBox ID="TxtPrice" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="Release Year" AssociatedControlID="TxtYear" />
                <asp:TextBox ID="TxtYear" runat="server" CssClass="form-control" />
            </div>

            <asp:Label ID="LabelMessage" runat="server" CssClass="error-message" />

            <div class="form-actions">
                <asp:Button ID="BtnSave" runat="server" Text="Save Changes" 
                    OnClick="BtnSave_Click" CssClass="btn-save" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
