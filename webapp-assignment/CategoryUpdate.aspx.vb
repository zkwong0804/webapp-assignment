Public Class CategoryUpdate
    Inherits System.Web.UI.Page
    Shared dbCtx As New AssignmentDbContext()
    Shared category As Category

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim selectedID As Int16 = CInt(Request.QueryString.Get("id"))
            category = dbCtx.Categories.Where(Function(cat) cat.id = selectedID).SingleOrDefault()
            Dim categories As List(Of Category) = dbCtx.Categories.ToList()

            For Each ec As Category In categories
                Dim listItem As New ListItem()
                listItem.Value = ec.id
                listItem.Text = ec.name
                ddlCategory.Items.Add(listItem)
            Next

            If IsNothing(category) Then
                Response.Redirect("CategoryNotFound.aspx")
            Else
                tbxName.Text = category.name
                ddlCategory.SelectedValue = category.category1
                cbxAvailable.Checked = category.isAvailable
            End If
        End If
    End Sub

    Protected Sub btnUpdate_Click() Handles btnUpdate.Click
        category.name = tbxName.Text
        category.category1 = ddlCategory.SelectedValue
        category.isAvailable = cbxAvailable.Checked

        dbCtx.SaveChanges()
        Response.Redirect("OwnerCategory.aspx")
    End Sub

End Class