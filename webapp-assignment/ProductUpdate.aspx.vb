Public Class ProductUpdate
    Inherits System.Web.UI.Page
    Shared dbCtx As New AssignmentDbContext()
    Shared product As Product
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim id As Integer = Request.QueryString.Get("id")
            product = Queryable.Where(dbCtx.Products, Function(f) f.id = id).SingleOrDefault()
            If IsNothing(product) Then
                Response.Redirect("ProductNotFound.aspx")
            Else
                Master.Name = product.name
                Master.Price = product.price
                Master.Amt = product.amt.ToString
                Master.Desc = product.description
                Master.Category = product.category
                Master.SetImage(product.imageLoc)
            End If
        End If
    End Sub

    Protected Sub btnUpdate_Click() Handles btnUpdate.Click

        If Page.IsValid Then
            product.name = Master.Name
            product.price = Master.Price
            product.amt = Master.Amt
            product.description = Master.Desc
            product.category = Master.Category

            If Master.IsHasImage Then
                Master.SaveImage()
                product.imageLoc = Master.GetUploadImageLoc()
            End If

            dbCtx.SaveChanges()
            Response.Redirect("OwnerProduct.aspx")
        End If
    End Sub
End Class