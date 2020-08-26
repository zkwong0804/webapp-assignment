Public Class ViewMember
    Inherits System.Web.UI.Page
    Private _member As Member
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Integer = Request.QueryString.Get("id")
        Me.SelectedMember = dbCtx.Members.Where(Function(f) f.id = id).SingleOrDefault()
        If IsNothing(Me.SelectedMember) Then
            Response.Redirect("MemberNotFound.aspx")
        End If
    End Sub

    Public Property SelectedMember As Member
        Get
            Return Me._member
        End Get
        Set(value As Member)
            Me._member = value
        End Set
    End Property

End Class