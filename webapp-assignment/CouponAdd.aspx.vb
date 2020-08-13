Public Class CouponAdd
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnAdd.Attributes.Add("Data-toggle", "modal")
        btnAdd.Attributes.Add("data-target", "#myModal")
    End Sub

    Protected Sub btnSend_Click() Handles btnSend.Click
        If Page.IsValid Then
            Dim coupon As Coupon = Master.GetCoupon()
            Dim allMembers As List(Of Member) = dbCtx.Members.ToList()
            Dim email As New Email()
            Dim subject As String = "New Coupon!!"
            Dim body As String = "Coupon: " & coupon.name
            body &= "<br />" & coupon.description
            email.SendMultiple(allMembers, subject, body)
            proceed()
        End If
    End Sub

    Protected Sub btnProceed_Click() Handles btnProceed.Click
        If Page.IsValid Then
            proceed()
        End If
    End Sub

    Private Sub proceed()
        dbCtx.Coupons.Add(Master.GetCoupon())
        dbCtx.SaveChanges()
        Response.Redirect("OwnerPromotionCoupon.aspx")
    End Sub

End Class