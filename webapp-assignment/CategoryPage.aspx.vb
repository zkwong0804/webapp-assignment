Public Class CategoryPage
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Dim category As Category
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Integer = Request.QueryString.Get("id")
        category = dbCtx.Categories.Where(Function(f) f.id = id).SingleOrDefault()
        If IsNothing(category) Then
            Response.Redirect("CategoryNotFound2.aspx")
        End If
        Master.Heading = category.name
        Master.SetCategories(category)
    End Sub
End Class