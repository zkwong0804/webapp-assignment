Public Class TemplateDownload
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim fp As String = Server.MapPath("~/Templates/template.xlsx")
        'Dim file As New System.IO.FileInfo(fp)
        'If file.Exists Then
        '    Response.Clear()
        '    Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", file.Name))
        '    Response.AddHeader("Content-Length", file.Length.ToString())
        '    Response.ContentType = "application/octet-stream"
        'End If
        Response.Redirect("~/Templates/template.xlsx")
    End Sub

End Class