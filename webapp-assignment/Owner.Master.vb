Public Class Admin
    Inherits System.Web.UI.MasterPage

    Dim dbCtx As New AssignmentDbContext()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("userType")) Or Session("userType") <> "owner" Then
            Response.Redirect("AccessDenied.aspx")
        End If
    End Sub

    Protected Sub lbtLogout_Click() Handles lbtLogout.Click
        Session.Remove("userType")
        Session.Remove("member")
        Response.Redirect("Default.aspx")
    End Sub

    Private Sub Admin_Init(sender As Object, e As EventArgs) Handles Me.Init
        If IsNothing(Session("member")) Then
            Session("member") = dbCtx.Owners.Where(Function(a) a.User.email = "tommy04081996@1utar.my").SingleOrDefault()
            Session("userType") = "owner"
        End If
    End Sub
End Class