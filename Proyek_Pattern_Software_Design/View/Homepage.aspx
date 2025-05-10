<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>This Is Home Page</h1>
    </div>
    <asp:Panel ID="PanelHomePage" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
            <Columns>
                <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" SortExpression="JewelID" />
                <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" SortExpression="JewelName" />
                <asp:BoundField DataField="JewelPrice" HeaderText="Jewel Price" SortExpression="JewelPrice" />
                <asp:TemplateField HeaderText="View Detail">
                    <ItemTemplate>
                        <asp:Button ID="BtnViewDetail" runat="server" Text="View Detail" CommandName="ViewDetail" CommandArgument='<%# Eval("JewelID") %>' UseSubmitBehavior="false"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </asp:Panel>
</asp:Content>
