<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Owner.Master" CodeBehind="CategoryAdd.aspx.vb" Inherits="webapp_assignment.AddCategory" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="ftco-section contact-section bg-light">
        <div class="container">
            <div class="row block-9">
                <div class="col-md-6 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">
                        <div class="form-group">
                            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                            <asp:TextBox ID="tbxName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbxName"
                                ErrorMessage="This field is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblCategory" runat="server" Text=" Parent category"></asp:Label>
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblAvailable" runat="server" Text="Is available?"></asp:Label>
                            <asp:CheckBox ID="cbxAvailable" runat="server" Checked="true" />
                        </div>

                        <div class="form-group">
                            <asp:Button ID="btnAdd" runat="server" Text="Add category" />
                        </div>
                    </div>                  
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">
</asp:Content>
