Public Class CategoryDelete
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Private _category As Category
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim _id As Integer = Request.QueryString.Get("id")
            Me.SelectedCategory = dbCtx.Categories.Where(Function(f) f.id = _id).SingleOrDefault()
        End If
    End Sub

    Public Property SelectedCategory As Category
        Get
            Return Me._category
        End Get
        Set(value As Category)
            Me._category = value
        End Set
    End Property

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs)
        Dim _id As Integer = Request.QueryString.Get("id")
        Me.SelectedCategory = dbCtx.Categories.Where(Function(f) f.id = _id).SingleOrDefault()
        If Not IsNothing(SelectedCategory) Then
            dbCtx.Categories.Remove(Me.SelectedCategory)
            Try
                dbCtx.SaveChanges()
                Response.Redirect("OwnerCategory.aspx")
            Catch ex As Entity.Infrastructure.DbUpdateException
                lblMessage.Text = ex.Message
                Response.Redirect("DeleteFail.aspx?id=" & SelectedCategory.id & "&name=" & SelectedCategory.name & "&object=category")
            End Try

        Else
            Response.Redirect("CategoryNotFound.aspx")
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("OwnerPortal.aspx")
    End Sub
End Class