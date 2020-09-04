Imports NPOI.XSSF.UserModel
Imports NPOI.SS.UserModel

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
            Try
                Dim fileloc As String = Server.MapPath(String.Format("/Spreadsheet/{0}", fupBulk.PostedFile.FileName))
                fupBulk.SaveAs(fileloc)
                Dim workbook As New XSSFWorkbook(fileloc)
                Dim worksheet As XSSFSheet = workbook.GetSheetAt(0)
                Dim i As Integer = 1
                While Not IsNothing(worksheet.GetRow(i))
                    Dim newProd As New Product()
                    Dim cRow As IRow = worksheet.GetRow(i)
                    Dim cName As ICell = cRow.GetCell(0)
                    Dim cPrice As ICell = cRow.GetCell(1)
                    Dim cAmt As ICell = cRow.GetCell(2)
                    Dim cDescription As ICell = cRow.GetCell(3)
                    Dim cCat As ICell = cRow.GetCell(4)

                    newProd.name = cName.ToString()
                    newProd.price = Decimal.Parse(cPrice.ToString())
                    newProd.amt = Integer.Parse(cAmt.ToString())
                    newProd.description = cDescription.ToString()
                    newProd.isAvailable = True
                    newProd.imageLoc = "~/images/Products/Default.png"

                    Dim catName As String = cCat.ToString()
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

            Catch ex As Exception
                lblProductMsg.Visible = True
                lblProductMsg.Text = $"Failed to bulk import.[{ex.Message}]"
            End Try

            dbCtx.SaveChanges()
            Response.Redirect("OwnerProduct.aspx")
        End If
    End Sub
End Class