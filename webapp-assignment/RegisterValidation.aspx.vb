Imports System.Net.Mail
Imports System.Net
Imports System.ComponentModel

Public Class RegisterValidation
    Inherits System.Web.UI.Page

    Shared vCode As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("rvEmail")) And IsNothing(Session("rvPass")) Then
            Response.Redirect("AccessDenied.aspx")
        Else
            If Not Page.IsPostBack Then
                vCode = CStr(CInt((9999 * Rnd()) + 1000))
                sendVerificationMail(Session("rvEmail"), vCode)
            End If
        End If
    End Sub

    Protected Sub sendVerificationMail(ByVal regMail As String, ByVal vCode As String)
        Dim emailClient As New Email()
        Try
            emailClient.Send(regMail, "Account registration verification", vCode)
            lblMessage.Text = "A verification code has already been sent to your mailbox. Please get your code to validate your account!"
            pnlValidate.Visible = True
        Catch ex As Exception
            lblMessage.Text = ex.Message.ToString()
        End Try
    End Sub

    Private Sub btnValidate_Click() Handles btnValidate.Click
        lblMessage.Text = tbxValidate.Text
        If tbxValidate.Text.ToString() = vCode Then
            pnlValidate.Visible = False
            lblMessage.Text = "Email verified! Please click the following link to proceed the account setup process!"
            lblMessage.Text &= "<br><a href='AccountUpdate.aspx'>Click here to complete your account</a>"
        Else
            lblMessage.Text = "Wrong verification code!"
        End If

    End Sub

End Class