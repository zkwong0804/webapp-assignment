Public Class Products
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Dim sb As New StringBuilder()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim userEmail As String = Request.QueryString.Get("email")
        Dim userPass As String = Request.QueryString.Get("pass")

        Dim owner As Owner = dbCtx.Owners.Where(Function(f) f.User.email = userEmail And f.User.password = userPass).SingleOrDefault()

        If IsNothing(owner) Then
            Response.Redirect("~/AccessDenied.aspx")
        End If

        Dim products As List(Of Product) = dbCtx.Products.ToList()
        Dim resBuilder As New StringBuilder()

        Response.ContentType = "application/json"

        resBuilder.Append("{")
        resBuilder.Append("""products"":[")
        For Each p As Product In products
            resBuilder.Append(GenerateProductJsonObject(p))
            resBuilder.Append(",")
        Next
        resBuilder.Append("]")
        resBuilder.Append("}")

        Response.Write(resBuilder.ToString())
    End Sub

    Protected Function GenerateProductJsonObject(ByVal p As Product)
        sb.Clear()
        sb.Append("{")
        sb.Append($"""id"": ""{p.id}"",")
        sb.Append($"""name"": ""{p.name}"",")
        sb.Append($"""price"": ""{p.price}"",")
        sb.Append($"""amt"": ""{p.amt}"",")
        sb.Append($"""description"": ""{p.description}"",")
        sb.Append($"""category"": ""{p.Category1.name}""")
        sb.Append("}")

        Return sb.ToString()
    End Function

End Class