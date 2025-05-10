<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="HandleOrder.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.HandleOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Handle Orders</h2>
    <asp:GridView ID="GridOrders" runat="server" AutoGenerateColumns="False" 
              OnRowCommand="GridOrders_RowCommand" 
              OnRowDataBound="GridOrders_RowDataBound">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction Id" />
            <asp:BoundField DataField="UserID" HeaderText="User Id" />
            <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnAction" runat="server" CommandName="UpdateStatus" />
                    <asp:Label ID="lblWaiting" runat="server" Text="Waiting user confirmation..." Visible="false" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="LabelMessage" runat="server" ForeColor="Green" />
</asp:Content>
