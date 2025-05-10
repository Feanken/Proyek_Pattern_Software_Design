<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddJewel.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.AddJewell" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add New Jewel</h2>

    <asp:Label ID="LabelMessage" runat="server" ForeColor="Red" />
    <table>
        <tr>
            <td>Jewel Name:</td>
            <td><asp:TextBox ID="TxtName" runat="server" /></td>
        </tr>
        <tr>
            <td>Category:</td>
            <td><asp:DropDownList ID="DDLCategory" runat="server" OnSelectedIndexChanged="DDLCategory_SelectedIndexChanged" /></td>
        </tr>
        <tr>
            <td>Brand:</td>
            <td><asp:DropDownList ID="DDLBrand" runat="server" OnSelectedIndexChanged="DDLBrand_SelectedIndexChanged" /></td>
        </tr>
        <tr>
            <td>Price:</td>
            <td><asp:TextBox ID="TxtPrice" runat="server" /></td>
        </tr>
        <tr>
            <td>Release Year:</td>
            <td><asp:TextBox ID="TxtYear" runat="server" /></td>
        </tr>
    </table>
    <br />
    <asp:Button ID="BtnAdd" runat="server" Text="Add Jewel" OnClick="BtnAdd_Click" />
    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
</asp:Content>
