<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Owner.Master" CodeBehind="ReportTotalSales.aspx.vb" Inherits="webapp_assignment.ReportTotalSales" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="ftco-section contact-section bg-light">
        <div class="container">
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">

                        <rsweb:ReportViewer ID="rvTotalSales" runat="server" Width="90%" Height="1000px">
                            <LocalReport ReportPath="Reports\TotalSales.rdlc">
                                <DataSources>
                                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="TotalSalesDS" />
                                </DataSources>
                            </LocalReport>
                            
                        </rsweb:ReportViewer>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AssignmentConnString %>" SelectCommand="SELECT * FROM [Order]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">
</asp:Content>
