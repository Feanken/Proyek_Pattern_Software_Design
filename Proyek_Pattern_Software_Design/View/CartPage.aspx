<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cart-container">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataKeyNames="JewelID"
            OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="JewelID" HeaderText="Id" ReadOnly="true" />
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
                        <asp:Button ID="BtnEdit" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="BtnDelete" runat="server" CommandName="Delete" Text="Remove" OnClientClick="return confirm('Are you sure you want to remove this item?');" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="BtnUpdate" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="BtnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="cart-summary">
            <asp:Label ID="lblTotal" runat="server" />
            <br />
            <asp:DropDownList ID="ddlPayment" runat="server">
                <asp:ListItem Text="Visa" Value="Visa" />
                <asp:ListItem Text="MasterCard" Value="MasterCard" />
                <asp:ListItem Text="PayPal" Value="PayPal" />
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnClearCart" runat="server" Text="Clear Cart" OnClick="btnClearCart_Click" />
            <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Checkout" OnClick="btnCheckout_Click" />
        </div>
    </div>
</asp:Content>