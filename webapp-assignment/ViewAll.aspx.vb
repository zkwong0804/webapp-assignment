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

        Dim min As Decimal = Master.GetMinPrice
        Dim max As Decimal = Master.GetMaxPrice
        Dim selection As List(Of Product) = dbCtx.Products.Where(Function(f) f.isAvailable And f.price >= min And f.price <= max).ToList()
        For Each p As Product In selection
            Dim pt As ProductThumb = LoadControl("~/CustomControls/ProductThumb.ascx")
            pt.Product = p
            pnlProducts.Controls.Add(pt)
        Next

    End Sub

    Private Sub ViewAll_Init(sender As Object, e As EventArgs) Handles Me.Init
    End Sub

    'Private Sub CheckPrice()
    '    Dim min As Integer = CInt(ddlMinPrice.SelectedValue)
    '    Dim max As Integer = CInt(ddlMaxPrice.SelectedValue)
    '    If min < max Then
    '        lblPriceInvalid.Visible = False
    '        MinPrice = min
    '        MaxPrice = max
    '    Else
    '        lblPriceInvalid.Visible = True
    '    End If

    'End Sub
End Class