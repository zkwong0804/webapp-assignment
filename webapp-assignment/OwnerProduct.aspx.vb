Imports Microsoft.Office.Interop

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

    Protected Sub btnBulk_Click(sender As Object, e As EventArgs)

        If Page.IsValid Then
            Dim fileloc As String = Server.MapPath(fupBulk.PostedFile.FileName)
            fupBulk.SaveAs(fileloc)
            Dim xlApp As New Excel.Application
            Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Open(fileloc)
            Dim xlWorkSheet As Excel.Worksheet = xlWorkBook.Worksheets("sheet1")

            Dim i As Integer = 2
            While Not IsNothing(xlWorkSheet.Cells(i, 1).value)
                Dim newProd As New Product()

                newProd.name = xlWorkSheet.Cells(i, 1).value.ToString()
                newProd.price = Decimal.Parse(xlWorkSheet.Cells(i, 2).value)
                newProd.amt = Integer.Parse(xlWorkSheet.Cells(i, 3).value)
                newProd.description = xlWorkSheet.Cells(i, 4).value.ToString()
                newProd.isAvailable = True
                newProd.imageLoc = "~/images/Products/Default.png"

                Dim catName As String = xlWorkSheet.Cells(i, 5).value.ToString()
                Dim checkCat As Category = dbCtx.Categories.Where(Function(f) f.name = catName).SingleOrDefault()
                If Not IsNothing(checkCat) Then
                    newProd.category = checkCat.id
                Else
                    Dim newCat As New Category()
                    newCat.name = catName
                    newCat.category1 = 1
                    newCat.isAvailable = True
                    dbCtx.Categories.Add(newCat)
                    dbCtx.SaveChanges()
                    newProd.category = newCat.id
                End If
                dbCtx.Products.Add(newProd)
                i += 1
            End While

            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

            dbCtx.SaveChanges()
            Response.Redirect("OwnerProduct.aspx")
        End If
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Class