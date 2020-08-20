Public Class OrderNotFound
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub OrderNotFound_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If IsNothing(Session("userType")) Then
            Response.Redirect("AccessDenied.aspx")
        Else
            If Session("userType").ToString() = "owner" Then
                Page.MasterPageFile = "~/Owner.Master"
            End If
        End If
    End Sub
End Class