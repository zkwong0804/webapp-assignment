<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Owner.Master" CodeBehind="OwnerProduct.aspx.vb" Inherits="webapp_assignment.OwnerProduct" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section contact-section bg-light">
        <div class="container">
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <asp:LinkButton ID="lbtAdd" runat="server" Text="Add"></asp:LinkButton>
                    <asp:LinkButton ID="lbtUpdate" runat="server" Text="Update"></asp:LinkButton>
                    <asp:LinkButton ID="lbtRemove" runat="server" Text="Remove"></asp:LinkButton>


                </div>
            </div>

            <div class="row block-9">
                <div class="col-md-9 order-md-last d-flex">
                    <div class="form-group">
                        <asp:Label ID="lblCategory" runat="server" Text="Product category"></asp:Label>
                        <asp:DropDownList ID="ddlCategory" runat="server" 
                            CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">
</asp:Content>
