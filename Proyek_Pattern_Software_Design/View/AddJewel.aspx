<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddJewel.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.AddJewell" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .add-jewel-container {
            padding: 40px 20px;
            max-width: 800px;
            margin: 0 auto;
        }
        .add-jewel-header {
            text-align: center;
            margin-bottom: 40px;
        }
        .add-jewel-header h2 {
            color: #4B6CB7;
            font-size: 2em;
            margin: 0;
            font-weight: 600;
        }
        .add-jewel-form {
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
        .btn-add {
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
        .btn-add:hover {
            background-color: #218838;
        }
        .btn-cancel {
            background-color: #6c757d;
            color: white;
            border: none;
            padding: 12px 24px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            font-weight: 500;
            transition: background-color 0.3s;
        }
        .btn-cancel:hover {
            background-color: #5a6268;
        }
    </style>

    <div class="add-jewel-container">
        <div class="add-jewel-header">
            <h2>Add New Jewel</h2>
        </div>

        <div class="add-jewel-form">
            <asp:Label ID="LabelMessage" runat="server" CssClass="error-message" />

            <div class="form-group">
                <asp:Label runat="server" Text="Jewel Name" AssociatedControlID="TxtName" />
                <asp:TextBox ID="TxtName" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="Category" AssociatedControlID="DDLCategory" />
                <asp:DropDownList ID="DDLCategory" runat="server" 
                    OnSelectedIndexChanged="DDLCategory_SelectedIndexChanged"
                    CssClass="form-select" />
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="Brand" AssociatedControlID="DDLBrand" />
                <asp:DropDownList ID="DDLBrand" runat="server" 
                    OnSelectedIndexChanged="DDLBrand_SelectedIndexChanged"
                    CssClass="form-select" />
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="Price" AssociatedControlID="TxtPrice" />
                <asp:TextBox ID="TxtPrice" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="Release Year" AssociatedControlID="TxtYear" />
                <asp:TextBox ID="TxtYear" runat="server" CssClass="form-control" />
            </div>

            <div class="form-actions">
                <asp:Button ID="BtnAdd" runat="server" Text="Add Jewel" 
                    OnClick="BtnAdd_Click" CssClass="btn-add" />
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" 
                    OnClick="BtnCancel_Click" CssClass="btn-cancel" />
            </div>
        </div>
    </div>
</asp:Content>
