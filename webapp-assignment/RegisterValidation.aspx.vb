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
                lblMessage.Text = "Register mail: " & Session("rvEmail")
                lblMessage.Text &= "<br />Register pass: " & Session("rvPass")
                vCode = CStr(CInt((9999 * Rnd()) + 1000))
                sendVerificationMail(Session("rvEmail"), vCode)
            End If
        End If
    End Sub

    Protected Sub sendVerificationMail(ByVal regMail As String, ByVal vCode As String)
        Dim host As String = "smtp.gmail.com"
        Dim port As Int16 = 25
        Dim smtpMail As String = "webapp.assignment.zhenkai@gmail.com"
        Dim smtpPass As String = "123321##"
        lblMessage.Text = "We are sending a verification email to your mailbox..."
        Dim client As New SmtpClient(host, port)
        client.EnableSsl = True
        client.Credentials = New NetworkCredential(smtpMail, smtpPass)
        client.Timeout = 500000
        AddHandler client.SendCompleted, AddressOf sendCompleteCallback
        Dim mailFrom As New MailAddress(smtpMail)
        Dim mailTo As New MailAddress(regMail)
        Dim vMail As New MailMessage(mailFrom, mailTo)
        vMail.Body = vCode
        vMail.BodyEncoding = UTF8Encoding.UTF8
        vMail.Subject = "Account registration verification"
        Try
            client.SendAsync(vMail, "email state")
        Catch ex As SmtpException
            lblMessage.Text = "Fail to send email.[ " & ex.Message & " ] (Code: " & ex.StatusCode.ToString() & ")"
        Catch ex As System.Threading.ThreadAbortException
            lblMessage.Text = "Fail from the thread " & ex.Message
        End Try
    End Sub

    Private Sub sendCompleteCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        Dim token As String = CStr(e.UserState)
        If e.Cancelled Then
            lblMessage.Text = "Email send cancel." & token
        ElseIf e.Error IsNot Nothing Then
            lblMessage.Text = "Email send error." & token & ". " & e.Error.Message
        Else
            lblMessage.Text = "Email have been sent to your mailbox successfuly! Please check your email!"
            pnlValidate.Visible = True
        End If
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