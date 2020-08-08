Public Class AccessDenied
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub AccessDenied_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Not IsNothing(Session("userType")) Then
            If Session("userType") = "owner" Then
                Page.MasterPageFile = "~/Owner.Master"
            Else
                Page.MasterPageFile = "~/Main.Master"
            End If
        End If
    End Sub
End Class