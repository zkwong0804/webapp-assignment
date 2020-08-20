<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Owner.master" CodeBehind="CouponDelete.aspx.vb" Inherits="webapp_assignment.CouponDelete" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section contact-section bg-light">
        <div class="container">
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">
                        <p>Do you want to delete the following coupon?</p>
                    </div>
                </div>
            </div>
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">
                        <table>
                            <tr>
                                <td>ID:</td>
                                <td><%= SelectedCoupon.id %></td>
                            </tr>
                            <tr>
                                <td>Name:</td>
                                <td><%= SelectedCoupon.name %></td>
                            </tr>
                            <tr>
                                <td>Description:</td>
                                <td><%= SelectedCoupon.description %></td>
                            </tr>
                            <tr>
                                <td>Discount rate:</td>
                                <td><%= SelectedCoupon.discountRate %></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">
                        <asp:Button ID="btnConfirm" ClientIDMode="Static" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
                        <asp:Button ID="btnCancel" ClientIDMode="Static" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="content3" ContentPlaceHolderID="jsHolder" runat="server">
    <script type="text/javascript">
        $("#btnCancel").click(function (e) {
            alert("The operation has been cancelled!")
        })
    </script>
</asp:Content>
