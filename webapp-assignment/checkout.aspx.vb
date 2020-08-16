Public Class Checkout1
    Inherits System.Web.UI.Page
    Private _cartTotal As Decimal
    Private _coupon As Coupon
    Private _shippingFee As Decimal
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.ShippingFee = 12
        End If

        If Not IsNothing(Session("cart")) Then
            gvCarts.DataSource = Master.CartList
            gvCarts.DataBind()
            gvCarts.HeaderRow.TableSection = TableRowSection.TableHeader
            gvCarts.UseAccessibleHeader = True
        End If

        UpdatePage()
    End Sub

    Protected Sub tbxCoupon_TextChanged() Handles tbxCoupon.TextChanged
        RedeemCoupon(tbxCoupon.Text)
    End Sub

    Protected Sub lbtCoupon_Click() Handles lbtCoupon.Click
        RedeemCoupon(tbxCoupon.Text)
    End Sub

    Protected Sub lbtMakePpayment_Click() Handles lbtMakePayment.Click
        Dim order As New Order()
        Dim member As Member = CType(Session("member"), Member)
        order.Member1 = member
        order.Coupon = Me.GrantedCoupon
        order._date = Date.Today
        order.shippingAddress = member.address
        order.isShipped = False
        order.status = "pending"
        order.total = Me.GrandTotal()
        For Each c As Cart In Master.CartList
            Dim po As New Product_Order()
            po.Product1 = c.Product
            po.price = c.Product.price
            po.quantity = c.OrderAmt
            order.Product_Order.Add(po)
        Next
        Session("order") = order
        Response.Redirect("PaymentGateway.aspx")
    End Sub

    Private Sub RedeemCoupon(ByVal code As String)
        Dim coupon As Coupon = dbCtx.Coupons.Where(Function(f) f.name = code AndAlso f.available).SingleOrDefault()
        If Not IsNothing(coupon) Then
            lblCoupon.Visible = False
            Me.GrantedCoupon = coupon
            If coupon.isFreeShipping Then
                Me.ShippingFee = 0
            End If
            pnlCoupon.Visible = False
            pnlAfterRedeem.Visible = True
        Else
            lblCoupon.Visible = True
        End If
    End Sub

    Protected Sub RemoveCartItem(sender As Object, e As CommandEventArgs)
        Master.RemoveCartItem(Integer.Parse(e.CommandArgument.ToString()))
        Debug.WriteLine($"Cart list count: {Master.CartList.Count}")
        UpdatePage()
    End Sub


    Protected Sub UpdatePage()
        If Not IsNothing(Session("cart")) AndAlso Master.CartList.Count > 0 Then
            pnlMsg.Visible = False
            gvCarts.Visible = True
            pnlTotal.Visible = True
        Else
            pnlMsg.Visible = True
            gvCarts.Visible = False
            pnlTotal.Visible = False
        End If

        Total = Master.CartTotal()
        gvCarts.DataBind()
    End Sub

    Public Property Total As Decimal
        Get
            Return Me._cartTotal
        End Get
        Set(value As Decimal)
            Me._cartTotal = value
        End Set
    End Property

    Public Function DiscountAmt() As Decimal
        Dim disc As Decimal = If(IsNothing(Me.GrantedCoupon), 0, Me.GrantedCoupon.discountRate)
        Return Math.Round(Decimal.ToDouble(Me.Total * disc / 100), 2, MidpointRounding.AwayFromZero)
    End Function

    Public Function GrandTotal() As Decimal
        Return (Me.Total - DiscountAmt() + Me.ShippingFee)
    End Function

    Public Property GrantedCoupon As Coupon
        Get
            Return Me._coupon
        End Get
        Set(value As Coupon)
            Me._coupon = value
        End Set
    End Property

    Public Property ShippingFee As Decimal
        Get
            Return Me._shippingFee
        End Get
        Set(value As Decimal)
            Me._shippingFee = value
        End Set
    End Property
End Class