Public Class Product1
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Dim product As Product
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Integer = Request.QueryString.Get("id")
        product = dbCtx.Products.Where(Function(f) f.id = id).SingleOrDefault()
        If IsNothing(product) Then
            Response.Redirect("ProductNotFound2.aspx")
        End If
    End Sub

    Public Property SelectedProduct As Product
        Get
            Return Me.product
        End Get
        Set(value As Product)
            Me.product = value
        End Set
    End Property

    Public Sub lbtAddCart_Click() Handles lbtAddCart.Click
        If Page.IsValid Then
            Master.AddToCart(SelectedProduct, Integer.Parse(tbxQuantity.Text))
            Response.Redirect("ViewAll.aspx")
        End If
    End Sub

    Public Sub lbtBuyNow_Click() Handles lbtBuyNow.Click
        If Page.IsValid Then
            Master.AddToCart(SelectedProduct, Integer.Parse(tbxQuantity.Text))
            Response.Redirect("Checkout.aspx")
        End If
    End Sub

    Protected Sub cvQuantity_ServerValidate(source As Object, args As ServerValidateEventArgs)
        Try
            Dim q As Integer = Integer.Parse(args.Value)
            If q < 0 Then
                args.IsValid = False
            End If
        Catch ex As FormatException
            args.IsValid = False
        End Try
    End Sub
End Class