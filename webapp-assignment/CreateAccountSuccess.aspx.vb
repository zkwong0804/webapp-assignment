Public Class CreateAccountSuccess
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("rvEmail")) Then
            Response.Redirect("AccessDenied.aspx")
        End If

        Session.Remove("rvEmail")
        Session.Remove("rvPass")
    End Sub

End Class