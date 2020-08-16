<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Owner.Master" CodeBehind="OwnerPromotionCoupon.aspx.vb" Inherits="webapp_assignment.OwnerPromotionCoupon" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section contact-section bg-light">
        <div class="container">
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        <asp:GridView ID="gvCoupons" runat="server" ItemType="webapp_assignment.Coupon"
                            SelectMethod="gvCoupons_GetData"
                            CssClass="table table-hover table-condensed"
                            BorderWidth="0" GridLines="None" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server"
                                            Text="<%# Item.id %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server"
                                            Text="<%# Item.name %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Desc">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesc" runat="server"
                                            Text="<%# Item.description %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Free shipping">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFreeShipping" runat="server"
                                            Text="<%# Item.isFreeShipping.ToString()%>" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Discount %">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiscount" runat="server"
                                            Text="<%# Item.discountRate.ToString() %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Availability">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAvailable" runat="server"
                                            Text="<%# Item.available.ToString() %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlEdit" runat="server" 
                                            Text="[ Edit ]" 
                                            NavigateUrl='<%# String.Format("CouponUpdate.aspx?id={0}", Item.id)%>'>

                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlDelete" runat="server" 
                                            Text="[ Delete ]" 
                                            NavigateUrl='<%# String.Format("CouponDelete.aspx?id={0}", Item.id)%>'>

                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                        </asp:GridView>

                        <asp:Button ID="btnAdd" runat="server" Text="Add coupon" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">ipt>
</asp:Content>
