<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Owner.Master" CodeBehind="OwnerProduct.aspx.vb" Inherits="webapp_assignment.OwnerProduct" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section contact-section bg-light">
        <div class="container">

            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <asp:Label ID="lblProductMsg" runat="server"
                        Visible="false"
                        Text="There is no product exist in database"></asp:Label>
                </div>
            </div>

            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <asp:Table ID="tabCategory" runat="server"
                        CssClass="table table-hover table-condensed">
                        <asp:TableHeaderRow ID="thrHeader">
                            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Image</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>RM</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Amt</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Desc</asp:TableHeaderCell>
                            <asp:TableHeaderCell ColumnSpan="2"></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </div>

            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <asp:Button ID="btnAdd" runat="server" Text="New product" />
                    <asp:Button ID="btnBulk" runat="server" Text="Excel bulk import" OnClick="btnBulk_Click" ValidationGroup="excelbulk"/>
                    <asp:FileUpload ID="fupBulk" runat="server" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="fupBulk" 
                        ErrorMessage="You must upload an excel doc in order to perform bulk upload!" 
                        ForeColor="Red" ValidationGroup="excelbulk"></asp:RequiredFieldValidator>
                    <a href="TemplateDownload.aspx">Download template</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">
</asp:Content>
