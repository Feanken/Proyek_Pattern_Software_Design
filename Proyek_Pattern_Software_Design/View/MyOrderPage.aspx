<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyOrderPage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.MyOrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction id" SortExpression="TransactionID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" />
            <asp:BoundField DataField="PaymentMethod" HeaderText="Payment" SortExpression="PaymentMethod" />
            <asp:BoundField DataField="TransactionStatus" HeaderText="Status" SortExpression="TransactionStatus" />
            <asp:TemplateField HeaderText="Detail">
                <ItemTemplate>
                    <asp:Button ID="btnView" runat="server" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("TransactionID") %>'/>
                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm Package" CommandName="Confirm" CommandArgument='<%# Eval("TransactionID") %>'/>
                    <asp:Button ID="btnReject" runat="server" Text="Reject Package" CommandName="Reject" CommandArgument='<%# Eval("TransactionID") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
        
</asp:Content>