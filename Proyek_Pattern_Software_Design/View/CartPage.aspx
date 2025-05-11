<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .cart-container {
            padding: 40px 20px;
            max-width: 1200px;
            margin: 0 auto;
        }
        .cart-header {
            text-align: center;
            margin-bottom: 40px;
        }
        .cart-header h2 {
            color: #4B6CB7;
            font-size: 2em;
            margin: 0;
            font-weight: 600;
        }
        .cart-grid {
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            overflow: hidden;
            margin-bottom: 30px;
        }
        .cart-grid .grid-view {
            width: 100%;
            border: none;
        }
        .cart-grid .grid-view th {
            background-color: #4B6CB7;
            color: white;
            padding: 15px;
            font-weight: 500;
            text-align: left;
        }
        .cart-grid .grid-view td {
            padding: 15px;
            border-bottom: 1px solid #eee;
            vertical-align: middle;
        }
        .cart-grid .grid-view tr:hover {
            background-color: #f8f9fa;
        }
        .cart-grid .grid-view input[type="text"] {
            width: 60px;
            padding: 8px;
            border: 1px solid #ddd;
            border-radius: 4px;
            text-align: center;
        }
        .btn-action {
            padding: 8px 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-weight: 500;
            transition: background-color 0.3s;
            margin-right: 8px;
        }
        .btn-edit {
            background-color: #4B6CB7;
            color: white;
        }
        .btn-edit:hover {
            background-color: #3a5a9e;
        }
        .btn-delete {
            background-color: #dc3545;
            color: white;
        }
        .btn-delete:hover {
            background-color: #c82333;
        }
        .btn-update {
            background-color: #28a745;
            color: white;
        }
        .btn-update:hover {
            background-color: #218838;
        }
        .btn-cancel {
            background-color: #6c757d;
            color: white;
        }
        .btn-cancel:hover {
            background-color: #5a6268;
        }
        .cart-summary {
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            padding: 30px;
            margin-top: 30px;
        }
        .cart-total {
            font-size: 1.5em;
            color: #4B6CB7;
            font-weight: 600;
            margin-bottom: 20px;
        }
        .payment-section {
            margin-bottom: 20px;
        }
        .payment-section label {
            display: block;
            margin-bottom: 8px;
            color: #333;
            font-weight: 500;
        }
        .payment-select {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 16px;
            margin-bottom: 20px;
        }
        .cart-actions {
            display: flex;
            gap: 15px;
            margin-top: 20px;
        }
        .btn-clear {
            background-color: #6c757d;
            color: white;
            padding: 12px 24px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            font-weight: 500;
            transition: background-color 0.3s;
        }
        .btn-clear:hover {
            background-color: #5a6268;
        }
        .btn-checkout {
            background-color: #28a745;
            color: white;
            padding: 12px 24px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            font-weight: 500;
            transition: background-color 0.3s;
        }
        .btn-checkout:hover {
            background-color: #218838;
        }
    </style>

    <div class="cart-container">
        <div class="cart-header">
            <h2>Shopping Cart</h2>
        </div>

        <div class="cart-grid">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                DataKeyNames="JewelID"
                OnRowEditing="GridView1_RowEditing"
                OnRowUpdating="GridView1_RowUpdating"
                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowDeleting="GridView1_RowDeleting"
                CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="JewelID" HeaderText="ID" ReadOnly="true" />
                    <asp:BoundField DataField="JewelName" HeaderText="Name" ReadOnly="true" />
                    <asp:BoundField DataField="JewelPrice" HeaderText="Price" DataFormatString="${0:N2}" ReadOnly="true" />
                    <asp:BoundField DataField="Brand" HeaderText="Brand" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <%# Eval("Quantity") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("Quantity") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subtotal">
                        <ItemTemplate>
                            <%# String.Format("${0:N2}", (Convert.ToDecimal(Eval("JewelPrice")) * Convert.ToInt32(Eval("Quantity")))) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="BtnEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn-action btn-edit" />
                            <asp:Button ID="BtnDelete" runat="server" CommandName="Delete" Text="Remove" 
                                OnClientClick="return confirm('Are you sure you want to remove this item?');" 
                                CssClass="btn-action btn-delete" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="BtnUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn-action btn-update" />
                            <asp:Button ID="BtnCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn-action btn-cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="cart-summary">
            <div class="cart-total">
                <asp:Label ID="lblTotal" runat="server" />
            </div>

            <div class="payment-section">
                <asp:Label runat="server" Text="Payment Method" AssociatedControlID="ddlPayment" />
                <asp:DropDownList ID="ddlPayment" runat="server" CssClass="payment-select">
                    <asp:ListItem Text="Visa" Value="Visa" />
                    <asp:ListItem Text="MasterCard" Value="MasterCard" />
                    <asp:ListItem Text="PayPal" Value="PayPal" />
                </asp:DropDownList>
            </div>

            <div class="cart-actions">
                <asp:Button ID="btnClearCart" runat="server" Text="Clear Cart" 
                    OnClick="btnClearCart_Click" CssClass="btn-clear" />
                <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Checkout" 
                    OnClick="btnCheckout_Click" CssClass="btn-checkout" />
            </div>
        </div>
    </div>
</asp:Content>