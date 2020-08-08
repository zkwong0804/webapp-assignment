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
                    <asp:Panel ID="pnlAdd" runat="server">
                        <div class="form-group">
                            <asp:Label ID="lblAddName" runat="server" Text="Product name"></asp:Label>
                            <asp:TextBox ID="tbxAddName" runat="server" 
                                ValidationGroup="add" 
                                CssClass="form-control"></asp:TextBox>
                            <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                            <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlUpdate" runat="server" Visible="false">
                        <h1>Update product</h1>

                    </asp:Panel>
                    <asp:Panel ID="pnlRemove" runat="server" Visible="false">
                        <h1>Remove product</h1>

                    </asp:Panel>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">
</asp:Content>
