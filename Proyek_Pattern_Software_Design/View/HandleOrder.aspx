<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="HandleOrder.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.HandleOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GVOrders" runat="server" AutoGenerateColumns="False" OnRowCommand="GVOrders_RowCommand">
    <Columns>
        <asp:BoundField DataField="TransactionID" HeaderText="Transaction Id" />
        <asp:BoundField DataField="UserID" HeaderText="User Id" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="BtnAction" runat="server" 
                            Text='<%# GetActionText(Eval("Status").ToString()) %>' 
                            CommandName="Action"
                            CommandArgument='<%# Eval("TransactionID") + "|" + Eval("Status") %>' 
                            Enabled='<%# GetActionEnabled(Eval("Status").ToString()) %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

</asp:Content>
