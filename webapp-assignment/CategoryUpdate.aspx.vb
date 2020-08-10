Public Class CategoryUpdate
    Inherits System.Web.UI.Page
    Shared dbCtx As AssignmentDbContext
    Shared category As Category
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim selectedId As Integer = Request.QueryString.Get("id")
            dbCtx = New AssignmentDbContext()
            category = dbCtx.Categories.Where(Function(f) f.id = selectedId).SingleOrDefault()

            If IsNothing(category) Then
                Response.Redirect("CategoryNotFound.aspx")
            Else
                Master.Name = category.name
                Master.Category = category.category1
                Master.Available = category.isAvailable
            End If
        End If
    End Sub

    Protected Sub btnUpdate_Click() Handles btnUpdate.Click
        category.name = Master.Name
        category.category1 = Master.Category
        category.isAvailable = Master.Available

        dbCtx.SaveChanges()
        Response.Redirect("OwnerCategory.aspx")
    End Sub

End Class