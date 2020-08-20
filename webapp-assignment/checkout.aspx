<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="Checkout.aspx.vb" Inherits="webapp_assignment.Checkout1" EnableViewState="true" ViewStateMode="Enabled" %>

<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_6.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <h1 class="mb-0 bread">Cart</h1>
                </div>
            </div>
        </div>
    </div>

    <section class="ftco-section ftco-cart">
        <div class="container">
            <div class="row">
                <div class="col-md-12 ftco-animate">
                    <div class="cart-list">

                        <asp:Panel ID="pnlMsg" runat="server" Visible="false">
                            <h3>Go get something for your cart now!</h3>
                        </asp:Panel>

                        <asp:GridView ID="gvCarts" runat="server" CssClass="table" Visible="false"
                            ItemType="webapp_assignment.Cart" AutoGenerateColumns="false" ClientIDMode="Static"
                            ShowHeaderWhenEmpty="true" BorderWidth="0" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-CssClass="product-remove">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" OnCommand="RemoveCartItem" CommandArgument='<%# Item.Product.id %>'>
                                            <span class="ion-ios-close"></span>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" ItemStyle-CssClass="image-prod">
                                    <ItemTemplate>
                                        <div class="img" style='<%# String.format("background-image: url({0});", Item.Product.imageLoc.SubString(1)) %>'></div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product" ItemStyle-CssClass="product-name">
                                    <ItemTemplate>
                                        <h3><%# Item.Product.name %></h3>
                                        <p><%# Item.Product.description %></p>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Price" ItemStyle-CssClass="price">
                                    <ItemTemplate>
                                        RM <%# Item.Product.price %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Quantity" ItemStyle-CssClass="quantity">
                                    <ItemTemplate>
                                        <div class="input-group mb-3">
                                            <asp:TextBox runat="server" Text='<%# Item.OrderAmt %>' CssClass="quantity form-control input-number" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        RM <%# Item.Product.price * Item.OrderAmt %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
            </div>

            <asp:Panel CssClass="row justify-content-start  bg-light" ID="pnlTotal" runat="server">
                <div class="col col-md-6 mt-5 cart-wrap ftco-animate">
                    <div class="cart-total mb-3">
                        <h3>Cart Totals</h3>
                        <p class="d-flex">
                            <span>Subtotal</span>
                            <span>RM <%= Total %></span>
                        </p>
                        <p class="d-flex">
                            <span>Delivery</span>
                            <span>RM <%= ShippingFee %></span>
                        </p>
                        <p class="d-flex">
                            <span>Discount</span>
                            <span>RM <%= DiscountAmt() %></span>
                        </p>
                        <hr>
                        <p class="d-flex total-price">
                            <span>Total</span>
                            <span>RM <%= GrandTotal() %></span>
                        </p>
                    </div>
                    <p class="text-center">
                        <asp:LinkButton ID="lbtMakePayment" runat="server" CssClass="btn btn-primary py-3 px-4">Make payment</asp:LinkButton>
                    </p>
                </div>

                <asp:Panel ID="pnlCoupon" runat="server" CssClass="col col-md-6 mt-5 cart-wrap ftco-animate">
                    <div class="cart-total mb-3">
                        <h3>Coupon</h3>
                        <p class="d-flex">
                            <asp:TextBox ID="tbxCoupon" runat="server" ClientIDMode="Static" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                            <asp:Label ID="lblCoupon" runat="server" Text="This coupon is currently not available" ForeColor="Red" Visible="false"></asp:Label>
                        </p>

                    </div>
                    <p class="text-center">
                        <asp:LinkButton ID="lbtCoupon" runat="server" CssClass="btn btn-primary py-3 px-4">Redeem coupon</asp:LinkButton></p>
                </asp:Panel>

                <asp:Panel ID="pnlAfterRedeem" runat="server" CssClass="col col-md-6 mt-5 cart-wrap ftco-animate" Visible="false">
                    <h1>Thanks for redeeming coupon!</h1>
                </asp:Panel>

            </asp:Panel>
        </div>
    </section>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">
    <script>
        $(document).ready(function () {

            $("#gvCarts").find("thead").addClass("thead-primary")

            $("#tbxCoupon").attr("placeholder", "Code")

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
