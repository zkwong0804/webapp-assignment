Public Class ViewAll
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cats As New List(Of Category)
        Dim products As List(Of Product) = dbCtx.Products.ToList()
        For Each prod As Product In products
            If Not cats.Contains(prod.Category1) Then
                cats.Add(prod.Category1)
            End If
        Next
        Master.SetCategories(cats)
        Master.Heading = "All Products"
        products = dbCtx.Products.Where(Function(f) f.isAvailable).ToList()

        For Each p As Product In products
            Dim pt As ProductThumb = LoadControl("~/CustomControls/ProductThumb.ascx")
            pt.Product = p
            pnlProducts.Controls.Add(pt)
        Next

    End Sub

    Private Sub ViewAll_Init(sender As Object, e As EventArgs) Handles Me.Init
    End Sub
End Class