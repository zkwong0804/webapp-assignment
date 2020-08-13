Public Class CouponDelete
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Integer = Request.QueryString.Get("id")
        Dim coupon As Coupon = dbCtx.Coupons.Find(id)
        If IsNothing(coupon) Then
            Response.Redirect("CouponNotFound.aspx")
        Else
            dbCtx.Coupons.Remove(coupon)
            Try
                dbCtx.SaveChanges()
                Response.Redirect("OwnerPromotionCoupon.aspx")
            Catch ex As Entity.Infrastructure.DbUpdateException
                Response.Redirect("DeleteFail.aspx?id=" & coupon.id & "&name=" & coupon.name & "&object=coupon")
            End Try
        End If
    End Sub

End Class