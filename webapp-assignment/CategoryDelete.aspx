<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Owner.Master" CodeBehind="CategoryDelete.aspx.vb" Inherits="webapp_assignment.CategoryDelete" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section contact-section bg-light">
        <div class="container">
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <asp:Label ID="lblMessage" runat="server">Do you really want to delete the following category?</asp:Label>
                </div>
            </div>
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <table>
                        <tr>
                            <td>ID:</td>
                            <td></td>
                            <td><%= SelectedCategory.id %></td>
                        </tr>
                        <tr>
                            <td>Name:</td>
                            <td></td>
                            <td><%= SelectedCategory.name %></td>
                        </tr>
                        <tr>
                            <td>Parent:</td>
                            <td></td>
                            <td><%= SelectedCategory.Category2.name %></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">


                    <asp:Button ID="btnConfirm" ClientIDMode="Static" Text="Yes" runat="server" OnClick="btnConfirm_Click" />
                    <asp:Button ID="btnCancel" ClientIDMode="Static" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
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
