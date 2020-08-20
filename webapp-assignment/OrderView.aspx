<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="OrderView.aspx.vb" Inherits="webapp_assignment.OrderView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section contact-section bg-light">
        <div class="container">
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <asp:FormView ID="fvOrder" runat="server" ItemType="webapp_assignment.Order"
                        SelectMethod="fvOrder_GetItem" UpdateMethod="fvOrder_UpdateItem">
                        <ItemTemplate>

                            <% If Session("userType").ToString() = "owner" %>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnCommand="btnEdit_Command" />
                            <% End If %>
                            <table class="table table-bordered">
                                <tr>
                                    <td>ID</td>
                                    <td colspan="3"><%# Item.id %></td>
                                </tr>

                                <tr>
                                    <td>Order date</td>
                                    <td><%# Item._date %></td>
                                    <td>Total price</td>
                                    <td><%# Item.total %></td>
                                </tr>

                                <tr>
                                    <td>Order status</td>
                                    <td><%# Item.status %></td>
                                    <td>Applied coupon</td>
                                    <td><%# GetCouponCode(Item.grantedCoupon) %></td>
                                </tr>

                                <tr>
                                    <td>Shipping address</td>
                                    <td colspan="3"><%# Item.shippingAddress %></td>
                                </tr>

                                <% If Session("userType").ToString() = "owner" %>
                                <tr>
                                    <td>Member</td>
                                    <td><%# Item.Member1.User.name %> <a href='<%# String.Format("ViewMember.aspx?id={0}", Item.member) %>'>[ View user ]</a></td>
                                    <td>IsShipped</td>
                                    <td>
                                        <asp:CheckBox runat="server" Checked='<%# Item.isShipped %>' />
                                    </td>
                                </tr>
                                <% End If %>
                            </table>

                            <asp:GridView ID="gvProducts" runat="server" CssClass="table table-hover table-sm"
                                ItemType="webapp_assignment.Product_Order" AutoGenerateColumns="false" ClientIDMode="Static"
                                ShowHeaderWhenEmpty="true" BorderWidth="0" GridLines="None" DataSource='<%# Item.Product_Order.ToList() %>'>
                                <Columns>

                                    <asp:TemplateField HeaderText="" ItemStyle-CssClass="image-prod">
                                        <ItemTemplate>
                                            <div class="img" style='<%# String.format("background-image: url({0});", Item.Product1.imageLoc.SubString(1)) %>'></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Product" ItemStyle-CssClass="product-name">
                                        <ItemTemplate>
                                            <h3><%# Item.Product1.name %></h3>
                                            <p><%# Item.Product1.description %></p>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Price" ItemStyle-CssClass="price">
                                        <ItemTemplate>
                                            RM <%# Item.Product1.price %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quantity" ItemStyle-CssClass="price">
                                        <ItemTemplate>
                                            <p><%# Item.quantity %></p>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total">
                                        <ItemTemplate>
                                            RM <%# Item.Product1.price * Item.quantity %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:Button ID="btnUpdate" ClientIDMode="Static" runat="server" Text="Update" OnCommand="btnUpdate_Command" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnCommand="btnCancel_Command" />
                            <table class="table table-bordered">
                                <tr>
                                    <td>ID</td>
                                    <td colspan="3"><%# Item.id %></td>
                                </tr>

                                <tr>
                                    <td>Order date</td>
                                    <td><%# Item._date %></td>
                                    <td>Total price</td>
                                    <td><%# Item.total %></td>
                                </tr>

                                <tr>
                                    <td>Order status</td>
                                    <td>
                                        <asp:DropDownList ID="ddlStatus" runat="server">
                                            <asp:ListItem Value="pending">Pending</asp:ListItem>
                                            <asp:ListItem Value="shipping">Shipping</asp:ListItem>
                                            <asp:ListItem Value="complete">Complete</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>Applied coupon</td>
                                    <td><%# GetCouponCode(Item.grantedCoupon) %></td>
                                </tr>

                                <tr>
                                    <td>Shipping address</td>
                                    <td colspan="3">
                                        <div class="form-group">
                                            <asp:TextBox ID="tbxShippingAddress" runat="server"
                                                CssClass="form-control" TextMode="MultiLine"
                                                Text='<%# Item.shippingAddress %>'></asp:TextBox>
                                        </div>

                                    </td>
                                </tr>

                                <tr>
                                    <td>Member</td>
                                    <td><%# Item.Member1.User.name %> <a href='<%# String.Format("ViewMember.aspx?id={0}", Item.member) %>'>[ View user ]</a></td>
                                    <td>IsShipped</td>
                                    <td>
                                        <asp:CheckBox ID="cbxIsShipped" runat="server" Checked='<%# Item.isShipped %>' /></td>
                                </tr>
                            </table>

                            <asp:GridView ID="gvProducts" runat="server" CssClass="table table-hover table-sm"
                                ItemType="webapp_assignment.Product_Order" AutoGenerateColumns="false" ClientIDMode="Static"
                                ShowHeaderWhenEmpty="true" BorderWidth="0" GridLines="None" DataSource='<%# Item.Product_Order.ToList() %>'>
                                <Columns>

                                    <asp:TemplateField HeaderText="" ItemStyle-CssClass="image-prod">
                                        <ItemTemplate>
                                            <div class="img" style='<%# String.format("background-image: url({0});", Item.Product1.imageLoc.SubString(1)) %>'></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Product" ItemStyle-CssClass="product-name">
                                        <ItemTemplate>
                                            <h3><%# Item.Product1.name %></h3>
                                            <p><%# Item.Product1.description %></p>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Price" ItemStyle-CssClass="price">
                                        <ItemTemplate>
                                            RM <%# Item.Product1.price %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quantity" ItemStyle-CssClass="price">
                                        <ItemTemplate>
                                            <p><%# Item.quantity %></p>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total">
                                        <ItemTemplate>
                                            RM <%# Item.Product1.price * Item.quantity %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </EditItemTemplate>
                    </asp:FormView>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">
    <script type="text/javascript">
        $("#btnUpdate").click(function (e) {
            alert("Order has been updated")
        })
    </script>
</asp:Content>
