<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyOrderPage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.MyOrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .orders-container {
            padding: 40px 20px;
            max-width: 1200px;
            margin: 0 auto;
        }
        .orders-header {
            text-align: center;
            margin-bottom: 40px;
        }
        .orders-header h1 {
            color: #4B6CB7;
            font-size: 2em;
            margin: 0;
            font-weight: 600;
        }
        .orders-grid {
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            overflow: hidden;
        }
        .orders-grid .grid-view {
            width: 100%;
            border: none;
        }
        .orders-grid .grid-view th {
            background-color: #4B6CB7;
            color: white;
            padding: 15px;
            font-weight: 500;
            text-align: left;
        }
        .orders-grid .grid-view td {
            padding: 15px;
            border-bottom: 1px solid #eee;
            vertical-align: middle;
        }
        .orders-grid .grid-view tr:hover {
            background-color: #f8f9fa;
        }
        .action-buttons {
            display: flex;
            gap: 10px;
            flex-wrap: wrap;
        }
        .btn-action {
            padding: 8px 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-weight: 500;
            transition: background-color 0.3s;
            text-decoration: none;
            display: inline-block;
        }
        .btn-view {
            background-color: #4B6CB7;
            color: white;
        }
        .btn-view:hover {
            background-color: #3a5a9e;
        }
        .btn-confirm {
            background-color: #28a745;
            color: white;
        }
        .btn-confirm:hover {
            background-color: #218838;
        }
        .btn-reject {
            background-color: #dc3545;
            color: white;
        }
        .btn-reject:hover {
            background-color: #c82333;
        }
        .status-pending {
            color: #ffc107;
            font-weight: 500;
        }
        .status-confirmed {
            color: #28a745;
            font-weight: 500;
        }
        .status-rejected {
            color: #dc3545;
            font-weight: 500;
        }
    </style>

    <div class="orders-container">
        <div class="orders-header">
            <h1>My Orders</h1>
        </div>

        <div class="orders-grid">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                OnRowCommand="GridView1_RowCommand" 
                OnRowDataBound="GridView1_RowDataBound"
                CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:BoundField DataField="PaymentMethod" HeaderText="Payment" SortExpression="PaymentMethod" />
                    <asp:BoundField DataField="TransactionStatus" HeaderText="Status" SortExpression="TransactionStatus" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <div class="action-buttons">
                                <asp:Button ID="btnView" runat="server" Text="View Details" 
                                    CommandName="ViewDetails" 
                                    CommandArgument='<%# Eval("TransactionID") %>'
                                    CssClass="btn-action btn-view"/>
                                <asp:Button ID="btnConfirm" runat="server" Text="Confirm Package" 
                                    CommandName="Confirm" 
                                    CommandArgument='<%# Eval("TransactionID") %>'
                                    CssClass="btn-action btn-confirm"/>
                                <asp:Button ID="btnReject" runat="server" Text="Reject Package" 
                                    CommandName="Reject" 
                                    CommandArgument='<%# Eval("TransactionID") %>'
                                    CssClass="btn-action btn-reject"/>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>