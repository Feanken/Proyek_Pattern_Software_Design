<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .home-container {
            padding: 40px 20px;
            max-width: 1600px;
            margin: 0 auto;
        }
        .hero-section {
            background: linear-gradient(135deg, #4B6CB7 0%, #182848 100%);
            color: white;
            padding: 60px 20px;
            text-align: center;
            margin-bottom: 40px;
            border-radius: 8px;
        }
        .hero-title {
            font-size: 2.5em;
            margin: 0 0 20px 0;
            font-weight: 600;
        }
        .hero-description {
            font-size: 1.2em;
            opacity: 0.9;
            max-width: 800px;
            margin: 0 auto;
        }
        .jewels-grid {
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            overflow: hidden;
            margin-bottom: 30px;
        }
        .jewels-grid .grid-view {
            width: 100%;
            border: none;
            font-size: 1.1em;
        }
        .jewels-grid .grid-view th {
            background-color: #4B6CB7;
            color: white;
            padding: 20px;
            font-weight: 500;
            text-align: left;
            font-size: 1.2em;
        }
        .jewels-grid .grid-view td {
            padding: 20px;
            border-bottom: 1px solid #eee;
            vertical-align: middle;
        }
        .jewels-grid .grid-view tr:hover {
            background-color: #f8f9fa;
        }
        .btn-view {
            background-color: #4B6CB7;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 1em;
            font-weight: 500;
            transition: background-color 0.3s;
            text-decoration: none;
            display: inline-block;
        }
        .btn-view:hover {
            background-color: #3a5a9e;
        }
        .price-column {
            font-weight: 500;
            color: #28a745;
        }
        .id-column {
            font-weight: 500;
            color: #4B6CB7;
        }
        .name-column {
            font-weight: 500;
        }
        @media (max-width: 768px) {
            .hero-title {
                font-size: 2em;
            }
            .hero-description {
                font-size: 1em;
            }
            .jewels-grid .grid-view {
                font-size: 1em;
            }
            .jewels-grid .grid-view th,
            .jewels-grid .grid-view td {
                padding: 15px;
            }
        }
    </style>

    <div class="home-container">
        <div class="hero-section">
            <h1 class="hero-title">Welcome to JAwels&Diamonds</h1>
            <p class="hero-description">Discover our exquisite collection of fine jewelry and diamonds. Each piece tells a unique story of elegance and craftsmanship.</p>
        </div>

        <asp:Panel ID="PanelHomePage" runat="server" CssClass="jewels-grid">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                OnRowCommand="GridView1_RowCommand" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged1"
                CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" SortExpression="JewelID" ItemStyle-CssClass="id-column" />
                    <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" SortExpression="JewelName" ItemStyle-CssClass="name-column" />
                    <asp:BoundField DataField="JewelPrice" HeaderText="Price" SortExpression="JewelPrice" DataFormatString="${0:N2}" ItemStyle-CssClass="price-column" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="BtnViewDetail" runat="server" Text="View Details" 
                                CommandName="ViewDetail" 
                                CommandArgument='<%# Eval("JewelID") %>' 
                                UseSubmitBehavior="false"
                                CssClass="btn-view"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
