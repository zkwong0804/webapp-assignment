Public Class OwnerCategory
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim categories = dbCtx.Categories.Where(Function(cat) cat.id <> 1).ToList()
        If IsNothing(categories) Or categories.Count <= 0 Then
            lblCategoryMsg.Visible = True
        Else
            For Each cat As Category In categories
                tabCategory.Rows.Add(GenerateTableRow(cat))
            Next
        End If
    End Sub
    Private Function GenerateTableRow(ByVal cat As Category) As TableRow

        Dim row As New TableRow()
        Dim idCell As New TableCell()
        Dim nameCell As New TableCell()
        Dim editCell As New TableCell()
        Dim deleteCell As New TableCell()

        idCell.Text = cat.id
        nameCell.Text = cat.name
        If Not cat.isAvailable Then
            idCell.ForeColor = Drawing.Color.Red
            nameCell.ForeColor = Drawing.Color.Red
        End If

        Dim lnkEdit As New HyperLink()
        lnkEdit.Text = "[ Edit ]"
        lnkEdit.NavigateUrl = "CategoryUpdate?id=" & cat.id
        editCell.Controls.Add(lnkEdit)

        Dim lnkDel As New HyperLink()
        lnkDel.Text = "[ Delete ]"
        lnkDel.NavigateUrl = "CategoryDelete?id=" & cat.id
        deleteCell.Controls.Add(lnkDel)

        row.Cells.Add(idCell)
        row.Cells.Add(nameCell)
        row.Cells.Add(editCell)
        row.Cells.Add(deleteCell)

        Return row
    End Function

    Protected Sub btnAdd_Click() Handles btnAdd.Click
        Response.Redirect("CategoryAdd.aspx")
    End Sub

End Class