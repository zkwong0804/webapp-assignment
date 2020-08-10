Public Class CategoryAdd
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAdd_Click() Handles btnAdd.Click
        If Page.IsValid Then
            Dim newCat As New Category()
            newCat.name = Master.Name
            newCat.isAvailable = Master.Available
            newCat.category1 = Master.Category

            dbCtx.Categories.Add(newCat)
            dbCtx.SaveChanges()
            Response.Redirect("OwnerCategory.aspx")
        End If
    End Sub

End Class