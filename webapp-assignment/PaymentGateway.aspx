<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="PaymentGateway.aspx.vb" Inherits="webapp_assignment.PaymentGateway" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="ftco-section">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xl-10 ftco-animate">
                    <div class="row mt-5 pt-3 d-flex">
                        <div class="col-md-6 d-flex">
                            <div class="cart-detail cart-total bg-light p-3 p-md-4">
                                <h3 class="billing-heading mb-4">Cart Total</h3>
                                <p class="d-flex">
                                    <span>Subtotal</span>
                                    <span><%= CDec(OrderDict.Item("total")) %></span>
                                </p>
                                <p class="d-flex">
                                    <span>Delivery</span>
                                    <span>RM <%= CDec(OrderDict.Item("shipping")) %></span>
                                </p>
                                <p class="d-flex">
                                    <span>Discount</span>
                                    <span>RM <%= CDec(OrderDict.Item("discount")) %></span>
                                </p>
                                <hr>
                                <p class="d-flex total-price">
                                    <span>Total</span>
                                    <span>RM <%= CDec(OrderDict.Item("grandTotal")) %></span>
                                </p>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="cart-detail bg-light p-3 p-md-4">
                                <h3 class="billing-heading mb-4">Payment Method</h3>
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <div class="radio">
                                            <label>
                                                <input type="radio" name="optradio" class="mr-2" checked="checked">
                                                Maybank</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <div class="radio">
                                            <label>
                                                <input type="radio" name="optradio" class="mr-2">
                                                Public bank</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <div class="radio">
                                            <label>
                                                <input type="radio" name="optradio" class="mr-2">
                                                UOB</label>
                                        </div>
                                    </div>
                                </div>
                                <p><asp:LinkButton ID="lbtMakePayment" runat="server" CssClass="btn btn-primary py-3 px-4">Make payment</asp:LinkButton></p>
                                <p><asp:LinkButton ID="lbtCancelOrder" runat="server" CssClass="btn btn-primary py-3 px-4" 
                                    ClientIDMode="Static">Cancel order</asp:LinkButton></p>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- .col-md-8 -->
            </div>
        </div>
    </section>
    <!-- .section -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">
    <script>
        $(document).ready(function () {

            $("#lbtCancelOrder").click(function (e) {
                alert("Your order has been cancelled!")
            })

            var quantitiy = 0;
            $('.quantity-right-plus').click(function (e) {

                // Stop acting like a button
                e.preventDefault();
                // Get the field name
                var quantity = parseInt($('#quantity').val());

                // If is not undefined

                $('#quantity').val(quantity + 1);


                // Increment

            });

            $('.quantity-left-minus').click(function (e) {
                // Stop acting like a button
                e.preventDefault();
                // Get the field name
                var quantity = parseInt($('#quantity').val());

                // If is not undefined

                // Increment
                if (quantity > 0) {
                    $('#quantity').val(quantity - 1);
                }
            });

        });
    </script>
</asp:Content>
