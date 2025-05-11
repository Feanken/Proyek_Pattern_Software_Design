<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="JewelsDetail.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.JewelsDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .detail-container {
            padding: 40px 20px;
            max-width: 800px;
            margin: 0 auto;
        }
        .detail-header {
            text-align: center;
            margin-bottom: 40px;
        }
        .detail-header h2 {
            color: #4B6CB7;
            font-size: 2em;
            margin: 0;
            font-weight: 600;
        }
        .detail-card {
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            padding: 30px;
        }
        .detail-table {
            width: 100%;
            border-collapse: collapse;
        }
        .detail-table tr {
            border-bottom: 1px solid #eee;
        }
        .detail-table tr:last-child {
            border-bottom: none;
        }
        .detail-table td {
            padding: 15px;
            vertical-align: top;
        }
        .detail-table td:first-child {
            width: 40%;
            font-weight: 500;
            color: #4B6CB7;
        }
        .detail-table td:last-child {
            color: #333;
        }
        .action-buttons {
            margin-top: 30px;
            display: flex;
            gap: 15px;
            justify-content: center;
        }
        .btn-action {
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-weight: 500;
            transition: background-color 0.3s;
            text-decoration: none;
            display: inline-block;
        }
        .btn-cart {
            background-color: #4B6CB7;
            color: white;
        }
        .btn-cart:hover {
            background-color: #3a5a9e;
        }
        .btn-edit {
            background-color: #28a745;
            color: white;
        }
        .btn-edit:hover {
            background-color: #218838;
        }
        .btn-delete {
            background-color: #dc3545;
            color: white;
        }
        .btn-delete:hover {
            background-color: #c82333;
        }
        .error-message {
            color: #dc3545;
            text-align: center;
            margin-top: 20px;
            font-weight: 500;
        }
    </style>

    <div class="detail-container">
        <div class="detail-header">
            <h2>Jewel Detail</h2>
        </div>

        <asp:Panel ID="PanelDetail" runat="server" Visible="false" CssClass="detail-card">
            <table class="detail-table">
                <tr>
                    <td>Name</td>
                    <td><asp:Label ID="LabelName" runat="server" /></td>
                </tr>
                <tr>
                    <td>Category</td>
                    <td><asp:Label ID="LabelCategory" runat="server" /></td>
                </tr>
                <tr>
                    <td>Brand</td>
                    <td><asp:Label ID="LabelBrand" runat="server" /></td>
                </tr>
                <tr>
                    <td>Country</td>
                    <td><asp:Label ID="LabelCountry" runat="server" /></td>
                </tr>
                <tr>
                    <td>Class</td>
                    <td><asp:Label ID="LabelClass" runat="server" /></td>
                </tr>
                <tr>
                    <td>Price</td>
                    <td><asp:Label ID="LabelPrice" runat="server" /></td>
                </tr>
                <tr>
                    <td>Release Year</td>
                    <td><asp:Label ID="LabelYear" runat="server" /></td>
                </tr>
            </table>

            <div class="action-buttons">
                <asp:Button ID="BtnAddToCart" runat="server" Text="Add to Cart" 
                    OnClick="BtnAddToCart_Click" Visible="false" 
                    CssClass="btn-action btn-cart"/>
                <asp:Button ID="BtnEdit" runat="server" Text="Edit" 
                    OnClick="BtnEdit_Click" Visible="false" 
                    CssClass="btn-action btn-edit"/>
                <asp:Button ID="BtnDelete" runat="server" Text="Delete" 
                    OnClick="BtnDelete_Click" Visible="false" 
                    CssClass="btn-action btn-delete"/>
            </div>
        </asp:Panel>

        <asp:Label ID="LabelError" runat="server" CssClass="error-message" />
    </div>
</asp:Content>
