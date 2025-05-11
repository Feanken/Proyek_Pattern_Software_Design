<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.TransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transaction Detail</h2>
    <asp:Label ID="lblTransactionId" runat="server" Font-Bold="true"></asp:Label>
    <br /><br />
    <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" SortExpression="TransactionID" />
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" SortExpression="JewelName" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
        </Columns>
    </asp:GridView>
</asp:Content>
