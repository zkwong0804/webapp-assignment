Public Class ProductAdd
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnAdd.Attributes.Add("Data-toggle", "modal")
        btnAdd.Attributes.Add("data-target", "#myModal")
    End Sub


    Protected Sub btnSend_Click(sender As Object, e As EventArgs)
        Dim email As New Email()
        Dim members As List(Of Member) = dbCtx.Members.ToList()
        email.SendMultiple(members, "New product is here!", String.Format("Get your latest {0} now!", Master.Name))
        AddProduct()
    End Sub

    Protected Sub btnProceed_Click(sender As Object, e As EventArgs)
        AddProduct()
    End Sub

    Protected Sub AddProduct()
        If Page.IsValid Then
            If Master.IsHasImage Then
                Master.ImageMessage = ""
                Dim newProd As New Product()
                newProd.name = Master.Name
                newProd.isAvailable = Master.Available
                newProd.category = Master.Category
                newProd.price = Master.Price
                newProd.amt = Master.Amt
                newProd.description = Master.Desc

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