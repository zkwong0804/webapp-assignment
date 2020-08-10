Public Class ProductAdd
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnAdd_Click() Handles btnAdd.Click
        If Page.IsValid Then
            If Master.IsHasImage Then
                Master.ImageMessage = ""
                Dim newProd As New Product()
                newProd.name = Master.Name
                newProd.isAvailable = Master.Available
                newProd.category = Master.Category
                newProd.price = Master.Price
                newProd.amt = Master.Amt
                newProd.desc = Master.Desc

                Master.SaveImage()
                newProd.imageLoc = Master.GetUploadImageLoc()
                dbCtx.Products.Add(newProd)
                dbCtx.SaveChanges()
                Response.Redirect("OwnerProduct.aspx")
            Else
                Master.ImageMessage = "This field is required!"
            End If
        End If
    End Sub
End Class