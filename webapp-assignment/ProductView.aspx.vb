Public Class ProductView
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim id As Integer = Integer.Parse(Request.QueryString.Get("id"))
            Dim product As Product = dbCtx.Products.Find(id)
            If Not IsNothing(product) Then
                Master.Name = product.name
                Master.Price = product.price
                Master.Amt = product.amt
                Master.Desc = product.description
                Master.Available = product.isAvailable
                Master.SetImage(product.imageLoc)
                Master.ImageUploadVisibilityToggle()
            Else
                Response.Redirect("ProductNotFound.aspx")
            End If
        Catch ex As FormatException
            Response.Redirect("ProductNotFound.aspx")
        End Try
    End Sub

End Class