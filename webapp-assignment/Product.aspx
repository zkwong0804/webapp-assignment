<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="Product.aspx.vb" Inherits="webapp_assignment.Product1" %>

<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="ftco-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 mb-5 ftco-animate">
                    <a href='<%= SelectedProduct.imageLoc.Substring(1) %>' class="image-popup prod-img-bg">
                        <img src='<%= SelectedProduct.imageLoc.Substring(1) %>' class="img-fluid" alt="Colorlib Template"></a>
                </div>
                <div class="col-lg-6 product-details pl-md-5 ftco-animate">
                    <h3><%= SelectedProduct.name %></h3>
                    <p class="price"><span>RM <%= SelectedProduct.price %></span></p>
                    <p><%= SelectedProduct.description %></p>
                    <div class="row mt-4">
                        <div class="w-100"></div>
                        <div class="input-group col-md-6 d-flex mb-3">
                            <span class="input-group-btn mr-2">
                                <button type="button" class="quantity-left-minus btn" data-type="minus" data-field="">
                                    <i class="ion-ios-remove"></i>
                                </button>
                            </span>

                            <asp:TextBox ID="tbxQuantity" CssClass="quantity form-control input-number" Text="1" runat="server" ClientIDMode="Static"></asp:TextBox>
                            <span class="input-group-btn ml-2">
                                <button type="button" class="quantity-right-plus btn" data-type="plus" data-field="">
                                    <i class="ion-ios-add"></i>
                                </button>
                            </span>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="tbxQuantity" ErrorMessage="This field is required!" ForeColor="Red">

                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:CustomValidator ID="cvQuantity" runat="server"
                                ControlToValidate="tbxQuantity"
                                ErrorMessage="Invalid quantity"
                                ForeColor="Red" OnServerValidate="cvQuantity_ServerValidate"></asp:CustomValidator>
                        </div>
                        <div class="w-100"></div>
                        <div class="col-md-12">
                            <p style="color: #000;"><%= SelectedProduct.amt %> piece available</p>
                        </div>
                    </div>
                    <p>
                        <asp:LinkButton ID="lbtAddCart" runat="server" CssClass="btn btn-black py-3 px-5 mr-2" ClientIDMode="Static">Add to Cart</asp:LinkButton>
                        <asp:LinkButton ID="lbtBuyNow" runat="server" CssClass="btn btn-primary py-3 px-5" ClientIDMode="Static">Buy Now</asp:LinkButton> <br />
                        
                        <asp:Label ID="lblStockMsg" runat="server" ForeColor="Red" Text="Not enough stock" Visible="false"></asp:Label>
                    </p>
                </div>
            </div>




            <div class="row mt-5">
                <div class="col-md-12 nav-link-wrap">
                    <div class="nav nav-pills d-flex text-center" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                        <a class="nav-link ftco-animate active mr-lg-1" id="v-pills-1-tab" data-toggle="pill" href="#v-pills-1" role="tab" aria-controls="v-pills-1" aria-selected="true">Description</a>

                        <a class="nav-link ftco-animate" id="v-pills-3-tab" data-toggle="pill" href="#v-pills-3" role="tab" aria-controls="v-pills-3" aria-selected="false">Reviews</a>

                    </div>
                </div>
                <div class="col-md-12 tab-wrap">

                    <div class="tab-content bg-light" id="v-pills-tabContent">

                        <div class="tab-pane fade show active" id="v-pills-1" role="tabpanel" aria-labelledby="day-1-tab">
                            <div class="p-4">
                                <h3 class="mb-4"><%= SelectedProduct.name %></h3>
                                <p><%= SelectedProduct.description %></p>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="v-pills-3" role="tabpanel" aria-labelledby="v-pills-day-3-tab">
                            <div class="row p-4">
                                <div class="col-md-7">
                                    <h3 class="mb-4"><%= GetTotalReviews() %> Reviews</h3>
                                    <asp:ListView ID="lvPostedcomments" runat="server" ItemType="webapp_assignment.Comment" SelectMethod="lvPostedcomments_GetData">
                                        <ItemTemplate>
                                            <div class="review">
                                                <div class="user-img" style="background-image: url(images/userp.png)"></div>
                                                <div class="desc">
                                                    <h4>
                                                        <span class="text-left"><%# Item.Member.User.name %></span>
                                                        <span class="text-right"></span>
                                                    </h4>
                                                    <p class="star">
                                                        <span>has given this product a 
                                                                <%# Item.rate %> 
                                                                <i class="ion-ios-star"></i>
                                                        </span>
                                                    </p>
                                                    <p>
                                                        <img src='<%# Item.pictureLoc.Substring(1)  %>' width="300" height="500" />
                                                    </p>
                                                    <p>
                                                        <%# Item.comment1 %>
                                                    </p>
                                                </div>
                                            </div>

                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>

                                
                                <% If HasBoughtBefore() Then %>
                                <%--Give a review--%>
                                <div class="col-md-4">
                                    <div class="rating-wrap">
                                        <h3 class="mb-4">Give a Review</h3>
                                        <div class="form-group">
                                            <label for="tbxReview">Write your review here:</label>
                                            <asp:TextBox ID="tbxReview" runat="server"
                                                TextMode="MultiLine"
                                                ClientIDMode="Static" CssClass="form-control">
                                            </asp:TextBox>

                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbxReview"
                                                ValidationGroup="review" ErrorMessage="This field is requried!" ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                        </div>

                                        <label for="ddlRate">Rate: </label>
                                        <asp:DropDownList ID="ddlRate" runat="server" ClientIDMode="Static">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:FileUpload ID="fupReview" runat="server" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="fupReview"
                                            ErrorMessage="You must upload a photo of your received product!" ValidationGroup="review"
                                            ForeColor="Red"></asp:RequiredFieldValidator>

                                        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" ClientIDMode="Static"
                                            Text="Post review" ValidationGroup="review" />
                                    </div>
                                </div>
                                <% End If %>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">
    <script>
        $(document).ready(function () {

            var quantitiy = 0;

            $("#btnPost").click(function (e) {
                alert("Thanks for review and comment our product!")
            });

            $('.quantity-right-plus').click(function (e) {

                // Stop acting like a button
                e.preventDefault();
                // Get the field name
                var quantity = parseInt($('#tbxQuantity').val());

                // If is not undefined

                $('#tbxQuantity').val(quantity + 1);


                // Increment

            });

            $('.quantity-left-minus').click(function (e) {
                // Stop acting like a button
                e.preventDefault();
                // Get the field name
                var quantity = parseInt($('#tbxQuantity').val());

                // If is not undefined

                // Increment
                if (quantity > 0) {
                    $('#tbxQuantity').val(quantity - 1);
                }
            });

        });
    </script>
</asp:Content>
