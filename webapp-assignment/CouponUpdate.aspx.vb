Public Class CouponUpdate
    Inherits System.Web.UI.Page
    Shared dbCtx As AssignmentDbContext
    Shared newCoupon As Coupon
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            dbCtx = New AssignmentDbContext()
            Dim id As Integer = Request.QueryString.Get("id")
            newCoupon = dbCtx.Coupons.Where(Function(f) f.id = id).SingleOrDefault()

            If IsNothing(newCoupon) Then
                Response.Redirect("CouponNotFound.aspx")
            Else
                Master.SetCoupon(newCoupon)
            End If
        End If
    End Sub

    Protected Sub btnUpdate_Click() Handles btnUpdate.Click
        If Page.IsValid Then

            newCoupon.available = Master.Available
            newCoupon.description = Master.Description
            newCoupon.discountRate = Master.DiscountRate
            newCoupon.isFreeShipping = Master.FreeShipping
            newCoupon.name = Master.Name

            dbCtx.SaveChanges()
            Response.Redirect("OwnerPromotionCoupon.aspx")
        End If

    End Sub

End Class