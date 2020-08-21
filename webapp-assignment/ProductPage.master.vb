Public Class ProductPage
    Inherits System.Web.UI.MasterPage
    Dim dbCtx As New AssignmentDbContext()
    Shared products As List(Of Product)
    Private _heading As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ProductPage_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Not Page.IsPostBack Then
            products = dbCtx.Products.OrderBy(Function(f) f.id And f.isAvailable).ToList()
        End If

        accordion.Attributes.Add("role", "tablist")
        accordion.Attributes.Add("aria-multiselectable", "true")
    End Sub

    Public Sub SetCategories(ByVal cats As List(Of Category))
        accordion.Controls.Clear()
        Dim ul As New HtmlGenericControl("ul")
        For Each cat As Category In cats
            Dim hl As New HyperLink()
            Dim li As New HtmlGenericControl("li")
            hl.Text = cat.name
            hl.NavigateUrl = "CategoryPage.aspx?id=" & cat.id
            li.Controls.Add(hl)
            ul.Controls.Add(li)
        Next

        accordion.Controls.Add(ul)
    End Sub

    Public Property Heading As String
        Get
            Return Me._heading
        End Get
        Set(value As String)
            Me._heading = value
        End Set
    End Property

    Protected Sub ddlMinPrice_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub ddlMaxPrice_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnSearchPrice_Click(sender As Object, e As EventArgs)

    End Sub

    Public Function GetMaxPrice() As Decimal
        Return Decimal.Parse(ddlMaxPrice.SelectedValue)
    End Function

    Public Function GetMinPrice() As Decimal
        Return Decimal.Parse(ddlMinPrice.SelectedValue)
    End Function


End Class