Public Class LoginRegister
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click() Handles btnLogin.Click
        Dim user As Member = dbCtx.Members.Where(Function(e) e.User.email = tbxLoginMail.Text).SingleOrDefault()
        If IsNothing(user) Then
            lblLoginMessage.Text = "Email does not exist in our database!"
        Else
            If tbxLoginPass.Text = user.User.password Then
                Session("member") = user
                Session("userType") = "member"
                Response.Redirect("Default.aspx")
            Else
                lblLoginMessage.Text = "Wrong password!"
            End If
        End If
    End Sub

    Protected Sub btnRegister_Click() Handles btnRegister.Click
        Dim user As User = dbCtx.Users.Where(Function(e) e.email = tbxRegisterMail.Text).SingleOrDefault()
        If IsNothing(user) Then
            Session("rvEmail") = tbxRegisterMail.Text
            Session("rvPass") = tbxRegisterPass1.Text
            Response.Redirect("RegisterValidation.aspx")
        Else
            lblExistingMail.Visible = True
        End If
    End Sub

End Class