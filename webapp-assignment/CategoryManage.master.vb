Public Class CategoryManage
    Inherits System.Web.UI.MasterPage
    Dim dbCtx As New AssignmentDbContext()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub CategoryManage_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim categories = dbCtx.Categories.ToList()
        If Not IsNothing(categories) And categories.Count > 0 Then
            For Each cat As Category In categories
                Dim li As New ListItem()
                li.Text = cat.name
                li.Value = cat.id
                ddlCategory.Items.Add(li)
            Next
        End If
    End Sub

    Public Property Name As String
        Get
            Return Me.tbxName.Text
        End Get
        Set(value As String)
            Me.tbxName.Text = value
        End Set
    End Property

    Public Property Category As Integer
        Get
            Return Integer.Parse(Me.ddlCategory.SelectedValue)
        End Get
        Set(value As Integer)
            Debug.WriteLine("Looping ddlcategory:")
            For Each it As ListItem In ddlCategory.Items
                Debug.WriteLine(it.Value)
            Next
            Me.ddlCategory.Items.FindByValue(value.ToString()).Selected = True
        End Set
    End Property

    Public Property Available As Boolean
        Get
            Return Me.cbxAvailable.Checked
        End Get
        Set(value As Boolean)
            Me.cbxAvailable.Checked = value
        End Set
    End Property

End Class