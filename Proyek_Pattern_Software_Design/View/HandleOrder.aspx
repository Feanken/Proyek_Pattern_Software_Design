<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="HandleOrder.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.HandleOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .handle-orders-container {
            padding: 40px 20px;
            max-width: 1200px;
            margin: 0 auto;
        }

        .handle-orders-header {
            text-align: center;
            margin-bottom: 40px;
        }

            .handle-orders-header h2 {
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
            margin-bottom: 30px;
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

        .btn-action {
            padding: 8px 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-weight: 500;
            transition: background-color 0.3s;
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

        .status-waiting {
            color: #ffc107;
            font-weight: 500;
            font-style: italic;
        }

        .status-confirmed {
            color: #28a745;
            font-weight: 500;
        }

        .status-rejected {
            color: #dc3545;
            font-weight: 500;
        }

        .success-message {
            color: #28a745;
            text-align: center;
            margin-top: 20px;
            font-weight: 500;
            padding: 15px;
            background-color: #d4edda;
            border-radius: 4px;
        }

        .error-message {
            color: #dc3545;
            text-align: center;
            margin-top: 20px;
            font-weight: 500;
            padding: 15px;
            background-color: #f8d7da;
            border-radius: 4px;
        }
    </style>

    <div class="handle-orders-container">
        <div class="handle-orders-header">
            <h2>Handle Orders</h2>
        </div>

        <div class="orders-grid">
            <asp:GridView ID="GridOrders" runat="server" AutoGenerateColumns="False"
                OnRowCommand="GridOrders_RowCommand"
                OnRowDataBound="GridOrders_RowDataBound"
                CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                    <asp:BoundField DataField="UserID" HeaderText="User ID" />
                    <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnAction" runat="server" CommandName="UpdateStatus" CssClass="btn-action" />
                            <asp:Label ID="lblWaiting" runat="server" Text="Waiting user confirmation..."
                                Visible="false" CssClass="status-waiting" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <asp:Label ID="LabelMessage" runat="server" CssClass="success-message" />
    </div>
</asp:Content>
