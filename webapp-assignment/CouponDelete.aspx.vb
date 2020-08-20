Public Class CouponDelete
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Private _c As Coupon
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Integer = Request.QueryString.Get("id")
        Me.SelectedCoupon = dbCtx.Coupons.Find(id)
    End Sub

    Public Property SelectedCoupon As Coupon
        Get
            Return Me._c
        End Get
        Set(value As Coupon)
            Me._c = value
        End Set
    End Property

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs)
        If IsNothing(Me.SelectedCoupon) Then
            Response.Redirect("CouponNotFound.aspx")
        Else
            dbCtx.Coupons.Remove(Me.SelectedCoupon)
            Try
                dbCtx.SaveChanges()
                Response.Redirect("OwnerPromotionCoupon.aspx")
            Catch ex As Entity.Infrastructure.DbUpdateException
                Response.Redirect("DeleteFail.aspx?id=" & Me.SelectedCoupon.id & "&name=" & Me.SelectedCoupon.name & "&object=coupon")
            End Try
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)

        Response.Redirect("OwnerPromotionCoupon.aspx")
    End Sub
End Class