<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportPage.aspx.cs" Inherits="Proyek_Pattern_Software_Design.View.ReportPage" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .report-container {
            padding: 40px 20px;
            max-width: 1400px;
            margin: 0 auto;
        }
        .report-header {
            text-align: center;
            margin-bottom: 40px;
        }
        .report-header h2 {
            color: #4B6CB7;
            font-size: 2em;
            margin: 0;
            font-weight: 600;
        }
        .report-viewer {
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            padding: 20px;
            margin-bottom: 30px;
        }
        .report-viewer .CrystalReportViewer {
            width: 100%;
            border: none;
        }
        .report-viewer .CrystalReportViewer table {
            width: 100%;
            border-collapse: collapse;
        }
        .report-viewer .CrystalReportViewer th {
            background-color: #4B6CB7;
            color: white;
            padding: 12px;
            font-weight: 500;
            text-align: left;
        }
        .report-viewer .CrystalReportViewer td {
            padding: 12px;
            border-bottom: 1px solid #eee;
        }
        .report-viewer .CrystalReportViewer tr:hover {
            background-color: #f8f9fa;
        }
    </style>

    <div class="report-container">
        <div class="report-header">
            <h2>Transaction Report</h2>
        </div>

        <div class="report-viewer">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
        </div>
    </div>
</asp:Content>