Public Class ProductDelete
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim selectedID As Int16 = CInt(Request.QueryString.Get("id"))
        Dim prod As Product = dbCtx.Products.Where(Function(f) f.id = selectedID).SingleOrDefault()
        If Not IsNothing(prod) Then
            dbCtx.Products.Remove(prod)
            Try
                dbCtx.SaveChanges()
                Response.Redirect("OwnerProduct.aspx")
            Catch ex As Entity.Infrastructure.DbUpdateException
                Response.Redirect("DeleteFail.aspx?id=" & prod.id & "&name=" & prod.name & "&object=product")
            End Try

        Else
            Response.Redirect("ProductNotFound.aspx")
        End If
    End Sub

End Class