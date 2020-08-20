<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Owner.Master" CodeBehind="ProductDelete.aspx.vb" Inherits="webapp_assignment.ProductDelete" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section contact-section bg-light">
        <div class="container">
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">
                        <p>Do you really want to delete the following product?</p>
                    </div>
                </div>
            </div>

            
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">
                        <table>
                            <tr>
                                <td><img src='<%= SelectedProduct.imageLoc.Substring(1) %>' width="100" height="100" /></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>ID: </td>
                                <td><%= SelectedProduct.id %></td>
                            </tr>
                            <tr>
                                <td>Name: </td>
                                <td><%= SelectedProduct.name %></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">
                        <asp:Button ID="btnConfirm" ClientIDMode="Static" Text="Confirm" runat="server" OnClick="btnConfirm_Click" />
                        <asp:Button ID="btnCancel" ClientIDMode="Static" Text="Cancel" runat="server" OnClick="btnCancel_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">
    <script type="text/javascript">
        $("#btnCancel").click(function (e) {
            alert("The operation has been cancelled!")
        })
    </script>
</asp:Content>
