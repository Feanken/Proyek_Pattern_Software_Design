<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="JewelsDetail.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.JewelsDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Jewel Detail</h2>

    <asp:Panel ID="PanelDetail" runat="server" Visible="false">
        <table>
            <tr><td><strong>Name:</strong></td><td><asp:Label ID="LabelName" runat="server" /></td></tr>
            <tr><td><strong>Category:</strong></td><td><asp:Label ID="LabelCategory" runat="server" /></td></tr>
            <tr><td><strong>Brand:</strong></td><td><asp:Label ID="LabelBrand" runat="server" /></td></tr>
            <tr><td><strong>Country:</strong></td><td><asp:Label ID="LabelCountry" runat="server" /></td></tr>
            <tr><td><strong>Class:</strong></td><td><asp:Label ID="LabelClass" runat="server" /></td></tr>
            <tr><td><strong>Price:</strong></td><td><asp:Label ID="LabelPrice" runat="server" /></td></tr>
            <tr><td><strong>Release Year:</strong></td><td><asp:Label ID="LabelYear" runat="server" /></td></tr>
        </table>
        <br />
        <asp:Button ID="BtnAddToCart" runat="server" Text="Add to Cart" OnClick="BtnAddToCart_Click" Visible="false" />
        <asp:Button ID="BtnEdit" runat="server" Text="Edit" OnClick="BtnEdit_Click" Visible="false" />
        <asp:Button ID="BtnDelete" runat="server" Text="Delete" OnClick="BtnDelete_Click" Visible="false" />
    </asp:Panel>

    <asp:Label ID="LabelError" runat="server" ForeColor="Red" />
</asp:Content>
