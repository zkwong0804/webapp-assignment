Public Class OwnerPromotionCoupon
    Inherits System.Web.UI.Page

    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gvCoupons.DataBind()
    End Sub

    ' The return type can be changed to IEnumerable, however to support
    ' paging and sorting, the following parameters must be added:
    '     ByVal maximumRows as Integer
    '     ByVal startRowIndex as Integer
    '     ByRef totalRowCount as Integer
    '     ByVal sortByExpression as String
    Public Function gvCoupons_GetData() As IQueryable(Of webapp_assignment.Coupon)
        Dim coupons As IQueryable(Of Coupon) = dbCtx.Coupons.ToList().AsQueryable()
        If IsNothing(coupons) Or coupons.Count <= 0 Then
            lblMsg.Text = "No coupons found in database!"
        Else
            lblMsg.Text = ""
        End If

        Return coupons
    End Function

    Protected Sub btnAdd_Click() Handles btnAdd.Click
        Response.Redirect("CouponAdd.aspx")
    End Sub

End Class