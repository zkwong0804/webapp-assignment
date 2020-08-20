Public Class ProductDelete
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Private _prod As Product
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetProduct()
    End Sub

    Private Sub GetProduct()
        Dim selectedID As Int16 = CInt(Request.QueryString.Get("id"))
        Me.SelectedProduct = dbCtx.Products.Where(Function(f) f.id = selectedID).SingleOrDefault()
    End Sub

    Public Property SelectedProduct As Product
        Get
            Return Me._prod
        End Get
        Set(value As Product)
            Me._prod = value
        End Set
    End Property

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs)
        If Not IsNothing(Me.SelectedProduct) Then
            dbCtx.Products.Remove(Me.SelectedProduct)
            Try
                dbCtx.SaveChanges()
                Response.Redirect("OwnerProduct.aspx")
            Catch ex As Entity.Infrastructure.DbUpdateException
                Response.Redirect("DeleteFail.aspx?id=" & Me.SelectedProduct.id & "&name=" & Me.SelectedProduct.name & "&object=product")
            End Try

        Else
            Response.Redirect("ProductNotFound.aspx")
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("OwnerProduct.aspx")
    End Sub
End Class