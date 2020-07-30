Public Class LoginRegister
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click() Handles btnLogin.Click
    End Sub

    Protected Sub btnRegister_Click() Handles btnRegister.Click
        Session("rvEmail") = tbxRegisterMail.Text
        Session("rvPass") = tbxRegisterPass1.Text
        Response.Redirect("RegisterValidation.aspx")
    End Sub

End Class