Public Class OrderGV
    Inherits System.Web.UI.UserControl
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            gvOrder.DataBind()
            ddlMembers.DataSource = dbCtx.Members.ToList()
            ddlMembers.DataValueField = "id"
            ddlMembers.DataTextField = "id"
            ddlMembers.DataBind()
        End If
    End Sub

    Protected Function DiscountAmt(ByVal id As Integer, ByVal total As Decimal) As Decimal
        Dim coupon As Coupon = dbCtx.Coupons.Where(Function(f) f.id = id).SingleOrDefault()

        Return If(IsNothing(coupon), 0, total * coupon.discountRate / 100)
    End Function

    ' The return type can be changed to IEnumerable, however to support
    ' paging and sorting, the following parameters must be added:
    '     ByVal maximumRows as Integer
    '     ByVal startRowIndex as Integer
    '     ByRef totalRowCount as Integer
    '     ByVal sortByExpression as String
    Public Function gvOrder_GetData() As IQueryable(Of webapp_assignment.Order)
        Dim orders As List(Of Order)
        If (Session("userType").ToString() = "member") Then
            Dim member As Member = CType(Session("member"), Member)
            orders = dbCtx.Orders.Where(Function(f) f.member = member.id).ToList()
        Else
            Dim sv As Integer = If(ddlMembers.SelectedValue = "", 1, CInt(ddlMembers.SelectedValue))
            orders = dbCtx.Orders.Where(Function(f) f.member = sv).ToList()
        End If

        Return orders.AsQueryable()
    End Function

    Protected Sub ddlMembers_SelectedIndexChanged(sender As Object, e As EventArgs)
        gvOrder.DataBind()
    End Sub
End Class