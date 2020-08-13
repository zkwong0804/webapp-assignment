Public Class CategoryView
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim id As Integer = Integer.Parse(Request.QueryString.Get("id"))
            Dim cat As Category = dbCtx.Categories.Find(id)
            If IsNothing(cat) Then
                Response.Redirect("CategoryNotFound.aspx")
            Else
                Master.Name = cat.name
                If Not IsNothing(cat.category1) Then
                    Master.Category = cat.category1
                Else
                    Master.Category = 1
                End If

                Master.Available = cat.isAvailable
            End If
        Catch ex As Exception
            Response.Redirect("CategoryNotFound.aspx")
        End Try
    End Sub

End Class