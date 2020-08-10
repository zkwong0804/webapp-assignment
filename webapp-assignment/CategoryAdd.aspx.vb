Public Class CategoryAdd
    Inherits System.Web.UI.Page
    Shared dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim categories = dbCtx.Categories.ToList()
        If Not IsNothing(categories) And categories.Count > 0 Then
            For Each cat As Category In categories
                Dim li As New ListItem()
                li.Text = cat.name
                li.Value = cat.id
                ddlCategory.Items.Add(li)
            Next
        End If
    End Sub

    Protected Sub btnAdd_Click() Handles btnAdd.Click
        If Page.IsValid Then
            Dim newCat As New Category()
            newCat.name = tbxName.Text
            newCat.isAvailable = cbxAvailable.Checked
            newCat.category1 = CInt(ddlCategory.SelectedValue)

            dbCtx.Categories.Add(newCat)
            dbCtx.SaveChanges()
            Response.Redirect("OwnerCategory.aspx")
        End If
    End Sub

End Class