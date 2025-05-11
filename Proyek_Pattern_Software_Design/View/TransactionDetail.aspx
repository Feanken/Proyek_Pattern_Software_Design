<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.TransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .transaction-container {
            padding: 40px 20px;
            max-width: 1000px;
            margin: 0 auto;
        }
        .transaction-header {
            text-align: center;
            margin-bottom: 40px;
        }
        .transaction-header h2 {
            color: #4B6CB7;
            font-size: 2em;
            margin: 0;
            font-weight: 600;
        }
        .transaction-id {
            text-align: center;
            font-size: 1.2em;
            color: #333;
            margin-bottom: 30px;
        }
        .transaction-id strong {
            color: #4B6CB7;
            font-weight: 600;
        }
        .transaction-grid {
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            overflow: hidden;
        }
        .transaction-grid .grid-view {
            width: 100%;
            border: none;
        }
        .transaction-grid .grid-view th {
            background-color: #4B6CB7;
            color: white;
            padding: 15px;
            font-weight: 500;
            text-align: left;
        }
        .transaction-grid .grid-view td {
            padding: 15px;
            border-bottom: 1px solid #eee;
            vertical-align: middle;
        }
        .transaction-grid .grid-view tr:hover {
            background-color: #f8f9fa;
        }
    </style>

    <div class="transaction-container">
        <div class="transaction-header">
            <h2>Transaction Detail</h2>
        </div>

        <div class="transaction-id">
            <asp:Label ID="lblTransactionId" runat="server" />
        </div>

        <div class="transaction-grid">
            <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" 
                OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged"
                CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                    <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" SortExpression="JewelName" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
