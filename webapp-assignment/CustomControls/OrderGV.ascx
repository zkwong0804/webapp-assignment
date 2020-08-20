<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OrderGV.ascx.vb" Inherits="webapp_assignment.OrderGV" %>

<%If Session("userType").ToString() = "owner" %>
<asp:DropDownList ID="ddlMembers" runat="server" OnSelectedIndexChanged="ddlMembers_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
<%End If %>

<asp:GridView ID="gvOrder" runat="server" CssClass="table table-hover table-condensed"
    ItemType="webapp_assignment.Order" AutoGenerateColumns="false" ClientIDMode="Static"
    ShowHeaderWhenEmpty="true" BorderWidth="0" GridLines="None" SelectMethod="gvOrder_GetData">
    <Columns>

        <asp:BoundField DataField="id" HeaderText="ID" />
        <asp:BoundField DataField="_date" HeaderText="Order Date" />
        <asp:BoundField DataField="status" HeaderText="Status" />
        <asp:BoundField DataField="total" HeaderText="Total" />
        <asp:TemplateField HeaderText="Disc Amt">
            <ItemTemplate>
                <p>RM <%# DiscountAmt(Item.grantedCoupon, Item.total) %></p>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Grand total">
            <ItemTemplate>
                <p>RM <%# Item.total - DiscountAmt(Item.grantedCoupon, Item.total) %></p>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <a href='<%# String.Format("OrderView.aspx?id={0}", Item.id) %>'>[ View Order ] </a>
            </ItemTemplate>
        </asp:TemplateField>


    </Columns>
</asp:GridView>
