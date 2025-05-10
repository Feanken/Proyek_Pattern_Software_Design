<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditJewel.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.EditJewel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Edit Jewel</h2>
    <asp:Panel ID="PanelEdit" runat="server">
        <table>
            <tr><td><strong>Name:</strong></td><td><asp:TextBox ID="TxtName" runat="server" /></td></tr>
            <tr><td><strong>Category:</strong></td>
                <td>
                    <asp:DropDownList ID="DDLCategory" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr><td><strong>Brand:</strong></td>
                <td>
                    <asp:DropDownList ID="DDLBrand" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr><td><strong>Price:</strong></td><td><asp:TextBox ID="TxtPrice" runat="server" /></td></tr>
            <tr><td><strong>Release Year:</strong></td><td><asp:TextBox ID="TxtYear" runat="server" /></td></tr>
        </table>
        <br />
        <asp:Button ID="BtnSave" runat="server" Text="Save Changes" OnClick="BtnSave_Click" />
        <asp:Label ID="LabelMessage" runat="server" ForeColor="Red" />
    </asp:Panel>
</asp:Content>
