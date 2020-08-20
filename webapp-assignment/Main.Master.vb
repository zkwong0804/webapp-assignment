Public Class Main
    Inherits System.Web.UI.MasterPage
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("member") = dbCtx.Owners.Where(Function(f) f.User.email = "tommy04081996@1utar.my").SingleOrDefault()
        'Session("userType") = "owner"
    End Sub

    Protected Sub lbtLogReg_Click() Handles lbtLogReg.Click
        Response.Redirect("LoginRegister.aspx")
    End Sub

    Protected Sub lbtAccount_Click() Handles lbtAccount.Click
        Response.Redirect("AccountUpdate.aspx")
    End Sub

    Protected Sub lbtLogout_Click() Handles lbtLogout.Click
        Session.Remove("member")
        Session.Remove("userType")
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub lbtCart_Click() Handles lbtCart.Click
        Response.Redirect("Checkout.aspx")
    End Sub

    Public Sub CheckCartSession()
        If IsNothing(Session("cart")) Then
            Session("cart") = New List(Of Cart)
        End If
    End Sub

    Public Sub AddToCart(ByVal prod As Product, ByVal orderAmt As Integer)
        If IsNothing(Session("userType")) Then
            Response.Redirect("LoginRegister.aspx")
        End If

        CheckCartSession()
        CType(Session("cart"), List(Of Cart)).Add(New Cart(prod, orderAmt))

    End Sub

    Public Sub RemoveCartItem(ByVal id As Integer)
        Dim cartList = Me.CartList
        Dim cart = cartList.Find(Function(f) f.Product.id = id)
        cartList.Remove(cart)
        Me.CartList = cartList
    End Sub

    Public Property CartList As List(Of Cart)
        Get
            Return CType(Session("cart"), List(Of Cart))
        End Get
        Set(value As List(Of Cart))
            Session("cart") = value
        End Set
    End Property

    Public Function CartTotal() As Decimal
        Dim total As Decimal = 0
        If Not IsNothing(Session("cart")) Then
            For Each c As Cart In Me.CartList
                total += c.Product.price * c.OrderAmt
            Next

        End If
        Return total
    End Function


End Class