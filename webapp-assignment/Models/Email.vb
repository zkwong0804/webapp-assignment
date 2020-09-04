Imports System.Net
Imports System.Net.Mail

Public Class Email
    Private _host As String
    Private _port As Integer
    Private _smtpMail As String
    Private _smtpPass As String
    Private _client As SmtpClient

    Public Sub New()
        Me.Host = "smtp.gmail.com"
        Me.Port = 25
        Me.SmtpMail = "webapp.assignment.zhenkai@gmail.com"
        Me.SmtpPass = "123321##"
        Me.Client = New SmtpClient(Me.Host, Me.Port)
        Me.Client.EnableSsl = True
        Me.Client.Credentials = New NetworkCredential(Me.SmtpMail, Me.SmtpPass)
        Me.Client.Timeout = 50000
    End Sub

    Public Property Host As String
        Get
            Return Me._host
        End Get
        Set(value As String)
            Me._host = value
        End Set
    End Property

    Public Property Port As Integer
        Get
            Return Me._port
        End Get
        Set(value As Integer)
            Me._port = value
        End Set
    End Property

    Public Property SmtpMail As String
        Get
            Return Me._smtpMail
        End Get
        Set(value As String)
            Me._smtpMail = value
        End Set
    End Property

    Public Property SmtpPass As String
        Get
            Return Me._smtpPass
        End Get
        Set(value As String)
            Me._smtpPass = value
        End Set
    End Property

    Public Property Client As SmtpClient
        Get
            Return Me._client
        End Get
        Set(value As SmtpClient)
            Me._client = value
        End Set
    End Property


    Public Sub Send(ByVal recepient As String, ByVal subject As String, ByVal body As String)
        Dim mailFrom As New MailAddress(Me.SmtpMail)
        Dim mailTo As New MailAddress(recepient)
        Dim vMail As New MailMessage(mailFrom, mailTo)
        vMail.Body = body
        vMail.BodyEncoding = UTF8Encoding.UTF8
        vMail.Subject = subject
        Me.Client.Send(vMail)
    End Sub

    Public Sub SendMultiple(ByVal recepients As List(Of Member), ByVal subject As String, ByVal body As String)
        If Not IsNothing(recepients) And recepients.Count > 0 Then
            Dim mailFrom As New MailAddress(Me.SmtpMail)

            Dim vMail As New MailMessage()
            vMail.From = mailFrom
            For Each member As Member In recepients
                vMail.To.Add(New MailAddress(member.User.email))
            Next
            vMail.Body = body
            vMail.BodyEncoding = UTF8Encoding.UTF8
            vMail.Subject = subject
            Me.Client.Send(vMail)
        End If
    End Sub
End Class
