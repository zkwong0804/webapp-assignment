Public Class OrderCheck
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub OrderCheck_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If IsNothing(Session("userType")) Then
            Response.Redirect("AccessDenied.aspx")
        End If

        If Session("userType") = "owner" Then
            Page.MasterPageFile = "~/Owner.Master"
        End If
    End Sub
End Class