Public Class CategoryDelete
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim selectedID As Int16 = CInt(Request.QueryString.Get("id"))
        Dim category As Category = dbCtx.Categories.Where(Function(f) f.id = selectedID).SingleOrDefault()
        If Not IsNothing(category) Then
            dbCtx.Categories.Remove(category)
            Try
                dbCtx.SaveChanges()
                Response.Redirect("OwnerCategory.aspx")
            Catch ex As Entity.Infrastructure.DbUpdateException
                lblMessage.Text = ex.Message
                Response.Redirect("DeleteFail.aspx?id=" & category.id & "&name=" & category.name & "&object=category")
            End Try

        Else
            Response.Redirect("CategoryNotFound.aspx")
        End If
    End Sub

End Class