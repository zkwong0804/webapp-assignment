Public Class OwnerProduct
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim products = dbCtx.Products.ToList()
        If IsNothing(products) Or products.Count <= 0 Then
            lblProductMsg.Visible = True
        Else
            For Each prod As Product In products
                tabCategory.Rows.Add(GenerateTableRow(prod))
            Next
        End If
    End Sub
    Private Function GenerateTableRow(ByVal prod As Product) As TableRow

        Dim row As New TableRow()
        Dim idCell As New TableCell()
        Dim imageCell As New TableCell()
        Dim nameCell As New TableCell()
        Dim priceCell As New TableCell()
        Dim amtCell As New TableCell()
        Dim descCell As New TableCell()
        Dim editCell As New TableCell()
        Dim deleteCell As New TableCell()

        idCell.Text = prod.id
        nameCell.Text = prod.name
        Dim imgControl As New Image()
        imgControl.Width = Unit.Pixel(50)
        imgControl.Height = Unit.Pixel(50)
        imgControl.ImageUrl = prod.imageLoc
        imageCell.Controls.Add(imgControl)
        priceCell.Text = prod.price.ToString()
        amtCell.Text = prod.amt.ToString()
        descCell.Text = prod.description

        If Not prod.isAvailable Then
            idCell.ForeColor = Drawing.Color.Red
            nameCell.ForeColor = Drawing.Color.Red
        End If

        Dim lnkEdit As New HyperLink()
        lnkEdit.Text = "[ Edit ]"
        lnkEdit.NavigateUrl = "ProductUpdate?id=" & prod.id
        editCell.Controls.Add(lnkEdit)

        Dim lnkDel As New HyperLink()
        lnkDel.Text = "[ Delete ]"
        lnkDel.NavigateUrl = "ProductDelete?id=" & prod.id
        deleteCell.Controls.Add(lnkDel)

        row.Cells.Add(idCell)
        row.Cells.Add(imageCell)
        row.Cells.Add(nameCell)
        row.Cells.Add(priceCell)
        row.Cells.Add(amtCell)
        row.Cells.Add(descCell)
        row.Cells.Add(editCell)
        row.Cells.Add(deleteCell)

        Return row
    End Function

    Protected Sub btnAdd_Click() Handles btnAdd.Click
        Response.Redirect("ProductAdd.aspx")
    End Sub

End Class