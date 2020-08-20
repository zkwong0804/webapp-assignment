Public Class PaymentGateway
    Inherits System.Web.UI.Page
    Private _orderDict As Dictionary(Of String, Object)
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("order")) Then
            Response.Redirect("AccessDenied.aspx")
        End If

        Me.OrderDict = CType(Session("order"), Dictionary(Of String, Object))
    End Sub

    Public Property OrderDict As Dictionary(Of String, Object)
        Get
            Return Me._orderDict
        End Get
        Set(value As Dictionary(Of String, Object))
            Me._orderDict = value
        End Set
    End Property

    Protected Sub lbtCancelOrder_Click() Handles lbtCancelOrder.Click
        clearSessions()
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub lbtMakePayment_Click() Handles lbtMakePayment.Click
        Dim order As Order = CType(Me.OrderDict.Item("order"), Order)


        dbCtx.Orders.Add(order)
        dbCtx.SaveChanges()
        For Each c As Cart In Master.CartList
            Dim po As New Product_Order()
            po.product = c.Product.id
            po.price = c.Product.price
            po.quantity = c.OrderAmt
            po.orderid = order.id
            dbCtx.Product_Order.Add(po)
        Next

        dbCtx.SaveChanges()
        clearSessions()
        Response.Redirect("PurchaseSuccess.aspx")
    End Sub

    Private Sub clearSessions()
        Session.Remove("cart")
        Session.Remove("shipping")
        Session.Remove("coupon")
        Session.Remove("order")
    End Sub

End Class