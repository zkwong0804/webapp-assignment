Public Class CategoryPage
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Dim category As Category
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Integer = Request.QueryString.Get("id")
        category = dbCtx.Categories.Where(Function(f) f.id = id).SingleOrDefault()
        If IsNothing(category) Then
            Response.Redirect("CategoryNotFound2.aspx")
        End If
        Master.Heading = category.name
        Dim min As Decimal = Master.GetMinPrice
        Dim max As Decimal = Master.GetMaxPrice
        Dim products As List(Of Product) = dbCtx.Products.Where(Function(f) f.isAvailable And f.category = id And f.price >= min And f.price <= max).ToList()

        For Each p As Product In products
            Dim pt As ProductThumb = LoadControl("~/CustomControls/ProductThumb.ascx")
            pt.Product = p
            pnlProducts.Controls.Add(pt)
        Next
    End Sub
End Class