Public Class OwnerLogin
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click() Handles btnLogin.Click
        Dim owner As Owner = dbCtx.Owners.Where(Function(e) e.User.email = tbxLoginMail.Text).SingleOrDefault()
        If Not IsNothing(owner) Then
            If owner.User.password = tbxLoginPass.Text Then
                Session("member") = owner
                Session("userType") = "owner"
                Response.Redirect("OwnerPortal.aspx")
            Else
                lblLoginMessage.Text = "Wrong password"
            End If
        Else
            lblLoginMessage.Text = "Email not found"
        End If
    End Sub

End Class