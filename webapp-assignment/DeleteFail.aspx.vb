Public Class DeleteFail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As String = Request.QueryString.Get("id")
        Dim obj As String = Request.QueryString.Get("object")
        Dim name As String = Request.QueryString.Get("name")

        lblMessage.Text = "<p>"
        lblMessage.Text &= "Failed to delete " & obj & " " & name & " [ID: " & id & "]. Make sure this is not a parent category!"
        lblMessage.Text &= "</p>"
    End Sub

End Class