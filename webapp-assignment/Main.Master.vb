Public Class Main
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("member")) Then
            'User already login
            lbtLogReg.Visible = False
            lbtAccount.Visible = True
            lbtLogout.Visible = True
            lbtCart.Visible = True
        Else
            lbtLogReg.Visible = True
            lbtAccount.Visible = False
            lbtAccount.Visible = False
            lbtCart.Visible = False
        End If
    End Sub

    Protected Sub lbtLogReg_Click() Handles lbtLogReg.Click
        Response.Redirect("LoginRegister.aspx")
    End Sub

    Protected Sub lbtAccount_Click() Handles lbtAccount.Click
        Response.Redirect("AccountUpdate.aspx")
    End Sub

    Protected Sub lbtLogout_Click() Handles lbtLogout.Click
        Session.Remove("member")
        Session.Remove("userType")
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub lbtCart_Click() Handles lbtCart.Click
        Response.Redirect("cart.aspx")
    End Sub

End Class